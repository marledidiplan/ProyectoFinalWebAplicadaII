using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Costo { get; set; }
        public int Ganancia { get; set; }
        public int Inventario { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Costo = 0;
            Ganancia = 0;
            Inventario = 0;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
