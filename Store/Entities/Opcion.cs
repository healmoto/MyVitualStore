using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Opcion
    {
        public int Consecutivo
        {
            set;
            get;
        }

        public string nombre
        {
            set;
            get;
        }

        public string url
        {
            set;
            get;
        }

        public int padre
        {
            set;
            get;
        }

        public int modulo
        {
            set;
            get;
        }
    }
}
