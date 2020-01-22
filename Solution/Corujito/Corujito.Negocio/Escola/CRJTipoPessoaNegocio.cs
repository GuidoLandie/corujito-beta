using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using Corujito.Entidade.Escola;


namespace Corujito.Negocio.Escola
{
    public class CRJTipoPessoaNegocio
    {
        #region Métodos Privados

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJTipoPessoa">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJTipoPessoa PopularEntidade(DataTable dtCRJTipoPessoa, int i)
        {
            //Criando um objeto do tipo CRJTipoPessoa.
            CRJTipoPessoa objCRJTipoPessoa = new CRJTipoPessoa();

            if (dtCRJTipoPessoa.Columns.Contains("IdTipoPessoa"))
            {
                if (dtCRJTipoPessoa.Rows[i]["IdTipoPessoa"] != DBNull.Value)
                {
                    objCRJTipoPessoa.IdTipoPessoa = Convert.ToInt32(dtCRJTipoPessoa.Rows[i]["IdTipoPessoa"].ToString());
                }
            }

            if (dtCRJTipoPessoa.Columns.Contains("Descricao"))
            {
                if (dtCRJTipoPessoa.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJTipoPessoa.Descricao = Convert.ToString(dtCRJTipoPessoa.Rows[i]["Descricao"]);
                }
            }

            return objCRJTipoPessoa;
        }

        #endregion

        #region Métodos Públicos


        /// <summary>
        /// Método que retorna todos os CRJTipoPessoa do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade CRJTipoPessoa contendo os CRJTipoPessoa do Banco de Dados.</returns>
        public List<CRJTipoPessoa> ObterCRJTipoPessoa()
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoPessoa> objCRJTipoPessoaColecao = new List<CRJTipoPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoPessoa;01"))
            {
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoPessoa.Rows.Count; i++)
                        {
                            CRJTipoPessoa objCRJTipoPessoa = PopularEntidade(dtCRJTipoPessoa, i);
                            objCRJTipoPessoaColecao.Add(objCRJTipoPessoa);
                            objCRJTipoPessoa = null;
                        }
                    }
                }
            }

            return objCRJTipoPessoaColecao;
        }


        /// <summary>
        /// Método que retorna os CRJTipoPessoa do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJTipoPessoa que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTipoPessoa contendo os CRJTipoPessoa do Banco de Dados.</returns>
        public CRJTipoPessoa ObterCRJTipoPessoaPorId(int pId)
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoPessoa> objCRJTipoPessoaColecao = new List<CRJTipoPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoPessoa;02"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdTipoPessoa", DbType.Int32, pId);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoPessoa.Rows.Count; i++)
                        {
                            CRJTipoPessoa objCRJTipoPessoa = PopularEntidade(dtCRJTipoPessoa, i);
                            objCRJTipoPessoaColecao.Add(objCRJTipoPessoa);
                            objCRJTipoPessoa = null;
                        }
                    }
                }
            }

            if (objCRJTipoPessoaColecao != null && objCRJTipoPessoaColecao.Count > 0)
                return objCRJTipoPessoaColecao[0];
            else
                return null;
        }

        /// <summary>
        /// Método que retorna os CRJTipoPessoa do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJTipoPessoa que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTipoPessoa contendo os CRJTipoPessoa do Banco de Dados.</returns>
        public List<CRJTipoPessoa> ObterCRJTipoPessoaPorIdPessoa(int pIdPessoa)
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoPessoa> objCRJTipoPessoaColecao = new List<CRJTipoPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoPessoa;03"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdPessoa", DbType.Int32, pIdPessoa);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoPessoa.Rows.Count; i++)
                        {
                            CRJTipoPessoa objCRJTipoPessoa = PopularEntidade(dtCRJTipoPessoa, i);
                            objCRJTipoPessoaColecao.Add(objCRJTipoPessoa);
                            objCRJTipoPessoa = null;
                        }
                    }
                }
            }


            return objCRJTipoPessoaColecao;

        }



        #endregion

    }


}
