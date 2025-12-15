using AutoMapper;
using FluentValidation;
using LoanTrack.Application.Dtos.Prestamo;
using LoanTrack.Application.Intereses;
using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IValidator<PrestamoCreateDto> _validatorCr;
        private readonly IValidator<PrestamoUpdateDto> _validatorUp;
        public PrestamoService(IPrestamoRepository repo, IMapper mapper, IValidator<PrestamoUpdateDto> validatorUp,IValidator<PrestamoCreateDto> validatorCr)
        {
            _repo = repo;
            _mapper = mapper;
            _validatorUp = validatorUp;
            _validatorCr = validatorCr;
        }

        public async Task<PrestamoCreateDto> Create(PrestamoCreateDto createDto)
        {
            await _validatorCr.ValidateAndThrowAsync(createDto);
            var entidad = _mapper.Map<Prestamo>(createDto);
            if (entidad == null) throw new Exception("La Entidad no puede ser Nula o Vacia");
            entidad.FechaVencimiento = entidad.FechaInicio.AddMonths(entidad.Plazo);
            var calculadora = CalculadoraInteresFactory.GetCalculator(entidad.Tinteres);
            var interesescalculados = calculadora.CaluladoraIntereses(entidad, DateTime.Now);
            await _repo.Create(entidad);

            return createDto;
        }

        public async Task<PrestamoUpdateDto> Update( PrestamoUpdateDto dto)
        {
            await _validatorUp.ValidateAndThrowAsync(dto);
            var entidad = _mapper.Map<Prestamo>(dto);
            if (entidad.PrestamoId <= 0) throw new KeyNotFoundException("ID Invalido o Inexistente");

            await _repo.Update(entidad);

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _repo.GetById(id);
            if (response == null) return false;

            await _repo.Delete(response);

            return true;
        }

        public Task<decimal> GetPagoSaldoHoyPrestamosPorCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PrestamoReadDto>> GetPrestamosActivosPorCliente(int idCliente)
        {
           var entidad = await _repo.GetPrestamosActivosPorCliente(idCliente);
           var dto = _mapper.Map<IEnumerable<PrestamoReadDto>>(entidad);

           return dto;
        }

        public async Task<IEnumerable<PrestamoReadDto>> GetPrestamosConVencimientoHoy()
        {
            var entidad = await _repo.GetPrestamosConVencimientoHoy();
            var dto = _mapper.Map < IEnumerable<PrestamoReadDto>>(entidad);

            return dto;
        }

        public async Task<IEnumerable<PrestamoReadDto>> GetPrestamosPorEstado(EstadoPrestamo estado)
        {
            var entidad = await _repo.GetPrestamosPorEstado(estado);
            var dto = _mapper.Map<IEnumerable<PrestamoReadDto>>(entidad);

            return dto;
        }

        public async Task<IEnumerable<PrestamoReadDto>> GetPrestamosVencidos()
        {
            var entidad = await _repo.GetPrestamosVencidos();
            var dto = _mapper.Map<IEnumerable<PrestamoReadDto>>(entidad);

            return dto;
        }

        
    }
}
