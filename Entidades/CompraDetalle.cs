using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
   public class CompraDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ArticuloId { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }

        public CompraDetalle()
        {
            DetalleId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public CompraDetalle(int detalleId, int articuloId, int cantidad, int precio, int importe)
        {

            this.DetalleId = detalleId;
            this.ArticuloId = articuloId;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Importe = importe;
        }
    }
}
