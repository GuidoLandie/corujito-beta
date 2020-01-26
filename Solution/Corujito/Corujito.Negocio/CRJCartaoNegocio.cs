using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace Corujito.Negocio
{


    public partial class CRJCartaoNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJCartao">Objeto do Tipo CRJCartao que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJCartao pCRJCartao)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdCartao.
                if (pCRJCartao.IdCartao == null)
                {
                    return "Campo IdCartao não pode ser vazio.";
                }
                

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdLancador.
                if (pCRJCartao.IdPessoa == null)
                {
                    return "Campo IdPessoa não pode ser vazio.";
                }
               

                

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo DataCartao.
                if (pCRJCartao.DataEmissao == null)
                {
                    return "Campo DataEmissão não pode ser vazio.";
                }
               


                //Finalizando a DLL Utilitario.
                 

                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJCartao">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJCartao PopularEntidade(DataTable dtCRJCartao, int i)
            {
                //Criando um objeto do tipo CRJCartao.
                CRJCartao objCRJCartao = new CRJCartao();

                if(dtCRJCartao.Columns.Contains("IdCartao"))
                {
                    if (dtCRJCartao.Rows[i]["IdCartao"] != DBNull.Value)
                    {
                        objCRJCartao.IdCartao = Convert.ToInt32(dtCRJCartao.Rows[i]["IdCartao"].ToString());
                    }
                }

                if(dtCRJCartao.Columns.Contains("IdPessoa"))
                {
                    if (dtCRJCartao.Rows[i]["IdPessoa"] != DBNull.Value)
                    {
                        objCRJCartao.IdPessoa = Convert.ToInt32(dtCRJCartao.Rows[i]["IdPessoa"].ToString());
                    }
                }

                

                if(dtCRJCartao.Columns.Contains("DataEmissao"))
                {
                    if (dtCRJCartao.Rows[i]["DataEmissao"] != DBNull.Value)
                    {
                        objCRJCartao.DataEmissao = Convert.ToDateTime(dtCRJCartao.Rows[i]["DataEmissao"].ToString());
                    }
                }

                return objCRJCartao;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJCartao no Banco de Dados.
            /// </summary>
            /// <param name="pCRJCartao">Objeto do Tipo CRJCartao que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJCartao pCRJCartao)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJCartao);

                string Retorno = string.Empty;
                object ret = null;

                //Se Existem Inconsistências retorna a inconsistência e sai do método.
                //Caso contrário realiza a Persistência no Banco.
                if (MensagemValidacao != null)
                {
                    return MensagemValidacao;
                }


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdPessoa", DbType.Int32, pCRJCartao.IdPessoa);
                    db.AddInParameter(dbCommand,"DataEmissao", DbType.DateTime, DateTime.Now);

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
            /// Método que Altera um CRJCartao no Banco de Dados.
            /// </summary>
            /// <param name="pCRJCartao">Objeto do Tipo CRJCartao que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJCartao pCRJCartao)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJCartao);
                

                //Se Existem Inconsistências retorna a inconsistência e sai do método.
                //Caso contrário realiza a Persistência no Banco.
                if (MensagemValidacao != null)
                {
                    return MensagemValidacao;
                }

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdCartao", DbType.Int32, pCRJCartao.IdCartao);
                    db.AddInParameter(dbCommand,"IdPessoa", DbType.Int32, pCRJCartao.IdPessoa);
                    db.AddInParameter(dbCommand,"DataEmissao", DbType.DateTime, pCRJCartao.DataEmissao);

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
            /// Método que Exclui um CRJCartao no Banco de Dados.
            /// </summary>
            /// <param name="pCRJCartao">Objeto do Tipo CRJCartao que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int pIdCartao)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdCartao", DbType.Int32, pIdCartao);

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
            /// Método que retorna todos os CRJCartao do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJCartao contendo os CRJCartao do Banco de Dados.</returns>
            public List<CRJCartao> ObterCRJCartao()
            {
                //Instânciando a Lista Tipada.
                List<CRJCartao> objCRJCartaoColecao = new List<CRJCartao>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJCartao = ds.Tables[0];

                            for (int i = 0; i < dtCRJCartao.Rows.Count; i++)
                            {
                                CRJCartao objCRJCartao = PopularEntidade(dtCRJCartao, i);
                                objCRJCartaoColecao.Add(objCRJCartao);
                                objCRJCartao = null;
                            }
                        }
                    }
                }

                return objCRJCartaoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJCartao do Banco de Dados.
            /// </summary>
            /// <param name="pIdCartao">IdCartao da CRJCartao que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJCartao contendo os CRJCartao do Banco de Dados.</returns>
            public List<CRJCartao> ObterCRJCartao(int pIdCartao)
            {
                //Instânciando a Lista Tipada.
                List<CRJCartao> objCRJCartaoColecao = new List<CRJCartao>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdCartao", DbType.Int32, pIdCartao);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJCartao = ds.Tables[0];

                            for (int i = 0; i < dtCRJCartao.Rows.Count; i++)
                            {
                                CRJCartao objCRJCartao = PopularEntidade(dtCRJCartao, i);
                                objCRJCartaoColecao.Add(objCRJCartao);
                                objCRJCartao = null;
                            }
                        }
                    }
                }

                return  objCRJCartaoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJCartao do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJCartao contendo os CRJCartao do Banco de Dados.</returns>
            public List<CRJCartao> ObterCRJCartao(string pString)
            {
                //Instânciando a Lista Tipada.
                List<CRJCartao> objCRJCartaoColecao = new List<CRJCartao>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao6"))
                {
                    //Parâmetros da Stored Procedure.
                    //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                    db.AddInParameter(dbCommand,"<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJCartao = ds.Tables[0];

                            for (int i = 0; i < dtCRJCartao.Rows.Count; i++)
                            {
                                CRJCartao objCRJCartao = PopularEntidade(dtCRJCartao, i);
                                objCRJCartaoColecao.Add(objCRJCartao);
                                objCRJCartao = null;
                            }
                        }
                    }
                }

                return objCRJCartaoColecao;
            }

            /// <summary>
            /// Método que retorna os CRJPessoa do Banco de Dados.
            /// </summary>
            /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
            public DataTable ObterCRJCartao(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null)
            {

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao6"))
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

            /// <summary>
            /// Método que retorna os CRJPessoa do Banco de Dados.
            /// </summary>
            /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
            public DataTable ObterCRJCartaoByIdPessoa(int idPessoa)
            {

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJCartao7"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "idPessoa", DbType.Int32, idPessoa);

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
