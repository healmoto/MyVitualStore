using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class VentaVO
    {
        public int Numero_venta
        {
            set;
            get;
        }

        public String NombreCliente
        {
            set;
            get;
        }

        public String Email
        {
            set;
            get;
        }

        public String Telefono
        {
            set;
            get;
        }

        public String Direccion
        {
            set;
            get;
        }

        public String Ciudad
        {
            set;
            get;
        }

        public String Barrio
        {
            set;
            get;
        }

        public String Comentarios
        {
            set;
            get;
        }

        public Int16  Envio
        {
            set;
            get;
        }

        public Int16  Pago
        {
            set;
            get;
        }

        public DateTime Fecha
        {
            set;
            get;
        }

        public String DescripcionEnvio
        {
            set;
            get;
        }

        public String DescripcionPago
        {
            set;
            get;
        }

        public Int16  Tarjeta
        {
            set;
            get;
        }

        public List<ProductoVO> Productos
        {
            set;
            get;
        }

        public Int16 PuntoVenta
        {
            set;
            get;
        }

        public decimal TotalVenta
        {
            set;
            get;
        }

        public string Archivo
        {
            set;
            get;
        }
    }
}
