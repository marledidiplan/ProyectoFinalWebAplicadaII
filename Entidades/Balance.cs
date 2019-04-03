using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Balance
    {
        [Key]
        public int BalanceId { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Balance()
        {
            BalanceId = 0;
            Monto = 0;
            Fecha = DateTime.Now;
        }
    }
}
