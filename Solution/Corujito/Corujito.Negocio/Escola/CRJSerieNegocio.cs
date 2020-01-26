using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using Corujito.Entidade.Escola;

namespace Corujito.Negocio
{


    public class CRJSerieNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJSerie">Objeto do Tipo CRJSerie que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJSerie pCRJSerie)
            {
                
                ////Validar Obrigatoriedade do campo idSerie.
                //if (pCRJSerie.idSerie == null)
                //{
                //    return "Campo idSerie não pode ser vazio.";
                //}
                               

                ////Validar se o campo DescSerie possui mais caracteres do que o permitido.
                //if (pCRJSerie.DescSerie.Length > 45)
                //{
                //    return "Campo DescSerie possui mais caracteres do que o permitido.";
                //}

                ////Validar Obrigatoriedade do campo DescSerie.
                //if (pCRJSerie.DescSerie == null || pCRJSerie.DescSerie.ToString() == "")
                //{
                //    return "Campo DescSerie não pode ser vazio.";
                //}


                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJSerie">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJSerie PopularEntidade(DataTable dtCRJSerie, int i)
            {
                //Criando um objeto do tipo CRJSerie.
                CRJSerie objCRJSerie = new CRJSerie();

                if(dtCRJSerie.Columns.Contains("idSerie"))
                {
                    if (dtCRJSerie.Rows[i]["idSerie"] != DBNull.Value)
                    {
                        objCRJSerie.idSerie = Convert.ToInt32(dtCRJSerie.Rows[i]["idSerie"].ToString());
                    }
                }

                if(dtCRJSerie.Columns.Contains("Descricao"))
                {
                    if (dtCRJSerie.Rows[i]["Descricao"] != DBNull.Value)
                    {
                        objCRJSerie.Descricao = Convert.ToString(dtCRJSerie.Rows[i]["Descricao"]);
                    }
                }

                return objCRJSerie;
            }



        #endregion
        
        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJSerie no Banco de Dados.
            /// </summary>
            /// <param name="pCRJSerie">Objeto do Tipo CRJSerie que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJSerie pCRJSerie, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJSerie);

                string Retorno = string.Empty;
                object ret = null;

                //Se Existem Inconsistências retorna a inconsistência e sai do método.
                //Caso contrário realiza a Persistência no Banco.
                if (MensagemValidacao != null)
                {
                    return MensagemValidacao;
                }


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSerie1"))
                {
                    //Parâmetros da Stored Procedure.
                   // db.AddInParameter(dbCommand,"DescSerie", DbType.String, pCRJSerie.DescSerie);
                    db.AddInParameter(dbCommand,"RUUsuarioLogado", DbType.String, pRUUsuarioLogado);

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
            /// Método que Altera um CRJSerie no Banco de Dados.
            /// </summary>
            /// <param name="pCRJSerie">Objeto do Tipo CRJSerie que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJSerie pCRJSerie, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJSerie);
                

                //Se Existem Inconsistências retorna a inconsistência e sai do método.
                //Caso contrário realiza a Persistência no Banco.
                if (MensagemValidacao != null)
                {
                    return MensagemValidacao;
                }

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSerie2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"idSerie", DbType.Int32, pCRJSerie.idSerie);
                   // db.AddInParameter(dbCommand,"DescSerie", DbType.String, pCRJSerie.DescSerie);
                    db.AddInParameter(dbCommand,"RUUsuarioLogado", DbType.String, pRUUsuarioLogado);

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
            /// Método que Exclui um CRJSerie no Banco de Dados.
            /// </summary>
            /// <param name="pCRJSerie">Objeto do Tipo CRJSerie que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int p, string pRUUsuarioLogado)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSerie3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"", DbType.Int32, p);
                    db.AddInParameter(dbCommand,"RUUsuarioLogado", DbType.String, pRUUsuarioLogado);

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
            /// Método que retorna todos os CRJSerie do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJSerie contendo os CRJSerie do Banco de Dados.</returns>
            public List<CRJSerie> ObterCRJSerie()
            {
                //Instânciando a Lista Tipada.
                List<CRJSerie> objCRJSerieColecao = new List<CRJSerie>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSerie4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJSerie = ds.Tables[0];

                            for (int i = 0; i < dtCRJSerie.Rows.Count; i++)
                            {
                                CRJSerie objCRJSerie = PopularEntidade(dtCRJSerie, i);
                                objCRJSerieColecao.Add(objCRJSerie);
                                objCRJSerie = null;
                            }
                        }
                    }
                }

                return objCRJSerieColecao;
            }


            /// <summary>
            /// Método que retorna os CRJSerie do Banco de Dados.
            /// </summary>
            /// <param name="p"> da CRJSerie que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJSerie contendo os CRJSerie do Banco de Dados.</returns>
            public CRJSerie ObterCRJSerie(int pIdSerie)
            {
                //Instânciando a Lista Tipada.
                List<CRJSerie> objCRJSerieColecao = new List<CRJSerie>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSerie2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdSerie", DbType.Int32, pIdSerie);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJSerie = ds.Tables[0];

                            for (int i = 0; i < dtCRJSerie.Rows.Count; i++)
                            {
                                CRJSerie objCRJSerie = PopularEntidade(dtCRJSerie, i);
                                objCRJSerieColecao.Add(objCRJSerie);
                                objCRJSerie = null;
                            }
                        }
                    }
                }

                if (objCRJSerieColecao != null && objCRJSerieColecao.Count > 0)
                    return objCRJSerieColecao[0];
                else
                    return null;
            }


            /// <summary>
            /// Método que retorna os CRJSerie do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJSerie contendo os CRJSerie do Banco de Dados.</returns>
            public List<CRJSerie> ObterCRJSerie(string pString)
            {
                //Instânciando a Lista Tipada.
                List<CRJSerie> objCRJSerieColecao = new List<CRJSerie>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSerie6"))
                {
                    //Parâmetros da Stored Procedure.
                    //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                    db.AddInParameter(dbCommand,"<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJSerie = ds.Tables[0];

                            for (int i = 0; i < dtCRJSerie.Rows.Count; i++)
                            {
                                CRJSerie objCRJSerie = PopularEntidade(dtCRJSerie, i);
                                objCRJSerieColecao.Add(objCRJSerie);
                                objCRJSerie = null;
                            }
                        }
                    }
                }

                return objCRJSerieColecao;
            }



        #endregion

    }


}
