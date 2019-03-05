using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ProductoVO
    {
        public Int32 Consecutivo
        {
            set;
            get;
        }

        public String Referencia
        {
            set;
            get;
        }

        public String ReferenciaAnterior
        {
            set;
            get;
        }

        public String Nombre
        {
            set;
            get;
        }

        public String Descripcion
        {
            set;
            get;
        }

        public String estado
        {
            set;
            get;
        }

        public String Tipo
        {
            set;
            get;
        }

        public String Imagen
        {
            set;
            get;
        }

        public String ImagenDerecha
        {
            set;
            get;
        }

        public decimal Precio_Venta
        {
            set;
            get;
        }

        public decimal Costo
        {
            set;
            get;
        }

        public String CodigoBarras
        {
            set;
            get;
        }

        public Int32 Cantidad
        {
            set;
            get;
        }

        public decimal TotalUnitario
        {
            set;
            get;
        }

        public short Promocion
        {
            set;
            get;
        }

    }
}
