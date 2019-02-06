using BLL;
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
    public partial class ConsulDepositos : System.Web.UI.Page
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
            DepositoGridView.DataBind();
            Expression<Func<Deposito, bool>> filtro = x => true;
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.DepositoID == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.DepositoID == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, " Deposito ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// CuentaId
                    int cuentaid = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.CuentaID == cuentaid && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.CuentaID == cuentaid;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Cuenta ID No Existe", "Fallido", "success");
                    }

                    break;



                case 2:// Concepto

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Concepto.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Concepto.Contains(TextCriterio.Text);
                    }
                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Concepto No Existe", "Fallido", "success");
                    }
                    break;

                case 3:// Monto
                    decimal monto = Utilities.Utils.ToDecimal(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Monto == monto && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Monto == monto;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.ShowToastr(this, "Monto No existe", "Fallido", "success");
                    }

                    break;

                case 4://Todos

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
                        Utilities.Utils.ShowToastr(this, "No existen Dichas Cuentas", "Fallido", "success");
                    }
                    break;

            }

            DepositoGridView.DataSource = repositorio.GetList(filtro);
            DepositoGridView.DataBind();
        }
    }
}