using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LoanTrack.Application.Dtos;
using LoanTrack.Application.Dtos.Cliente;
using LoanTrack.Domain.Entities;

namespace LoanTrack.Application.Mapping
{
    public class ClienteProfile:Profile
    {
        public ClienteProfile()
        {
            //Entidad => DTO
            CreateMap<Cliente, ClienteReadDTO>();

            //DTO => Entidad
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
