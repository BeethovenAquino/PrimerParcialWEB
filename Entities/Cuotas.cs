using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable()]
    public class Cuotas
    {
        [Key]
        public int CuotaID { get; set; }
        public int PrestamoID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoApagar { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Balance { get; set; }
      
        [ForeignKey("PrestamoID")]
        public virtual Prestamo prestamos { get; set; }

        public Cuotas(int cuotaID, int prestamoID, DateTime fecha, decimal montoApagar, decimal interes, decimal capital, decimal balance)
        {
            CuotaID = cuotaID;
            PrestamoID = prestamoID;
            Fecha = fecha;
            MontoApagar = montoApagar;
            Interes = interes;
            Capital = capital;
            Balance = balance;
        }

        public Cuotas()
        {
            CuotaID = 0;
            PrestamoID = 0;
            Fecha = DateTime.Now;
            MontoApagar = 0;
            Interes = 0;
            Capital=0;
            Balance = 0;
           

        }
    }
}
