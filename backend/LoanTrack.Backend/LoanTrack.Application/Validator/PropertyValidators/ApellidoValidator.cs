using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.PropertyValidators
{
    public static class ApellidoValidator
    {
        public static void Validate(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Apellido no puede estar vacio");
        }
    }
}
