using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace Corujito.Negocio
{


    public partial class CRJForumTopicoNegocio
    {


        #region Métodos Privados
            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJForumTopico">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJForumTopico PopularEntidade(DataTable dtCRJForumTopico, int i)
            {
                //Criando um objeto do tipo CRJForumTopico.
                CRJForumTopico objCRJForumTopico = new CRJForumTopico();

                if(dtCRJForumTopico.Columns.Contains("IdForumTopico"))
                {
                    if (dtCRJForumTopico.Rows[i]["IdForumTopico"] != DBNull.Value)
                    {
                        objCRJForumTopico.IdForumTopico = Convert.ToInt32(dtCRJForumTopico.Rows[i]["IdForumTopico"].ToString());
                    }
                }

                if (dtCRJForumTopico.Columns.Contains("Titulo"))
                {
                    if (dtCRJForumTopico.Rows[i]["Titulo"] != DBNull.Value)
                    {
                        objCRJForumTopico.Titulo = dtCRJForumTopico.Rows[i]["Titulo"].ToString();
                    }
                }

                if (dtCRJForumTopico.Columns.Contains("Mensagem"))
                {
                    if (dtCRJForumTopico.Rows[i]["Mensagem"] != DBNull.Value)
                    {
                        objCRJForumTopico.Mensagem = dtCRJForumTopico.Rows[i]["Mensagem"].ToString();
                    }
                }

                if (dtCRJForumTopico.Columns.Contains("DataCriacao"))
                {
                    if (dtCRJForumTopico.Rows[i]["DataCriacao"] != DBNull.Value)
                    {
                        objCRJForumTopico.DataCriacao = Convert.ToDateTime(dtCRJForumTopico.Rows[i]["DataCriacao"].ToString());
                    }
                }

                if (dtCRJForumTopico.Columns.Contains("IdClasse"))
                {
                    if (dtCRJForumTopico.Rows[i]["IdClasse"] != DBNull.Value)
                    {
                        objCRJForumTopico.IdClasse = Convert.ToInt32(dtCRJForumTopico.Rows[i]["IdClasse"].ToString());
                    }
                }

                if (dtCRJForumTopico.Columns.Contains("IdCriador"))
                {
                    if (dtCRJForumTopico.Rows[i]["IdCriador"] != DBNull.Value)
                    {
                        objCRJForumTopico.IdCriador = Convert.ToInt32(dtCRJForumTopico.Rows[i]["IdCriador"].ToString());
                    }
                }


                return objCRJForumTopico;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJForumTopico no Banco de Dados.
            /// </summary>
            /// <param name="pCRJForumTopico">Objeto do Tipo CRJForumTopico que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJForumTopico pCRJForumTopico)
            {
                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumTopico;1"))
                {
                    //Parâmetros da Stored Procedure.
                    //db.AddInParameter(dbCommand,"IdForumTopico", DbType.Int32, pCRJForumTopico.IdForumTopico);
                    db.AddInParameter(dbCommand,"Titulo", DbType.String, pCRJForumTopico.Titulo);
                    db.AddInParameter(dbCommand,"Mensagem", DbType.String, pCRJForumTopico.Mensagem);
                    db.AddInParameter(dbCommand,"DataCriacao", DbType.DateTime, DateTime.Now);
                    db.AddInParameter(dbCommand,"IdClasse", DbType.Int32, pCRJForumTopico.IdClasse);
                    db.AddInParameter(dbCommand,"IdCriador", DbType.Int32, pCRJForumTopico.IdCriador);

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
            /// Método que Altera um CRJForumTopico no Banco de Dados.
            /// </summary>
            /// <param name="pCRJForumTopico">Objeto do Tipo CRJForumTopico que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJForumTopico pCRJForumTopico)
            {
                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumTopico;2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdForumTopico", DbType.Int32, pCRJForumTopico.IdForumTopico);
                    db.AddInParameter(dbCommand, "Titulo", DbType.String, pCRJForumTopico.Titulo);
                    db.AddInParameter(dbCommand, "Mensagem", DbType.String, pCRJForumTopico.Mensagem);
                    db.AddInParameter(dbCommand, "DataCriacao", DbType.DateTime, pCRJForumTopico.DataCriacao);
                    db.AddInParameter(dbCommand, "IdClasse", DbType.Int32, pCRJForumTopico.IdClasse);
                    db.AddInParameter(dbCommand, "IdCriador", DbType.Int32, pCRJForumTopico.IdCriador);

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
            /// Método que Exclui um CRJForumTopico no Banco de Dados.
            /// </summary>
            /// <param name="pCRJForumTopico">Objeto do Tipo CRJForumTopico que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int pIdForumTopico)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumTopico;3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdForumTopico", DbType.Int32, pIdForumTopico);

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
            /// Método que retorna todos os CRJForumTopico do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJForumTopico contendo os CRJForumTopico do Banco de Dados.</returns>
            public List<CRJForumTopico> ObterCRJForumTopico()
            {
                //Instânciando a Lista Tipada.
                List<CRJForumTopico> objCRJForumTopicoColecao = new List<CRJForumTopico>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumTopico;4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJForumTopico = ds.Tables[0];

                            for (int i = 0; i < dtCRJForumTopico.Rows.Count; i++)
                            {
                                CRJForumTopico objCRJForumTopico = PopularEntidade(dtCRJForumTopico, i);
                                objCRJForumTopicoColecao.Add(objCRJForumTopico);
                                objCRJForumTopico = null;
                            }
                        }
                    }
                }

                return objCRJForumTopicoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJForumTopico do Banco de Dados.
            /// </summary>
            /// <param name="pIdForumTopico">IdForumTopico da CRJForumTopico que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJForumTopico contendo os CRJForumTopico do Banco de Dados.</returns>
            public List<CRJForumTopico> ObterCRJForumTopico(int pIdForumTopico)
            {
                //Instânciando a Lista Tipada.
                List<CRJForumTopico> objCRJForumTopicoColecao = new List<CRJForumTopico>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumTopico;5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdForumTopico", DbType.Int32, pIdForumTopico);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJForumTopico = ds.Tables[0];

                            for (int i = 0; i < dtCRJForumTopico.Rows.Count; i++)
                            {
                                CRJForumTopico objCRJForumTopico = PopularEntidade(dtCRJForumTopico, i);
                                objCRJForumTopicoColecao.Add(objCRJForumTopico);
                                objCRJForumTopico = null;
                            }
                        }
                    }
                }

                return  objCRJForumTopicoColecao;
            }

            /// <summary>
            /// Método que retorna os CRJForumTopico do Banco de Dados.
            /// </summary>
            /// <param name="pIdForumTopico">IdForumTopico da CRJForumTopico que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJForumTopico contendo os CRJForumTopico do Banco de Dados.</returns>
            public List<CRJForumTopico> ObterCRJForumTopicoByClasse(int pIdClasse)
            {
                //Instânciando a Lista Tipada.
                List<CRJForumTopico> objCRJForumTopicoColecao = new List<CRJForumTopico>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJForumTopico;6"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdClasse", DbType.Int32, pIdClasse);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJForumTopico = ds.Tables[0];

                            for (int i = 0; i < dtCRJForumTopico.Rows.Count; i++)
                            {
                                CRJForumTopico objCRJForumTopico = PopularEntidade(dtCRJForumTopico, i);
                                objCRJForumTopicoColecao.Add(objCRJForumTopico);
                                objCRJForumTopico = null;
                            }
                        }
                    }
                }

                return objCRJForumTopicoColecao;
            }


        #endregion

    }


}
