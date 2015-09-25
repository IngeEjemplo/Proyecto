using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ControladoraVenta
/// </summary>
public class ControladoraVenta
{
    ControladoraBDVenta controladoraBDVenta = new ControladoraBDVenta();
	public ControladoraVenta()
	{

	}

    public DataTable consultarVentas()
    {
        return controladoraBDVenta.consultarVentas();
    }

    public int retornarTotalVentas()
    {
        return controladoraBDVenta.retornarTotalVentas();
    }

    public void ejecutarAccion(int modo, Object [] datos) {
        switch (modo) {
            case 1: { // INSERTAR
                EntidadVenta venta = new EntidadVenta(datos);
                controladoraBDVenta.insertarVenta(venta);
                
            };
            break;
            case 2:
            { // MODIFICAR
                EntidadVenta venta = new EntidadVenta(datos);
                controladoraBDVenta.modificarVenta(venta);

            };
            break;
        }
    }

    public void ejecutarAccion(int modo, int idVenta)
    {
        if(modo==3){
            controladoraBDVenta.eliminarCuenta(idVenta);
        }
    }

    public DataTable consultarVenta(int idVenta) {
        return controladoraBDVenta.consultarVenta(idVenta);
    }
}