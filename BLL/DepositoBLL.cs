using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositoBLL
    {
        public override bool Guardar(Deposito entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Cuenta.Find(entity.CuentaId).Balance += entity.Monto;
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

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var Deposito = contexto.Depositos.Find(id);
                contexto.Cuenta.Find(Deposito.CuentaId).Balance -= Deposito.Monto;
                contexto.Entry(Deposito).State = System.Data.Entity.EntityState.Deleted;
                if (contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }


        public override bool Modificar(Deposito entity)
        {
            var BaseDatos = base.Buscar(entity.DepositoId);
            bool paso = false;
            Contexto contexto = new DAL.Contexto();
            try
            {

                contexto.Cuenta.Find(entity.CuentaId).Balance -= BaseDatos.Monto;
                contexto.Cuenta.Find(entity.CuentaId).Balance += entity.Monto;

                contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                    paso = true;


            }
            catch (Exception)
            {

                throw;
            }



            return paso;
        }
    }
}
