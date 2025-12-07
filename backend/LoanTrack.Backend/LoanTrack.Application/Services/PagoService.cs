using AutoMapper;
using LoanTrack.Application.Dtos.Pago;
using LoanTrack.Application.Interfaces;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Interfaces;
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

        public PagoService(IPagoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<PagoCreateDto> Create(PagoCreateDto pagoDto)
        {
            var entidad = _mapper.Map<Pago>(pagoDto);
            await _repo.Create(entidad);
            return pagoDto;
        }

        public async Task<PagoUpdateDto> Update(PagoUpdateDto pagoDto)
        {
            var entidad = _mapper.Map<Pago>(pagoDto);
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
