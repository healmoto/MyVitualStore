using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entities;
using DAL;

/// <summary>
/// Summary description for WS_Info
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WS_Info : System.Web.Services.WebService {

    public WS_Info () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<ProductoVO> ConsultarProductos(UsuarioVO  _token) {
        List<ProductoVO> _productos = new List<ProductoVO>();
        DAL.DAL_PuntoVenta.DAL_PuntoVenta oPuntoVenta = new DAL.DAL_PuntoVenta.DAL_PuntoVenta();
        if (ValidarToken(_token) == true)
        {
            _productos = oPuntoVenta.ConsultarProductos();
        }
        return _productos;
    }

    private bool ValidarToken(UsuarioVO _token)
    {
        bool _valido = false;
        DAL.DAL_PuntoVenta.DAL_PuntoVenta  oPuntoVentas = new DAL.DAL_PuntoVenta.DAL_PuntoVenta ();
        _valido = oPuntoVentas.ValidarToken(_token);
        return _valido;
    }

    [WebMethod]
    public List<ProveedorVO> ConsultarProveedores(UsuarioVO _token)
    {
        List<ProveedorVO> _proveedor = new List<ProveedorVO>();
        DAL.DAL_PuntoVenta.DAL_PuntoVenta oPuntoVenta = new DAL.DAL_PuntoVenta.DAL_PuntoVenta();
        if (ValidarToken(_token) == true)
        {
            _proveedor = oPuntoVenta.ConsultarProveedores();
        }
        return _proveedor;
    }

    [WebMethod]
    public bool CompraNueva(UsuarioVO _token, Compra _compra)
    {
        bool _valido = false;
        DAL.DAL_PuntoVenta.DAL_PuntoVenta oPuntoVenta = new DAL.DAL_PuntoVenta.DAL_PuntoVenta();
        if (ValidarToken(_token) == true)
        {
            if (oPuntoVenta.InsertarCompra(_compra) > 0)
            {
                _valido = true;
            }
        }
        return _valido;
    }

    [WebMethod]
    public bool VentaNueva(UsuarioVO _token, VentaVO _venta)
    {
        bool _valido = false;
        DAL.DAL_PuntoVenta.DAL_PuntoVenta oPuntoVenta = new DAL.DAL_PuntoVenta.DAL_PuntoVenta();
        DAL.DAL_Ventas.DAL_Venta oVentas = new DAL.DAL_Ventas.DAL_Venta();
        if (ValidarToken(_token) == true)
        {
            if (oVentas.InsertarVenta(_venta) > 0)
            {
                _valido = true;
            }
        }
        else
        {
            _valido = false;
        }
        return _valido;
    }

    [WebMethod]
    public List<ConsultaVentaVO> ConsultarVentas(DateTime _fecha, Int16 _tarjeta, Int16 _web)
    {
        DAL.DAL_Consultas.DAL_Consultascs consulta = new DAL.DAL_Consultas.DAL_Consultascs();
        return consulta.ConsultarVentas(_fecha, _tarjeta, _web);
    }
}
