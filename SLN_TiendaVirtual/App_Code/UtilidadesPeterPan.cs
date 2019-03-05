using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Recursos para la aplicacion
/// </summary>
public class UtilidadesPeterPan
{

    public static void VerificarSesion()
    {
        if (HttpContext.Current.Session[UtilidadesPeterPan.USUARIO] == null)
        {
            HttpContext.Current.Response.Redirect("Login.aspx", true);
        }
    }

    public enum eTipoPago
    { 
        eConsignacion=1,
        ePagos=2,
        ePaypal=3,
        eContraentrega
    }

    public enum eEnvio
    {
        eServientrega = 1,
        eDomicilio = 2,
        eSinEnvio = 3
    }
    
    const String _CATALOGO = "catalogo";
    const String _TIPOPRODUCTO = "tipoProducto";
    const String _TIPO_DEFAULT = "C";
    const String _DOMINIO_ORDEN = "OR";
    const String _DOMINIO_ORDEN_DEFAULT = "NO";
    const String _DATATEXT_DOMINIO = "Descripcion";
    const String _DATAVALUE_DOMINIO = "Codigo";
    const String _BUSQUEDA = "Busqueda";
    const String _PRODUCTOS = "productos";
    const String _VENTAS = "ventas";
    const String _PROMO_ACTUAL = "PROMO_ACTUAL";
    const String _DOMINIO_CIUDAD = "CIU";
    const String _DOMINIO_TIPO_PROD = "TIP";
    const String _SESION_VENTA = "VENTA";
    const String _VALOR_VENTA = "VALOR_VENTA";
    const String _PARAMETRO_SERV = "VSERV";
    const String _PARAMETRO_DOM = "VDOM";
    const String _USUARIO = "USUARIO";
	public UtilidadesPeterPan()
	{
		
	}

    public static String USUARIO
    {
        get { return _USUARIO; }
    }

    public static String PARAMETRO_DOM
    {
        get { return _PARAMETRO_DOM; }
    }

    public static String PARAMETRO_SERV
    {
        get { return _PARAMETRO_SERV; }
    }

    public static String VALOR_VENTA
    {
        get { return _VALOR_VENTA; }
    }

    public static String SESION_VENTA
    {
        get { return _SESION_VENTA; }
    }

    public static String DOMINIO_CIUDAD
    {
        get { return _DOMINIO_CIUDAD; }
    }

    public static String DOMINIO_TIPO_PROD
    {
        get { return _DOMINIO_TIPO_PROD; }
    }

    public static String PROMO_ACTUAL
    {
        get { return _PROMO_ACTUAL; }
    }

    public static String VENTAS
    {
        get { return _VENTAS; }
    }

    public static String PRODUCTOS
    {
        get { return _PRODUCTOS; }
    }

    public static String BUSQUEDA
    {
        get { return _BUSQUEDA; }
    }

    public static String DATATEXT_DOMINIO
    {
        get { return _DATATEXT_DOMINIO; }
    }

    public static String DATAVALUE_DOMINIO
    {
        get { return _DATAVALUE_DOMINIO; }
    }

    public static String DOMINIO_ORDEN
    {
        get { return _DOMINIO_ORDEN; }
    }

    public static String DOMINIO_ORDEN_DEFAULT
    {
        get { return _DOMINIO_ORDEN_DEFAULT; }
    }


    public static String TIPO_DEFAULT
    {
        get { return _TIPO_DEFAULT ; }
    }

    public static String CATALOGO
    {
        get { return _CATALOGO; }
    }

    public static String TIPO_PROD
    {
        get { return _TIPOPRODUCTO; }
    }
}