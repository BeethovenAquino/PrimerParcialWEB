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
            Prestamo prestamo = new Prestamo();
            bool paso = false;
            var DetalleAnt = _contexto.Cuotas.Where(x => x.CuotaID == prestamo.CuentaID).AsNoTracking().ToList();

            foreach (var item in DetalleAnt)
            {
                
            }
            return paso;
        }
        
    }
}
