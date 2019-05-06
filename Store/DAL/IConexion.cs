using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace DAL
{
    public interface IConexion
    {
        DbCommand GetStoredProcCommand(string storedProcedureName);

        void AddInParameter(DbCommand command, string name, DbType dbType, Object value);

        IDataReader ExecuteReader(DbCommand command);

        void AddOutParameter(DbCommand command, string name, DbType dbType, int size);

        Object GetParameterValue(DbCommand command, string name);

        void ExecuteNonQuery(DbCommand command);
    }
}
