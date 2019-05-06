using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Compra
    {
        public string Proveedor { set; get; }
        public DateTime Fecha { set; get; }
        public string factura { set; get; }
        public List<ProductoVO> Productos { set; get; }
    }
}
