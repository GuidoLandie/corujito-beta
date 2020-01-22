using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade.Escola;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


namespace Corujito.Negocio.Escola
{
    public class CRJTipoAtividadeBO
    {
        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJTipoAtividade">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJTipoAtividade PopularEntidade(DataTable dtCRJTipoAtividade, int i)
        {
            //Criando um objeto do tipo CRJTipoAtividade.
            CRJTipoAtividade objCRJTipoAtividade = new CRJTipoAtividade();

            if (dtCRJTipoAtividade.Columns.Contains("IdTipoAtividade"))
            {
                if (dtCRJTipoAtividade.Rows[i]["IdTipoAtividade"] != DBNull.Value)
                {
                    objCRJTipoAtividade.IdTipoAtividade = Convert.ToInt32(dtCRJTipoAtividade.Rows[i]["IdTipoAtividade"].ToString());
                }
            }

            if (dtCRJTipoAtividade.Columns.Contains("Descricao"))
            {
                if (dtCRJTipoAtividade.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJTipoAtividade.Descricao = Convert.ToString(dtCRJTipoAtividade.Rows[i]["Descricao"]);

                }
            }

            return objCRJTipoAtividade;
        }


        /// <summary>
        /// Método que retorna os CRJTipoAtividade do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJTipoAtividade que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTipoAtividade contendo os CRJTipoAtividade do Banco de Dados.</returns>
        public List<CRJTipoAtividade> ObterCRJTipoAtividade()
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoAtividade> objCRJTipoAtividadeColecao = new List<CRJTipoAtividade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoAtividade;1"))
            {

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoAtividade = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoAtividade.Rows.Count; i++)
                        {
                            CRJTipoAtividade objCRJTipoAtividade = PopularEntidade(dtCRJTipoAtividade, i);
                            objCRJTipoAtividadeColecao.Add(objCRJTipoAtividade);
                            objCRJTipoAtividade = null;
                        }
                    }
                }
            }

            return objCRJTipoAtividadeColecao;
        }

        /// <summary>
        /// Método que retorna os CRJTipoAtividade do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJTipoAtividade que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTipoAtividade contendo os CRJTipoAtividade do Banco de Dados.</returns>
        public CRJTipoAtividade ObterCRJTipoAtividade(string p_Tipodesc = null, int? IdTipoAtividade = null)
        {
            //Instânciando a Lista Tipada.
            List<CRJTipoAtividade> objCRJTipoAtividadeColecao = new List<CRJTipoAtividade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoAtividade;3"))
            {
                db.AddInParameter(dbCommand, "Descricao", DbType.String, p_Tipodesc);
                db.AddInParameter(dbCommand, "IdTipoAtividade", DbType.Int32, IdTipoAtividade);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTipoAtividade = ds.Tables[0];

                        for (int i = 0; i < dtCRJTipoAtividade.Rows.Count; i++)
                        {
                            CRJTipoAtividade objCRJTipoAtividade = PopularEntidade(dtCRJTipoAtividade, i);
                            objCRJTipoAtividadeColecao.Add(objCRJTipoAtividade);
                            objCRJTipoAtividade = null;
                        }
                    }
                }
            }

            if (objCRJTipoAtividadeColecao.Count > 0)
                return objCRJTipoAtividadeColecao[0];
            else
                return null;
        }

        /// <summary>
        /// Método que Insere um CRJProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProduto">Objeto do Tipo CRJProduto que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>


        ///// <summary>
        ///// Método que retorna os CRJTipoAtividade do Banco de Dados.
        ///// </summary>
        ///// <param name="pIdPessoa">IdPessoa da CRJTipoAtividade que consultado no Banco de Dados.</param>
        ///// <returns>Lista Tipada da Entidade CRJTipoAtividade contendo os CRJTipoAtividade do Banco de Dados.</returns>
        //public CRJTipoAtividade ObterCRJTipoAtividadePorID(int IdTipo)
        //{
        //    //Instânciando a Lista Tipada.
        //    List<CRJTipoAtividade> objCRJTipoAtividadeColecao = new List<CRJTipoAtividade>();

        //    Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
        //    using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTipoAtividade;2"))
        //    {

        //        db.AddInParameter(dbCommand, "@IdTipoAtividade", DbType.Int32, IdTipo);

        //        using (DataSet ds = db.ExecuteDataSet(dbCommand))
        //        {
        //            if (ds != null && ds.Tables.Count > 0)
        //            {
        //                DataTable dtCRJTipoAtividade = ds.Tables[0];

        //                for (int i = 0; i < dtCRJTipoAtividade.Rows.Count; i++)
        //                {
        //                    CRJTipoAtividade objCRJTipoAtividade = PopularEntidade(dtCRJTipoAtividade, i);
        //                    objCRJTipoAtividadeColecao.Add(objCRJTipoAtividade);
        //                    objCRJTipoAtividade = null;
        //                }
        //            }
        //        }
        //    }

        //    if (objCRJTipoAtividadeColecao.Count > 0)
        //        return objCRJTipoAtividadeColecao[0];
        //    else
        //        return null;
        //}

    }

}
