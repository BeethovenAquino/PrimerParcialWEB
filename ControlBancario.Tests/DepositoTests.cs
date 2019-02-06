using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBancario.Tests
{

    [TestClass]
   public class DepositoTests
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();

            Deposito deposito = new Deposito();
            deposito.DepositoID = 0;

            deposito.Fecha = DateTime.Now;
            deposito.CuentaID = 1;
            deposito.Concepto = "Pago de Luz";
            deposito.Monto = 500;

            Assert.IsTrue(repositorio.Guardar(deposito));
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();

            Deposito deposito = new Deposito();
            deposito.DepositoID = 1;

            deposito.Fecha = DateTime.Now;
            deposito.CuentaID = 1;
            deposito.Concepto = "Pago de Luz";
            deposito.Monto = 300;

            Assert.IsTrue(repositorio.Guardar(deposito));
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            Assert.IsNotNull(repositorio.Eliminar(1));
        }

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            Assert.IsNotNull(repositorio.Buscar(1));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            var lista = repositorio.GetList(x => true);
            Assert.IsNotNull(lista);

        }
    }
}
