using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace Corujito.Negocio
{


    public partial class CRJOcorrenciaNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJOcorrencia">Objeto do Tipo CRJOcorrencia que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJOcorrencia pCRJOcorrencia)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdOcorrencia.
                if (pCRJOcorrencia.IdOcorrencia == null)
                {
                    return "Campo IdOcorrencia não pode ser vazio.";
                }
                

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdLancador.
                if (pCRJOcorrencia.IdLancador == null)
                {
                    return "Campo IdLancador não pode ser vazio.";
                }
               

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdAluno.
                if (pCRJOcorrencia.IdAluno == null)
                {
                    return "Campo IdAluno não pode ser vazio.";
                }
              

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

    

                //Validar Obrigatoriedade do campo Ocorrencia.
                if (pCRJOcorrencia.Ocorrencia == null || pCRJOcorrencia.Ocorrencia.ToString() == "")
                {
                    return "Campo Ocorrencia não pode ser vazio.";
                }


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

                //Validar Obrigatoriedade do campo Providencias.
                if (pCRJOcorrencia.Providencias == null || pCRJOcorrencia.Providencias.ToString() == "")
                {
                    return "Campo Providencias não pode ser vazio.";
                }


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo DataOcorrencia.
                if (pCRJOcorrencia.DataOcorrencia == null)
                {
                    return "Campo DataOcorrencia não pode ser vazio.";
                }
               


                //Finalizando a DLL Utilitario.
                 

                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJOcorrencia">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJOcorrencia PopularEntidade(DataTable dtCRJOcorrencia, int i)
            {
                //Criando um objeto do tipo CRJOcorrencia.
                CRJOcorrencia objCRJOcorrencia = new CRJOcorrencia();

                if(dtCRJOcorrencia.Columns.Contains("IdOcorrencia"))
                {
                    if (dtCRJOcorrencia.Rows[i]["IdOcorrencia"] != DBNull.Value)
                    {
                        objCRJOcorrencia.IdOcorrencia = Convert.ToInt32(dtCRJOcorrencia.Rows[i]["IdOcorrencia"].ToString());
                    }
                }

                if(dtCRJOcorrencia.Columns.Contains("IdLancador"))
                {
                    if (dtCRJOcorrencia.Rows[i]["IdLancador"] != DBNull.Value)
                    {
                        objCRJOcorrencia.IdLancador = Convert.ToInt32(dtCRJOcorrencia.Rows[i]["IdLancador"].ToString());
                    }
                }

                if(dtCRJOcorrencia.Columns.Contains("IdAluno"))
                {
                    if (dtCRJOcorrencia.Rows[i]["IdAluno"] != DBNull.Value)
                    {
                        objCRJOcorrencia.IdAluno = Convert.ToInt32(dtCRJOcorrencia.Rows[i]["IdAluno"].ToString());
                    }
                }

                

                if(dtCRJOcorrencia.Columns.Contains("Ocorrencia"))
                {
                    if (dtCRJOcorrencia.Rows[i]["Ocorrencia"] != DBNull.Value)
                    {
                        objCRJOcorrencia.Ocorrencia = Convert.ToString(dtCRJOcorrencia.Rows[i]["Ocorrencia"]);
                    }
                }

                if(dtCRJOcorrencia.Columns.Contains("Providencias"))
                {
                    if (dtCRJOcorrencia.Rows[i]["Providencias"] != DBNull.Value)
                    {
                        objCRJOcorrencia.Providencias = Convert.ToString(dtCRJOcorrencia.Rows[i]["Providencias"]);
                    }
                }

                if(dtCRJOcorrencia.Columns.Contains("DataOcorrencia"))
                {
                    if (dtCRJOcorrencia.Rows[i]["DataOcorrencia"] != DBNull.Value)
                    {
                        objCRJOcorrencia.DataOcorrencia = Convert.ToDateTime(dtCRJOcorrencia.Rows[i]["DataOcorrencia"].ToString());
                    }
                }

                return objCRJOcorrencia;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJOcorrencia no Banco de Dados.
            /// </summary>
            /// <param name="pCRJOcorrencia">Objeto do Tipo CRJOcorrencia que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJOcorrencia pCRJOcorrencia)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJOcorrencia);

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdLancador", DbType.Int32, pCRJOcorrencia.IdLancador);
                    db.AddInParameter(dbCommand,"IdAluno", DbType.Int32, pCRJOcorrencia.IdAluno);
                    db.AddInParameter(dbCommand,"Natureza", DbType.String, "");
                    db.AddInParameter(dbCommand,"Ocorrencia", DbType.String, pCRJOcorrencia.Ocorrencia);
                    db.AddInParameter(dbCommand,"Providencias", DbType.String, pCRJOcorrencia.Providencias);
                    db.AddInParameter(dbCommand,"DataOcorrencia", DbType.DateTime, DateTime.Now);

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
            /// Método que Altera um CRJOcorrencia no Banco de Dados.
            /// </summary>
            /// <param name="pCRJOcorrencia">Objeto do Tipo CRJOcorrencia que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJOcorrencia pCRJOcorrencia)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJOcorrencia);
                

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdOcorrencia", DbType.Int32, pCRJOcorrencia.IdOcorrencia);
                    db.AddInParameter(dbCommand,"IdLancador", DbType.Int32, pCRJOcorrencia.IdLancador);
                    db.AddInParameter(dbCommand,"IdAluno", DbType.Int32, pCRJOcorrencia.IdAluno);
                    db.AddInParameter(dbCommand,"Natureza", DbType.String, pCRJOcorrencia.Natureza);
                    db.AddInParameter(dbCommand,"Ocorrencia", DbType.String, pCRJOcorrencia.Ocorrencia);
                    db.AddInParameter(dbCommand,"Providencias", DbType.String, pCRJOcorrencia.Providencias);
                    db.AddInParameter(dbCommand,"DataOcorrencia", DbType.DateTime, pCRJOcorrencia.DataOcorrencia);

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
            /// Método que Exclui um CRJOcorrencia no Banco de Dados.
            /// </summary>
            /// <param name="pCRJOcorrencia">Objeto do Tipo CRJOcorrencia que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int pIdOcorrencia, string pRUUsuarioLogado)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdOcorrencia", DbType.Int32, pIdOcorrencia);
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
            /// Método que retorna todos os CRJOcorrencia do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJOcorrencia contendo os CRJOcorrencia do Banco de Dados.</returns>
            public List<CRJOcorrencia> ObterCRJOcorrencia()
            {
                //Instânciando a Lista Tipada.
                List<CRJOcorrencia> objCRJOcorrenciaColecao = new List<CRJOcorrencia>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJOcorrencia = ds.Tables[0];

                            for (int i = 0; i < dtCRJOcorrencia.Rows.Count; i++)
                            {
                                CRJOcorrencia objCRJOcorrencia = PopularEntidade(dtCRJOcorrencia, i);
                                objCRJOcorrenciaColecao.Add(objCRJOcorrencia);
                                objCRJOcorrencia = null;
                            }
                        }
                    }
                }

                return objCRJOcorrenciaColecao;
            }


            /// <summary>
            /// Método que retorna os CRJOcorrencia do Banco de Dados.
            /// </summary>
            /// <param name="pIdOcorrencia">IdOcorrencia da CRJOcorrencia que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJOcorrencia contendo os CRJOcorrencia do Banco de Dados.</returns>
            public List<CRJOcorrencia> ObterCRJOcorrencia(int pIdOcorrencia)
            {
                //Instânciando a Lista Tipada.
                List<CRJOcorrencia> objCRJOcorrenciaColecao = new List<CRJOcorrencia>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdOcorrencia", DbType.Int32, pIdOcorrencia);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJOcorrencia = ds.Tables[0];

                            for (int i = 0; i < dtCRJOcorrencia.Rows.Count; i++)
                            {
                                CRJOcorrencia objCRJOcorrencia = PopularEntidade(dtCRJOcorrencia, i);
                                objCRJOcorrenciaColecao.Add(objCRJOcorrencia);
                                objCRJOcorrencia = null;
                            }
                        }
                    }
                }

                return  objCRJOcorrenciaColecao;
            }


            /// <summary>
            /// Método que retorna os CRJOcorrencia do Banco de Dados.
            /// </summary>
            /// <param name="pIdOcorrencia">IdOcorrencia da CRJOcorrencia que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJOcorrencia contendo os CRJOcorrencia do Banco de Dados.</returns>
            public DataTable ObterCRJOcorrenciaByAluno(int pIdAluno)
            {
                //Instânciando a Lista Tipada.
                //List<CRJOcorrencia> objCRJOcorrenciaColecao = new List<CRJOcorrencia>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia7"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdAluno", DbType.Int32, pIdAluno);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            return ds.Tables[0];
                        }
                    }
                }

                return new DataTable();
            }


            /// <summary>
            /// Método que retorna os CRJPessoa do Banco de Dados.
            /// </summary>
            /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
            public DataTable ObterCRJOcorrencia(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null)
            {

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJOcorrencia6"))
                {
                    //Parâmetros da Stored Procedure.

                    if (!string.IsNullOrEmpty(pNome))
                        db.AddInParameter(dbCommand, "pNome", DbType.String, pNome);

                    if (!string.IsNullOrEmpty(pEmail))
                        db.AddInParameter(dbCommand, "pEmail", DbType.String, pEmail);

                    if (!string.IsNullOrEmpty(pCPF))
                        db.AddInParameter(dbCommand, "pCPF", DbType.String, pCPF);

                    if (!string.IsNullOrEmpty(pTelefone))
                        db.AddInParameter(dbCommand, "pTelefone", DbType.String, pTelefone);

                    if (!string.IsNullOrEmpty(pRA))
                        db.AddInParameter(dbCommand, "pRA", DbType.String, pRA);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                          return ds.Tables[0];

                            
                        }
                    }
                }

                return new DataTable();
            }



        #endregion

    }


}
