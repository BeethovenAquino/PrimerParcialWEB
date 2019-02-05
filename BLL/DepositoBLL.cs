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
    public class DepositoBLL : RepositorioBase<Deposito>
    {
        public bool Guardar(Deposito entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.Depositos.Add(entity) != null)
                {

                    var cuenta = contexto.Cuenta.Find(entity.CuentaID);
                    //Incrementar el balance
                    cuenta.Balance += entity.Monto;


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


        public override bool Modificar(Deposito entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            try
            {
                
                //Buscar

                var depositosanterior = repositorio.Buscar(entity.DepositoID);

                var Cuenta = contexto.Cuenta.Find(entity.CuentaID);
                var Cuentasanterior = contexto.Cuenta.Find(depositosanterior.CuentaID);

                if (entity.CuentaID != depositosanterior.CuentaID)
                {
                    Cuenta.Balance += entity.Monto;
                    Cuentasanterior.Balance -= depositosanterior.Monto;
                }



                //identificar la diferencia ya sea restada o sumada
                decimal diferencia;
                diferencia = entity.Monto - depositosanterior.Monto;



                //aplicar diferencia al inventario 
                Cuenta.Balance += diferencia;

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
