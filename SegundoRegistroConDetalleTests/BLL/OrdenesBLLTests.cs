using Microsoft.VisualStudio.TestTools.UnitTesting;
using SegundoRegistroConDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using SegundoRegistroConDetalle.Models;

namespace SegundoRegistroConDetalle.BLL.Tests
{
    [TestClass()]
    public class OrdenesBLLTests
    {
        [TestMethod()]
        public void ExisteTest()
        {
            bool paso;
            paso = OrdenesBLL.Existe(2);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Ordenes ordenes = new Ordenes();

            ordenes.OrdenId = 0;
            ordenes.Fecha = DateTime.Now;
            ordenes.SuplidorId = 1;
            ordenes.Monto = 150;

            ordenes.OrdenesDetalle.Add(new OrdenesDetalle
            {
                Id = 0,
                OrdenId = ordenes.OrdenId,
                ProductoId = 1,
                Cantidad = 10,
                Costo = 10
            });

            paso = OrdenesBLL.Insertar(ordenes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Ordenes ordenes = new Ordenes();

            ordenes.OrdenId = 0;
            ordenes.Fecha = DateTime.Now;
            ordenes.SuplidorId = 1;
            ordenes.Monto = 100;

            ordenes.OrdenesDetalle.Add(new OrdenesDetalle
            {
                Id = 0,
                OrdenId = ordenes.OrdenId,
                ProductoId = 1,
                Cantidad = 20,
                Costo = 10
            });

            paso = OrdenesBLL.Guardar(ordenes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Ordenes ordenes = new Ordenes();

            ordenes.OrdenId = 1;
            ordenes.Fecha = DateTime.Now;
            ordenes.SuplidorId = 1;
            ordenes.Monto = 1000;

            ordenes.OrdenesDetalle.Add(new OrdenesDetalle
            {
                Id = 0,
                OrdenId = ordenes.OrdenId,
                ProductoId = 1,
                Cantidad = 50,
                Costo = 50
            });

            paso = OrdenesBLL.Modificar(ordenes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;

            if (OrdenesBLL.Eliminar(2))
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso;
            var ordenes = OrdenesBLL.Buscar(1);
            if (ordenes != null)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso;
            var lista = OrdenesBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }
    }
}