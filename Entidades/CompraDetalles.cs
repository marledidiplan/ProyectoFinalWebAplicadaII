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
    public class CompraDetalles
    {
        [Key]
        public int Id { get; set; }
        public int CompraDetalleId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }



        public CompraDetalles()
        {
            Id = 0;
            CompraDetalleId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public CompraDetalles(int id, int compraDetalleId, int articuloId, int cantidad, int precio, int importe)
        {
            this.Id = id;
            this.CompraDetalleId = compraDetalleId;
            this.ArticuloId = articuloId;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Importe = importe;
        }
    }
}
