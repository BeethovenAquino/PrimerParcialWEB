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
    public partial class Depositos : System.Web.UI.Page

    {
        string condicion = "Select One";
        RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                LlenaComboCuentaID();
                FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DepositoIDTextbox.Text = "0";
            }

        }

        public Deposito LlenaClase()
        {
            Deposito deposito = new Deposito();
            int id;
            bool result = int.TryParse(DepositoIDTextbox.Text, out id);
            if (result == true)
            {
                deposito.DepositoID = id;
            }
            else
            {
                deposito.DepositoID = 0;
            }

            deposito.CuentaID = Convert.ToInt32(DropDownList.SelectedValue);

            deposito.Concepto = ConceptoTextbox.Text;
            deposito.Fecha = Convert.ToDateTime(FechadateTime.Text);
            deposito.Monto = Convert.ToDecimal(MontoTexbox.Text.ToString());

            return deposito;
        }

        private void LlenaCampos(Deposito deposito)
        {
            DepositoIDTextbox.Text = deposito.DepositoID.ToString();
            LlenaComboCuentaID();
            ConceptoTextbox.Text = deposito.Concepto;
            MontoTexbox.Text = deposito.Monto.ToString();
          
        }
        private void Limpiar()
        {
            DepositoIDTextbox.Text = "";
            LlenaComboCuentaID();
            ConceptoTextbox.Text = "";
            MontoTexbox.Text = "";
            FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        void MostrarMensaje(TiposMensajes tipo, string mensaje)

        {

            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensajes.Success)

                ErrorLabel.CssClass = "alert-success";

            else

                ErrorLabel.CssClass = "alert-danger";

        }

        private void LlenaComboCuentaID()
        {
            RepositorioBase<Cuentas> cuentas = new RepositorioBase<Cuentas>();
            DropDownList.Items.Clear();
            DropDownList.Items.Add(condicion);
            DropDownList.DataSource = cuentas.GetList(x => true);
            DropDownList.DataValueField = "CuentaID";
            DropDownList.DataTextField = "Nombre";
            DropDownList.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (DropDownList.SelectedValue == condicion)
                return;


            DepositoBLL repositorio = new DepositoBLL();
            Deposito depositos = LlenaClase();
            RepositorioBase<Cuentas> cuentas = new RepositorioBase<Cuentas>();

            var validar = cuentas.Buscar(Utilities.Utils.ToInt(DropDownList.SelectedValue));

            bool paso = false;


            if (validar != null)
            {

                if (Page.IsValid)
                {
                    if (DepositoIDTextbox.Text == "0")
                    {
                        paso = repositorio.Guardar(depositos);

                    }

                    else
                    {
                        var verificar = repositorio.Buscar(Utilities.Utils.ToInt(DepositoIDTextbox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(depositos);
                        }
                        else
                        {
                            Utilities.Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "success");
                            return;
                        }
                    }

                    if (paso)

                    {
                        Utilities.Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");

                    }

                    else

                    {
                        Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "success");
                    }
                    Limpiar();
                    return;
                }


            }
            else
            {
                Utilities.Utils.ShowToastr(this, "El numero de cuenta no existe", "Fallo", "success");
                return;


            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            
            DepositoBLL repositorio = new DepositoBLL();
            RepositorioBase<Deposito> dep = new RepositorioBase<Deposito>();


            int id = Utilities.Utils.ToInt(DepositoIDTextbox.Text);
            var depositos = repositorio.Buscar(id);


            if (depositos == null)
            {
                Utilities.Utils.ShowToastr(this, "El deposito no existe", "Fallo", "success");
            }

            else
            {
                repositorio.Eliminar(id);



                Utilities.Utils.ShowToastr(this, "Elimino Correctamente", "Exito", "success");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();


            Deposito depositos = repositorio.Buscar(Utilities.Utils.ToInt(DepositoIDTextbox.Text));

            Limpiar();
            if (depositos != null)
            {
                LlenaCampos(depositos);

                Utilities.Utils.ShowToastr(this, "Se ha Encontrado su deposito", "Exito", "success");
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "el ID registrado no existe", "Fallido", "success");
            }
        }
    }
}
