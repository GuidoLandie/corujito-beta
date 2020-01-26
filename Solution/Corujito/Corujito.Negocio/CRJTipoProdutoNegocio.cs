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
    public class CRJTipoProdutoNegocio
    {

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJTipoProduto">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJTipoProduto PopularEntidade(DataTable dtCRJTipoProduto, int i)
        {
            //Criando um objeto do tipo CRJTipoProduto.
            CRJTipoProduto objCRJTipoProduto = new CRJTipoProduto();

            if (dtCRJTipoProduto.Columns.Contains("IdTipoProduto"))
            {
                if (dtCRJTipoProduto.Rows[i]["IdTipoProduto"] != DBNull.Value)
                {
                    objCRJTipoProduto.IdTipoProduto = Convert.ToInt32(dtCRJTipoProduto.Rows[i]["IdTipoProduto"].ToString());
                }
            }

            if (dtCRJTipoProduto.Columns.Contains("Nome"))
            {
                if (dtCRJTipoProduto.Rows[i]["Nome"] != DBNull.Value)
                {
                    objCRJTipoProduto.Nome = Convert.ToString(dtCRJTipoProduto.Rows[i]["Nome"]);

                }
            }

            return objCRJTipoProduto;
        }

        
        /// <summary>
        /// Método que retorna os CRJTipoProduto do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJTipoProduto que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTipoProduto contendo os CRJTipoProduto do Banco de Dados.</returns>
        public List<CRJTipoProduto> ObterCRJTipoProduto()
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoProduto> objCRJTipoProdutoColecao = new List<CRJTipoProduto>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoProduto1"))
            {

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoProduto = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoProduto.Rows.Count; i++)
                        {
                            CRJTipoProduto objCRJTipoProduto = PopularEntidade(dtCRJTipoProduto, i);
                            objCRJTipoProdutoColecao.Add(objCRJTipoProduto);
                            objCRJTipoProduto = null;
                        }
                    }
                }
            }

            return objCRJTipoProdutoColecao;
        }

        /// <summary>
        /// Método que retorna os CRJTipoProduto do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJTipoProduto que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTipoProduto contendo os CRJTipoProduto do Banco de Dados.</returns>
        public CRJTipoProduto ObterCRJTipoProdutoPorID(int IdTipo)
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoProduto> objCRJTipoProdutoColecao = new List<CRJTipoProduto>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoProduto2"))
            {

                db.AddInParameter(dbCommand, "@IdTipoProduto", DbType.Int32, IdTipo);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoProduto = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoProduto.Rows.Count; i++)
                        {
                            CRJTipoProduto objCRJTipoProduto = PopularEntidade(dtCRJTipoProduto, i);
                            objCRJTipoProdutoColecao.Add(objCRJTipoProduto);
                            objCRJTipoProduto = null;
                        }
                    }
                }
            }

            if (objCRJTipoProdutoColecao.Count > 0)
                return objCRJTipoProdutoColecao[0];
            else
                return null;
        }
    
    }
}
