using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso;
            usuario.UsuarioId = 2;
            usuario.Nombre = "Maria";
            usuario.NombreUsuario = "maria";
            usuario.Contrasena = "1234";
            usuario.ConfirmarContra = "1234";
            usuario.Telefono = "809-889-0000";
            usuario.Cedula = "402-0000000-5";
            paso = repositorio.Guardar(usuario);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso;
            usuario.UsuarioId = 2;
            usuario.Nombre = "Maria";
            usuario.NombreUsuario = "maria";
            usuario.Contrasena = "1234";
            usuario.ConfirmarContra = "1234";
            usuario.Telefono = "809-889-0000";
            usuario.Cedula = "402-0000000-5";
            paso = repositorio.Modificar(usuario);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = 2;
            Usuarios usuario = new Usuarios();
            usuario = repositorio.Buscar(id);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = 2;
            bool paso;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            var usuario = repositorio.GetList(x => true);
            Assert.IsNotNull(usuario);
        }

    }
}
