using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class CompraTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
            Compra compra = new Compra();
            bool paso;
            compra.CompraId = 4;
            compra.UsuarioId = 1;
            compra.SuplidorId = 1;
            compra.BalanceC = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 100;
            compra.SubTotal = 75;
            compra.Itbis = 25;
            compra.BalanceC = 300;
            compra.Efectivo = 200;
            compra.Devuelta = 100;
            compra.General = 100;
            compra.TipoDePago = "Contado";
            paso = repositorio.Guardar(compra);


            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
            Compra compra = new Compra();
            bool paso;
            compra.CompraId = 4;
            compra.UsuarioId = 1;
            compra.SuplidorId = 1;
            compra.BalanceC = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 100;
            compra.SubTotal = 75;
            compra.Itbis = 25;
            compra.BalanceC = 300;
            compra.Efectivo = 200;
            compra.Devuelta = 100;
            compra.General = 100;
            compra.TipoDePago = "Contado";
            paso = repositorio.Modificar(compra);


            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
            Compra compra = new Compra();
            int id = 1;
            compra = repositorio.Buscar(id);
            Assert.IsNotNull(compra);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();

            bool paso;
            int id = 2;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
            var comprass = repositorio.GetList(x => true);
            Assert.IsNotNull(comprass);
        }


    }
}
