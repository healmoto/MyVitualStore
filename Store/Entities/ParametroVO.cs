using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ParametroVO
    {
        public String  Nemonico
        {
            set;
            get;
        }

        public String Descripcion
        {
            set;
            get;
        }

        public String Alfanumerico
        {
            set;
            get;
        }

        public int Entero
        {
            set;
            get;
        }

        public decimal Moneda
        {
            set;
            get;
        }
    }
}
