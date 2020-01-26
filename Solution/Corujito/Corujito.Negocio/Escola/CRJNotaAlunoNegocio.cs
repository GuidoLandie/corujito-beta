using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade.Escola;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Corujito.Negocio.Escola
{
    public class CRJNotaAlunoNegocio
    {
        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJNotaAluno">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJNotaAluno PopularEntidade(DataTable dtCRJNotaAluno, int i)
        {
            //Criando um objeto do tipo CRJNotaAluno.
            CRJNotaAluno objCRJNotaAluno = new CRJNotaAluno();

            if (dtCRJNotaAluno.Columns.Contains("IdNotaAluno"))
            {
                if (dtCRJNotaAluno.Rows[i]["IdNotaAluno"] != DBNull.Value)
                {
                    objCRJNotaAluno.IdNotaAluno = Convert.ToInt32(dtCRJNotaAluno.Rows[i]["IdNotaAluno"].ToString());
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("IdMatricula"))
            {
                if (dtCRJNotaAluno.Rows[i]["IdMatricula"] != DBNull.Value)
                {
                    objCRJNotaAluno.IdMatricula = Convert.ToInt32(dtCRJNotaAluno.Rows[i]["IdMatricula"].ToString());
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("IdProfXMatXClasse"))
            {
                if (dtCRJNotaAluno.Rows[i]["IdProfXMatXClasse"] != DBNull.Value)
                {
                    objCRJNotaAluno.IdProfXMatXClasse = Convert.ToInt32(dtCRJNotaAluno.Rows[i]["IdProfXMatXClasse"].ToString());
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("DataNota"))
            {
                if (dtCRJNotaAluno.Rows[i]["DataNota"] != DBNull.Value)
                {
                    objCRJNotaAluno.DataNota = Convert.ToDateTime(Convert.ToDateTime(dtCRJNotaAluno.Rows[i]["DataNota"].ToString()).ToShortDateString());
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("Nota"))
            {
                if (dtCRJNotaAluno.Rows[i]["Nota"] != DBNull.Value)
                {
                    objCRJNotaAluno.Nota = float.Parse(dtCRJNotaAluno.Rows[i]["Nota"].ToString());
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("Atribuidor"))
            {
                if (dtCRJNotaAluno.Rows[i]["Atribuidor"] != DBNull.Value)
                {
                    objCRJNotaAluno.Atribuidor = Convert.ToInt32(dtCRJNotaAluno.Rows[i]["Atribuidor"].ToString());
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("Nome"))
            {
                if (dtCRJNotaAluno.Rows[i]["Nome"] != DBNull.Value)
                {
                    objCRJNotaAluno.NomeAluno = dtCRJNotaAluno.Rows[i]["Nome"].ToString();
                }
            }

            if (dtCRJNotaAluno.Columns.Contains("Atividade"))
            {
                if (dtCRJNotaAluno.Rows[i]["Atividade"] != DBNull.Value)
                {
                    objCRJNotaAluno.Atividade = dtCRJNotaAluno.Rows[i]["Atividade"].ToString();
                }
            }

            

            return objCRJNotaAluno;
        }

        /// <summary>
        /// Método que Insere um CRJNotaAluno no Banco de Dados.
        /// </summary>
        /// <param name="pCRJNotaAluno">Objeto do Tipo CRJNotaAluno que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string IncluirNotaAtividade(int IdProfMatClasse, int IdAividade, int IdLancador)
        {

            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJNotaAluno01"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "IdProfMatClasse", DbType.Int32, IdProfMatClasse);
                db.AddInParameter(dbCommand, "IdAtividade", DbType.Int32, IdAividade);
                db.AddInParameter(dbCommand, "IdLancador", DbType.Int32, IdLancador);

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

            return Retorno;

        }

        /// <summary>
        /// Método que Altera um CRJNotaAluno no Banco de Dados.
        /// </summary>
        /// <param name="pCRJNotaAluno">Objeto do Tipo CRJNotaAluno que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(int IdNotaAluno, float Nota, int IdLancador)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJNotaAluno02"))
            {

                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdNotaAluno", DbType.Int32, IdNotaAluno);
                db.AddInParameter(dbCommand, "Nota", DbType.Double, Nota);
                db.AddInParameter(dbCommand, "IdLancador", DbType.Int32, IdLancador);

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

        public string Excluir(int IdAtividade ,int IdLancador)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJNotaAluno5"))
            {

                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdAtividade", DbType.Int32, IdAtividade);               
                db.AddInParameter(dbCommand, "IdLancador", DbType.Int32, IdLancador);

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
        /// Método que retorna os CRJNotaAluno do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJNotaAluno que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJNotaAluno contendo os CRJNotaAluno do Banco de Dados.</returns>
        public List<CRJNotaAluno> ObterCRJNotaAluno(int IdProfMatClasse)
        {
            //Instânciando a Lista Tipada.
            List<CRJNotaAluno> objCRJNotaAlunoColecao = new List<CRJNotaAluno>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJNotaAluno03"))
            {

                db.AddInParameter(dbCommand, "IdProMatClasse", DbType.Int32, IdProfMatClasse);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJNotaAluno = ds.Tables[0];

                        for (int i = 0; i < dtCRJNotaAluno.Rows.Count; i++)
                        {
                            CRJNotaAluno objCRJNotaAluno = PopularEntidade(dtCRJNotaAluno, i);
                            objCRJNotaAlunoColecao.Add(objCRJNotaAluno);
                            objCRJNotaAluno = null;
                        }
                    }
                }
            }

            return objCRJNotaAlunoColecao;
        }

        /// <summary>
        /// Método que retorna os CRJNotaAluno do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJNotaAluno que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJNotaAluno contendo os CRJNotaAluno do Banco de Dados.</returns>
        public DataTable ObterCRJNotaAlunoPorAluno(int IdAluno)
        {
            //Instânciando a Lista Tipada.
            List<CRJNotaAluno> objCRJNotaAlunoColecao = new List<CRJNotaAluno>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJNotaAluno04"))
            {

                db.AddInParameter(dbCommand, "IdAluno", DbType.Int32, IdAluno);


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
    }
}
