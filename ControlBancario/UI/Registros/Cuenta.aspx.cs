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
                
            }

        }

        public Cuentas LlenaClase(Cuentas cuentas)
        {
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


        void MostrarMensaje(TiposMensajes tipo, string mensaje)

        {

            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensajes.Success)

                ErrorLabel.CssClass = "alert-success";

            else

                ErrorLabel.CssClass = "alert-danger";

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuentas = new Cuentas();
            bool paso = false;

            LlenaClase(cuentas);
            //Validacion
            if (cuentas.CuentaID == 0)

                paso = repositorio.Guardar(cuentas);
            else
                paso = repositorio.Modificar(cuentas);
            if (paso)

            {
                MostrarMensaje(TiposMensajes.Success, "Registro Exitoso!");
                Limpiar();

            }
            else
                MostrarMensaje(TiposMensajes.Error, "No fue posible Guardar el Registro");

            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();



            int id = 0;
            if (CuentaIDTextbox.Text != null)
            {
                id = Convert.ToInt32(CuentaIDTextbox.Text);
            }

            else
                return;
            if (CuentaIDTextbox.Text != null)
            {

                //Si tiene algun prestamo o deposito enlazado no elimina
                RepositorioBase<Deposito> repositorios = new BLL.RepositorioBase<Deposito>();

                if (repositorios.GetList(x => x.CuentaID == id).Count() > 0)
                {
                    MostrarMensaje(TiposMensajes.Error, "No Fue Posible Eliminarlo, Contiene Depositos en esa Cuenta");

                }

                var usuario = repositorio.Buscar(id);



                if (usuario == null)

                    MostrarMensaje(TiposMensajes.Error, "Registro no encontrado");

                else

                    repositorio.Eliminar(id);
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();


            Cuentas cuentas = repositorio.Buscar(Convert.ToInt32(CuentaIDTextbox.Text));
            if (cuentas != null)
            {
                LlenaCampos(cuentas);
            }
            else
            {
                Response.Write("<script>alert('Usuario no encontrado');</script>");

            }

        }
    }
}