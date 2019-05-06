using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class InventarioVO
    {
        public DateTime  Fecha_Inventario
        {
            set;
            get;
        }
        public String Referencia
        {
            set;
            get;
        }

        public String Producto
        {
            set;
            get;
        }

        public int Inventario
        {
            set;
            get;
        }

        public int Entradas
        {
            set;
            get;
        }

        public int Salidas
        {
            set;
            get;
        }

        public int Saldo
        {
            set;
            get;
        }
    }
}
