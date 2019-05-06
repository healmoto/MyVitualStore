using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.Common;
using System.Data;

namespace DAL.DAL_PuntoVenta
{
    public class DAL_PuntoVenta
    {
        private IConexion conexionDB;

        public DAL_PuntoVenta()
        {
            conexionDB = new ConexionDAL();
        }

        public bool ValidarToken(UsuarioVO _token)
        {
            DbCommand dbConsulta;
            bool  existe = false;
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_PV_CONSULTAR_TOKEN");
                conexionDB.AddInParameter(dbConsulta, "@strUsuario", DbType.String, _token.Usuario.ToString());
                conexionDB.AddInParameter(dbConsulta, "@strPass", DbType.String, _token.Contraseña.ToString());
                conexionDB.AddInParameter(dbConsulta, "@strEquipo", DbType.String, _token.Equipo.ToString());
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        existe = dr["existe"].ToString() == "1" ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return existe;
        }

        public List<ProductoVO> ConsultarProductos()
        {
            DbCommand dbConsulta;
            List<ProductoVO> _productos = new List<ProductoVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_PV_CONSULTAR_PRODUCTOS");
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

        private ProductoVO RetornaProducto(IDataReader dr)
        {
            ProductoVO _producto = new ProductoVO();
            _producto.Consecutivo = Convert.ToInt32(dr["consecutivo"]);
            _producto.Descripcion = dr["descripcion"].ToString();
            _producto.estado = dr["estado"].ToString();
            _producto.Nombre = dr["nombre"].ToString();
            _producto.Referencia = dr["referencia"].ToString();
            _producto.Tipo = dr["tipo"].ToString();
            _producto.Precio_Venta = Convert.ToDecimal(dr["precio_venta"]);
            _producto.Costo = Convert.ToDecimal(dr["costo"]);
            return _producto;
        }

        private ProveedorVO RetornaProveedor(IDataReader dr)
        {
            ProveedorVO _proveedor = new ProveedorVO();
            _proveedor.Consecutivo = Convert.ToInt32(dr["consecutivo"]);
            _proveedor.Nombre = dr["nombre"].ToString();
            _proveedor.Nit = dr["nit"].ToString();
            _proveedor.Telefono = dr["telefono"].ToString();
            _proveedor.Correo = dr["correo"].ToString();
            _proveedor.Direccion = dr["direccion"].ToString();
            return _proveedor;
        }

        public List<ProveedorVO> ConsultarProveedores()
        {
            DbCommand dbConsulta;
            List<ProveedorVO> _proveedores = new List<ProveedorVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_PV_CONSULTARPROVEEDORES");
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _proveedores.Add(RetornaProveedor(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _proveedores;
        }

        public int InsertarCompra(Compra _compra)
        {
            DbCommand dbInsertar;
            try
            {
                dbInsertar = conexionDB.GetStoredProcCommand("PRC_PV_COMPRA");
                conexionDB.AddInParameter(dbInsertar, "@fecha", DbType.Date, _compra.Fecha);
                conexionDB.AddInParameter(dbInsertar, "@factura", DbType.String, _compra.factura);
                conexionDB.AddInParameter(dbInsertar, "@proveedor", DbType.String, _compra.Proveedor);
                conexionDB.AddOutParameter(dbInsertar, "@numero", DbType.Int32, 10);
                conexionDB.ExecuteNonQuery(dbInsertar);
                Int32 numero_compra = 0;
                numero_compra = Convert.ToInt32(conexionDB.GetParameterValue(dbInsertar, "@numero"));
                int contador = 0;
                foreach (ProductoVO _producto in _compra.Productos)
                {
                    contador = contador + 1;
                    InsertarDetalle(_producto, contador, numero_compra);
                }
                return numero_compra;
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
                return 0;
            }
        }

        private void InsertarDetalle(ProductoVO producto, Int32 _numeroDetalle, Int32 _numeroCompra)
        {
            DbCommand dbInsertar;
            try
            {
                dbInsertar = conexionDB.GetStoredProcCommand("PRC_PV_DETALLE_COMPRA");
                conexionDB.AddInParameter(dbInsertar, "@numero_compra", DbType.Int32, _numeroCompra);
                conexionDB.AddInParameter(dbInsertar, "@numero_detalle", DbType.Int32, _numeroDetalle);
                conexionDB.AddInParameter(dbInsertar, "@producto", DbType.String, producto.CodigoBarras);
                conexionDB.AddInParameter(dbInsertar, "@cantidad", DbType.Int32, producto.Cantidad);
                conexionDB.AddInParameter(dbInsertar, "@precio_venta", DbType.Decimal, producto.Precio_Venta);
                conexionDB.AddInParameter(dbInsertar, "@costo", DbType.Decimal, producto.Costo);
                conexionDB.AddInParameter(dbInsertar, "@referenciaAnterior", DbType.String, producto.ReferenciaAnterior);
                conexionDB.ExecuteNonQuery(dbInsertar);
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
        }

    }
}
