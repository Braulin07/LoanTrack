using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Enums
{
    namespace LoanTrack.Domain.Enums
    {
        public enum TipoInteres
        {
            // Interés calculado siempre sobre el capital original.
            // Fórmula simple: Capital × Tasa × Tiempo.
            Simple = 1,

            // Interés calculado sobre el saldo pendiente.
            // Baja a medida que el usuario paga capital.
            SaldoInsoluto = 2,

            // Interés calculado por día según la diferencia de fechas.
            // Ideal para saldar antes o pagos irregulares.
            Diario = 3,

            // Interés calculado como si nunca bajara el capital.
            // Muy usado por financieras informales.
            Flat = 4,

            // Sistema de amortización de cuota fija (Sistema Francés).
            // Interés sobre saldo + cuota constante.
            CuotaFija = 5
        }
    }

}
