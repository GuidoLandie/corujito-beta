using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio
{
    public class EstadoNegocio
    {
        #region Métodos Privados

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtEstado">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static Estado PopularEntidade(DataTable dtEstado, int i)
        {
            //Criando um objeto do tipo Estado.
            Estado objEstado = new Estado();

            if (dtEstado.Columns.Contains("id"))
            {
                if (dtEstado.Rows[i]["id"] != DBNull.Value)
                {
                    objEstado.id = Convert.ToInt32(dtEstado.Rows[i]["id"].ToString());
                }
            }

            if (dtEstado.Columns.Contains("nome"))
            {
                if (dtEstado.Rows[i]["nome"] != DBNull.Value)
                {
                    objEstado.nome = Convert.ToString(dtEstado.Rows[i]["nome"]);
                }
            }

            if (dtEstado.Columns.Contains("pais"))
            {
                if (dtEstado.Rows[i]["pais"] != DBNull.Value)
                {
                    objEstado.pais = Convert.ToInt16(dtEstado.Rows[i]["pais"]);
                }
            }

            if (dtEstado.Columns.Contains("uf"))
            {
                if (dtEstado.Rows[i]["uf"] != DBNull.Value)
                {
                    objEstado.uf = Convert.ToString(dtEstado.Rows[i]["uf"]);
                }
            }

            return objEstado;
        }

        #endregion

        #region Métodos Públicos


        /// <summary>
        /// Método que retorna todos os Estado do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade Estado contendo os Estado do Banco de Dados.</returns>
        public List<Estado> ObterEstado(int? IdPais = null)
        {
            //Instânciando a Lista Tipada.
            List<Estado> objEstadoColecao = new List<Estado>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPEstado"))
            {

                db.AddInParameter(dbCommand, "idPais", DbType.Int32, IdPais);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtEstado = ds.Tables[0];

                        for (int i = 0; i < dtEstado.Rows.Count; i++)
                        {
                            Estado objEstado = PopularEntidade(dtEstado, i);
                            objEstadoColecao.Add(objEstado);
                            objEstado = null;
                        }
                    }
                }
            }

            return objEstadoColecao;
        }

        #endregion
    }
}
