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
        public bool Guardar(Prestamo entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.Prestamo.Add(entity) != null)
                {

                    var cuenta = contexto.Cuenta.Find(entity.CuentaID);
                    //Incrementar el balance
                    cuenta.Balance += entity.TotalAPagar;


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Deposito depositos = contexto.Depositos.Find(id);

                if (depositos != null)
                {
                    var cuenta = contexto.Cuenta.Find(depositos.CuentaID);
                    //Incrementar la cantidad
                    cuenta.Balance -= depositos.Monto;

                    contexto.Entry(depositos).State = EntityState.Deleted;

                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public override bool Modificar(Prestamo entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            try
            {

                var depositosanterior = repositorio.Buscar(entity.PrestamoID);

                var Cuenta = contexto.Cuenta.Find(entity.CuentaID);
                var Cuentasanterior = contexto.Cuenta.Find(depositosanterior.CuentaID);

                if (entity.CuentaID != depositosanterior.CuentaID)
                {
                    //Cuenta.Balance += entity.Monto;
                    Cuentasanterior.Balance -= depositosanterior.Monto;
                }


                decimal diferencia;
                //diferencia = entity.Monto - depositosanterior.Monto;

                /*Cuenta.Balance += diferencia*/;

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
        
    }
}
