using AutoMapper;
using LoanTrack.Application.Dtos.Pago;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Mapping
{
    public class PagoProfile : Profile
    {
        public PagoProfile()
        {
            //Entidad => DTO
            CreateMap<Pago, PagoReadDto>();

            //DTO => Entidad
            CreateMap<PagoCreateDto, Pago>();
            CreateMap<PagoUpdateDto, Pago>();
        }
    }
}
