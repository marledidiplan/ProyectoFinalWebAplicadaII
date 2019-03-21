using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntradaBalance
    {
        [Key]
        public int EntradaBalanceId { get; set; }
        public int BalanceId { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }

        public EntradaBalance()
        {
            EntradaBalanceId = 0;
            BalanceId = 0;
            Fecha = DateTime.Now;
            Monto = 0;

        }
    }
}
