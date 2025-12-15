using AutoMapper;
using FluentValidation;
using LoanTrack.Application.Dtos.Pago;
using LoanTrack.Application.Intereses;
using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _repo;
        private readonly IPrestamoRepository _repoPresta;
        private readonly IMapper _mapper;
        private readonly IValidator<PagoCreateDto> _ValidatorCr;
        private readonly IValidator<PagoUpdateDto> _ValidatorUp;
        private readonly IValidator<RegistrarPagoDto> _validatorRG;

        public PagoService(IPagoRepository repo, IPrestamoRepository repopresta, IMapper mapper,IValidator<PagoUpdateDto> validatorUp,IValidator<PagoCreateDto> validatorCr, IValidator<RegistrarPagoDto> validatorRG)
        {
            _repo = repo;
            _repoPresta = repopresta;
            _mapper = mapper;
            _ValidatorUp = validatorUp;
            _ValidatorCr = validatorCr;
            _validatorRG = validatorRG;
        }


        public async Task<PagoCreateDto> Create(PagoCreateDto pagoDto)
        {
            await _ValidatorCr.ValidateAndThrowAsync(pagoDto);
            var entidad = _mapper.Map<Pago>(pagoDto);
            await _repo.Create(entidad);
            return pagoDto;
        }

        public async Task<PagoUpdateDto> Update(PagoUpdateDto pagoDto)
        {
            await _ValidatorUp.ValidateAndThrowAsync(pagoDto);
            var entidad = _mapper.Map<Pago>(pagoDto);

            entidad = await _repo.GetById(pagoDto.PagoId);
            if (entidad == null) throw new KeyNotFoundException("Pago no encontrado");

            _mapper.Map(pagoDto, entidad);

            await _repo.Update(entidad);
            return pagoDto;
        }


        public async Task<bool> Delete(int pagoId)
        {
            var entidad = await _repo.GetById(pagoId);
            if (entidad == null) return false;
            await _repo.Delete(entidad);
            return true;
        }


        public async Task<IEnumerable<PagoReadDto>> GetPagosEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            var entidad = await _repo.GetPagosEntreFechas(fechaInicio, fechaFin);
            var dto = _mapper.Map<IEnumerable<PagoReadDto>>(entidad);
            return dto;
        }


        public async Task<IEnumerable<PagoReadDto>> GetPagosPorPrestamo(int prestamoId)
        {
            var entidad = await _repo.GetPagosPorPrestamo(prestamoId);
            var dto = _mapper.Map<IEnumerable<PagoReadDto>>(entidad);
            return dto;
        }


        public async Task<decimal> GetTotalPagadoPorPrestamo(int prestamoId)
        {
            return await _repo.GetTotalPagadoPorPrestamo(prestamoId);
        }


        public async Task<PagoReadDto> GetUltimoPago(int prestamoId)
        {
            var entidad = await _repo.GetUltimoPago(prestamoId);
            var dto = _mapper.Map<PagoReadDto>(entidad);
            return dto;
        }

        public async Task<ResultadoPagoDto> RegistrarPago(RegistrarPagoDto dto)
        {
           
            await _validatorRG.ValidateAndThrowAsync(dto);
            var prestamo = await _repoPresta.GetById(dto.prestamoId);

            decimal saldoPendiente = prestamo.MontoPrestado - prestamo.MontoPagado;

            if (saldoPendiente <= 0)
                throw new ArgumentException("El préstamo ya está saldado");

            DateTime hoy = DateTime.Now;

            var calculadora = CalculadoraInteresFactory.GetCalculator(prestamo.TipoInteres);
            decimal interesesGenerados = calculadora.CaluladoraIntereses(prestamo, hoy);

            decimal pagoAInteres = Math.Min(dto.montoPago, interesesGenerados);
            decimal pagoACapital = dto.montoPago - pagoAInteres;

            prestamo.InteresesPagados += pagoAInteres;
            prestamo.MontoPagado += pagoACapital;
            prestamo.FechaUltimoPago = hoy;


            if (pagoAInteres >= interesesGenerados)
            {
                prestamo.FechaVencimiento = prestamo.FechaVencimiento.AddMonths(1);
            }

            bool estaAtrasado = hoy > prestamo.FechaVencimiento;

            decimal balanceParaPonerseAlDia = 0;

            if (estaAtrasado)
            {
                balanceParaPonerseAlDia = interesesGenerados - pagoAInteres;
                if (balanceParaPonerseAlDia < 0)
                    balanceParaPonerseAlDia = 0;
            }

            var pago = new Pago
            {
                PrestamoId = dto.prestamoId,
                MontoPagado = dto.montoPago,
                MontoCapital = pagoACapital,
                MontoInteres = pagoAInteres,
                FechaPago = hoy
            };

            await _repo.Create(pago);
            await _repoPresta.Update(prestamo);


            decimal saldoCapitalRestante = prestamo.MontoPrestado - prestamo.MontoPagado;

            return new ResultadoPagoDto
            {
                IdPago = pago.PagoId,
                IdPrestamo = dto.prestamoId,
                FechaPago = hoy,
                PagoTotal = dto.montoPago,
                CapitalPagado = pagoACapital,
                InteresPagado = pagoAInteres,

                SaldoCapitalRestante = saldoCapitalRestante,

                PrestamoEnAtraso = estaAtrasado,
                EstadoPrestamo = estaAtrasado ? "Atrasado" : "Al Día",

                FechaVencimientoActual = prestamo.FechaVencimiento,
                ProximaFechaVencimiento = prestamo.FechaVencimiento.AddMonths(1),

                BalanceParaSalirDeAtraso = balanceParaPonerseAlDia,

                MensajeResumen = estaAtrasado
                    ? $"El préstamo sigue en atraso. Debe pagar {balanceParaPonerseAlDia} para ponerse al día."
                    : "Pago registrado correctamente. El préstamo está al día."
            };
        }



    }
}
