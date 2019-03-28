using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class UnitTest1
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
            articulo.Costo = 30;
            articulo.Ganancia = 10;
            articulo.Inventario = 1;
            paso = repositorio.Guardar(articulo);

            Assert.AreEqual(paso, true);

        }
    }
}
