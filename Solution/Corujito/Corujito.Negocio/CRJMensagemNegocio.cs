using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace Corujito.Negocio
{


    public partial class CRJMensagemNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJMensagem">Objeto do Tipo CRJMensagem que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJMensagem pCRJMensagem)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdMensagem.
                if (pCRJMensagem.IdMensagem == null)
                {
                    return "Campo IdMensagem não pode ser vazio.";
                }
                

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdLancador.
                if (pCRJMensagem.IdLancador == null)
                {
                    return "Campo IdLancador não pode ser vazio.";
                }
               

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdAluno.
                if (pCRJMensagem.IdAluno == null)
                {
                    return "Campo IdAluno não pode ser vazio.";
                }
              

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

    

                //Validar Obrigatoriedade do campo Mensagem.
                if (pCRJMensagem.Mensagem == null || pCRJMensagem.Mensagem.ToString() == "")
                {
                    return "Campo Mensagem não pode ser vazio.";
                }





                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo DataMensagem.
                if (pCRJMensagem.DataMensagem == null)
                {
                    return "Campo DataMensagem não pode ser vazio.";
                }
               


                //Finalizando a DLL Utilitario.
                 

                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJMensagem">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJMensagem PopularEntidade(DataTable dtCRJMensagem, int i)
            {
                //Criando um objeto do tipo CRJMensagem.
                CRJMensagem objCRJMensagem = new CRJMensagem();

                if(dtCRJMensagem.Columns.Contains("IdMensagem"))
                {
                    if (dtCRJMensagem.Rows[i]["IdMensagem"] != DBNull.Value)
                    {
                        objCRJMensagem.IdMensagem = Convert.ToInt32(dtCRJMensagem.Rows[i]["IdMensagem"].ToString());
                    }
                }

                if(dtCRJMensagem.Columns.Contains("IdLancador"))
                {
                    if (dtCRJMensagem.Rows[i]["IdLancador"] != DBNull.Value)
                    {
                        objCRJMensagem.IdLancador = Convert.ToInt32(dtCRJMensagem.Rows[i]["IdLancador"].ToString());
                    }
                }

                if(dtCRJMensagem.Columns.Contains("IdAluno"))
                {
                    if (dtCRJMensagem.Rows[i]["IdAluno"] != DBNull.Value)
                    {
                        objCRJMensagem.IdAluno = Convert.ToInt32(dtCRJMensagem.Rows[i]["IdAluno"].ToString());
                    }
                }

                

                if(dtCRJMensagem.Columns.Contains("Mensagem"))
                {
                    if (dtCRJMensagem.Rows[i]["Mensagem"] != DBNull.Value)
                    {
                        objCRJMensagem.Mensagem = Convert.ToString(dtCRJMensagem.Rows[i]["Mensagem"]);
                    }
                }

                

                if(dtCRJMensagem.Columns.Contains("DataMensagem"))
                {
                    if (dtCRJMensagem.Rows[i]["DataMensagem"] != DBNull.Value)
                    {
                        objCRJMensagem.DataMensagem = Convert.ToDateTime(dtCRJMensagem.Rows[i]["DataMensagem"].ToString());
                    }
                }

                return objCRJMensagem;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJMensagem no Banco de Dados.
            /// </summary>
            /// <param name="pCRJMensagem">Objeto do Tipo CRJMensagem que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJMensagem pCRJMensagem)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJMensagem);

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdLancador", DbType.Int32, pCRJMensagem.IdLancador);
                    db.AddInParameter(dbCommand,"IdAluno", DbType.Int32, pCRJMensagem.IdAluno);
                    db.AddInParameter(dbCommand,"Natureza", DbType.String, "");
                    db.AddInParameter(dbCommand,"Mensagem", DbType.String, pCRJMensagem.Mensagem);
                    db.AddInParameter(dbCommand,"DataMensagem", DbType.DateTime, DateTime.Now);

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
            /// Método que Altera um CRJMensagem no Banco de Dados.
            /// </summary>
            /// <param name="pCRJMensagem">Objeto do Tipo CRJMensagem que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJMensagem pCRJMensagem)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJMensagem);
                

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdMensagem", DbType.Int32, pCRJMensagem.IdMensagem);
                    db.AddInParameter(dbCommand,"IdLancador", DbType.Int32, pCRJMensagem.IdLancador);
                    db.AddInParameter(dbCommand,"IdAluno", DbType.Int32, pCRJMensagem.IdAluno);
                    db.AddInParameter(dbCommand,"Mensagem", DbType.String, pCRJMensagem.Mensagem);
                    db.AddInParameter(dbCommand,"DataMensagem", DbType.DateTime, pCRJMensagem.DataMensagem);

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
            /// Método que Exclui um CRJMensagem no Banco de Dados.
            /// </summary>
            /// <param name="pCRJMensagem">Objeto do Tipo CRJMensagem que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int pIdMensagem, string pRUUsuarioLogado)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdMensagem", DbType.Int32, pIdMensagem);
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
            /// Método que retorna todos os CRJMensagem do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJMensagem contendo os CRJMensagem do Banco de Dados.</returns>
            public List<CRJMensagem> ObterCRJMensagem()
            {
                //Instânciando a Lista Tipada.
                List<CRJMensagem> objCRJMensagemColecao = new List<CRJMensagem>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJMensagem = ds.Tables[0];

                            for (int i = 0; i < dtCRJMensagem.Rows.Count; i++)
                            {
                                CRJMensagem objCRJMensagem = PopularEntidade(dtCRJMensagem, i);
                                objCRJMensagemColecao.Add(objCRJMensagem);
                                objCRJMensagem = null;
                            }
                        }
                    }
                }

                return objCRJMensagemColecao;
            }


            /// <summary>
            /// Método que retorna os CRJMensagem do Banco de Dados.
            /// </summary>
            /// <param name="pIdMensagem">IdMensagem da CRJMensagem que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJMensagem contendo os CRJMensagem do Banco de Dados.</returns>
            public List<CRJMensagem> ObterCRJMensagem(int pIdMensagem)
            {
                //Instânciando a Lista Tipada.
                List<CRJMensagem> objCRJMensagemColecao = new List<CRJMensagem>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdMensagem", DbType.Int32, pIdMensagem);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJMensagem = ds.Tables[0];

                            for (int i = 0; i < dtCRJMensagem.Rows.Count; i++)
                            {
                                CRJMensagem objCRJMensagem = PopularEntidade(dtCRJMensagem, i);
                                objCRJMensagemColecao.Add(objCRJMensagem);
                                objCRJMensagem = null;
                            }
                        }
                    }
                }

                return  objCRJMensagemColecao;
            }


            /// <summary>
            /// Método que retorna os CRJMensagem do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJMensagem contendo os CRJMensagem do Banco de Dados.</returns>
            public List<CRJMensagem> ObterCRJMensagem(string pString)
            {
                //Instânciando a Lista Tipada.
                List<CRJMensagem> objCRJMensagemColecao = new List<CRJMensagem>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem6"))
                {
                    //Parâmetros da Stored Procedure.
                    //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                    db.AddInParameter(dbCommand,"<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJMensagem = ds.Tables[0];

                            for (int i = 0; i < dtCRJMensagem.Rows.Count; i++)
                            {
                                CRJMensagem objCRJMensagem = PopularEntidade(dtCRJMensagem, i);
                                objCRJMensagemColecao.Add(objCRJMensagem);
                                objCRJMensagem = null;
                            }
                        }
                    }
                }

                return objCRJMensagemColecao;
            }

            /// <summary>
            /// Método que retorna os CRJPessoa do Banco de Dados.
            /// </summary>
            /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
            public DataTable ObterCRJMensagem(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null)
            {

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMensagem6"))
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
