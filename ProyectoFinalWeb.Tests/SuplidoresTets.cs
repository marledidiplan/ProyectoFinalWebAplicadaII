using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class SuplidoresTets
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            Suplidores suplidor = new Suplidores();
            bool paso;
            suplidor.SuplidorId = 2;
            suplidor.Nombre = "Maria";
            suplidor.Cedula = "00000000000";
            suplidor.Direccion = "Bani";
            suplidor.Telefono = "1111111111";
            suplidor.Email = "maria@gmail.com";
            paso = repositorio.Guardar(suplidor);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            Suplidores suplidor = new Suplidores();
            bool paso;
            suplidor.SuplidorId = 2;
            suplidor.Nombre = "Maria";
            suplidor.Cedula = "00000000000";
            suplidor.Direccion = "Bani";
            suplidor.Telefono = "1111111111";
            suplidor.Email = "maria@gmail.com";
            paso = repositorio.Modificar(suplidor);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            Suplidores suplidor = new Suplidores();
            int id = 1;
            suplidor = repositorio.Buscar(id);
            Assert.IsNotNull(suplidor);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            int id = 2;
            bool paso;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            var suplidor = repositorio.GetList(x => true);
            Assert.IsNotNull(suplidor);
        }


    }
}
