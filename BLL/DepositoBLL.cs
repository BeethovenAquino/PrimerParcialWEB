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
                contexto.Cuenta.Find(entity.CuentaID).Balance += entity.Monto;
                contexto.Depositos.Add(entity);
                if (contexto.SaveChanges() > 0)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                
                Deposito DepositoAnt = contexto.Depositos.Find(entity.DepositoID);

                var cuenta = contexto.Cuenta.Find(entity.CuentaID);
                var CuentaAnt = contexto.Cuenta.Find(DepositoAnt.CuentaID);

                if (entity.CuentaID != DepositoAnt.CuentaID)
                {
                    cuenta.Balance += entity.Monto;
                    CuentaAnt.Balance -= DepositoAnt.Monto;
                }
                {
                    decimal diferencia = entity.Monto - DepositoAnt.Monto;
                    cuenta.Balance += diferencia;
                }

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }



            return paso;

        }
    }
}
