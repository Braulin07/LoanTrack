using AutoMapper;
using LoanTrack.Application.Dtos.Prestamo;
using LoanTrack.Application.Interfaces;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using LoanTrack.Domain.Interfaces;
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

        public PrestamoService(IPrestamoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PrestamoCreateDto> Create(PrestamoCreateDto createDto)
        {
            var entidad = _mapper.Map<Prestamo>(createDto);
            if (entidad == null) throw new Exception("La Entidad no puede ser Nula o Vacia");

            await _repo.Create(entidad);

            return createDto;
        }

        public async Task<PrestamoUpdateDto> Update( PrestamoUpdateDto dto)
        {
            var entidad = _mapper.Map<Prestamo>(dto);
            if (entidad.IdPrestamo <= 0) throw new KeyNotFoundException("ID Invalido o Inexistente");

            await _repo.Update(entidad);

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _repo.GetById(id);
            if (response == null) throw new Exception("False: Usuario NO fue eliminado");

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
