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
        private readonly IMapper _mapper;
        private readonly IValidator<PagoCreateDto> _ValidatorCr;
        private readonly IValidator<PagoUpdateDto> _ValidatorUp;

        public PagoService(IPagoRepository repo, IMapper mapper,IValidator<PagoUpdateDto> validatorUp,IValidator<PagoCreateDto> validatorCr)
        {
            _repo = repo;
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
<<<<<<< HEAD
            await _ValidatorUp.ValidateAndThrowAsync(pagoDto);
            var entidad = _mapper.Map<Pago>(pagoDto);
=======
            var entidad = await _repo.GetById(pagoDto.PagoId);
            if (entidad == null) throw new KeyNotFoundException("Pago no encontrado");

            _mapper.Map(pagoDto, entidad);

>>>>>>> develop
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


        public async Task<IEnumerable<PagoReadDto>> GetPagosEntreFechas(DateOnly fechaInicio, DateOnly fechaFin)
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

    }
}
