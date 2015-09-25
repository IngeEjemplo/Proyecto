using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataSetVentaTableAdapters;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ControladoraBDVenta
/// </summary>
public class ControladoraBDVenta
{
    VENTASTableAdapter adapterVentas;
	public ControladoraBDVenta()
	{
        //adapterVentas = new VENTASTableAdapter();	
	}

    public DataTable consultarVentas() {
        DataTable dt = new DataTable();
        //dt = adapterVentas.GetData();
        return dt;
    }

    public int retornarTotalVentas() {
        int respuesta = 0;
        //respuesta = (int)(adapterVentas.totalVentas());
        return respuesta;
    }

    public void insertarVenta(EntidadVenta venta) {
        try
        {
            //this.adapterVentas.Insert(venta.ID, venta.Fecha, venta.Proveedor, venta.Descripcion, venta.NombreProducto, venta.CantidadInventario, venta.CantidadSolicitada); 
        }
        catch (SqlException e)
        {
            int r = e.Number;
            if (r == 2627)
            {
                // "Ya existe una venta con este id";
            }
            else
            {
                //"Se ha producido un error al insertar la venta";
            }
        }
    }

    public void modificarVenta(EntidadVenta venta)
    {
        try
        {
            //this.adapterVentas.Update(venta.ID, venta.Fecha, venta.Proveedor, venta.Descripcion, venta.NombreProducto, venta.CantidadInventario, venta.CantidadSolicitada, venta.ID); 
        }
        catch (SqlException e)
        {
            int r = e.Number;
            if (r == 2627)
            {
                // "Ya existe una venta con este id";
            }
            else
            {
                //"Se ha producido un error al modificar la venta";
            }
        }
    }

    public void eliminarCuenta(int idVenta) {
        try
        {
            //adapterVentas.Delete(idVenta);

        }
        catch (SqlException e)
        {
            //"Ha ocurrido un error al eliminar la venta";
        }
    }

    public DataTable consultarVenta(int idVenta) {
        DataTable dt = new DataTable();
        //dt = this.adapterVentas.consultarFila(idVenta);
        return dt;
    }
}