<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Prestamos.aspx.cs" Inherits="ControlBancario.UI.Registros.Prestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Registro de Prestamos</ins></h1>
            <br />
        </div>
        </div>

            <div class="col-sm-12">

                <div class="Container-fluid">
                    <div class="align-content-center">
                        
                        </div>
                 <%--   PrestamoID--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="PrestamoID: "></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="PrestamoIDTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                                    </td>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                                        <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="PrestamoIDTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                  <%--  Fecha--%>

                <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label8" runat="server" Text="Fecha: "></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="FechadateTime" ValidationGroup="Guardar" runat="server" class="form-control" type="date" Height="30" Width="300" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechadateTime" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                            </table>
                        </div>
                        </div>
                    <%--CuentadropList--%>
                <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Cuenta" runat="server" Text="CuentaID: "></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="CuentaDropDownList" runat="server"></asp:DropDownList>
                                    </td>
                                    <td>
                                       <%--<asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        <asp:CustomValidator ValidationGroup="Guardar" ID="CustomValidator2" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="DropDownList" runat="server" ErrorMessage="Seleccione una cuenta" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>

                <%--CapitalTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label3" runat="server" Text="Capital:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="CapitalTexbox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                         <asp:RegularExpressionValidator ID="Valida" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="CapitalTexbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="ValidaCapital" runat="server" ErrorMessage="El campo &quot;Capital&quot; esta vacio" ControlToValidate="CapitalTexbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

             
                <%--InteresesTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Text="Intereses anual:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="InteresesTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                          <asp:RegularExpressionValidator ID="ValidaMontoNUM" runat="server" ErrorMessage=' solo acepta numeros' ControlToValidate="InteresesTextBox" ValidationExpression="^[0.0-9.0]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                         <asp:RequiredFieldValidator ID="ValidaInteres" runat="server" ErrorMessage="El campo &quot;Monto&quot; esta vacio" ControlToValidate="InteresesTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

               <%--TiempoTextbox--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Text="Tiempo en meses:"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TiempoTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                          <asp:RegularExpressionValidator ID="ValidaMeses" runat="server" ErrorMessage='Campo solo acepta numeros' ControlToValidate="TiempoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="ValidaMeses2" runat="server" ErrorMessage="El campo &quot;Tiempo en meses&quot; esta vacio" ControlToValidate="TiempoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                <%--CalcularButton--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <div class="col-md-4 col-sm-4">
                            <asp:Button ID="CalcularButton" OnClick="CalcularButton_Click" ValidationGroup="Calcular" CssClass="form-control btn btn-primary" runat="server" Text="Calcular" />
                        </div>
                    </div>
                </div>

                 <%--Total--%>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Text="Total: "></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TotalTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campos Obligatorios" ControlToValidate="TotalTextBox" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo Numeros" ControlToValidate="MontoTexbox" Font-Bold="True" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>--%>
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                
                <%--CuaotasGridView--%>
                <div class="form-group">
                    <div class=" col-md-12 col-sm-12">
                        
                                <asp:GridView ID="CuotasGridView" AllowPaging="true"  PageSize="12" runat="server" Height="100%" Width="100%" class="table table-responsive text-center" AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />

                                    <Columns>
                                        <asp:BoundField DataField="CuotaID" HeaderText="CuotaID" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                        <asp:BoundField DataField="Interes" HeaderText="Interes" />
                                        <asp:BoundField DataField="Capital" HeaderText="Capital" />
                                        <asp:BoundField DataField="MontoApagar" HeaderText="Monto A pagar" />
                                        <asp:BoundField DataField="Balance" HeaderText="Balance" />


                                    </Columns>

                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>

                     
                </div>

            </div>

        
        <%--Botones--%>
     <div class="panel-footer">
            <div class="text-center">
      <asp:Label class="text-center " ID="ErrorLabel" runat="server" Text=""></asp:Label>

                        <asp:Button ID="NuevoButton" runat="server" class="btn btn-info" Text="Nuevo" OnClick="NuevoButton_Click" ValidationGroup="Nuevo" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="Guardar"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                <asp:Button ID="ReporteButton" runat="server" class="btn btn-success" Text="Imrpimir" OnClick="ReporteButton_Click" />
   
    </div>

     </div>


</asp:Content>
