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
    public class CRJFrequenciaNegocio
    {
        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJFrequencia">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJFrequencia PopularEntidade(DataTable dtCRJFrequencia, int i)
        {
            //Criando um objeto do tipo CRJFrequencia.
            CRJFrequencia objCRJFrequencia = new CRJFrequencia();

            if (dtCRJFrequencia.Columns.Contains("IdFrequencia"))
            {
                if (dtCRJFrequencia.Rows[i]["IdFrequencia"] != DBNull.Value)
                {
                    objCRJFrequencia.IdFrequencia = Convert.ToInt32(dtCRJFrequencia.Rows[i]["IdFrequencia"].ToString());
                }
            }

            if (dtCRJFrequencia.Columns.Contains("IdCRJMatricula"))
            {
                if (dtCRJFrequencia.Rows[i]["IdCRJMatricula"] != DBNull.Value)
                {
                    objCRJFrequencia.IdCRJMatricula = Convert.ToInt32(dtCRJFrequencia.Rows[i]["IdCRJMatricula"].ToString());
                }
            }

            if (dtCRJFrequencia.Columns.Contains("IdProfXMatXClasse"))
            {
                if (dtCRJFrequencia.Rows[i]["IdProfXMatXClasse"] != DBNull.Value)
                {
                    objCRJFrequencia.IdProfXMatXClasse = Convert.ToInt32(dtCRJFrequencia.Rows[i]["IdProfXMatXClasse"].ToString());
                }
            }

            if (dtCRJFrequencia.Columns.Contains("DataAula"))
            {
                if (dtCRJFrequencia.Rows[i]["DataAula"] != DBNull.Value)
                {
                    objCRJFrequencia.DataAula = Convert.ToDateTime(Convert.ToDateTime(dtCRJFrequencia.Rows[i]["DataAula"].ToString()).ToShortDateString());
                }
            }

            if (dtCRJFrequencia.Columns.Contains("Presente"))
            {
                if (dtCRJFrequencia.Rows[i]["Presente"] != DBNull.Value)
                {
                    objCRJFrequencia.Presente = Convert.ToBoolean(dtCRJFrequencia.Rows[i]["Presente"].ToString());
                }
            }

            if (dtCRJFrequencia.Columns.Contains("IdLancador"))
            {
                if (dtCRJFrequencia.Rows[i]["IdLancador"] != DBNull.Value)
                {
                    objCRJFrequencia.IdLancador = Convert.ToInt32(dtCRJFrequencia.Rows[i]["IdLancador"].ToString());
                }
            }

            if (dtCRJFrequencia.Columns.Contains("Nome"))
            {
                if (dtCRJFrequencia.Rows[i]["Nome"] != DBNull.Value)
                {
                    objCRJFrequencia.NomeAluno = dtCRJFrequencia.Rows[i]["Nome"].ToString();
                }
            }


            return objCRJFrequencia;
        }

        /// <summary>
        /// Método que Insere um CRJFrequencia no Banco de Dados.
        /// </summary>
        /// <param name="pCRJFrequencia">Objeto do Tipo CRJFrequencia que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string IncluirFrequencia(int IdProfMatClasse, DateTime DataPresenca, int IdLancador)
        {

            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFrequencia;01"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "IdProfMatClasse", DbType.Int32, IdProfMatClasse);
                db.AddInParameter(dbCommand, "DataAula", DbType.DateTime, DataPresenca);
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
        /// Método que Altera um CRJFrequencia no Banco de Dados.
        /// </summary>
        /// <param name="pCRJFrequencia">Objeto do Tipo CRJFrequencia que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(int IdFrequencia, bool Presente, int IdLancador)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFrequencia;02"))
            {

                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdFrequencia", DbType.Int32, IdFrequencia);
                db.AddInParameter(dbCommand, "Presente", DbType.Boolean, Presente);
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
        /// Método que retorna os CRJFrequencia do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJFrequencia que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJFrequencia contendo os CRJFrequencia do Banco de Dados.</returns>
        public List<CRJFrequencia> ObterCRJFrequencia(int IdProfMatClasse)
        {
            //Instânciando a Lista Tipada.
            List<CRJFrequencia> objCRJFrequenciaColecao = new List<CRJFrequencia>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFrequencia;03"))
            {

                db.AddInParameter(dbCommand, "IdProMatClasse", DbType.Int32, IdProfMatClasse);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJFrequencia = ds.Tables[0];

                        for (int i = 0; i < dtCRJFrequencia.Rows.Count; i++)
                        {
                            CRJFrequencia objCRJFrequencia = PopularEntidade(dtCRJFrequencia, i);
                            objCRJFrequenciaColecao.Add(objCRJFrequencia);
                            objCRJFrequencia = null;
                        }
                    }
                }
            }

            return objCRJFrequenciaColecao;
        }

        /// <summary>
        /// Método que retorna os CRJFrequencia do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJFrequencia que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJFrequencia contendo os CRJFrequencia do Banco de Dados.</returns>
        public DataTable ObterCRJFrequenciaPorAluno(int IdAluno)
        {
            //Instânciando a Lista Tipada.
            List<CRJFrequencia> objCRJFrequenciaColecao = new List<CRJFrequencia>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFrequencia;05"))
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
