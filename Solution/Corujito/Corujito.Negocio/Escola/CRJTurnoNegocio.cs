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


    public class CRJTurnoNegocio
    {


        #region Métodos Privados


        /// <summary>
        /// Validar informações os dados enviados pelo usuário.
        /// </summary>
        /// <param name="pCRJTurno">Objeto do Tipo CRJTurno que será armazenado no Banco de Dados.</param>
        /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
        private string Validar(CRJTurno pCRJTurno)
        {
            //Declarando e Instanciando a DLL Utilitarios.



            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
            //Validar Obrigatoriedade do campo idTurno.
            if (pCRJTurno.idTurno == null)
            {
                return "Campo idTurno não pode ser vazio.";
            }



            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo DescTurno é um número.


            //Finalizando a DLL Utilitario.


            //Se não houveram inconsistências retorna Null.
            return null;
        }


        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJTurno">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJTurno PopularEntidade(DataTable dtCRJTurno, int i)
        {
            //Criando um objeto do tipo CRJTurno.
            CRJTurno objCRJTurno = new CRJTurno();

            if (dtCRJTurno.Columns.Contains("idTurno"))
            {
                if (dtCRJTurno.Rows[i]["idTurno"] != DBNull.Value)
                {
                    objCRJTurno.idTurno = Convert.ToInt32(dtCRJTurno.Rows[i]["idTurno"].ToString());
                }
            }

            if (dtCRJTurno.Columns.Contains("DescTurno"))
            {
                if (dtCRJTurno.Rows[i]["DescTurno"] != DBNull.Value)
                {
                    //    objCRJTurno.DescTurno = Convert.ToInt32(dtCRJTurno.Rows[i]["DescTurno"].ToString());
                }
            }

            return objCRJTurno;
        }



        #endregion



        #region Métodos Públicos


        /// <summary>
        /// Método que Insere um CRJTurno no Banco de Dados.
        /// </summary>
        /// <param name="pCRJTurno">Objeto do Tipo CRJTurno que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJTurno pCRJTurno, string pRUUsuarioLogado)
        {
            //Chamando método que faz a Validação dos dados passados pelo usuário.
            string MensagemValidacao = Validar(pCRJTurno);

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

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurno;1"))
            {
                //Parâmetros da Stored Procedure.
                // db.AddInParameter(dbCommand,"DescTurno", DbType.Int32, pCRJTurno.DescTurno);
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
        /// Método que Altera um CRJTurno no Banco de Dados.
        /// </summary>
        /// <param name="pCRJTurno">Objeto do Tipo CRJTurno que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJTurno pCRJTurno, string pRUUsuarioLogado)
        {
            //Chamando método que faz a Validação dos dados passados pelo usuário.
            string MensagemValidacao = Validar(pCRJTurno);


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

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurno;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "idTurno", DbType.Int32, pCRJTurno.idTurno);
                //db.AddInParameter(dbCommand,"DescTurno", DbType.Int32, pCRJTurno.DescTurno);
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
        /// Método que Exclui um CRJTurno no Banco de Dados.
        /// </summary>
        /// <param name="pCRJTurno">Objeto do Tipo CRJTurno que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int p, string pRUUsuarioLogado)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurno;3"))
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
        /// Método que retorna todos os CRJTurno do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade CRJTurno contendo os CRJTurno do Banco de Dados.</returns>
        public List<CRJTurno> ObterCRJTurno()
        {
            //Instânciando a Lista Tipada.
            List<CRJTurno> objCRJTurnoColecao = new List<CRJTurno>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurno;4"))
            {
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTurno = ds.Tables[0];

                        for (int i = 0; i < dtCRJTurno.Rows.Count; i++)
                        {
                            CRJTurno objCRJTurno = PopularEntidade(dtCRJTurno, i);
                            objCRJTurnoColecao.Add(objCRJTurno);
                            objCRJTurno = null;
                        }
                    }
                }
            }

            return objCRJTurnoColecao;
        }


        /// <summary>
        /// Método que retorna os CRJTurno do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJTurno que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJTurno contendo os CRJTurno do Banco de Dados.</returns>
        public CRJTurno ObterCRJTurno(int pTurno)
        {
            //Instânciando a Lista Tipada.
            List<CRJTurno> objCRJTurnoColecao = new List<CRJTurno>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurno;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdTurno", DbType.Int32, pTurno);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTurno = ds.Tables[0];

                        for (int i = 0; i < dtCRJTurno.Rows.Count; i++)
                        {
                            CRJTurno objCRJTurno = PopularEntidade(dtCRJTurno, i);
                            objCRJTurnoColecao.Add(objCRJTurno);
                            objCRJTurno = null;
                        }
                    }
                }
            }

            if (objCRJTurnoColecao.Count > 0)
                return objCRJTurnoColecao[0];
            else
                return null;
        }


        /// <summary>
        /// Método que retorna os CRJTurno do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade CRJTurno contendo os CRJTurno do Banco de Dados.</returns>
        public List<CRJTurno> ObterCRJTurno(string pString)
        {
            //Instânciando a Lista Tipada.
            List<CRJTurno> objCRJTurnoColecao = new List<CRJTurno>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJTurno;6"))
            {
                //Parâmetros da Stored Procedure.
                //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                db.AddInParameter(dbCommand, "<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJTurno = ds.Tables[0];

                        for (int i = 0; i < dtCRJTurno.Rows.Count; i++)
                        {
                            CRJTurno objCRJTurno = PopularEntidade(dtCRJTurno, i);
                            objCRJTurnoColecao.Add(objCRJTurno);
                            objCRJTurno = null;
                        }
                    }
                }
            }

            return objCRJTurnoColecao;
        }



        #endregion

    }


}
