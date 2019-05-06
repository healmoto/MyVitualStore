using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.Common;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAL.DAL_Ventas
{
    public class DAL_Venta
    {
        private IConexion conexionDB;

        public DAL_Venta()
        {
            conexionDB = new ConexionDAL();
        }

        private void InsertarDetalle(ProductoVO producto, Int32 _numeroDetalle, Int32 _numeroVenta)
        {
            DbCommand dbInsertar;
            try
            {
                dbInsertar = conexionDB.GetStoredProcCommand("PRC_DETALLE");
                conexionDB.AddInParameter(dbInsertar, "@numero_venta", DbType.Int32, _numeroVenta);
                conexionDB.AddInParameter(dbInsertar, "@numero_detalle", DbType.Int32, _numeroDetalle);
                if (producto.Referencia == null)
                {
                    conexionDB.AddInParameter(dbInsertar, "@producto", DbType.String, producto.CodigoBarras);
                }
                if (producto.CodigoBarras == null)
                {
                    conexionDB.AddInParameter(dbInsertar, "@producto", DbType.String, producto.Referencia);
                }
                if (producto.Precio_Venta > 0)
                {
                    conexionDB.AddInParameter(dbInsertar, "@precio_venta", DbType.Decimal, producto.Precio_Venta);
                }
                if (producto.Cantidad > 0)
                {
                    conexionDB.AddInParameter(dbInsertar, "@cantidad", DbType.Int32, producto.Cantidad);
                }
                conexionDB.ExecuteNonQuery(dbInsertar);
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
        }

        public void InsertarContacto(Contacto contacto)
        {
            DbCommand dbInsertar;
            try
            {
                dbInsertar = conexionDB.GetStoredProcCommand("PRC_INSERTAR_CONTACTO");
                conexionDB.AddInParameter(dbInsertar, "@producto", DbType.String, contacto.Producto);
                conexionDB.AddInParameter(dbInsertar, "@nombre", DbType.String, contacto.Nombre);
                conexionDB.AddInParameter(dbInsertar, "@email", DbType.String, contacto.Email);
                conexionDB.AddInParameter(dbInsertar, "@comentarios", DbType.String, contacto.Comentarios);
                conexionDB.ExecuteNonQuery(dbInsertar);
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
        }

        public int InsertarVenta(VentaVO venta)
        {
            DbCommand dbInsertar;
            try
            {
                dbInsertar = conexionDB.GetStoredProcCommand("PRC_VENTA");
                conexionDB.AddInParameter(dbInsertar, "@cliente", DbType.String, venta.NombreCliente);
                conexionDB.AddInParameter(dbInsertar, "@barrio", DbType.String, venta.Barrio);
                conexionDB.AddInParameter(dbInsertar, "@ciudad", DbType.String, venta.Ciudad);
                conexionDB.AddInParameter(dbInsertar, "@comentarios", DbType.String, venta.Comentarios);
                conexionDB.AddInParameter(dbInsertar, "@direccion", DbType.String, venta.Direccion);
                conexionDB.AddInParameter(dbInsertar, "@email", DbType.String, venta.Email);
                conexionDB.AddInParameter(dbInsertar, "@telefono", DbType.String, venta.Telefono);
                conexionDB.AddInParameter(dbInsertar, "@envio", DbType.Int32, venta.Envio);
                conexionDB.AddInParameter(dbInsertar, "@pago", DbType.Int32, venta.Pago);
                conexionDB.AddInParameter(dbInsertar, "@tarjeta", DbType.Int16, venta.Tarjeta);
                conexionDB.AddInParameter(dbInsertar, "@punto_venta", DbType.Int16, venta.PuntoVenta);
                conexionDB.AddInParameter(dbInsertar, "@archivo", DbType.String, venta.Archivo);
                conexionDB.AddOutParameter(dbInsertar, "@numero", DbType.Int32, 10);
                conexionDB.ExecuteNonQuery(dbInsertar);
                Int32 numero_factura = 0;
                numero_factura = Convert.ToInt32(conexionDB.GetParameterValue(dbInsertar, "@numero"));
                int contador = 0;
                foreach (ProductoVO _producto in venta.Productos)
                {
                    contador = contador + 1;
                    InsertarDetalle(_producto, contador, numero_factura);
                }
                return numero_factura;
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
                return 0;
            }
        }

        public string InsertarCierre(decimal _base, decimal _efectivo, DateTime _fecha)
        {
            DbCommand dbInsertar;
            string _salida=String.Empty;
            try
            {
                dbInsertar = conexionDB.GetStoredProcCommand("PRC_PV_REALIZARCIERRE");
                conexionDB.AddInParameter(dbInsertar, "@fecha", DbType.Date, _fecha);
                conexionDB.AddInParameter(dbInsertar, "@base", DbType.Decimal , _base);
                conexionDB.AddInParameter(dbInsertar, "@efectivo", DbType.Decimal, _efectivo);
                conexionDB.AddOutParameter(dbInsertar, "@salida", DbType.String, 200);
                conexionDB.ExecuteNonQuery(dbInsertar);
                _salida = dbInsertar.Parameters["@salida"].Value.ToString();
                if (_salida.Length > 0)
                {
                    throw new Exception(_salida);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _salida;
        }

    }

}
