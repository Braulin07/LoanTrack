using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.PropertyValidators
{
    public static class NombreValidator
    {
        public static void Validate(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Nombre no puede estar Vacio");
        }
    }
}
