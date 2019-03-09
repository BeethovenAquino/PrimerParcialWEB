using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBancario.UI.Registros
{
    public partial class Cuenta : System.Web.UI.Page
    {
        RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BalanceTexbox.Text = "0";
                CuentaIDTextbox.Text = "0";
            }

        }

        public Cuentas LlenaClase()
        {
            Cuentas cuentas = new Cuentas();
            int id;
            bool result = int.TryParse(CuentaIDTextbox.Text, out id);
            if (result == true)
            {
                cuentas.CuentaID = id;
            }
            else
            {
                cuentas.CuentaID = 0;
            }

            cuentas.Nombre = nombreTextbox.Text;
            cuentas.Balance = Convert.ToDecimal(BalanceTexbox.Text.ToString());
            
            return cuentas;
        }

        private void LlenaCampos(Cuentas cuentas)
        {
            CuentaIDTextbox.Text = cuentas.CuentaID.ToString();
            nombreTextbox.Text = cuentas.Nombre;
            BalanceTexbox.Text = cuentas.Balance.ToString();
           

        }

        private void Limpiar()
        {
            CuentaIDTextbox.Text = "";
            nombreTextbox.Text = "";
            BalanceTexbox.Text = "";
            
        }


       

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();

            Cuentas cuenta = LlenaClase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (Utilities.Utils.ToInt(CuentaIDTextbox.Text) >=0)
                {
                    paso = repositorio.Guardar(cuenta);

                }
                else
                {
                    var verificar = repositorio.Buscar(Utilities.Utils.ToInt(CuentaIDTextbox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(cuenta);
                    }
                    else
                    {
                        Utilities.Utils.ShowToastr(this, "Cuenta No Existe", "Fallido", "error");
                        return;
                    }
                }

                if (paso)

                {
                    Utilities.Utils.ShowToastr(this, "Cuenta Registrada", "Exito", "Exito");
                }

                else

                {
                    Utilities.Utils.ShowToastr(this, "No pudo Guardarse la cuenta", "ERROR", "error");
                }
                Limpiar();
                return;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            
            int id = Utilities.Utils.ToInt(CuentaIDTextbox.Text);
            var cuenta = repositorio.Buscar(id);
            

            if (cuenta == null)
            {
                Utilities.Utils.ShowToastr(this, "No se puede Eliminar", "error");
            }

            //Si tiene algun prestamo o deposito enlazado no elimina
            RepositorioBase<Deposito> repositorios = new RepositorioBase<Deposito>();

            if (repositorios.GetList(x => x.CuentaID == id).Count() > 0)
            {
                Utilities.Utils.ShowToastr(this, "No se puede Eliminar, La cuenta contiene depositos","error");

            }

            else
            {
                repositorio.Eliminar(id);
                Utilities.Utils.ShowToastr(this, "Cuenta Eliminada", "Exito");
                Limpiar();
            }
        }


        
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();

            var cuentas = repositorio.Buscar(
                Utilities.Utils.ToInt(CuentaIDTextbox.Text));
            if (cuentas != null)
            {
                LlenaCampos(cuentas);
                Utilities.Utils.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                Limpiar();
                Utilities.Utils.ShowToastr(this,
                    "No se pudo encontrar la cuenta ",
                    "Error", "error");
            }
           
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('~/UI/Reportes/ReporteCuenta.aspx','_blanck');</script");
        }
    }
}