using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto: DbContext
    {

        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
     

        public Contexto() : base("ConStr")
        {
        }
    }
}
