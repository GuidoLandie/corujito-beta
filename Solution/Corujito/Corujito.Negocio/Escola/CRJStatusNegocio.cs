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

    public class CRJStatusNegocio
    {


        #region Métodos Privados


        /// <summary>
        /// Validar informações os dados enviados pelo usuário.
        /// </summary>
        /// <param name="pCRJStatus">Objeto do Tipo CRJStatus que será armazenado no Banco de Dados.</param>
        /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
        private string Validar(CRJStatus pCRJStatus)
        {

            //Validar se o campo Descricao possui mais caracteres do que o permitido.
            if (pCRJStatus.Descricao.Length > 50)
            {
                return "Campo Descricao possui mais caracteres do que o permitido.";
            }

            //Validar Obrigatoriedade do campo Descricao.
            if (pCRJStatus.Descricao == null || pCRJStatus.Descricao.ToString() == "")
            {
                return "Campo Descricao não pode ser vazio.";
            }


            //Finalizando a DLL Utilitario.


            //Se não houveram inconsistências retorna Null.
            return null;
        }


        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJStatus">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJStatus PopularEntidade(DataTable dtCRJStatus, int i)
        {
            //Criando um objeto do tipo CRJStatus.
            CRJStatus objCRJStatus = new CRJStatus();

            if (dtCRJStatus.Columns.Contains("IdStatus"))
            {
                if (dtCRJStatus.Rows[i]["IdStatus"] != DBNull.Value)
                {
                    objCRJStatus.IdStatus = Convert.ToInt32(dtCRJStatus.Rows[i]["IdStatus"].ToString());
                }
            }

            if (dtCRJStatus.Columns.Contains("Descricao"))
            {
                if (dtCRJStatus.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJStatus.Descricao = Convert.ToString(dtCRJStatus.Rows[i]["Descricao"]);
                }
            }

            return objCRJStatus;
        }



        #endregion



        #region Métodos Públicos


        /// <summary>
        /// Método que Insere um CRJStatus no Banco de Dados.
        /// </summary>
        /// <param name="pCRJStatus">Objeto do Tipo CRJStatus que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJStatus pCRJStatus, string pRUUsuarioLogado)
        {
            //Chamando método que faz a Validação dos dados passados pelo usuário.
            string MensagemValidacao = Validar(pCRJStatus);

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

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJStatus1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJStatus.Descricao);
                db.AddInParameter(dbCommand, "RUUsuarioLogado", DbType.String, pRUUsuarioLogado);

                //Executar Comando no Banco.
                ret = db.ExecuteNonQuery(dbCommand);
            }

            if (ret != null && ret != DBNull.Value)
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
        /// Método que Altera um CRJStatus no Banco de Dados.
        /// </summary>
        /// <param name="pCRJStatus">Objeto do Tipo CRJStatus que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJStatus pCRJStatus, string pRUUsuarioLogado)
        {
            //Chamando método que faz a Validação dos dados passados pelo usuário.
            string MensagemValidacao = Validar(pCRJStatus);


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

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJStatus2"))
            {
                //Parâmetros da Stored Procedure.
                //db.AddInParameter(dbCommand,"IdStatus", DbType.Int32, pCRJStatus.IdStatus);
                db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJStatus.Descricao);
                db.AddInParameter(dbCommand, "RUUsuarioLogado", DbType.String, pRUUsuarioLogado);

                //Executar Comando no Banco.
                ret = db.ExecuteNonQuery(dbCommand);
            }

            if (ret != null && ret != DBNull.Value)
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
        /// Método que Exclui um CRJStatus no Banco de Dados.
        /// </summary>
        /// <param name="pCRJStatus">Objeto do Tipo CRJStatus que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int p, string pRUUsuarioLogado)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJStatus3"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "", DbType.Int32, p);
                db.AddInParameter(dbCommand, "RUUsuarioLogado", DbType.String, pRUUsuarioLogado);

                //Executar Comando no Banco.
                ret = db.ExecuteNonQuery(dbCommand);
            }

            if (ret != null && ret != DBNull.Value)
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
        /// Método que retorna todos os CRJStatus do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade CRJStatus contendo os CRJStatus do Banco de Dados.</returns>
        public List<CRJStatus> ObterCRJStatus()
        {
            //Instânciando a Lista Tipada.
            List<CRJStatus> objCRJStatusColecao = new List<CRJStatus>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJStatus"))
            {
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJStatus = ds.Tables[0];

                        for (int i = 0; i < dtCRJStatus.Rows.Count; i++)
                        {
                            CRJStatus objCRJStatus = PopularEntidade(dtCRJStatus, i);
                            objCRJStatusColecao.Add(objCRJStatus);
                            objCRJStatus = null;
                        }
                    }
                }
            }

            return objCRJStatusColecao;
        }


        /// <summary>
        /// Método que retorna os CRJStatus do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJStatus que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJStatus contendo os CRJStatus do Banco de Dados.</returns>
        public CRJStatus ObterCRJStatusPorID(int p)
        {
            //Instânciando a Lista Tipada.
            List<CRJStatus> objCRJStatusColecao = new List<CRJStatus>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJStatus02"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "p_IdStatus", DbType.Int32, p);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJStatus = ds.Tables[0];

                        for (int i = 0; i < dtCRJStatus.Rows.Count; i++)
                        {
                            CRJStatus objCRJStatus = PopularEntidade(dtCRJStatus, i);
                            objCRJStatusColecao.Add(objCRJStatus);
                            objCRJStatus = null;
                        }
                    }
                }
            }

            if (objCRJStatusColecao != null && objCRJStatusColecao.Count > 0)
                return objCRJStatusColecao[0];
            else
                return null;
        }


        /// <summary>
        /// Método que retorna os CRJStatus do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade CRJStatus contendo os CRJStatus do Banco de Dados.</returns>
        public List<CRJStatus> ObterCRJStatus(string pString)
        {
            //Instânciando a Lista Tipada.
            List<CRJStatus> objCRJStatusColecao = new List<CRJStatus>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJStatus6"))
            {
                //Parâmetros da Stored Procedure.
                //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                db.AddInParameter(dbCommand, "<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJStatus = ds.Tables[0];

                        for (int i = 0; i < dtCRJStatus.Rows.Count; i++)
                        {
                            CRJStatus objCRJStatus = PopularEntidade(dtCRJStatus, i);
                            objCRJStatusColecao.Add(objCRJStatus);
                            objCRJStatus = null;
                        }
                    }
                }
            }

            return objCRJStatusColecao;
        }



        #endregion

    }


}
