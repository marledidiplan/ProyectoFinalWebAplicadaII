using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Suplidores> sublidors { get; set; }
        public DbSet<Articulos> articulos { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<PagoCompra> pagoCompras { get; set; }
        public DbSet<EntradaBalance> entradaBalances { get; set; }
        public DbSet<Balance> balances { get; set; }


        public Contexto() : base("ConStr")
        {

        }
    }
}
