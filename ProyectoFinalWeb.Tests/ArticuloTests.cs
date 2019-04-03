using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class ArticuloTests
    {
        [TestMethod]
        public void GuardarTest()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            bool paso = false;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 2;
            articulo.Descripcion = "Pan";
            articulo.Precio = 50;
            articulo.Costo = 25;
            articulo.Ganancia = 100;
            articulo.Inventario = 4;
            articulo.Fecha = DateTime.Now;
            paso = repositorio.Guardar(articulo);

            Assert.AreEqual(paso, true);

        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 3;
            articulo.Descripcion = "Pan";
            articulo.Precio = 100;
            articulo.Costo = 30;
            articulo.Ganancia = 45;
            articulo.Inventario = 0;
            paso = repositorio.Modificar(articulo);

            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulo = new Articulos();
            int id = 3;
            articulo = repositorio.Buscar(id);
            Assert.IsNotNull(articulo);


        }
        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            bool paso;
            int id = 2;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            var articulo = repositorio.GetList(x => true);
            Assert.IsNotNull(articulo);

        }
    }
}