using AutoMapper;
using LoanTrack.Application.Dtos.Usuario;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            //Entidad => Dto
            CreateMap<Usuario, UsuarioReadDto>();

            //Dto => Entidad
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();
        }
    }
}
