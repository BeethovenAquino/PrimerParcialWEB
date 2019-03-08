using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [Serializable()]
    public class Prestamo
    {
        [Key]
        public int PrestamoID { get; set; }
        public int CuentaID { get; set; }
        public decimal Interes { get; set; }
        public int Tiempo { get; set; }
        public decimal Capital { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalAPagar { get; set; }
        public virtual List<Cuotas> Detalle { get; set; }

        public Prestamo(int prestamoID, int cuentaID, decimal interes, int tiempo, decimal capital, DateTime fecha, int totalAPagar, List<Cuotas> detalle)
        {
            PrestamoID = prestamoID;
            CuentaID = cuentaID;
            Interes = interes;
            Tiempo = tiempo;
            Capital = capital;
            Fecha = fecha;
            TotalAPagar = totalAPagar;
            Detalle = detalle;
        }

        public Prestamo()
        {
            PrestamoID = 0;
            CuentaID = 0;
            Interes = 0;
            Tiempo = 0;
            Capital = 0;
            Fecha = DateTime.Now;
            TotalAPagar = 0;
            Detalle = new List<Cuotas>();

        }

        public void AgregarDetalle(int CuotaID,int PrestamoID, DateTime Fecha,decimal MontoApagar, decimal Interes, decimal Capital, decimal Balance)
        {
            this.Detalle.Add(new Cuotas(CuotaID,PrestamoID, Fecha, MontoApagar, Interes, Capital, Balance));
        }
    }
}
