<%@ Page Title="Venta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Venta.aspx.cs" Inherits="Venta" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <!DOCTYPE html>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tituloVentas">
        <h1>Mantenimiento de las compras</h1>
    </div>
    <div id="btnsControl" style="float:right">
        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click"/>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
    </div>
    <div style="float:left;">
        <div id="ctrTitulo">
            <asp:Label ID="lblIdCompra" runat="server" Text="ID Compra" Width="100px"></asp:Label>
            <asp:TextBox ID="txtIdCompra" runat="server" Enabled="false" width="20px"></asp:TextBox>
        </div>
        <div id="ctrFecha">
            <asp:Label ID="lblFecha" runat="server" Text="Fecha Compra" Width="100px"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" Enabled="true" width="300px"></asp:TextBox>
        </div>
        <div id="ctrProveedor">
            <asp:Label ID="lblProveedor" runat="server" Text="Proveedor" Width="100px"></asp:Label>
            <asp:DropDownList ID="drpProveedor" runat="server"></asp:DropDownList>
        </div>
        <div id="ctrDesc">
            <asp:Label ID="lblDesc" runat="server" Text="Descripción" Width="100px"></asp:Label>
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div id="ctrProd">
            <asp:Label ID="lblProd" runat="server" Text="Nombre Producto" Width="200px"></asp:Label>
            <asp:DropDownList ID="drpProd" runat="server" OnSelectedIndexChanged="drpProd_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:Label ID="lblInv" runat="server" Text="Cantidad Inventario"></asp:Label>
            <asp:TextBox ID="txtInv" runat="server" Enabled="false" width="50px"></asp:TextBox>
            <asp:Label ID="lblSol" runat="server" Text="Cantidad Solicitada"></asp:Label>
            <asp:TextBox ID="txtSol" runat="server" width="50px"></asp:TextBox>
        </div>
        <div id="btnAgBo" style="float:left">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click"/>
        </div>
        <div id="tablaVentas">
            <asp:GridView ID="gridVentas" runat="server" OnRowCommand="gridVentas_RowCommand" OnPageIndexChanged="gridVentas_PageIndexChanged">
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="Consultar" CommandName="seleccionarVenta" Visible="true" CausesValidation="false" />
                </Columns> 
            </asp:GridView>  
        </div>
    </div>
</asp:Content>


