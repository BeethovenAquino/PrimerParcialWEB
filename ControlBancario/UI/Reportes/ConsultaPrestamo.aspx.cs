using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBancario.UI.Reportes
{
    public partial class ConsultaPrestamo : System.Web.UI.Page
    {
        RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ConsulPrestamoReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ConsulPrestamoReportViewer.Reset();

                ConsulPrestamoReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ConsultarPrestamoReport.rdlc");

                ConsulPrestamoReportViewer.LocalReport.DataSources.Clear();

                ConsulPrestamoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ConsulPrestamo", repositorio.GetList(x => true)));
                ConsulPrestamoReportViewer.LocalReport.Refresh();
            }
        }
    }
}