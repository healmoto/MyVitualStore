using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.Common;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DAL.DAL_Consultas
{
    public class DAL_Consultascs
    {
        private IConexion conexionDB;

        public DAL_Consultascs()
        {
            conexionDB = new ConexionDAL();
        }

        public List<ProductoVO> ConsultarProductos(string strCriterio)
        {
            DbCommand dbConsulta;
            List<ProductoVO> _productos = new List<ProductoVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_PRODUCTOS");
                conexionDB.AddInParameter(dbConsulta, "@criterio", DbType.String, strCriterio);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _productos.Add(RetornaProducto(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _productos;
        }

        public DateTime  ConsultarFechaInventario()
        {
            DbCommand dbConsulta;
            DateTime _fecha = DateTime.MinValue;
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_FECHA_INVENTARIO");
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _fecha = Convert.ToDateTime(dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _fecha;
        }

        public List<InventarioVO> ConsultarIventario(DateTime _fechaInicial, DateTime _fechaFinal)
        {
            DbCommand dbConsulta;
            List<InventarioVO> _productos = new List<InventarioVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_ConsultarInventario");
                conexionDB.AddInParameter(dbConsulta, "@fechaInicial", DbType.Date, _fechaInicial.ToShortDateString());
                conexionDB.AddInParameter(dbConsulta, "@fechaFinal", DbType.Date, _fechaFinal.ToShortDateString());
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _productos.Add(retornaInventario(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _productos;
        }

        private InventarioVO retornaInventario(IDataReader dr)
        {
            InventarioVO inventario = new InventarioVO();
            inventario.Entradas = Convert.ToInt32(dr[4]);
            inventario.Fecha_Inventario = Convert.ToDateTime(dr[0]);
            inventario.Inventario = Convert.ToInt32(dr[3]);
            inventario.Producto = dr[2].ToString();
            inventario.Referencia = dr[1].ToString();
            inventario.Saldo = Convert.ToInt32(dr[6]);
            inventario.Salidas = Convert.ToInt32(dr[5]);
            return inventario;
        }

        public void Guardar(ProductoVO _producto, Int16 _tipoRegistro)
        {
            DbCommand dbInsert;
            try
            {
                dbInsert = conexionDB.GetStoredProcCommand("PRC_GUARDAR_PRODUCTO");
                conexionDB.AddInParameter(dbInsert, "@consecutivo", DbType.Int32, _producto.Consecutivo);
                conexionDB.AddInParameter(dbInsert, "@referencia", DbType.String, _producto.Referencia);
                conexionDB.AddInParameter(dbInsert, "@nombre", DbType.String, _producto.Nombre);
                conexionDB.AddInParameter(dbInsert, "@descripcion", DbType.String, _producto.Descripcion);
                conexionDB.AddInParameter(dbInsert, "@precio_venta", DbType.Decimal, _producto.Precio_Venta);
                conexionDB.AddInParameter(dbInsert, "@estado", DbType.String, _producto.estado);
                conexionDB.AddInParameter(dbInsert, "@imagen", DbType.String, _producto.Imagen);
                conexionDB.AddInParameter(dbInsert, "@promocion", DbType.Int16, _producto.Promocion);
                conexionDB.AddInParameter(dbInsert, "@TipoRegistro", DbType.Int16, _tipoRegistro);
                conexionDB.AddInParameter(dbInsert, "@costo", DbType.Decimal, _producto.Costo);
                conexionDB.AddInParameter(dbInsert, "@tipo", DbType.String, _producto.Tipo);
                conexionDB.ExecuteNonQuery(dbInsert);
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
        }

        public void Eliminar(Int32 _consecutivo)
        {
            DbCommand dbDelete;
            try
            {
                dbDelete = conexionDB.GetStoredProcCommand("PRC_ELIMINAR_PRODUCTO");
                conexionDB.AddInParameter(dbDelete, "@consecutivo", DbType.Int32, _consecutivo);
                conexionDB.ExecuteNonQuery(dbDelete);
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
        }

        public ProductoVO ConsultarProducto(Int32 intConsecutivo)
        {
            DbCommand dbConsulta;
            ProductoVO _producto = new ProductoVO();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_PRODUCTOS");
                conexionDB.AddInParameter(dbConsulta, "@intConsecutivo", DbType.Int32, intConsecutivo);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _producto = RetornaProducto(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _producto;
        }

        public List<Consolidado> Consolidado(int tipo, int anio, int mes)
        {
            DbCommand dbConsulta;
            List<Consolidado> _consolidado = new List<Consolidado>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTA_CONSOLIDADO");
                conexionDB.AddInParameter(dbConsulta, "@TIPO", DbType.Int32, tipo);
                conexionDB.AddInParameter(dbConsulta, "@ANIO", DbType.Int32, anio);
                conexionDB.AddInParameter(dbConsulta, "@MES", DbType.Int32, mes);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        Consolidado _consola = new Consolidado();
                        _consola = RetornaConsolidado(dr,tipo);
                        _consolidado.Add(_consola);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _consolidado;
        }


        private Consolidado RetornaConsolidado(IDataReader dr, int tipo)
        {
            Consolidado _cons = new Consolidado();
            _cons.Anio = Convert.ToInt16(dr["AÑO"]);
            if (tipo == 3)
            {
                _cons.Mes = dr["MES"].ToString();
                _cons.Dia = Convert.ToInt16(dr["DIA"].ToString());
            }
            if (tipo == 2)
            {
                _cons.Mes = dr["MES"].ToString();
            }
            _cons.Utilidad = Convert.ToDecimal(dr["UTILIDAD"].ToString());
            _cons.Ventas = Convert.ToDecimal(dr["VENTAS"].ToString());
            _cons.Tarjeta = Convert.ToDecimal(dr["TARJETA"].ToString());
            return _cons;
        }

        private ProductoVO RetornaProducto(IDataReader dr)
        {
            ProductoVO _producto = new ProductoVO();
            _producto.Consecutivo = Convert.ToInt32(dr["consecutivo"]);
            _producto.Descripcion = dr["descripcion"].ToString();
            _producto.estado = dr["estado"].ToString();
            _producto.Nombre = dr["nombre"].ToString();
            _producto.Referencia = dr["referencia"].ToString();
            _producto.Precio_Venta = Convert.ToDecimal(dr["precio_venta"]);
            _producto.Costo = Convert.ToDecimal(dr["costo"]);
            _producto.Imagen = dr["imagen"].ToString();
            _producto.Promocion = Convert.ToInt16(dr["promocion_activa"]);
            _producto.Tipo = dr["tipo"].ToString();
            return _producto;
        }

        public List<ProductoVO> ConsultarCatalogo(string codTipo, string codOrden)
        {
            DbCommand dbConsulta;
            List<ProductoVO> _productos = new List<ProductoVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_CATALOGO");
                conexionDB.AddInParameter(dbConsulta, "@strTipo", DbType.String, codTipo);
                conexionDB.AddInParameter(dbConsulta, "@strOrden", DbType.String, codOrden);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _productos.Add(RetornaDominio(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _productos;
        }

        public List<ProductoVO> ConsultarXCriterio(string codOrden, string strCriterio)
        {
            DbCommand dbConsulta;
            List<ProductoVO> _productos = new List<ProductoVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_CRITERIO");
                conexionDB.AddInParameter(dbConsulta, "@strOrden", DbType.String, codOrden);
                conexionDB.AddInParameter(dbConsulta, "@strCriterio", DbType.String, strCriterio);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _productos.Add(RetornaDominio(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _productos;
        }

        public List<ProductoVO> ConsultarPromociones()
        {
            DbCommand dbConsulta;
            List<ProductoVO> _productos = new List<ProductoVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_PROMOCIONES");
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _productos.Add(RetornaDominio(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _productos;
        }

        public ProductoVO ConsultarXReferencia(string strReferencia)
        {
            DbCommand dbConsulta;
            ProductoVO _producto = new ProductoVO();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_REFERENCIA");
                conexionDB.AddInParameter(dbConsulta, "@strReferencia", DbType.String, strReferencia);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _producto = RetornaDominio(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _producto;
        }

        private ProductoVO RetornaDominio(IDataReader dr)
        {
            Control web = new Control();
            ProductoVO _producto = new ProductoVO();
            _producto.Consecutivo = Convert.ToInt32(dr["consecutivo"]);
            _producto.Descripcion = dr["descripcion"].ToString();
            _producto.estado = dr["estado"].ToString();
            _producto.Nombre = dr["nombre"].ToString();
            _producto.Referencia  = dr["referencia"].ToString();
            _producto.Tipo  = dr["tipo"].ToString();
            _producto.estado = dr["estado"].ToString();
            _producto.Precio_Venta = Convert.ToDecimal(dr["precio_venta"]);
            _producto.Imagen = web.ResolveUrl(dr["imagen"].ToString());
            return _producto;
        }

        private ConsultaVentaVO RetornaVenta(IDataReader dr)
        {
            ConsultaVentaVO _venta = new ConsultaVentaVO();
            _venta.Barrio = dr["barrio"] == null ? String.Empty : dr["barrio"].ToString();
            _venta.Numero_Venta = Convert.ToInt32(dr["numero_venta"]);
            _venta.Numero_Detalle = Convert.ToInt64(dr["numero_detalle"]);
            _venta.Cliente = dr["cliente"] == null ? String.Empty : dr["cliente"].ToString();
            _venta.Fecha = Convert.ToDateTime(dr["fecha"]);
            _venta.Ciudad = dr["Ciudad"]==null ? String.Empty : dr["Ciudad"].ToString();
            _venta.Comentarios = dr["comentarios"] == null ? String.Empty : dr["comentarios"].ToString();
            _venta.Email = dr["email"] == null ? String.Empty : dr["email"].ToString();
            _venta.Telefono = dr["telefono"] == null ? String.Empty : dr["telefono"].ToString();
            _venta.Envio = dr["envio"] == null ? String.Empty : dr["envio"].ToString();
            _venta.Pago = dr["pago"] == null ? String.Empty : dr["pago"].ToString();
            _venta.Producto = dr["producto"] == null ? String.Empty : dr["producto"].ToString();
            _venta.Cantidad = Convert.ToInt32(dr["cantidad"]);
            _venta.Precio = Convert.ToDecimal(dr["precio_venta"]);
            _venta.Total = Convert.ToDecimal(dr["Total"]);
            _venta.Archivo = dr["Archivo"].ToString();
            return _venta;
        }

        public int IniciarSesion(String strUsuario, String strContraseña)
        { 
            DbCommand dbConsulta;
            int existe = 0;
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAR_USUARIO");
                conexionDB.AddInParameter(dbConsulta, "@strUsuario", DbType.String, strUsuario);
                conexionDB.AddInParameter(dbConsulta, "@strContraseña", DbType.String, strContraseña);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        existe = Convert.ToInt16(dr["existe"]);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return existe;
        }

        public List<ConsultaVentaVO> ConsultarVentas(DateTime _fecha, Int16 _tarjeta, Int16 _web)
        {
            DbCommand dbConsulta;
            List<ConsultaVentaVO> _ventas = new List<ConsultaVentaVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTAS_VENTAS");
                conexionDB.AddInParameter(dbConsulta, "@fecha", DbType.Date, _fecha);
                conexionDB.AddInParameter(dbConsulta, "@web", DbType.Int16, _web);
                conexionDB.AddInParameter(dbConsulta, "@tarjeta", DbType.Int16, _tarjeta);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _ventas.Add(RetornaVenta(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _ventas;
        }

        public void EliminarVenta(Int64 numero_venta, Int64 numero_detalle)
        {
            DbCommand dbConsulta;
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_ELIMINAR_VENTAS");
                conexionDB.AddInParameter(dbConsulta, "@numero_detalle", DbType.Int64, numero_detalle);
                conexionDB.AddInParameter(dbConsulta, "@numero_venta", DbType.Int64, numero_venta);
                conexionDB.ExecuteNonQuery(dbConsulta);
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
        }

        public List<ProductoVO> ConsultarDetalles(int intVenta)
        {
            DbCommand dbConsulta;
            List<ProductoVO> _productos = new List<ProductoVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_DETALLE_VENTA");
                conexionDB.AddInParameter(dbConsulta, "@numero_venta", DbType.String, intVenta);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _productos.Add(RetornaDominio(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _productos;
        }

        public List<Opcion> ConsultarMenu(int Modulo)
        {
            DbCommand dbConsulta;
            List<Opcion> _opciones = new List<Opcion>();
            Opcion _opt;
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_CONSULTARMENU");
                conexionDB.AddInParameter(dbConsulta, "@modulo", DbType.Int16, Modulo);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _opt = new Opcion();
                        _opt.Consecutivo = Convert.ToInt32(dr["identificador"]);
                        _opt.nombre = dr["nombre"].ToString();
                        _opt.url = dr["url"].ToString();
                        _opt.padre = Convert.ToInt32(dr["padre"]);
                        _opt.modulo = Convert.ToInt32(dr["modulo"]);
                        _opciones.Add(_opt);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _opciones;
        }

    }
}

