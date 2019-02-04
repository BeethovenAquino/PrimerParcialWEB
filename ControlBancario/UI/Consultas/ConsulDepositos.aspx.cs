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

                FechaCheckBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaCheckBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
        bool paso = false;
        Expression<Func<Deposito, bool>> filtrar = x => true;

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {

            var DesdeDateTime = Convert.ToDateTime(DesdeTextBox.Text);
            var HastaDateTime = Convert.ToDateTime(HastaTextBox.Text);
            int id = 0;
            if (TextCriterio.Text == string.Empty && FechaCheckBox.Checked == true)
            {
                filtrar = t => true && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
            }
            else
            {
                filtrar = t => true;
            }
            switch (TipodeFiltro.SelectedIndex)
            {

                //Lista todo
                case 0:

                    if (FechaCheckBox.Checked == true)
                    {
                        filtrar = t => true && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => true;
                    }

                    break;

                case 1:
                    if (paso)
                        return;
                    id = int.Parse(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtrar = t => t.CuentaID == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.CuentaID == id;
                    }

                    break;

                case 2:
                    if (paso)
                        return;
                    if (FechaCheckBox.Checked == true)
                    {
                        filtrar = t => t.DepositoID.Equals(TextCriterio.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.DepositoID.Equals(TextCriterio.Text);

                    }
                    break;

                case 3:

                    if (FechaCheckBox.Checked == true)
                    {
                        filtrar = t => t.Concepto.Equals(TextCriterio.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Concepto.Equals(TextCriterio.Text);
                    }

                    break;

                case 4:
                    if (paso)
                        return;
                    if (FechaCheckBox.Checked == true)
                    {
                        filtrar = t => t.Monto.Equals(TextCriterio.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Monto.Equals(TextCriterio.Text);
                    }

                    break;

            }

            DepositoGridView.DataSource = repositorio.GetList(filtrar);
            DepositoGridView.DataBind();


        }
    }
}