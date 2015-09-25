using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Venta : System.Web.UI.Page
{
    public int[] inventario = { 4, 3, 6, 8 };
    private static int modo = 1;
    private static int idVenta = -1;
    ControladoraVenta controladoraVenta = new ControladoraVenta();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDropDownProductos();
            llenarDropDownProveedores();
            controlarCampos(false);
        }
        llenarGrid();
    }
    protected void gridVentas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "seleccionarVenta":
                {
                    GridViewRow filaSeleccionada = this.gridVentas.Rows[Convert.ToInt32(e.CommandArgument)];
                    idVenta = Convert.ToInt32(filaSeleccionada.Cells[1].Text);
                    llenarDatos(idVenta);
                };
                break;
        }

    }
    protected void gridVentas_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        modo = 1;
        vaciarCampos();
        controlarCampos(true);
        this.txtIdCompra.Text = Convert.ToString(controladoraVenta.retornarTotalVentas());
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        modo = 2;
        if (idVenta != -1)
        {
            controlarCampos(true);
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        modo = 3;
        if(idVenta!=-1){
            controladoraVenta.ejecutarAccion(modo, idVenta);
        }
        idVenta = -1;
        llenarGrid();
        vaciarCampos();
    }
    protected void vaciarCampos() {
        this.txtDesc.Text = "";
        this.txtFecha.Text = "";
        this.txtInv.Text = "";
        this.txtSol.Text = "";
        this.txtIdCompra.Text = "";
    }
    protected void controlarCampos(Boolean condicion) {
        if (condicion)
        {
            this.txtSol.Enabled = true;
            this.txtDesc.Enabled = true;
            this.txtFecha.Enabled = true;
            this.drpProveedor.Enabled = true;
            this.drpProd.Enabled = true;
        }
        else {
            this.txtSol.Enabled = false;
            this.txtDesc.Enabled = false;
            this.txtFecha.Enabled = false;
            this.drpProveedor.Enabled = false;
            this.drpProd.Enabled = false;
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Object [] datosNuevos = new Object[7];
        datosNuevos[0] = this.txtIdCompra.Text;
        datosNuevos[1] = this.txtFecha.Text;
        datosNuevos[2] = this.drpProveedor.SelectedValue.ToString();
        datosNuevos[3] = this.txtDesc.Text;
        datosNuevos[4] = this.drpProd.SelectedValue.ToString();
        datosNuevos[5] = this.txtInv.Text;
        datosNuevos[6] = this.txtSol.Text;
        controladoraVenta.ejecutarAccion(modo, datosNuevos);
        llenarGrid();
        controlarCampos(false);
        idVenta = -1;
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        vaciarCampos();
        controlarCampos(false);
    }

    protected void llenarGrid() {
        DataTable dt = crearTablaVenta();
        DataTable ventas = controladoraVenta.consultarVentas();
        Object [] datos = new Object[3];
        if (ventas.Rows.Count > 0)
        {
            foreach(DataRow fila in ventas.Rows){
                datos[0] = fila[0].ToString();
                datos[1] = fila[1].ToString();
                datos[2] = fila[3].ToString();
                dt.Rows.Add(datos);
            }
        }
        else {
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            dt.Rows.Add(datos);
        }
        this.gridVentas.DataSource = dt;
        this.gridVentas.DataBind();
    }

    protected DataTable crearTablaVenta() {
        DataTable dt = new DataTable();
        DataColumn columna;

        columna = new DataColumn();
        columna.DataType = System.Type.GetType("System.String");
        columna.ColumnName = "IDVenta";
        dt.Columns.Add(columna);

        columna = new DataColumn();
        columna.DataType = System.Type.GetType("System.String");
        columna.ColumnName = "Fecha";
        dt.Columns.Add(columna);

        columna = new DataColumn();
        columna.DataType = System.Type.GetType("System.String");
        columna.ColumnName = "Descripcion";
        dt.Columns.Add(columna);

        return dt;
    }

    protected void llenarDropDownProductos() {
        this.drpProd.Items.Clear();
        Object[] datos = new Object[4];
        datos[0] = "Coca cola";
        datos[1] = "Fanta";
        datos[2] = "Galleta chiky";
        datos[3] = "Galleta de mantequilla";
        this.drpProd.DataSource = datos;
        this.drpProd.DataBind();
    }

    protected void llenarDropDownProveedores()
    {
        this.drpProveedor.Items.Clear();
        Object[] datos = new Object[4];
        datos[0] = "Distribuidora La Florida";
        datos[1] = "Distribuciones Horizontales";
        datos[2] = "Dos Pinos";
        datos[3] = "Pozuelo";
        this.drpProveedor.DataSource = datos;
        this.drpProveedor.DataBind();
    }


    protected void drpProd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtInv.Text = inventario[this.drpProd.SelectedIndex].ToString();
    }

    public void llenarDatos(int idVenta) {
        DataTable datosFila = controladoraVenta.consultarVenta(idVenta);
        if(datosFila.Rows.Count==1){
            this.txtIdCompra.Text = datosFila.Rows[0][0].ToString();
            this.txtFecha.Text = datosFila.Rows[0][1].ToString();
            if (this.drpProveedor.Items.FindByText(datosFila.Rows[0][2].ToString()) != null){
               ListItem aux = this.drpProveedor.Items.FindByText(datosFila.Rows[0][2].ToString());
               this.drpProveedor.SelectedValue = aux.Value;
            }
            this.txtDesc.Text = datosFila.Rows[0][3].ToString();
            if (this.drpProd.Items.FindByText(datosFila.Rows[0][4].ToString()) != null)
            {
                ListItem aux = this.drpProd.Items.FindByText(datosFila.Rows[0][4].ToString());
                this.drpProd.SelectedValue = aux.Value;
            }
            this.txtInv.Text = datosFila.Rows[0][5].ToString();
            this.txtSol.Text = datosFila.Rows[0][6].ToString();
        }
    }

}