using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Enums
{
    internal enum AccionAuditoria
    {
        CREATE = 1,
        UPDATE = 2,
        DELETE = 3,
        CONFIRM = 4,
        CANCELATION = 5
    }
}
