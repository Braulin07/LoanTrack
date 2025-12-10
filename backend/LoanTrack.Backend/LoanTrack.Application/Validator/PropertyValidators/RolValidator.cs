using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.PropertyValidators
{
    public static class RolValidator
    {
        public static void Validate(RolUsuario rol)
        {
            if (rol <= 0)
                throw new KeyNotFoundException("Rol Inexistente");


            //if (rol >= 4)
            //    throw new KeyNotFoundException("Rol Inexistente");
        }
    }
}
