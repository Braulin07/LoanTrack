using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validation.PropertyValidators
{
    public static class EmailValidator
    {
        public static void  Validate(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email no puede estar vacio");
        }
    }
}
