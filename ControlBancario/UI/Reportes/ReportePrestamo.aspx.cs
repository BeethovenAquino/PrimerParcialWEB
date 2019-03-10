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
    public partial class ReportePrestamo : System.Web.UI.Page
    {
        RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var Prestamos = repositorio.GetList(x => true).Last();
            List<Prestamo> prestamo = new List<Prestamo>();

            //prestamo.Add(new Prestamo(Prestamos.PrestamoID, Prestamos.Interes, Prestamos.CuentaID, Prestamos.Capital, Prestamos.Tiempo, Prestamos.Fecha, Prestamos.TotalAPagar));

            if (!Page.IsPostBack)
            {
                PrestamoReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                PrestamoReportViewer.Reset();
                PrestamoReportViewer.LocalReport.ReportPath = Server.MapPath(@"..\Reportes\PrestamoReport.rdlc");

                PrestamoReportViewer.LocalReport.DataSources.Clear();

                PrestamoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", repositorio.GetList(x=>true)));
                PrestamoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuotasDt", repositorio.GetList(x => true).Last().Detalle));

                PrestamoReportViewer.LocalReport.Refresh();
            }
        }
    }
}
