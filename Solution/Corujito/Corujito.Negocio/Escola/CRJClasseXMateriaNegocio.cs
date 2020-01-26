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


    public class CRJClasseXMateriaNegocio
    {


        #region Métodos Privados


        /// <summary>
        /// Validar informações os dados enviados pelo usuário.
        /// </summary>
        /// <param name="pCRJClasseXMateria">Objeto do Tipo CRJClasseXMateria que será armazenado no Banco de Dados.</param>
        /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
        private string Validar(CRJClasseXMateria pCRJClasseXMateria)
        {
            //Declarando e Instanciando a DLL Utilitarios.



            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
            //Validar Obrigatoriedade do campo idClasseXMateria.
            if (pCRJClasseXMateria.idClasseXMateria == null)
            {
                return "Campo idClasseXMateria não pode ser vazio.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
            //Validar Obrigatoriedade do campo idClasses.
            if (pCRJClasseXMateria.idClasses == null)
            {
                return "Campo idClasses não pode ser vazio.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.
            //Validar Obrigatoriedade do campo idMateria.
            if (pCRJClasseXMateria.idMateria == null)
            {
                return "Campo idMateria não pode ser vazio.";
            }

            //Finalizando a DLL Utilitario.


            //Se não houveram inconsistências retorna Null.
            return null;
        }


        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJClasseXMateria">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJClasseXMateria PopularEntidade(DataTable dtCRJClasseXMateria, int i)
        {
            //Criando um objeto do tipo CRJClasseXMateria.
            CRJClasseXMateria objCRJClasseXMateria = new CRJClasseXMateria();

            if (dtCRJClasseXMateria.Columns.Contains("idClasseXMateria"))
            {
                if (dtCRJClasseXMateria.Rows[i]["idClasseXMateria"] != DBNull.Value)
                {
                    objCRJClasseXMateria.idClasseXMateria = Convert.ToInt32(dtCRJClasseXMateria.Rows[i]["idClasseXMateria"].ToString());
                }
            }

            if (dtCRJClasseXMateria.Columns.Contains("idClasses"))
            {
                if (dtCRJClasseXMateria.Rows[i]["idClasses"] != DBNull.Value)
                {
                    //objCRJClasseXMateria.idClasses = Convert.ToInt32(dtCRJClasseXMateria.Rows[i]["idClasses"].ToString());
                }
            }

            if (dtCRJClasseXMateria.Columns.Contains("idMateria"))
            {
                if (dtCRJClasseXMateria.Rows[i]["idMateria"] != DBNull.Value)
                {
                    //objCRJClasseXMateria.idMateria = Convert.ToInt32(dtCRJClasseXMateria.Rows[i]["idMateria"].ToString());
                }
            }

            return objCRJClasseXMateria;
        }



        #endregion



        #region Métodos Públicos


        /// <summary>
        /// Método que Insere um CRJClasseXMateria no Banco de Dados.
        /// </summary>
        /// <param name="pCRJClasseXMateria">Objeto do Tipo CRJClasseXMateria que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJClasseXMateria pCRJClasseXMateria, string pRUUsuarioLogado)
        {
            //Chamando método que faz a Validação dos dados passados pelo usuário.
            string MensagemValidacao = Validar(pCRJClasseXMateria);

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

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasseXMateria1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "idClasses", DbType.Int32, pCRJClasseXMateria.idClasses);
                db.AddInParameter(dbCommand, "idMateria", DbType.Int32, pCRJClasseXMateria.idMateria);
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
        /// Método que Altera um CRJClasseXMateria no Banco de Dados.
        /// </summary>
        /// <param name="pCRJClasseXMateria">Objeto do Tipo CRJClasseXMateria que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJClasseXMateria pCRJClasseXMateria, string pRUUsuarioLogado)
        {
            //Chamando método que faz a Validação dos dados passados pelo usuário.
            string MensagemValidacao = Validar(pCRJClasseXMateria);


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

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasseXMateria2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "idClasseXMateria", DbType.Int32, pCRJClasseXMateria.idClasseXMateria);
                db.AddInParameter(dbCommand, "idClasses", DbType.Int32, pCRJClasseXMateria.idClasses);
                db.AddInParameter(dbCommand, "idMateria", DbType.Int32, pCRJClasseXMateria.idMateria);
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
        /// Método que Exclui um CRJClasseXMateria no Banco de Dados.
        /// </summary>
        /// <param name="pCRJClasseXMateria">Objeto do Tipo CRJClasseXMateria que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int p, string pRUUsuarioLogado)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasseXMateria3"))
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
        /// Método que retorna todos os CRJClasseXMateria do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade CRJClasseXMateria contendo os CRJClasseXMateria do Banco de Dados.</returns>
        public List<CRJClasseXMateria> ObterCRJClasseXMateria()
        {
            //Instânciando a Lista Tipada.
            List<CRJClasseXMateria> objCRJClasseXMateriaColecao = new List<CRJClasseXMateria>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasseXMateria4"))
            {
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJClasseXMateria = ds.Tables[0];

                        for (int i = 0; i < dtCRJClasseXMateria.Rows.Count; i++)
                        {
                            CRJClasseXMateria objCRJClasseXMateria = PopularEntidade(dtCRJClasseXMateria, i);
                            objCRJClasseXMateriaColecao.Add(objCRJClasseXMateria);
                            objCRJClasseXMateria = null;
                        }
                    }
                }
            }

            return objCRJClasseXMateriaColecao;
        }


        /// <summary>
        /// Método que retorna os CRJClasseXMateria do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJClasseXMateria que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJClasseXMateria contendo os CRJClasseXMateria do Banco de Dados.</returns>
        public List<CRJClasseXMateria> ObterCRJClasseXMateria(int p)
        {
            //Instânciando a Lista Tipada.
            List<CRJClasseXMateria> objCRJClasseXMateriaColecao = new List<CRJClasseXMateria>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasseXMateria5"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "", DbType.Int32, p);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJClasseXMateria = ds.Tables[0];

                        for (int i = 0; i < dtCRJClasseXMateria.Rows.Count; i++)
                        {
                            CRJClasseXMateria objCRJClasseXMateria = PopularEntidade(dtCRJClasseXMateria, i);
                            objCRJClasseXMateriaColecao.Add(objCRJClasseXMateria);
                            objCRJClasseXMateria = null;
                        }
                    }
                }
            }

            return objCRJClasseXMateriaColecao;
        }


        /// <summary>
        /// Método que retorna os CRJClasseXMateria do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade CRJClasseXMateria contendo os CRJClasseXMateria do Banco de Dados.</returns>
        public List<CRJClasseXMateria> ObterCRJClasseXMateria(string pString)
        {
            //Instânciando a Lista Tipada.
            List<CRJClasseXMateria> objCRJClasseXMateriaColecao = new List<CRJClasseXMateria>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJClasseXMateria6"))
            {
                //Parâmetros da Stored Procedure.
                //TODO: Substitue o valor "<< INFORME O NOME DO PARAMETRO >>" pelo Nome do Parâmetro da Procedure.
                db.AddInParameter(dbCommand, "<< INFORME O NOME DO PARAMETRO >>", DbType.String, pString);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJClasseXMateria = ds.Tables[0];

                        for (int i = 0; i < dtCRJClasseXMateria.Rows.Count; i++)
                        {
                            CRJClasseXMateria objCRJClasseXMateria = PopularEntidade(dtCRJClasseXMateria, i);
                            objCRJClasseXMateriaColecao.Add(objCRJClasseXMateria);
                            objCRJClasseXMateria = null;
                        }
                    }
                }
            }

            return objCRJClasseXMateriaColecao;
        }



        #endregion

    }


}
