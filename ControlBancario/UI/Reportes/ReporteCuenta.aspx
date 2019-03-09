<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCuenta.aspx.cs" Inherits="ControlBancario.ReporteCuenta" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form2" runat="server">
        <div id="div1">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="CuentaReportViewer" runat="server" Height="100%" Width="100%"></rsweb:ReportViewer>
        </div>
    </form>
    
</body>
</html>
