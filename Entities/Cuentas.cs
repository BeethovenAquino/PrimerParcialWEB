﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cuentas
    {
        [Key]
        public int CuentaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public Decimal Balance { get; set; }

        public Cuentas(int cuentaID, DateTime fecha, string nombre, decimal balance)
        {
            CuentaID = cuentaID;
            Fecha = fecha;
            Nombre = nombre;
            Balance = balance;
        }

        public Cuentas()
        {
            CuentaID = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Balance = 0;
        }
    }
}
