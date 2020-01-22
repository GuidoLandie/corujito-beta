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
    public class AplicacaoBO
    {

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtAplicacao">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private Aplicacao PopularEntidade(DataTable dtAplicacao, int i)
        {
            //Criando um objeto do tipo Aplicacao.
            Aplicacao objAplicacao = new Aplicacao();

            if (dtAplicacao.Columns.Contains("IdAplicacao"))
            {
                if (dtAplicacao.Rows[i]["IdAplicacao"] != DBNull.Value)
                {
                    objAplicacao.IdAplicacao = Convert.ToInt32(dtAplicacao.Rows[i]["IdAplicacao"].ToString());
                }
            }

            if (dtAplicacao.Columns.Contains("Nome"))
            {
                if (dtAplicacao.Rows[i]["Nome"] != DBNull.Value)
                {
                    objAplicacao.Nome = Convert.ToString(dtAplicacao.Rows[i]["Nome"].ToString());
                }
            }

            if (dtAplicacao.Columns.Contains("Descricao"))
            {
                if (dtAplicacao.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objAplicacao.Descricao = Convert.ToString(dtAplicacao.Rows[i]["Descricao"].ToString());
                }
            }


            if (dtAplicacao.Columns.Contains("AplicacaoPai"))
            {
                if (dtAplicacao.Rows[i]["AplicacaoPai"] != DBNull.Value)
                {
                    int CodigoAplicacaoPai = Convert.ToInt32(dtAplicacao.Rows[i]["AplicacaoPai"]);

                    List<Aplicacao> objAplicacaoColecao = new List<Aplicacao>();

                    objAplicacaoColecao = ObterAplicacao(CodigoAplicacaoPai);

                    if (objAplicacaoColecao != null && objAplicacaoColecao.Count > 0)
                    {
                        objAplicacao.AplicacaoPai = objAplicacaoColecao[0];
                    }

                    objAplicacaoColecao = null;


                }
            }

            if (dtAplicacao.Columns.Contains("Caminho"))
            {
                if (dtAplicacao.Rows[i]["Caminho"] != DBNull.Value)
                {
                    objAplicacao.Caminho = Convert.ToString(dtAplicacao.Rows[i]["Caminho"]);
                }
            }

            if (dtAplicacao.Columns.Contains("FlagSelecao"))
            {
                if (dtAplicacao.Rows[i]["FlagSelecao"] != DBNull.Value)
                {
                    objAplicacao.FlagSelecao = Convert.ToBoolean(dtAplicacao.Rows[i]["FlagSelecao"]);
                }
            }

            return objAplicacao;
        }

        /// <summary>
        /// Método que retorna os Aplicacao do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade Aplicacao contendo os Aplicacao do Banco de Dados.</returns>


        /// <summary>
        /// Método que retorna os Aplicacao do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade Aplicacao contendo os Aplicacao do Banco de Dados.</returns>
        public List<Aplicacao> ObterAplicacoesDoUsuario(string Login, int? IdAplicacaoPai = null)
        {
            //Instânciando a Lista Tipada.
            List<Aplicacao> objAplicacaoColecao = new List<Aplicacao>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAplicacoes;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pLogin", DbType.String, Login);
                db.AddInParameter(dbCommand, "pAplicacaoPai", DbType.Int32, IdAplicacaoPai);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtAplicacao = ds.Tables[0];

                        for (int i = 0; i < dtAplicacao.Rows.Count; i++)
                        {
                            Aplicacao objAplicacao = PopularEntidade(dtAplicacao, i);
                            objAplicacaoColecao.Add(objAplicacao);
                            objAplicacao = null;
                        }
                    }
                }
            }

            return objAplicacaoColecao;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="IdAplicacao"></param>
        ///// <param name="IdAplicacaoPai"></param>
        ///// <returns></returns>
        //public List<Aplicacao> ObterAplicacao(int? IdAplicacao = null, int? IdAplicacaoPai = null)
        //{
        //    AplicacaoDAO objAplicacaoDAO = new AplicacaoDAO();
        //    List<Aplicacao> objAplicacao = new List<Aplicacao>();

        //    objAplicacao = this.ObterAplicacao(IdAplicacao, IdAplicacaoPai);

        //    return objAplicacao;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdAplicacao"></param>
        /// <param name="IdAplicacaoPai"></param>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public List<Aplicacao> ObterAplicacao(int? IdAplicacao = null, int? IdAplicacaoPai = null, string pUsuario = null)
        {
            //Instânciando a Lista Tipada.
            List<Aplicacao> objAplicacaoColecao = new List<Aplicacao>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAplicacoes;1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdAplicacao", DbType.Int32, IdAplicacao);
                db.AddInParameter(dbCommand, "pAplicacaoPai", DbType.Int32, IdAplicacaoPai);
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, pUsuario);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtAplicacao = ds.Tables[0];

                        for (int i = 0; i < dtAplicacao.Rows.Count; i++)
                        {
                            Aplicacao objAplicacao = PopularEntidade(dtAplicacao, i);
                            objAplicacaoColecao.Add(objAplicacao);
                            objAplicacao = null;
                        }
                    }
                }
            }

            return objAplicacaoColecao;
        }


        private void CriarHTMLMenuFromPai(ref string strMenu, int AplicationPai, string Usuario)
        {            
            List<Aplicacao> objColecao = new List<Aplicacao>();

            objColecao = this.ObterAplicacoesDoUsuario(Usuario, AplicationPai);

            if (objColecao != null && objColecao.Count > 0)
            {
                strMenu += "<ul>";
                foreach (Aplicacao Item in objColecao)
                {
                    strMenu += "<li>" + Item.Caminho;
                    CriarHTMLMenuFromPai(ref strMenu, Item.IdAplicacao, Usuario);
                    strMenu += "</li>";
                }
                strMenu += "</ul>";
            }
        }

        public string CriarMenuDoUsuario(string pLogin)
        {
            string strMenu = string.Empty;

            List<Aplicacao> objAplicacaoColecao = new List<Aplicacao>();            

            objAplicacaoColecao = this.ObterAplicacoesDoUsuario(pLogin, null);

            MenuBO Menu = new MenuBO();

            foreach (Aplicacao Item in objAplicacaoColecao)
            {
                Menu.AddAplication(Item);
            }


            return Menu.ToString();
        }

        public string CaminhoAplicacao(int IdAplicacao)
        {
            List<Aplicacao> objAplicacaoColecao = new List<Aplicacao>();
            AplicacaoBO objAplicacaoBo = new AplicacaoBO();

            objAplicacaoColecao = ObterAplicacao(IdAplicacao);

            if (objAplicacaoColecao != null && objAplicacaoColecao.Count > 0)
            {
                return objAplicacaoColecao[0].Caminho;
            }

            return string.Empty;
        }



    }

}
