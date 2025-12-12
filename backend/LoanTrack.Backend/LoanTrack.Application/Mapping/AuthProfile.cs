using AutoMapper;
using LoanTrack.Application.Dtos.Authentication;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            //Entidad => DTO
            CreateMap<Usuario, AuthResponseDto>();

            //DTO => Entidad
            CreateMap<LoginRequestDto, Usuario>();
            CreateMap<RegisterUserRequestDto, Usuario>();
        }
    }
}
