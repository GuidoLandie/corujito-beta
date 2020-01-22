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
    
    public  class CRJClassesNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJClasses">Objeto do Tipo CRJClasses que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJClasses pCRJClasses)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo idClasses.
                if (pCRJClasses.idClasses == null)
                {
                    return "Campo idClasses não pode ser vazio.";
                }
               


                //// TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                ////Validar Obrigatoriedade do campo idSerieXTurma.
                //if (pCRJClasses.Serie.idSerie == null)
                //{
                //    return "Campo idSerieXTurma não pode ser vazio.";
                //}
              


                //// TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                ////Validar Obrigatoriedade do campo idTurno.
                //if (pCRJClasses.idTurno == null)
                //{
                //    return "Campo idTurno não pode ser vazio.";
                //}
                
                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJClasses">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJClasses PopularEntidade(DataTable dtCRJClasses, int i)
            {
                //Criando um objeto do tipo CRJClasses.
                CRJClasses objCRJClasses = new CRJClasses();

                if(dtCRJClasses.Columns.Contains("IdClasse"))
                {
                    if (dtCRJClasses.Rows[i]["IdClasse"] != DBNull.Value)
                    {
                        objCRJClasses.idClasses = Convert.ToInt32(dtCRJClasses.Rows[i]["IdClasse"].ToString());
                    }
                }

                if (dtCRJClasses.Columns.Contains("IdEnsino"))
                {
                    if (dtCRJClasses.Rows[i]["IdEnsino"] != DBNull.Value)
                    {
                        int IdEnsino = Convert.ToInt32(dtCRJClasses.Rows[i]["IdEnsino"].ToString());

                        objCRJClasses.Ensino = (new CRJEnsinoNegocio().ObterCRJEnsino(IdEnsino));
                          
                    }
                }


                if (dtCRJClasses.Columns.Contains("IdSerie"))
                {
                    if (dtCRJClasses.Rows[i]["IdSerie"] != DBNull.Value)
                    {
                        int IdSerie = Convert.ToInt32(dtCRJClasses.Rows[i]["IdEnsino"].ToString());
                        
                        objCRJClasses.Serie = (new CRJSerieNegocio().ObterCRJSerie(IdSerie));
                        
                    }
                }

                if (dtCRJClasses.Columns.Contains("IdTurno"))
                {
                    if (dtCRJClasses.Rows[i]["IdTurno"] != DBNull.Value)
                    {
                        int IdTurno = Convert.ToInt32(dtCRJClasses.Rows[i]["IdTurno"].ToString());

                        objCRJClasses.Turno = (new CRJTurnoNegocio().ObterCRJTurno(IdTurno));

                    }
                }

                if (dtCRJClasses.Columns.Contains("NomeTurma"))
                {
                    if (dtCRJClasses.Rows[i]["NomeTurma"] != DBNull.Value)
                    {
                        objCRJClasses.NomeTurma = Convert.ToString(dtCRJClasses.Rows[i]["NomeTurma"]);                      
                    }
                }

                return objCRJClasses;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJClasses no Banco de Dados.
            /// </summary>
            /// <param name="pCRJClasses">Objeto do Tipo CRJClasses que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJClasses pCRJClasses, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJClasses);

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasses;1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"idSerieXTurma", DbType.Int32, pCRJClasses.Serie.idSerie);
                    db.AddInParameter(dbCommand,"idTurno", DbType.Int32, pCRJClasses.Turno.idTurno);
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
            /// Método que Altera um CRJClasses no Banco de Dados.
            /// </summary>
            /// <param name="pCRJClasses">Objeto do Tipo CRJClasses que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJClasses pCRJClasses, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJClasses);
                

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasses;2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"idClasses", DbType.Int32, pCRJClasses.idClasses);
                    db.AddInParameter(dbCommand,"idSerieXTurma", DbType.Int32, pCRJClasses.idClasses);
                    //db.AddInParameter(dbCommand,"idTurno", DbType.Int32, pCRJClasses.idTurno);
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
            /// Método que Exclui um CRJClasses no Banco de Dados.
            /// </summary>
            /// <param name="pCRJClasses">Objeto do Tipo CRJClasses que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int p, string pRUUsuarioLogado)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasses;3"))
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
            /// Método que retorna os CRJClasses do Banco de Dados.
            /// </summary>
            /// <param name="p"> da CRJClasses que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJClasses contendo os CRJClasses do Banco de Dados.</returns>
            public CRJClasses ObterCRJClasses(int pIdClasse)
            {
                //Instânciando a Lista Tipada.

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasse;1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "idClasse", DbType.Int32, pIdClasse);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJClasses = ds.Tables[0];

                            for (int i = 0; i < dtCRJClasses.Rows.Count; i++)
                            {
                                CRJClasses objCRJClasses = PopularEntidade(dtCRJClasses, i);
                                return objCRJClasses;
                            }
                        }
                      
                    }
                }
                return null;
            }



            /// <summary>
            /// Método que retorna os CRJClasses do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJClasses contendo os CRJClasses do Banco de Dados.</returns>
            public List<CRJClasses> ObterCRJClasses()
            {
                //Instânciando a Lista Tipada.
                List<CRJClasses> objCRJClassesColecao = new List<CRJClasses>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasses;1"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJClasses = ds.Tables[0];

                            for (int i = 0; i < dtCRJClasses.Rows.Count; i++)
                            {
                                CRJClasses objCRJClasses = PopularEntidade(dtCRJClasses, i);
                                objCRJClassesColecao.Add(objCRJClasses);
                                objCRJClasses = null;
                            }
                        }
                    }
                }

                return objCRJClassesColecao;
            }



        #endregion

    }


}
