<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Depositos.aspx.cs" Inherits="ControlBancario.UI.Registros.Depositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group container">
        <div class="row">
            <div class="col-sm-12">

                <div class="Container-fluid">
                    <div class="align-content-center">
                        <div class="panel-heading text-center">
                            <h1><ins>Deposito</ins></h1>
                            <br />
                        </div>

                        <%--DepositoID--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="DepositoID:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="DepositoIDTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                                    </td>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" ValidationGroup="Buscar" />
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="DepositoIDTextbox" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--Fecha--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label8" runat="server" Text="Fecha:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="FechadateTime" runat="server" class="form-control" type="date" Height="30" Width="300" MaxLength="10"></asp:TextBox>
                                    </td>

                                </tr>
                            </table>
                        </div>
                        <%--CuentaDropList--%>
                         <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Cuenta" runat="server" Text="CuentaID:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="DropDownList" runat="server"></asp:DropDownList>
                                    </td>
                                    <td>
                                       <%--<asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        <asp:CustomValidator ValidationGroup="Guardar" ID="CustomValidator2" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="DropDownList" runat="server" ErrorMessage="Seleccione una cuenta" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>

                         <%--ConceptoTextbox--%>
                    
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Text="Concepto:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="ConceptoTextbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="ConceptoTextbox" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Letras" ControlToValidate="ConceptoTextbox" Font-Bold="True" ForeColor="Red" ValidationExpression="[A-Za-z ]*">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                         <%--Monto Textbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label3" runat="server" Text="Monto:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="MontoTexbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="MontoTexbox" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo Numeros" ControlToValidate="MontoTexbox" Font-Bold="True" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>--%>
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />





                        <asp:Label class="text-center " ID="ErrorLabel" runat="server" Text=""></asp:Label>

                        <asp:Button ID="NuevoButton" runat="server" class="btn btn-info" Text="Nuevo" OnClick="NuevoButton_Click" ValidationGroup="Nuevo" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" style="height: 29px" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
    


    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <link href="/Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-3.2.1.slim.min.js"></script>

</asp:Content>
