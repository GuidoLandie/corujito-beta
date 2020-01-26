using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio
{
    public class CidadeNegocio
    {
        #region Métodos Privados

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCidade">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static Cidade PopularEntidade(DataTable dtCidade, int i)
        {
            //Criando um objeto do tipo Cidade.
            Cidade objCidade = new Cidade();

            if (dtCidade.Columns.Contains("id"))
            {
                if (dtCidade.Rows[i]["id"] != DBNull.Value)
                {
                    objCidade.id = Convert.ToInt32(dtCidade.Rows[i]["id"].ToString());
                }
            }

            if (dtCidade.Columns.Contains("nome"))
            {
                if (dtCidade.Rows[i]["nome"] != DBNull.Value)
                {
                    objCidade.nome = Convert.ToString(dtCidade.Rows[i]["nome"]);
                }
            }

            if (dtCidade.Columns.Contains("estado"))
            {
                if (dtCidade.Rows[i]["estado"] != DBNull.Value)
                {
                    objCidade.estado = Convert.ToInt16(dtCidade.Rows[i]["estado"]);
                }
            }

            return objCidade;
        }

        #endregion

        #region Métodos Públicos


        /// <summary>
        /// Método que retorna os Cidade do Banco de Dados.
        /// </summary>
        /// <param name="p"> da Cidade que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade Cidade contendo os Cidade do Banco de Dados.</returns>
        public List<Cidade> ObterCidade(int? pIdEstado = null)
        {
            //Instânciando a Lista Tipada.
            List<Cidade> objCidadeColecao = new List<Cidade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCidade01"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "idEstado", DbType.Int32, pIdEstado);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCidade = ds.Tables[0];

                        for (int i = 0; i < dtCidade.Rows.Count; i++)
                        {
                            Cidade objCidade = PopularEntidade(dtCidade, i);
                            objCidadeColecao.Add(objCidade);
                            objCidade = null;
                        }
                    }
                }
            }


            return objCidadeColecao;

        }

        #endregion
    }
}
