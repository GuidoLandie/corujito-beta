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


    public class CRJEnsinoNegocio
    {


        #region Métodos Privados


        /// <summary>
        /// Validar informações os dados enviados pelo usuário.
        /// </summary>
        /// <param name="pCRJEnsino">Objeto do Tipo CRJEnsino que será armazenado no Banco de Dados.</param>
        /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
        private string Validar(CRJEnsino pCRJEnsino)
        {
            //Declarando e Instanciando a DLL Utilitarios.



            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
            //Validar Obrigatoriedade do campo idEnsino.
            if (pCRJEnsino.idEnsino == null)
            {
                return "Campo idEnsino não pode ser vazio.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
            //Validar Obrigatoriedade do campo idEscola.
            if (pCRJEnsino.idEscola == null)
            {
                return "Campo idEscola não pode ser vazio.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo DescEnsino possui mais caracteres do que o permitido.
            if (pCRJEnsino.DescEnsino.Length > 45)
            {
                return "Campo DescEnsino possui mais caracteres do que o permitido.";
            }

            //Validar Obrigatoriedade do campo DescEnsino.
            if (pCRJEnsino.DescEnsino == null || pCRJEnsino.DescEnsino.ToString() == "")
            {
                return "Campo DescEnsino não pode ser vazio.";
            }


            //Finalizando a DLL Utilitario.


            //Se não houveram inconsistências retorna Null.
            return null;
        }


        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJEnsino">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJEnsino PopularEntidade(DataTable dtCRJEnsino, int i)
        {
            //Criando um objeto do tipo CRJEnsino.
            CRJEnsino objCRJEnsino = new CRJEnsino();

            if (dtCRJEnsino.Columns.Contains("idEnsino"))
            {
                if (dtCRJEnsino.Rows[i]["idEnsino"] != DBNull.Value)
                {
                    objCRJEnsino.idEnsino = Convert.ToInt32(dtCRJEnsino.Rows[i]["idEnsino"].ToString());
                }
            }

            if (dtCRJEnsino.Columns.Contains("idEscola"))
            {
                if (dtCRJEnsino.Rows[i]["idEscola"] != DBNull.Value)
                {
                    objCRJEnsino.idEscola = new CRJEscola();
                }
            }

            if (dtCRJEnsino.Columns.Contains("Descricao"))
            {
                if (dtCRJEnsino.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJEnsino.DescEnsino = Convert.ToString(dtCRJEnsino.Rows[i]["Descricao"]);
                }
            }

            return objCRJEnsino;
        }



        #endregion



        #region Métodos Públicos

        /// <summary>
        /// Método que retorna todos os CRJEnsino do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade CRJEnsino contendo os CRJEnsino do Banco de Dados.</returns>
        public List<CRJEnsino> ObterCRJEnsino()
        {
            //Instânciando a Lista Tipada.
            List<CRJEnsino> objCRJEnsinoColecao = new List<CRJEnsino>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJEnsino;01"))
            {
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJEnsino = ds.Tables[0];

                        for (int i = 0; i < dtCRJEnsino.Rows.Count; i++)
                        {
                            CRJEnsino objCRJEnsino = PopularEntidade(dtCRJEnsino, i);
                            objCRJEnsinoColecao.Add(objCRJEnsino);
                            objCRJEnsino = null;
                        }
                    }
                }
            }

            return objCRJEnsinoColecao;
        }

        public List<CRJEnsino> ObterCRJEnsinoxProfessor(int pIdProfessor)
        {
            //Instânciando a Lista Tipada.
            List<CRJEnsino> objCRJEnsinoColecao = new List<CRJEnsino>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJEnsino;01"))
            {
                //db.AddInParameter(dbCommand, "@Idprofessor", DbType.Int32, pIdProfessor);
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJEnsino = ds.Tables[0];

                        for (int i = 0; i < dtCRJEnsino.Rows.Count; i++)
                        {
                            CRJEnsino objCRJEnsino = PopularEntidade(dtCRJEnsino, i);
                            objCRJEnsinoColecao.Add(objCRJEnsino);
                            objCRJEnsino = null;
                        }
                    }
                }
            }

            return objCRJEnsinoColecao;
        }
        

        /// <summary>
        /// Método que retorna os CRJEnsino do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJEnsino que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJEnsino contendo os CRJEnsino do Banco de Dados.</returns>
        public CRJEnsino ObterCRJEnsino(int pIdEnsino)
        {
            //Instânciando a Lista Tipada.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJEnsino;1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pidEnsino", DbType.Int32, pIdEnsino);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJEnsino = ds.Tables[0];

                        for (int i = 0; i < dtCRJEnsino.Rows.Count; i++)
                        {
                            CRJEnsino objCRJEnsino = PopularEntidade(dtCRJEnsino, i);
                            return objCRJEnsino;
                        }
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Método que retorna os CRJEnsino do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade CRJEnsino contendo os CRJEnsino do Banco de Dados.</returns>
        public List<CRJEnsino> ObterCRJEnsino(string pString)
        {
            //Instânciando a Lista Tipada.
            List<CRJEnsino> objCRJEnsinoColecao = new List<CRJEnsino>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJEnsino;6"))
            {
                //Parâmetros da Stored Procedure.
                //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                db.AddInParameter(dbCommand, "<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJEnsino = ds.Tables[0];

                        for (int i = 0; i < dtCRJEnsino.Rows.Count; i++)
                        {
                            CRJEnsino objCRJEnsino = PopularEntidade(dtCRJEnsino, i);
                            objCRJEnsinoColecao.Add(objCRJEnsino);
                            objCRJEnsino = null;
                        }
                    }
                }
            }

            return objCRJEnsinoColecao;
        }



        #endregion

    }


}
