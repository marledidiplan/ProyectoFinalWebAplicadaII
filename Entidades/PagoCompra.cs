using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class PagoCompra
    {
        [Key]
        public int PagoCompraId { get; set; }
        public int SuplidorId { get; set; }
        public int CompraId { get; set; }
        public int BalanceId { get; set; }
        public DateTime Fecha { get; set; }
        public int MontoPagar { get; set; }
        public int Deuda { get; set; }


        public PagoCompra()
        {
            PagoCompraId = 0;
            SuplidorId = 0;
            BalanceId = 0;
            CompraId = 0;
            Deuda = 0;
            Fecha = DateTime.Now;
            MontoPagar = 0;

        }
    }
}
