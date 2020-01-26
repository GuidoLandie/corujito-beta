using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace Corujito.Negocio
{


    public partial class CRJForumMensagemNegocio
    {


        #region Métodos Privados
            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJForumMensagem">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJForumMensagem PopularEntidade(DataTable dtCRJForumMensagem, int i)
            {
                //Criando um objeto do tipo CRJForumMensagem.
                CRJForumMensagem objCRJForumMensagem = new CRJForumMensagem();

                if(dtCRJForumMensagem.Columns.Contains("IdForumMensagem"))
                {
                    if (dtCRJForumMensagem.Rows[i]["IdForumMensagem"] != DBNull.Value)
                    {
                        objCRJForumMensagem.IdForumTopico = Convert.ToInt32(dtCRJForumMensagem.Rows[i]["IdForumMensagem"].ToString());
                    }
                }

                if(dtCRJForumMensagem.Columns.Contains("Mensagem"))
                {
                    if (dtCRJForumMensagem.Rows[i]["Mensagem"] != DBNull.Value)
                    {
                        objCRJForumMensagem.Mensagem = dtCRJForumMensagem.Rows[i]["Mensagem"].ToString();
                    }
                }

                if(dtCRJForumMensagem.Columns.Contains("DataCriacao"))
                {
                    if (dtCRJForumMensagem.Rows[i]["DataCriacao"] != DBNull.Value)
                    {
                        objCRJForumMensagem.DataCriacao = Convert.ToDateTime(dtCRJForumMensagem.Rows[i]["DataCriacao"].ToString());
                    }
                }

                if(dtCRJForumMensagem.Columns.Contains("IdForumTopico"))
                {
                    if (dtCRJForumMensagem.Rows[i]["IdForumTopico"] != DBNull.Value)
                    {
                        objCRJForumMensagem.IdForumTopico = Convert.ToInt32(dtCRJForumMensagem.Rows[i]["IdForumTopico"].ToString());
                    }
                }

                if(dtCRJForumMensagem.Columns.Contains("IdCriador"))
                {
                    if (dtCRJForumMensagem.Rows[i]["IdCriador"] != DBNull.Value)
                    {
                        objCRJForumMensagem.IdCriador = Convert.ToInt32(dtCRJForumMensagem.Rows[i]["IdCriador"].ToString());
                    }
                }



                return objCRJForumMensagem;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJForumMensagem no Banco de Dados.
            /// </summary>
            /// <param name="pCRJForumMensagem">Objeto do Tipo CRJForumMensagem que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJForumMensagem pCRJForumMensagem)
            {
                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumMensagem1"))
                {

                    //Parâmetros da Stored Procedure.
                    //db.AddInParameter(dbCommand,"IdForumMensagem", DbType.Int32, pCRJForumMensagem.IdForumMensagem);
                    db.AddInParameter(dbCommand,"Mensagem", DbType.String, pCRJForumMensagem.Mensagem);
                    db.AddInParameter(dbCommand,"DataCriacao", DbType.DateTime, DateTime.Now);
                    db.AddInParameter(dbCommand,"IdForumTopico", DbType.Int32, pCRJForumMensagem.IdForumTopico);
                    db.AddInParameter(dbCommand,"IdCriador", DbType.Int32, pCRJForumMensagem.IdCriador);

                    //Executar Comando no Banco.
                    ret = db.ExecuteNonQuery(dbCommand);
                }

                if(ret != null && ret != DBNull.Value)
                {
                    Retorno = Convert.ToString(ret);
                }
                else
                {
                    Retorno = string.Empty;
                }

                return Retorno;

            }


            /// <summary>
            /// Método que Altera um CRJForumMensagem no Banco de Dados.
            /// </summary>
            /// <param name="pCRJForumMensagem">Objeto do Tipo CRJForumMensagem que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJForumMensagem pCRJForumMensagem)
            {
                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumMensagem2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdForumMensagem", DbType.Int32, pCRJForumMensagem.IdForumMensagem);
                    db.AddInParameter(dbCommand, "Mensagem", DbType.String, pCRJForumMensagem.Mensagem);
                    db.AddInParameter(dbCommand, "DataCriacao", DbType.DateTime, pCRJForumMensagem.DataCriacao);
                    db.AddInParameter(dbCommand, "IdForumTopico", DbType.Int32, pCRJForumMensagem.IdForumTopico);
                    db.AddInParameter(dbCommand, "IdCriador", DbType.Int32, pCRJForumMensagem.IdCriador);

                    //Executar Comando no Banco.
                    ret = db.ExecuteNonQuery(dbCommand);
                }

                if(ret != null && ret != DBNull.Value)
                {
                    Retorno = Convert.ToString(ret);
                }
                else
                {
                    Retorno = string.Empty;
                }

                return Retorno;

            }


            /// <summary>
            /// Método que Exclui um CRJForumMensagem no Banco de Dados.
            /// </summary>
            /// <param name="pCRJForumMensagem">Objeto do Tipo CRJForumMensagem que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int pIdForumMensagem)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumMensagem3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdForumMensagem", DbType.Int32, pIdForumMensagem);

                    //Executar Comando no Banco.
                    ret = db.ExecuteNonQuery(dbCommand);
                }

                if(ret != null && ret != DBNull.Value)
                {
                    Retorno = Convert.ToString(ret);
                }
                else
                {
                    Retorno = string.Empty;
                }

                return Retorno;

            }


            /// <summary>
            /// Método que retorna todos os CRJForumMensagem do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJForumMensagem contendo os CRJForumMensagem do Banco de Dados.</returns>
            public List<CRJForumMensagem> ObterCRJForumMensagem()
            {
                //Instânciando a Lista Tipada.
                List<CRJForumMensagem> objCRJForumMensagemColecao = new List<CRJForumMensagem>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumMensagem4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJForumMensagem = ds.Tables[0];

                            for (int i = 0; i < dtCRJForumMensagem.Rows.Count; i++)
                            {
                                CRJForumMensagem objCRJForumMensagem = PopularEntidade(dtCRJForumMensagem, i);
                                objCRJForumMensagemColecao.Add(objCRJForumMensagem);
                                objCRJForumMensagem = null;
                            }
                        }
                    }
                }

                return objCRJForumMensagemColecao;
            }


            /// <summary>
            /// Método que retorna os CRJForumMensagem do Banco de Dados.
            /// </summary>
            /// <param name="pIdForumTopico">IdForumTopico da CRJForumMensagem que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJForumMensagem contendo os CRJForumMensagem do Banco de Dados.</returns>
            public List<CRJForumMensagem> ObterCRJForumMensagem(int pIdForumMensagem)
            {
                //Instânciando a Lista Tipada.
                List<CRJForumMensagem> objCRJForumMensagemColecao = new List<CRJForumMensagem>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumMensagem5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdForumMensagem", DbType.Int32, pIdForumMensagem);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJForumMensagem = ds.Tables[0];

                            for (int i = 0; i < dtCRJForumMensagem.Rows.Count; i++)
                            {
                                CRJForumMensagem objCRJForumMensagem = PopularEntidade(dtCRJForumMensagem, i);
                                objCRJForumMensagemColecao.Add(objCRJForumMensagem);
                                objCRJForumMensagem = null;
                            }
                        }
                    }
                }

                return  objCRJForumMensagemColecao;
            }

            /// <summary>
            /// Método que retorna os CRJForumMensagem do Banco de Dados.
            /// </summary>
            /// <param name="pIdForumTopico">IdForumTopico da CRJForumMensagem que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJForumMensagem contendo os CRJForumMensagem do Banco de Dados.</returns>
            public DataTable ObterCRJForumMensagemByTopico(int pIdForumTopico)
            {
                //Instânciando a Lista Tipada.
                List<CRJForumMensagem> objCRJForumMensagemColecao = new List<CRJForumMensagem>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumMensagem6"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdForumTopico", DbType.Int32, pIdForumTopico);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            return  ds.Tables[0];

                            //for (int i = 0; i < dtCRJForumMensagem.Rows.Count; i++)
                            //{
                            //    CRJForumMensagem objCRJForumMensagem = PopularEntidade(dtCRJForumMensagem, i);
                            //    objCRJForumMensagemColecao.Add(objCRJForumMensagem);
                            //    objCRJForumMensagem = null;
                            //}
                        }
                    }
                }

                return new DataTable();
            }


        #endregion

    }


}
