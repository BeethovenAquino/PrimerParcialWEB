using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Deposito
    {
        [Key]
        public int DepositoID { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaID { get; set; }
        public string Concepto { get; set; }
        public Decimal Monto { get; set; }

        public Deposito(int depositoID, DateTime fecha, int cuentaID, string concepto, decimal monto)
        {
            DepositoID = depositoID;
            Fecha = fecha;
            CuentaID = cuentaID;
            Concepto = concepto;
            Monto = monto;
        }

        public Deposito()
        {
            DepositoID = 0;
            Fecha = DateTime.Now;
            CuentaID = 0;
            Concepto = string.Empty;
            Concepto = string.Empty;
            Monto = 0;
        }
    }
}
