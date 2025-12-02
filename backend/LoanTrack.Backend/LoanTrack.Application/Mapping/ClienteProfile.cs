using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LoanTrack.Application.Dtos;
using LoanTrack.Domain.Entities;

namespace LoanTrack.Application.Mapping
{
    public class ClienteProfile:Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteReadDTO>();
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
