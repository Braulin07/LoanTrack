using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Pago
{
    public class ResultadoPagoDto
    {
        // Info básica del pago
        public int IdPago { get; set; }
        public int IdPrestamo { get; set; }
        public DateTime FechaPago { get; set; }

        // Monto del pago y su distribución
        public decimal PagoTotal { get; set; }
        public decimal CapitalPagado { get; set; }
        public decimal InteresPagado { get; set; }

        // Estado actual del préstamo después del pago
        public decimal SaldoCapitalRestante { get; set; }
        public bool PrestamoEnAtraso { get; set; }
        public string EstadoPrestamo { get; set; } = string.Empty; // Ej: "Pendiente", "Atrasado", "Saldado"

        // Info clave para el negocio
        public DateTime FechaVencimientoActual { get; set; }
        public DateTime? ProximaFechaVencimiento { get; set; }

        /// <summary>
        /// Cuánto falta para que el cliente se ponga al día
        /// (cubrir intereses + mora pendiente).
        /// Si es 0 o menor, ya no está en atraso.
        /// </summary>
        public decimal BalanceParaSalirDeAtraso { get; set; }

        // Opcional: datos de contexto para el frontend
        public string MensajeResumen { get; set; } = string.Empty;
    }
}
