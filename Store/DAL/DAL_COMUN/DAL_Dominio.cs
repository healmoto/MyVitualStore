using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.Common;
using System.Data;

namespace DAL.DAL_COMUN
{
    public class DAL_Dominio
    {
        private IConexion conexionDB;

        public DAL_Dominio()
        {
            conexionDB = new ConexionDAL();
        }

        public List<ValorDominioVO> ConsultarDominio(string  codDominio)
        {
            DbCommand dbConsulta;
            List<ValorDominioVO> _dominios = new List<ValorDominioVO>();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PR_DOM_CONSULTAR_DOMINIO");
                conexionDB.AddInParameter(dbConsulta, "@codDominio", DbType.String, codDominio);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _dominios.Add(RetornaDominio(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _dominios;
        }


        public ValorDominioVO ConsultarDominio(string codDominio, string codPadre)
        {
            DbCommand dbConsulta;
            ValorDominioVO _dominio = new ValorDominioVO();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_OBTENER_DOMINIO");
                conexionDB.AddInParameter(dbConsulta, "@strPadre", DbType.String, codPadre);
                conexionDB.AddInParameter(dbConsulta, "@strDominio", DbType.String, codDominio);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _dominio = RetornaDominio(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _dominio;
        }

        private ValorDominioVO RetornaDominio(IDataReader dr)
        {
            ValorDominioVO _dominio = new ValorDominioVO();
            _dominio.Codigo = dr["DOMINIO"].ToString();
            _dominio.Descripcion = dr["descripcion"].ToString();
            return _dominio;
        }

        public ParametroVO ConsultarParametro(string strNemonico)
        {
            DbCommand dbConsulta;
            ParametroVO _parametro = new ParametroVO();
            try
            {
                dbConsulta = conexionDB.GetStoredProcCommand("PRC_OBTENER_PARAMETRO");
                conexionDB.AddInParameter(dbConsulta, "@strNemonico", DbType.String, strNemonico);
                using (IDataReader dr = conexionDB.ExecuteReader(dbConsulta))
                {
                    while (dr.Read())
                    {
                        _parametro = RetornaParametro(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                CLS_Error error = new CLS_Error(ex.Message + "-" + ex.StackTrace);
            }
            return _parametro;
        }

        private ParametroVO RetornaParametro(IDataReader dr)
        {
            ParametroVO _parametro = new ParametroVO();
            _parametro.Nemonico = dr["nemonico"].ToString();
            _parametro.Descripcion = dr["descripcion"].ToString();
            _parametro.Alfanumerico = dr["alfanumerico"].ToString();
            _parametro.Entero = Convert.ToInt32(dr["entero"]);
            _parametro.Moneda = Convert.ToDecimal(dr["moneda"]);
            return _parametro;
        }
    }
}
