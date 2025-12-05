using AutoMapper;
using LoanTrack.Application.Dtos.Prestamo;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Mapping
{
    public class PrestamoProfile : Profile
    {
        public PrestamoProfile()
        {
            //Entidad =>  DTO
            CreateMap<Prestamo, PrestamoReadDto>();

            //DTO => Entidad
            CreateMap<PrestamoCreateDto, Prestamo>();
            CreateMap<PrestamoUpdateDto, Prestamo>();
        }
    }
}
