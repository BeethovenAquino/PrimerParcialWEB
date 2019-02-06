using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlBancario.Tests
{
    [TestClass]
    public class CuentaTests
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();

            Cuentas cuentas = new Cuentas();
            cuentas.CuentaID = 0;

            cuentas.Fecha = DateTime.Now;
            cuentas.Nombre = "Clifford";
            cuentas.Balance = 0;

            Assert.IsTrue(repositorio.Guardar(cuentas));
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();

            Cuentas cuentas = new Cuentas();
            cuentas.CuentaID = 1;

            cuentas.Fecha = DateTime.Now;
            cuentas.Nombre = "Marieth";
            cuentas.Balance = 0;

            Assert.IsTrue(repositorio.Modificar(cuentas));
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Assert.IsNotNull(repositorio.Eliminar(1));
        }

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Assert.IsNotNull(repositorio.Buscar(1));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            var lista = repositorio.GetList(x => true);
            Assert.IsNotNull(lista);

        }
    }
}
