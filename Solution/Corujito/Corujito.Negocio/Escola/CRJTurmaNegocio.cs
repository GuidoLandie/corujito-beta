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


    public class CRJTurmaNegocio
    {


        #region Métodos Privados


            /// <summary>
            /// Validar informações os dados enviados pelo usuário.
            /// </summary>
            /// <param name="pCRJTurma">Objeto do Tipo CRJTurma que será armazenado no Banco de Dados.</param>
            /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
            private string Validar(CRJTurma pCRJTurma)
            {
                //Declarando e Instanciando a DLL Utilitarios.
                 


                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
                //Validar Obrigatoriedade do campo idTurma.
                if (pCRJTurma.idTurma == null)
                {
                    return "Campo idTurma não pode ser vazio.";
                }
                
                // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

                //Validar se o campo DescTurma possui mais caracteres do que o permitido.
                if (pCRJTurma.DescTurma.Length > 255)
                {
                    return "Campo DescTurma possui mais caracteres do que o permitido.";
                }


                //Finalizando a DLL Utilitario.
                 

                //Se não houveram inconsistências retorna Null.
                return null;
            }


            /// <summary>
            /// Popular a Entidade.
            /// </summary>
            /// <param name="dtCRJTurma">Datatable contendo os dados.</param>
            /// <param name="i">Índice no DataTable</param>
            /// <returns>Entidade Populada.</returns>
            private static CRJTurma PopularEntidade(DataTable dtCRJTurma, int i)
            {
                //Criando um objeto do tipo CRJTurma.
                CRJTurma objCRJTurma = new CRJTurma();

                if(dtCRJTurma.Columns.Contains("idTurma"))
                {
                    if (dtCRJTurma.Rows[i]["idTurma"] != DBNull.Value)
                    {
                        objCRJTurma.idTurma = Convert.ToInt32(dtCRJTurma.Rows[i]["idTurma"].ToString());
                    }
                }

                if(dtCRJTurma.Columns.Contains("DescTurma"))
                {
                    if (dtCRJTurma.Rows[i]["DescTurma"] != DBNull.Value)
                    {
                        objCRJTurma.DescTurma = Convert.ToString(dtCRJTurma.Rows[i]["DescTurma"]);
                    }
                }

                return objCRJTurma;
            }



        #endregion



        #region Métodos Públicos


            /// <summary>
            /// Método que Insere um CRJTurma no Banco de Dados.
            /// </summary>
            /// <param name="pCRJTurma">Objeto do Tipo CRJTurma que será armazenado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Incluir(CRJTurma pCRJTurma, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJTurma);

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurma1"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"DescTurma", DbType.String, pCRJTurma.DescTurma);
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
            /// Método que Altera um CRJTurma no Banco de Dados.
            /// </summary>
            /// <param name="pCRJTurma">Objeto do Tipo CRJTurma que será atualizado no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Alterar(CRJTurma pCRJTurma, string pRUUsuarioLogado)
            {
                //Chamando método que faz a Validação dos dados passados pelo usuário.
                string MensagemValidacao = Validar(pCRJTurma);
                

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

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurma2"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"idTurma", DbType.Int32, pCRJTurma.idTurma);
                    db.AddInParameter(dbCommand,"DescTurma", DbType.String, pCRJTurma.DescTurma);
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
            /// Método que Exclui um CRJTurma no Banco de Dados.
            /// </summary>
            /// <param name="pCRJTurma">Objeto do Tipo CRJTurma que será excluído no Banco de Dados.</param>
            /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
            /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
            public string Excluir(int p, string pRUUsuarioLogado)
            {

                string Retorno = string.Empty;
                object ret = null;


                //Iniciando Persistência no Banco de Dados.
                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");

                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurma3"))
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
            /// Método que retorna todos os CRJTurma do Banco de Dados.
            /// </summary>
            /// <returns>Lista Tipada da Entidade CRJTurma contendo os CRJTurma do Banco de Dados.</returns>
            public List<CRJTurma> ObterCRJTurma()
            {
                //Instânciando a Lista Tipada.
                List<CRJTurma> objCRJTurmaColecao = new List<CRJTurma>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurma4"))
                {
                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJTurma = ds.Tables[0];

                            for (int i = 0; i < dtCRJTurma.Rows.Count; i++)
                            {
                                CRJTurma objCRJTurma = PopularEntidade(dtCRJTurma, i);
                                objCRJTurmaColecao.Add(objCRJTurma);
                                objCRJTurma = null;
                            }
                        }
                    }
                }

                return objCRJTurmaColecao;
            }


            /// <summary>
            /// Método que retorna os CRJTurma do Banco de Dados.
            /// </summary>
            /// <param name="p"> da CRJTurma que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJTurma contendo os CRJTurma do Banco de Dados.</returns>
            public List<CRJTurma> ObterCRJTurma(int p)
            {
                //Instânciando a Lista Tipada.
                List<CRJTurma> objCRJTurmaColecao = new List<CRJTurma>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurma5"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand,"", DbType.Int32, p);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJTurma = ds.Tables[0];

                            for (int i = 0; i < dtCRJTurma.Rows.Count; i++)
                            {
                                CRJTurma objCRJTurma = PopularEntidade(dtCRJTurma, i);
                                objCRJTurmaColecao.Add(objCRJTurma);
                                objCRJTurma = null;
                            }
                        }
                    }
                }

                return  objCRJTurmaColecao;
            }


            /// <summary>
            /// Método que retorna os CRJTurma do Banco de Dados.
            /// </summary>
            /// <param name="pString"></param>
            /// <returns>Lista Tipada da Entidade CRJTurma contendo os CRJTurma do Banco de Dados.</returns>
            public List<CRJTurma> ObterCRJTurma(string pString)
            {
                //Instânciando a Lista Tipada.
                List<CRJTurma> objCRJTurmaColecao = new List<CRJTurma>();

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase( "BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurma6"))
                {
                    //Parâmetros da Stored Procedure.
                    //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                    db.AddInParameter(dbCommand,"<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                    using (DataSet ds = db.ExecuteDataSet(dbCommand))
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dtCRJTurma = ds.Tables[0];

                            for (int i = 0; i < dtCRJTurma.Rows.Count; i++)
                            {
                                CRJTurma objCRJTurma = PopularEntidade(dtCRJTurma, i);
                                objCRJTurmaColecao.Add(objCRJTurma);
                                objCRJTurma = null;
                            }
                        }
                    }
                }

                return objCRJTurmaColecao;
            }



        #endregion

    }


}
