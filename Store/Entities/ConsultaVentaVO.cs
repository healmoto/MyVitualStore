using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ConsultaVentaVO
    {
        public Int64 Numero_Venta { set; get; }
        public Int64 Numero_Detalle { set; get; }
        public String Cliente { set; get; }
        public DateTime Fecha { set; get; }
        public String Ciudad { set; get; }
        public String Barrio { set; get; }
        public String Comentarios { set; get; }
        public String Email { set; get; }
        public String Telefono { set; get; }
        public String Envio { set; get; }
        public String Pago { set; get; }
        public String Producto { set; get; }
        public Int32 Cantidad { set; get; }
        public decimal Precio { set; get; }
        public decimal Total { set; get; }
        public string Archivo { set; get; }
    }
}
