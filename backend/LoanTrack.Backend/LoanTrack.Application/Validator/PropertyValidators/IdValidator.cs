using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.PropertyValidators
{
    public static class IdValidator
    {
        public static void Validate(int id)
        {
            if (int.IsNegative(id))
                throw new Exception("ID no puede ser negativo");

            if (id == 0)
                throw new Exception("ID no puede ser 0");
        }
    }
}
