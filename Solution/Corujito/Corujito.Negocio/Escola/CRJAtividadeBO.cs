using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Corujito.Entidade.Escola;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio.Escola
{
    public class CRJAtividadeBO
    {
        private static CRJAtividade PopularEntidade(DataTable dtCRJAtividade, int i)
        {
            //Criando um objeto do tipo CRJAtividade.
            CRJAtividade objCRJAtividade = new CRJAtividade();

            if (dtCRJAtividade.Columns.Contains("IdAtividade"))
            {
                if (dtCRJAtividade.Rows[i]["IdAtividade"] != DBNull.Value)
                {
                    objCRJAtividade.IdAtividade = Convert.ToInt16(dtCRJAtividade.Rows[i]["IdAtividade"].ToString());
                }
            }


            if (dtCRJAtividade.Columns.Contains("NomeAtividade"))
            {

                if (dtCRJAtividade.Rows[i]["NomeAtividade"] != DBNull.Value)
                {
                    objCRJAtividade.NomeAtividade = dtCRJAtividade.Rows[i]["NomeAtividade"].ToString();
                }
            }

            objCRJAtividade.TipoAtividade = new CRJTipoAtividade();

            if (dtCRJAtividade.Columns.Contains("IdTipoAtividade"))
            {

                if (dtCRJAtividade.Rows[i]["IdTipoAtividade"] != DBNull.Value)
                {
                    int IdTipoAtividade = Convert.ToInt16(dtCRJAtividade.Rows[i]["IdTipoAtividade"]);
                    objCRJAtividade.TipoAtividade = (new CRJTipoAtividadeBO().ObterCRJTipoAtividade(null, IdTipoAtividade));
                }
            }


            if (dtCRJAtividade.Columns.Contains("IdProfXMatxEns"))
            {
                if (dtCRJAtividade.Rows[i]["IdProfXMatxEns"] != DBNull.Value)
                {
                    objCRJAtividade.IdProfXMatxEns = Convert.ToInt16(dtCRJAtividade.Rows[i]["IdProfXMatxEns"]);
                }
            }

            if (dtCRJAtividade.Columns.Contains("Datainicial"))
            {
                if (dtCRJAtividade.Rows[i]["Datainicial"] != DBNull.Value)
                {
                    objCRJAtividade.Datainicial = Convert.ToDateTime(dtCRJAtividade.Rows[i]["Datainicial"]);
                }
            }

            if (dtCRJAtividade.Columns.Contains("DataFinal"))
            {
                if (dtCRJAtividade.Rows[i]["DataFinal"] != DBNull.Value)
                {
                    objCRJAtividade.DataFinal = Convert.ToDateTime(dtCRJAtividade.Rows[i]["DataFinal"]);
                }
            }


            if (dtCRJAtividade.Columns.Contains("Descricao"))
            {
                if (dtCRJAtividade.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJAtividade.Descricao = Convert.ToString(dtCRJAtividade.Rows[i]["Descricao"]);
                }
            }
            if (dtCRJAtividade.Columns.Contains("NomeMateria"))
            {
                if (dtCRJAtividade.Rows[i]["NomeMateria"] != DBNull.Value)
                {
                    objCRJAtividade.NomeMateria = Convert.ToString(dtCRJAtividade.Rows[i]["NomeMateria"]);
                }
            }







            return objCRJAtividade;
        }

        /// <summary>
        /// Método que Insere um CRJAtividade no Banco de Dados.
        /// </summary>
        /// <param name="pCRJAtividade">Objeto do Tipo CRJAtividade que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJAtividade pCRJAtividade, int IdUsurioLogado)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAtividade1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdTipoAtividade", DbType.Int32, pCRJAtividade.TipoAtividade.IdTipoAtividade);
                db.AddInParameter(dbCommand, "IdProfXMatXClasse", DbType.Int32, pCRJAtividade.IdProfXMatxEns);
                db.AddInParameter(dbCommand, "NomeAtividade", DbType.String, pCRJAtividade.NomeAtividade);
                db.AddInParameter(dbCommand, "Datainicial", DbType.DateTime, pCRJAtividade.Datainicial);
                db.AddInParameter(dbCommand, "DataFinal", DbType.DateTime, pCRJAtividade.DataFinal);
                db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJAtividade.Descricao);


                //Executar Comando no Banco.
                ret = db.ExecuteScalar(dbCommand);
            }

            if (ret != null && ret != DBNull.Value)
            {
                Retorno = Convert.ToString(ret);
            }
            else
            {
                Retorno = string.Empty;
            }

            int IdAtividade = 0;

            if (int.TryParse(Retorno, out IdAtividade) == true)
            {
                CRJNotaAlunoNegocio objNotaBO = new CRJNotaAlunoNegocio();
                objNotaBO.IncluirNotaAtividade(pCRJAtividade.IdProfXMatxEns, IdAtividade, IdUsurioLogado);
            }

            return Retorno;

        }

        /// <summary>
        /// Método que Altera um CRJAtividade no Banco de Dados.
        /// </summary>
        /// <param name="pCRJAtividade">Objeto do Tipo CRJAtividade que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJAtividade pCRJAtividade, int IdUsuario)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAtividade2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdAtividade", DbType.Int32, pCRJAtividade.IdAtividade);
                db.AddInParameter(dbCommand, "IdTipoAtividade", DbType.Int32, pCRJAtividade.TipoAtividade.IdTipoAtividade);
                db.AddInParameter(dbCommand, "IdProfXMatXClasse", DbType.Int32, pCRJAtividade.IdProfXMatxEns);
                db.AddInParameter(dbCommand, "NomeAtividade", DbType.String, pCRJAtividade.NomeAtividade);
                db.AddInParameter(dbCommand, "Datainicial", DbType.DateTime, pCRJAtividade.Datainicial);
                db.AddInParameter(dbCommand, "DataFinal", DbType.DateTime, pCRJAtividade.DataFinal);
                db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJAtividade.Descricao);



                //Executar Comando no Banco.
                ret = db.ExecuteScalar(dbCommand);
            }

            if (ret != null && ret != DBNull.Value)
            {
                Retorno = Convert.ToString(ret);
            }
            else
            {
                Retorno = string.Empty;
            }




            if (pCRJAtividade.IdAtividade == 0)
            {
                int IdAtividade = 0;

                if (int.TryParse(Retorno, out IdAtividade) == true)
                {
                    CRJNotaAlunoNegocio objNotaBO = new CRJNotaAlunoNegocio();
                    objNotaBO.IncluirNotaAtividade(pCRJAtividade.IdProfXMatxEns, IdAtividade, IdUsuario);
                }
            }

            return Retorno;

        }

        /// <summary>
        /// Método que Exclui um CRJAtividade no Banco de Dados.
        /// </summary>
        /// <param name="pCRJAtividade">Objeto do Tipo CRJAtividade que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int idAtividade, int IdLancador)
        {

            if (idAtividade > 0)
            {
                CRJNotaAlunoNegocio objNotaBO = new CRJNotaAlunoNegocio();
                objNotaBO.Excluir(idAtividade, IdLancador);
            }

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAtividade3"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdAtividade", DbType.Int32, idAtividade);



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

            int IdAtividade = 0;





            return Retorno;

        }

        /// <summary>
        /// Método que retorna os CRJAtividade do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJAtividade que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJAtividade contendo os CRJAtividade do Banco de Dados.</returns>

        public List<CRJAtividade> ObterCRJAtividadePorId(int IdClasse)
        {
            //Instânciando a Lista Tipada.
            List<CRJAtividade> objCRJAtividadeColecao = new List<CRJAtividade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAtividade06"))
            {
                db.AddInParameter(dbCommand, "@IdClasse", DbType.Int32, IdClasse);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJAtividade = ds.Tables[0];

                        for (int i = 0; i < dtCRJAtividade.Rows.Count; i++)
                        {
                            CRJAtividade objCRJAtividade = PopularEntidade(dtCRJAtividade, i);
                            objCRJAtividadeColecao.Add(objCRJAtividade);
                            objCRJAtividade = null;
                        }
                    }
                }
            }

            return objCRJAtividadeColecao;
        }

        public List<CRJAtividade> ObterCRJAtividadePorAluno(int IdAluno)
        {
            //Instânciando a Lista Tipada.
            List<CRJAtividade> objCRJAtividadeColecao = new List<CRJAtividade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAtividade07"))
            {
                db.AddInParameter(dbCommand, "IdAluno", DbType.Int32, IdAluno);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJAtividade = ds.Tables[0];

                        for (int i = 0; i < dtCRJAtividade.Rows.Count; i++)
                        {
                            CRJAtividade objCRJAtividade = PopularEntidade(dtCRJAtividade, i);
                            objCRJAtividadeColecao.Add(objCRJAtividade);
                            objCRJAtividade = null;
                        }
                    }
                }
            }

            return objCRJAtividadeColecao;
        }


    }
}
