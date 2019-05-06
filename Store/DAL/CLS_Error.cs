using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace DAL
{
    public class CLS_Error
    {
        public CLS_Error(String sMensaje)
        {
            String nombre = HttpContext.Current.Server.MapPath("Fotos") + "\\" +
            DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString()+".txt";
            //File.Create(nombre);
            // Create a file to write to. 
            using (StreamWriter sw = File.CreateText(nombre))
            {
                sw.WriteLine(sMensaje);
            }	
        }
    }
}
