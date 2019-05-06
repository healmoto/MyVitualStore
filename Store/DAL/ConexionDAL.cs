using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class ConexionDAL: IConexion 
    {
        private Database DBConexion = DatabaseFactory.CreateDatabase();

        System.Data.Common.DbCommand IConexion.GetStoredProcCommand(string storedProcedureName)
        {
            return DBConexion.GetStoredProcCommand(storedProcedureName);
        }

        void IConexion.AddInParameter(System.Data.Common.DbCommand command, string name, System.Data.DbType dbType, object value)
        {
            DBConexion.AddInParameter(command, name, dbType, value);
        }

        System.Data.IDataReader IConexion.ExecuteReader(System.Data.Common.DbCommand command)
        {
            return DBConexion.ExecuteReader(command);
        }

        void IConexion.AddOutParameter(System.Data.Common.DbCommand command, string name, System.Data.DbType dbType, int size)
        {
            DBConexion.AddOutParameter(command, name, dbType, size);
        }

        object IConexion.GetParameterValue(System.Data.Common.DbCommand command, string name)
        {
            return DBConexion.GetParameterValue(command, name);
        }

        void IConexion.ExecuteNonQuery(System.Data.Common.DbCommand command)
        {
            DBConexion.ExecuteNonQuery(command);
        }
    }
}
