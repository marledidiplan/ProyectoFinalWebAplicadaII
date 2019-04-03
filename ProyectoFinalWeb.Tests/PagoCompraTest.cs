using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL;
using DAL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class PagoCompraTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
            PagoCompra pago = new PagoCompra();
            bool paso=false;
            pago.PagoCompraId = 3;
            pago.MontoPagar = 10;
            paso = repositorio.Guardar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
            PagoCompra pago = new PagoCompra();
            bool paso = false;
            pago.PagoCompraId = 3;
            pago.MontoPagar = 150;
            paso = repositorio.Modificar(pago);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
            PagoCompra pagoCompra = new PagoCompra();
            int id = 2;
            pagoCompra = repositorio.Buscar(id);
            Assert.IsNotNull(pagoCompra);

        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
            int id = 3;
            bool paso;
            paso = repositorio.Eliminar(id);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
            var suplidor = repositorio.GetList(x => true);
            Assert.IsNotNull(suplidor);
        }
    }
}
