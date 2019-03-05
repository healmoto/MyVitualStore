using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Entities;

namespace PuntoVenta
{
    public enum eTipoObjeto
    {
        Productos,
        Proveedores
    }

    public class PuntoVenta_Business
    {
        public void Serializar(string filename, Object  objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public Object Deserializar(string filename)
        {
            Object objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
