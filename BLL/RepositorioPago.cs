using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class RepositorioPago : RepositorioBase<PagoCompra>
   {
        public override bool Guardar(PagoCompra pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.pagoCompras.Add(pago) != null)
                {
                    contexto.sublidors.Find(pago.SuplidorId).CuentasPorPagar -= pago.MontoPagar;
                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Modificar(PagoCompra pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Suplidores> repoS = new RepositorioBase<Suplidores>();
            try
            {


                PagoCompra pagoC = Buscar(pago.PagoCompraId);
                PagoCompra pagoCompra = Buscar(pago.PagoCompraId);
                int desigualdad = pago.MontoPagar - pagoCompra.MontoPagar;
                var pagos = contexto.sublidors.Find(pago.SuplidorId);
                var monto = contexto.pagoCompras.Find(pago.PagoCompraId);
                pagos.CuentasPorPagar -= desigualdad;
                monto.Deuda -= desigualdad;
                repoS.Modificar(pagos);
                Modificar(monto);

                contexto.Entry(pago).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public override PagoCompra Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PagoCompra pago = new PagoCompra();

            try
            {
                pago = contexto.pagoCompras.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            PagoCompra pago = new PagoCompra();
            try
            {
                pago = contexto.pagoCompras.Find(id);

                contexto.sublidors.Find(pago.SuplidorId).CuentasPorPagar += pago.MontoPagar;
                contexto.pagoCompras.Remove(pago);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }




    }
}
