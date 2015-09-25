using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EntidadVenta
/// </summary>
public class EntidadVenta
{
    private int id;
    private DateTime fecha;
    private String proveedor;
    private String descripcion;
    private String nombreProducto;
    private int cantidadInventario;
    private int cantidadSolicitada;
	public EntidadVenta(Object [] datos)
	{   
		this.id = Convert.ToInt32(datos[0].ToString());
        this.fecha = Convert.ToDateTime(datos[1].ToString());
        this.proveedor = datos[2].ToString();
        this.descripcion = datos[3].ToString();
        this.nombreProducto = datos[4].ToString();
        this.cantidadInventario = Convert.ToInt32(datos[5].ToString());
        this.cantidadSolicitada = Convert.ToInt32(datos[6].ToString());
	}

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }

    public String Proveedor
    {
        get { return proveedor; }
        set { proveedor = value; }
    }

    public String Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public String NombreProducto
    {
        get { return nombreProducto; }
        set { nombreProducto = value; }
    }

    public int CantidadInventario
    {
        get { return cantidadInventario; }
        set { cantidadInventario = value; }
    }

    public int CantidadSolicitada
    {
        get { return cantidadSolicitada; }
        set { cantidadSolicitada = value; }
    }

}