using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamoBLL : RepositorioBase<Prestamo>
    {
        public override bool Guardar(Prestamo entity)
        {
            decimal total = 0;
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in entity.Detalle)
                {
                    total += item.Interes + item.Capital;
                }

                if (contexto.Prestamo.Add(entity) != null)
                {

                    var cuenta = contexto.Cuenta.Find(entity.CuentaID);
                    //Incrementar el balance
                    cuenta.Balance += total;



                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            decimal total = 0;
            try
            {
                Prestamo Cuotas = _contexto.Prestamo.Find(id);

                var Anterior = _contexto.Prestamo.Find(Cuotas.PrestamoID);
                foreach (var item in Anterior.Detalle)
                {
                    if (!Cuotas.Detalle.Exists(d => d.CuotaID == item.CuotaID))
                        _contexto.Entry(item).State = EntityState.Deleted;
                }
                foreach (var item in Cuotas.Detalle)
                {
                    total -= item.Interes+item.Capital;
                }
                _contexto.Cuenta.Find(Cuotas.CuentaID).Balance += total;
                _contexto.Prestamo.Remove(Cuotas);

                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public override bool Modificar(Prestamo entity)
        {
            _contexto = new DAL.Contexto();
            decimal montoBaseDatos = 0;
            decimal montoEntidad = 0;
            bool paso = false;
            try
            {
                //Busca el detalle anterior en base de datos
                var detalleAnterior = _contexto.Cuotas.Where(x => x.PrestamoID == entity.PrestamoID).AsNoTracking().ToList();



                //Agrega a la variable montoBaseDatos el monto del capital mas el interes
                foreach (var item in detalleAnterior)
                {
                    montoBaseDatos += item.Capital + item.Interes;

                }

                //Agrega a la variable montoEntidad el monto del capital mas el interes
                foreach (var item in entity.Detalle)
                {
                    montoEntidad += item.Capital + item.Interes;
                }

                _contexto.Cuenta.Find(entity.CuentaID).Balance -= montoBaseDatos;
                _contexto.Cuenta.Find(entity.CuentaID).Balance += montoEntidad;

                //Marca como borrado alguna cuota que este en base de datos y no en la lista detalle

                if (entity.Detalle.Count < detalleAnterior.Count)
                {
                    foreach (var item in detalleAnterior)
                    {
                        if (!entity.Detalle.Exists(x => x.CuotaID.Equals(item.CuotaID)))
                        {
                            _contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;

                        }
                    }
                }

                //Modifica o agrega una nueva cuota 
                foreach (var item in entity.Detalle)
                {
                    _contexto.Entry(item).State = item.CuotaID == 0 ? EntityState.Added : EntityState.Modified;
                }

                //modifica la entidad
                _contexto.Entry(entity).State = EntityState.Modified;

                //Guarda
                paso = _contexto.SaveChanges() > 0 ? true : false;


            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
        
    }
}
