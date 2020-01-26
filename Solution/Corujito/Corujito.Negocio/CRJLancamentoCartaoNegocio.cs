using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace Corujito.Negocio
{


    public partial class CRJLancamentoCartaoNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJLancamentoCartao">Objeto do Tipo CRJLancamentoCartao que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJLancamentoCartao pCRJLancamentoCartao)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdLancamentoCartao.
                if (pCRJLancamentoCartao.IdLancamentoCartao == null)
                {
                    return "Campo IdLancamentoCartao não pode ser vazio.";
                }
                

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdCartao.
                if (pCRJLancamentoCartao.IdCartao == null)
                {
                    return "Campo IdCartao não pode ser vazio.";
                }

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo IdCartao.
                if (pCRJLancamentoCartao.IdLancador == null)
                {
                    return "Campo IdLancador não pode ser vazio.";
                }
               

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo Valor.
                if (pCRJLancamentoCartao.Valor == null)
                {
                    return "Campo Valor não pode ser vazio.";
                }
              

                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo DataLancamento.
                if (pCRJLancamentoCartao.DataLancamento == null)
                {
                    return "Campo DataLancamento não pode ser vazio.";
                }
               


                //Finalizando a DLL Utilitario.
                 

                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJLancamentoCartao">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJLancamentoCartao PopularEntidade(DataTable dtCRJLancamentoCartao, int i)
            {
                //Criando um objeto do tipo CRJLancamentoCartao.
                CRJLancamentoCartao objCRJLancamentoCartao = new CRJLancamentoCartao();

                if(dtCRJLancamentoCartao.Columns.Contains("IdLancamentoCartao"))
                {
                    if (dtCRJLancamentoCartao.Rows[i]["IdLancamentoCartao"] != DBNull.Value)
                    {
                        objCRJLancamentoCartao.IdLancamentoCartao = Convert.ToInt32(dtCRJLancamentoCartao.Rows[i]["IdLancamentoCartao"].ToString());
                    }
                }

                if(dtCRJLancamentoCartao.Columns.Contains("IdCartao"))
                {
                    if (dtCRJLancamentoCartao.Rows[i]["IdCartao"] != DBNull.Value)
                    {
                        objCRJLancamentoCartao.IdLancador = Convert.ToInt32(dtCRJLancamentoCartao.Rows[i]["IdCartao"].ToString());
                    }
                }

                if (dtCRJLancamentoCartao.Columns.Contains("IdLancador"))
                {
                    if (dtCRJLancamentoCartao.Rows[i]["IdLancador"] != DBNull.Value)
                    {
                        objCRJLancamentoCartao.IdCartao = Convert.ToInt32(dtCRJLancamentoCartao.Rows[i]["IdLancador"].ToString());
                    }
                }

                if(dtCRJLancamentoCartao.Columns.Contains("Valor"))
                {
                    if (dtCRJLancamentoCartao.Rows[i]["Valor"] != DBNull.Value)
                    {
                        objCRJLancamentoCartao.Valor = Convert.ToDouble(dtCRJLancamentoCartao.Rows[i]["Valor"].ToString());
                    }
                }

                if(dtCRJLancamentoCartao.Columns.Contains("DataLancamento"))
                {
                    if (dtCRJLancamentoCartao.Rows[i]["DataLancamento"] != DBNull.Value)
                    {
                        objCRJLancamentoCartao.DataLancamento = Convert.ToDateTime(dtCRJLancamentoCartao.Rows[i]["DataLancamento"].ToString());
                    }
                }

                return objCRJLancamentoCartao;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJLancamentoCartao no Banco de Dados.
            /// </summary>
            /// <param name="pCRJLancamentoCartao">Objeto do Tipo CRJLancamentoCartao que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJLancamentoCartao pCRJLancamentoCartao)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJLancamentoCartao);

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdCartao", DbType.Int32, pCRJLancamentoCartao.IdCartao);
                    db.AddInParameter(dbCommand, "IdLancador", DbType.Int32, pCRJLancamentoCartao.IdLancador);
                    db.AddInParameter(dbCommand,"Valor", DbType.Currency, pCRJLancamentoCartao.Valor);
                    db.AddInParameter(dbCommand,"DataLancamento", DbType.DateTime, DateTime.Now);
                    db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJLancamentoCartao.Descricao);


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
            /// Método que Altera um CRJLancamentoCartao no Banco de Dados.
            /// </summary>
            /// <param name="pCRJLancamentoCartao">Objeto do Tipo CRJLancamentoCartao que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJLancamentoCartao pCRJLancamentoCartao)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJLancamentoCartao);
                

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdLancamentoCartao", DbType.Int32, pCRJLancamentoCartao.IdLancamentoCartao);
                    db.AddInParameter(dbCommand,"IdCartao", DbType.Int32, pCRJLancamentoCartao.IdCartao);
                    db.AddInParameter(dbCommand, "IdLancador", DbType.Int32, pCRJLancamentoCartao.IdLancador);
                    db.AddInParameter(dbCommand,"Valor", DbType.Currency, pCRJLancamentoCartao.Valor);
                    db.AddInParameter(dbCommand,"DataLancamento", DbType.DateTime, pCRJLancamentoCartao.DataLancamento);

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
            /// Método que Exclui um CRJLancamentoCartao no Banco de Dados.
            /// </summary>
            /// <param name="pCRJLancamentoCartao">Objeto do Tipo CRJLancamentoCartao que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int pIdLancamentoCartao)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao3"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdLancamentoCartao", DbType.Int32, pIdLancamentoCartao);

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
            /// Método que retorna todos os CRJLancamentoCartao do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJLancamentoCartao contendo os CRJLancamentoCartao do Banco de Dados.</returns>
            public List<CRJLancamentoCartao> ObterCRJLancamentoCartao()
            {
                //Instânciando a Lista Tipada.
                List<CRJLancamentoCartao> objCRJLancamentoCartaoColecao = new List<CRJLancamentoCartao>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJLancamentoCartao = ds.Tables[0];

                            for (int i = 0; i < dtCRJLancamentoCartao.Rows.Count; i++)
                            {
                                CRJLancamentoCartao objCRJLancamentoCartao = PopularEntidade(dtCRJLancamentoCartao, i);
                                objCRJLancamentoCartaoColecao.Add(objCRJLancamentoCartao);
                                objCRJLancamentoCartao = null;
                            }
                        }
                    }
                }

                return objCRJLancamentoCartaoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJLancamentoCartao do Banco de Dados.
            /// </summary>
            /// <param name="pIdLancamentoCartao">IdLancamentoCartao da CRJLancamentoCartao que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJLancamentoCartao contendo os CRJLancamentoCartao do Banco de Dados.</returns>
            public List<CRJLancamentoCartao> ObterCRJLancamentoCartao(int pIdLancamentoCartao)
            {
                //Instânciando a Lista Tipada.
                List<CRJLancamentoCartao> objCRJLancamentoCartaoColecao = new List<CRJLancamentoCartao>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"IdLancamentoCartao", DbType.Int32, pIdLancamentoCartao);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJLancamentoCartao = ds.Tables[0];

                            for (int i = 0; i < dtCRJLancamentoCartao.Rows.Count; i++)
                            {
                                CRJLancamentoCartao objCRJLancamentoCartao = PopularEntidade(dtCRJLancamentoCartao, i);
                                objCRJLancamentoCartaoColecao.Add(objCRJLancamentoCartao);
                                objCRJLancamentoCartao = null;
                            }
                        }
                    }
                }

                return  objCRJLancamentoCartaoColecao;
            }


            /// <summary>
            /// Método que retorna os CRJLancamentoCartao do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJLancamentoCartao contendo os CRJLancamentoCartao do Banco de Dados.</returns>
            public List<CRJLancamentoCartao> ObterCRJLancamentoCartao(string pString)
            {
                //Instânciando a Lista Tipada.
                List<CRJLancamentoCartao> objCRJLancamentoCartaoColecao = new List<CRJLancamentoCartao>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao6"))
                {
                    //Parâmetros da Stored Procedure.
                    //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                    db.AddInParameter(dbCommand,"<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJLancamentoCartao = ds.Tables[0];

                            for (int i = 0; i < dtCRJLancamentoCartao.Rows.Count; i++)
                            {
                                CRJLancamentoCartao objCRJLancamentoCartao = PopularEntidade(dtCRJLancamentoCartao, i);
                                objCRJLancamentoCartaoColecao.Add(objCRJLancamentoCartao);
                                objCRJLancamentoCartao = null;
                            }
                        }
                    }
                }

                return objCRJLancamentoCartaoColecao;
            }

            /// <summary>
            /// Método que retorna os CRJPessoa do Banco de Dados.
            /// </summary>
            /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
            public DataTable ObterCRJLancamentoCartao(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null)
            {

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao6"))
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
            public DataTable ObterCRJLancamentoCartao2(int idCartao)
            {
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJLancamentoCartao7"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdCartao", DbType.Int32, idCartao);

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
