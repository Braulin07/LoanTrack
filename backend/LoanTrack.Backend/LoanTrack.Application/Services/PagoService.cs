using AutoMapper;
using FluentValidation;
using LoanTrack.Application.Dtos.Pago;
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

        public PagoService(IPagoRepository repo, IPrestamoRepository repopresta, IMapper mapper,IValidator<PagoUpdateDto> validatorUp,IValidator<PagoCreateDto> validatorCr)
        {
            _repo = repo;
            _repoPresta = repopresta;
            _mapper = mapper;
            _ValidatorUp = validatorUp;
            _ValidatorCr = validatorCr;
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
            
            var prestamo = await _repoPresta.GetById(dto.prestamoId);

            decimal saldoPendiete = prestamo.MontoPrestado - prestamo.MontoPagado;

            if (saldoPendiete <= 0)
                throw new ArgumentException("El prestamo esta saldado");

            DateTime hoy = DateTime.Now;

            decimal interesesGenerado = saldoPendiete * prestamo.TasaInteres;

            decimal pagoAInteres = 0;
            decimal pagoACapital = 0;

            decimal montoRestante = dto.montoPago;

            if(montoRestante > 0)
            {
                 pagoAInteres = Math.Min(montoRestante,interesesGenerado);
                montoRestante -= pagoAInteres;
            }

            if(montoRestante > 0)
            {
                pagoACapital = montoRestante;
                montoRestante = 0;
            }

            prestamo.MontoPagado += pagoACapital;
            prestamo.InteresesPagados += pagoAInteres;
            prestamo.FechaUltimoPago = hoy;

            if(pagoAInteres >= interesesGenerado)
            {
                prestamo.FechaVencimiento.AddMonths(1);
            }

            bool EstadoAtrasado = (hoy > prestamo.FechaVencimiento);

            decimal balanceParaSalirDeAtraso = 0;

            if (EstadoAtrasado)
            {
                balanceParaSalirDeAtraso = interesesGenerado - pagoAInteres;
                if (balanceParaSalirDeAtraso < 0)
                    balanceParaSalirDeAtraso = 0;
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
            return new ResultadoPagoDto
            {
                IdPago = pago.PagoId,
                IdPrestamo = dto.prestamoId,
                FechaPago = hoy,
                PagoTotal = dto.montoPago,
                CapitalPagado = pagoACapital,
                InteresPagado = pagoAInteres,

                SaldoCapitalRestante = prestamo.MontoPrestado - prestamo.MontoPagado,

                PrestamoEnAtraso = EstadoAtrasado,
                EstadoPrestamo = EstadoAtrasado ? "Atrasado" : "Al Día",
                FechaVencimientoActual = prestamo.FechaVencimiento,
                ProximaFechaVencimiento = prestamo.FechaVencimiento.AddMonths(1),
                BalanceParaSalirDeAtraso = balanceParaSalirDeAtraso,

                MensajeResumen = EstadoAtrasado
                    ? $"El préstamo sigue en atraso. Debe pagar {balanceParaSalirDeAtraso} para ponerse al día."
            : "Pago registrado correctamente. El préstamo está al día."
            };
          

        }

    
    }
}
