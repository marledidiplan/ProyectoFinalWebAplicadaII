using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Compra
    {
        [Key]
        public int CompraId { get; set; }
        public int UsuarioId { get; set; }
        public int SuplidorId { get; set; }
        public int BalanceId { get; set; }

        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public int SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public int BalanceC { get; set; }
        public int Efectivo { get; set; }
        public int Devuelta { get; set; }
        public int General { get; set; }
        public string TipoDePago { get; set; }

        public virtual List<CompraDetalles> Detalles { get; set; }

        public Compra()
        {
            Total = 0;
            this.Detalles = new List<CompraDetalles>();
        }
        public void AgregarDetalle(int id, int compraDetalleId, int articuloId, int cantidad, int precio, int importe)
        {
            this.Detalles.Add(new CompraDetalles(id, compraDetalleId, articuloId, cantidad, precio, importe));
        }
    }
}
