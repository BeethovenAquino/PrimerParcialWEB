using BLL;
using ControlBancario.Utilities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBancario.UI.Consultas
{
    public partial class ConsulCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }



        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            CuentaGridView.DataBind();
            Expression<Func<Cuentas, bool>> filtro = x => true;
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.CuentaID == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.CuentaID == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Cuenta No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// Nombre

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Nombre.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Nombre.Contains(TextCriterio.Text);
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;



                case 2:// Balance

                    decimal balance = Utils.ToDecimal(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Balance == balance && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Balance == balance;
                    }
                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Balance no encontrado", "Fallido", "success");
                        return;
                    }
                    break;

                case 3://Todos

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = x => true;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "No existen dichas cuentas", "Fallido", "success");
                        return;
                    }
                    break;

            }

            CuentaGridView.DataSource = repositorio.GetList(filtro);
            CuentaGridView.DataBind();


        }
    }
}