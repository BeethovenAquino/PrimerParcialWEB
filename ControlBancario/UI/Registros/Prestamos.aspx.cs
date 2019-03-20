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
    public partial class Prestamos : System.Web.UI.Page
    {
        decimal interes = 0;
        decimal Capital = 0;
        decimal MontoApagar = 0;
        decimal Balance = 0;
        decimal tiempo = 0;
        decimal interesporciento = 0;
        DateTime Fecha;
        Decimal MontoCuota = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaComboCuentaID();
                FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                PrestamoIDTextbox.Text = "0";
            }

        }

        public Prestamo LlenaClase()
        {
            Prestamo prestamo = new Prestamo();
            prestamo.PrestamoID = Utilities.Utils.ToInt(PrestamoIDTextbox.Text);
            prestamo.CuentaID = Utilities.Utils.ToInt(CuentaDropDownList.SelectedValue);
            prestamo.Capital = Utilities.Utils.ToDecimal(CapitalTexbox.Text);
            prestamo.Fecha = Convert.ToDateTime(FechadateTime.Text);
            prestamo.Interes = Utilities.Utils.ToDecimal(InteresesTextBox.Text);
            prestamo.Tiempo = Utilities.Utils.ToInt(TiempoTextBox.Text);
            prestamo.TotalAPagar = Utilities.Utils.ToInt(TotalTextBox.Text);
            prestamo.Detalle = (List<Cuotas>)ViewState["Cuota"];

            return prestamo;
        }

        private void Limpiar()
        {
            PrestamoIDTextbox.Text = "0";
            FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CapitalTexbox.Text = string.Empty;
            InteresesTextBox.Text = string.Empty;
            TiempoTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            CuotasGridView.DataSource = null;
            CuotasGridView.DataBind();
            LlenaComboCuentaID();
            ViewState["Cuota"] = null;
        }

        private void LlenaComboCuentaID()
        {
            RepositorioBase<Cuentas> cuentas = new RepositorioBase<Cuentas>();
            CuentaDropDownList.Items.Clear();
            CuentaDropDownList.DataSource = cuentas.GetList(x => true);
            CuentaDropDownList.DataValueField = "CuentaID";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
        }

        private void LlenaCampos(Prestamo prestamo)
        {
            Limpiar();
            PrestamoIDTextbox.Text = prestamo.PrestamoID.ToString();
            LlenaComboCuentaID();
            CapitalTexbox.Text = prestamo.Capital.ToString();
            InteresesTextBox.Text = prestamo.Interes.ToString();
            TiempoTextBox.Text = prestamo.Tiempo.ToString();
            TotalTextBox.Text = prestamo.TotalAPagar.ToString();
            CuotasGridView.DataSource = prestamo.Detalle;
            CuotasGridView.DataBind();

        }

        public List<Cuotas> CalculodeCuotas()
        {
            List<Cuotas> cuotas = new List<Cuotas>();
            Prestamo prestamo = new Prestamo();
            interesporciento = Utilities.Utils.ToDecimal(InteresesTextBox.Text);
            Capital = Utilities.Utils.ToDecimal(CapitalTexbox.Text);
            MontoApagar = Capital + (Capital * interesporciento);
            tiempo = Utilities.Utils.ToDecimal(TiempoTextBox.Text);
            interes = Capital * interesporciento / tiempo;
            Fecha = DateTime.Now;
            Capital = Capital / tiempo;
            MontoCuota = MontoApagar / tiempo;
            Balance = MontoApagar;

            
            for (int i = 0; i < tiempo; i++)
            {
                Balance -= MontoCuota;


                if (i == 0)
                {
                    cuotas.Add(new Cuotas(0, i + 1,0, Fecha,Math.Round(MontoCuota,2), Math.Round(interes,2), Math.Round(Capital,2),Math.Round(Balance,2)));
                }
                else
                    cuotas.Add(new Cuotas(0, i + 1,0, Fecha.AddMonths(i), Math.Round(MontoCuota,2), Math.Round(interes,2), Math.Round(Capital,2), Math.Round(Balance,2)));
                
            }
            return cuotas;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(CuentaDropDownList.SelectedValue) == 0)
                return;

            if(CuotasGridView.Rows.Count==0)
            {
                Utilities.Utils.ShowToastr(this, "No se encuentra el ID", "Error", "error");
                return;
            }


            PrestamoBLL repositorio = new PrestamoBLL();
            Prestamo prestamo = LlenaClase();

            RepositorioBase<Cuentas> cuentas = new RepositorioBase<Cuentas>();

            var validar = cuentas.Buscar(Utilities.Utils.ToInt(CuentaDropDownList.SelectedValue));

            bool paso = false;


            if (validar != null)
            {

                if (Page.IsValid)
                {
                    if (prestamo.PrestamoID == 0)
                    {
                        paso = repositorio.Guardar(prestamo);

                    }

                    else
                    {
                        var verificar = repositorio.Buscar(Utilities.Utils.ToInt(PrestamoIDTextbox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(prestamo);
                        }
                        else
                        {
                            Utilities.Utils.ShowToastr(this, "No se encuentra el ID", "Error","error");
                            return;
                        }
                    }

                    if (paso)

                    {
                        Utilities.Utils.ShowToastr(this, "Cuenta Registrada", "Exito", "Exito");

                    }

                    else

                    {
                        Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Error","error");
                    }
                    Limpiar();
                    return;
                }


            }
            else
            {
                Utilities.Utils.ShowToastr(this, "El numero de cuenta no existe", "Error","Error");
                return;


            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            PrestamoBLL repositorio = new PrestamoBLL();
            RepositorioBase<Prestamo> dep = new RepositorioBase<Prestamo>();


            int id = Utilities.Utils.ToInt(PrestamoIDTextbox.Text);
            var depositos = repositorio.Buscar(id);


            if (depositos == null)
            {
                Utilities.Utils.ShowToastr(this, "El Prestamo no existe", "Error","error");
            }

            else
            {
                repositorio.Eliminar(id);
                
                Utilities.Utils.ShowToastr(this, "Elimino Correctamente", "Exito","Exito");
                Limpiar();
            }

        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {
            int id;
            if (Convert.ToInt32(CuentaDropDownList.SelectedValue) != 0)
                id = Convert.ToInt32(CuentaDropDownList.SelectedValue);


            if (Convert.ToInt32(CuentaDropDownList.SelectedValue) != 0)
            {
                ViewState["Cuota"] = CalculodeCuotas();
            }


            CuotasGridView.DataSource = ViewState["Cuota"];
            CuotasGridView.DataBind();

            TotalTextBox.Text = MontoApagar.ToString();



        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();


            Prestamo prestamo = repositorio.Buscar(Utilities.Utils.ToInt(PrestamoIDTextbox.Text));

            Limpiar();
            if (prestamo != null)
            {
                LlenaCampos(prestamo);

                Utilities.Utils.ShowToastr(this, "Se ha Encontrado su deposito", "Exito","Exito");
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "el ID registrado no existe", "Error","error");
            }

        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('../Reportes/ReportePrestamo.aspx','_blanck');</script");
            //Response.Redirect("~/Reportes/ReportePrestamo.aspx");

            
        }
    }
}