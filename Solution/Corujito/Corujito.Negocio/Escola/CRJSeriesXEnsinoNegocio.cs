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


    public class CRJSeriesXEnsinoNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJSeriesXEnsino">Objeto do Tipo CRJSeriesXEnsino que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJSeriesXEnsino pCRJSeriesXEnsino)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo idAnoXEnsino.
                if (pCRJSeriesXEnsino.idAnoXEnsino == null)
                {
                    return "Campo idAnoXEnsino não pode ser vazio.";
                }
             

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo idSerie.
                if (pCRJSeriesXEnsino.idSerie == null)
                {
                    return "Campo idSerie não pode ser vazio.";
                }
                

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo idEnsino.
                if (pCRJSeriesXEnsino.idEnsino == null)
                {
                    return "Campo idEnsino não pode ser vazio.";
                }
               

                //Finalizando a DLL Utilitario.
                 

                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJSeriesXEnsino">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJSeriesXEnsino PopularEntidade(DataTable dtCRJSeriesXEnsino, int i)
            {
                //Criando um objeto do tipo CRJSeriesXEnsino.
                CRJSeriesXEnsino objCRJSeriesXEnsino = new CRJSeriesXEnsino();

                if(dtCRJSeriesXEnsino.Columns.Contains("idAnoXEnsino"))
                {
                    if (dtCRJSeriesXEnsino.Rows[i]["idAnoXEnsino"] != DBNull.Value)
                    {
                        objCRJSeriesXEnsino.idAnoXEnsino = Convert.ToInt32(dtCRJSeriesXEnsino.Rows[i]["idAnoXEnsino"].ToString());
                    }
                }

                if(dtCRJSeriesXEnsino.Columns.Contains("idSerie"))
                {
                    if (dtCRJSeriesXEnsino.Rows[i]["idSerie"] != DBNull.Value)
                    {
                        //objCRJSeriesXEnsino.idSerie = Convert.ToInt32(dtCRJSeriesXEnsino.Rows[i]["idSerie"].ToString());
                    }
                }

                if(dtCRJSeriesXEnsino.Columns.Contains("idEnsino"))
                {
                    if (dtCRJSeriesXEnsino.Rows[i]["idEnsino"] != DBNull.Value)
                    {
                        //objCRJSeriesXEnsino.idEnsino = Convert.ToInt32(dtCRJSeriesXEnsino.Rows[i]["idEnsino"].ToString());
                    }
                }

                return objCRJSeriesXEnsino;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJSeriesXEnsino no Banco de Dados.
            /// </summary>
            /// <param name="pCRJSeriesXEnsino">Objeto do Tipo CRJSeriesXEnsino que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJSeriesXEnsino pCRJSeriesXEnsino, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJSeriesXEnsino);

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSeriesXEnsino;1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"idSerie", DbType.Int32, pCRJSeriesXEnsino.idSerie);
                    db.AddInParameter(dbCommand,"idEnsino", DbType.Int32, pCRJSeriesXEnsino.idEnsino);
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
            /// Método que Altera um CRJSeriesXEnsino no Banco de Dados.
            /// </summary>
            /// <param name="pCRJSeriesXEnsino">Objeto do Tipo CRJSeriesXEnsino que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJSeriesXEnsino pCRJSeriesXEnsino, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJSeriesXEnsino);
                

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSeriesXEnsino;2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"idAnoXEnsino", DbType.Int32, pCRJSeriesXEnsino.idAnoXEnsino);
                    db.AddInParameter(dbCommand,"idSerie", DbType.Int32, pCRJSeriesXEnsino.idSerie);
                    db.AddInParameter(dbCommand,"idEnsino", DbType.Int32, pCRJSeriesXEnsino.idEnsino);
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
            /// Método que Exclui um CRJSeriesXEnsino no Banco de Dados.
            /// </summary>
            /// <param name="pCRJSeriesXEnsino">Objeto do Tipo CRJSeriesXEnsino que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int p, string pRUUsuarioLogado)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSeriesXEnsino;3"))
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
            /// Método que retorna todos os CRJSeriesXEnsino do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJSeriesXEnsino contendo os CRJSeriesXEnsino do Banco de Dados.</returns>
            public List<CRJSeriesXEnsino> ObterCRJSeriesXEnsino()
            {
                //Instânciando a Lista Tipada.
                List<CRJSeriesXEnsino> objCRJSeriesXEnsinoColecao = new List<CRJSeriesXEnsino>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSeriesXEnsino;4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJSeriesXEnsino = ds.Tables[0];

                            for (int i = 0; i < dtCRJSeriesXEnsino.Rows.Count; i++)
                            {
                                CRJSeriesXEnsino objCRJSeriesXEnsino = PopularEntidade(dtCRJSeriesXEnsino, i);
                                objCRJSeriesXEnsinoColecao.Add(objCRJSeriesXEnsino);
                                objCRJSeriesXEnsino = null;
                            }
                        }
                    }
                }

                return objCRJSeriesXEnsinoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJSeriesXEnsino do Banco de Dados.
            /// </summary>
            /// <param name="p"> da CRJSeriesXEnsino que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJSeriesXEnsino contendo os CRJSeriesXEnsino do Banco de Dados.</returns>
            public List<CRJSeriesXEnsino> ObterCRJSeriesXEnsino(int p)
            {
                //Instânciando a Lista Tipada.
                List<CRJSeriesXEnsino> objCRJSeriesXEnsinoColecao = new List<CRJSeriesXEnsino>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSeriesXEnsino;5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"", DbType.Int32, p);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJSeriesXEnsino = ds.Tables[0];

                            for (int i = 0; i < dtCRJSeriesXEnsino.Rows.Count; i++)
                            {
                                CRJSeriesXEnsino objCRJSeriesXEnsino = PopularEntidade(dtCRJSeriesXEnsino, i);
                                objCRJSeriesXEnsinoColecao.Add(objCRJSeriesXEnsino);
                                objCRJSeriesXEnsino = null;
                            }
                        }
                    }
                }

                return  objCRJSeriesXEnsinoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJSeriesXEnsino do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJSeriesXEnsino contendo os CRJSeriesXEnsino do Banco de Dados.</returns>
            public List<CRJSeriesXEnsino> ObterCRJSeriesXEnsino(string pString)
            {
                //Instânciando a Lista Tipada.
                List<CRJSeriesXEnsino> objCRJSeriesXEnsinoColecao = new List<CRJSeriesXEnsino>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJSeriesXEnsino;6"))
                {
                    //Parâmetros da Stored Procedure.
                    //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                    db.AddInParameter(dbCommand,"<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJSeriesXEnsino = ds.Tables[0];

                            for (int i = 0; i < dtCRJSeriesXEnsino.Rows.Count; i++)
                            {
                                CRJSeriesXEnsino objCRJSeriesXEnsino = PopularEntidade(dtCRJSeriesXEnsino, i);
                                objCRJSeriesXEnsinoColecao.Add(objCRJSeriesXEnsino);
                                objCRJSeriesXEnsino = null;
                            }
                        }
                    }
                }

                return objCRJSeriesXEnsinoColecao;
            }



        #endregion

    }


}
