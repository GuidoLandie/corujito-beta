using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio
{
    public class FuncionalidadeBO
    {
        /// <summary>
        /// Metodo que retorna todas as funcionalidades de um grupo
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns></returns>
        public List<Funcionalidade> ObterFuncionalidade(int IdGrupo)
        {
            //Instânciando a Lista Tipada.
            List<Funcionalidade> objFuncionalidadeColecao = new List<Funcionalidade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFuncionalidadeAplicacao1"))
            {
                //Parâmetros da Stored Procedure.                         
                db.AddInParameter(dbCommand, "IdGrupo", DbType.Int32, IdGrupo);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtFuncionalidade = ds.Tables[0];

                        for (int i = 0; i < dtFuncionalidade.Rows.Count; i++)
                        {
                            Funcionalidade objFuncionalidade = PopularEntidade(dtFuncionalidade, i);
                            objFuncionalidadeColecao.Add(objFuncionalidade);
                            objFuncionalidade = null;
                        }
                    }
                }
            }

            return objFuncionalidadeColecao;
        }

        /// <summary>
        /// Metodo que retorna todas as funcionalidades de um usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<Funcionalidade> ObterFuncionalidade(string Usuario)
        {
            //Instânciando a Lista Tipada.
            List<Funcionalidade> objFuncionalidadeColecao = new List<Funcionalidade>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFuncionalidadeAplicacao2"))
            {
                //Parâmetros da Stored Procedure.                         
                db.AddInParameter(dbCommand, "Usuario", DbType.String, Usuario);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtFuncionalidade = ds.Tables[0];

                        for (int i = 0; i < dtFuncionalidade.Rows.Count; i++)
                        {
                            Funcionalidade objFuncionalidade = PopularEntidade(dtFuncionalidade, i);
                            objFuncionalidadeColecao.Add(objFuncionalidade);
                            objFuncionalidade = null;
                        }
                    }
                }
            }

            return objFuncionalidadeColecao;
        }

        public string IncluirPermissaoGrupo(int IdGrupo, List<Funcionalidade> objFuncionlidades)
        {

            string retorno = ExcluirPermissaoFuncionalidadeGrupo(IdGrupo);

            int LinhasAfetadas = 0;

            if (int.TryParse(retorno, out LinhasAfetadas) == true)
            {
                return this.IncluirPermissaoFuncionalidadeGrupo(IdGrupo, objFuncionlidades);
            }
            else
                return retorno;
        }

        public string IncluirPermissaoUsuario(string usario, List<Funcionalidade> objFuncionlidades)
        {

            string retorno = this.ExcluirPermissaoFuncionaliddadeUsuario(usario);

            int LinhasAfetadas = 0;

            if (int.TryParse(retorno, out LinhasAfetadas) == true)
            {
                return this.IncluirPermissaoFuncionalidadeUsuario(usario, objFuncionlidades);
            }
            else
                return retorno;
        }

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtFuncionalidade">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static Funcionalidade PopularEntidade(DataTable dtFuncionalidade, int i)
        {
            //Criando um objeto do tipo Funcionalidade.
            Funcionalidade objFuncionalidade = new Funcionalidade();

            if (dtFuncionalidade.Columns.Contains("PossuiPermissao"))
            {
                if (dtFuncionalidade.Rows[i]["PossuiPermissao"] != DBNull.Value)
                {

                    objFuncionalidade.PossuiPermissao = Convert.ToBoolean(dtFuncionalidade.Rows[i]["PossuiPermissao"]);
                }
            }

            if (dtFuncionalidade.Columns.Contains("IdFuncionalidade"))
            {
                if (dtFuncionalidade.Rows[i]["IdFuncionalidade"] != DBNull.Value)
                {
                    objFuncionalidade.IdFuncionalidade = Convert.ToInt32(dtFuncionalidade.Rows[i]["IdFuncionalidade"].ToString());
                }
            }

            if (dtFuncionalidade.Columns.Contains("NomeAplicacao"))
            {
                if (dtFuncionalidade.Rows[i]["NomeAplicacao"] != DBNull.Value)
                {
                    objFuncionalidade.NomeAplicacao = Convert.ToString(dtFuncionalidade.Rows[i]["NomeAplicacao"].ToString());
                }
            }

            if (dtFuncionalidade.Columns.Contains("IdAplicacao"))
            {
                if (dtFuncionalidade.Rows[i]["IdAplicacao"] != DBNull.Value)
                {
                    objFuncionalidade.IdAplicacao = Convert.ToInt32(dtFuncionalidade.Rows[i]["IdAplicacao"].ToString());
                }
            }

            if (dtFuncionalidade.Columns.Contains("Descricao"))
            {
                if (dtFuncionalidade.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objFuncionalidade.Descricao = Convert.ToString(dtFuncionalidade.Rows[i]["Descricao"].ToString());
                }
            }


            return objFuncionalidade;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <param name="IdFuncionalidade"></param>
        /// <param name="IdAplicacao"></param>
        /// <returns></returns>
        protected string IncluirPermissaoFuncionalidadeGrupo(int IdGrupo, List<Funcionalidade> objFUncionalidade)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            foreach (Funcionalidade Item in objFUncionalidade)
            {
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFuncionalidadeAplicacao03"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "IdGrupo", DbType.Int32, IdGrupo);
                    db.AddInParameter(dbCommand, "IdFuncionalidade", DbType.Int32, Item.IdFuncionalidade);
                    db.AddInParameter(dbCommand, "IdAplicacao", DbType.Int32, Item.IdAplicacao);

                    //Executar Comando no Banco.
                    ret = db.ExecuteScalar(dbCommand);
                }
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
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <param name="IdFuncionalidade"></param>
        /// <param name="IdAplicacao"></param>
        /// <returns></returns>
        protected string IncluirPermissaoFuncionalidadeUsuario(string User, List<Funcionalidade> objFUncionalidade)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            foreach (Funcionalidade Item in objFUncionalidade)
            {
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFuncionalidadeAplicacao04"))
                {
                    //Parâmetros da Stored Procedure.
                    db.AddInParameter(dbCommand, "Usuario", DbType.String, User);
                    db.AddInParameter(dbCommand, "IdFuncionalidade", DbType.Int32, Item.IdFuncionalidade);
                    db.AddInParameter(dbCommand, "IdAplicacao", DbType.Int32, Item.IdAplicacao);

                    //Executar Comando no Banco.
                    ret = db.ExecuteScalar(dbCommand);
                }
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
        /// Método que Altera um Funcionalidade no Banco de Dados.
        /// </summary>
        /// <param name="pFuncionalidade">Objeto do Tipo Funcionalidade que será atualizado no Banco de Dados.</param>
        /// <param name="pRUFuncionalidadeLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        protected string ExcluirPermissaoFuncionalidadeGrupo(int IdGrupo)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFuncionalidadeAplicacao6"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdGrupo", DbType.Int32, IdGrupo);

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
        /// Método que Altera um Funcionalidade no Banco de Dados.
        /// </summary>
        /// <param name="pFuncionalidade">Objeto do Tipo Funcionalidade que será atualizado no Banco de Dados.</param>
        /// <param name="pRUFuncionalidadeLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        protected string ExcluirPermissaoFuncionaliddadeUsuario(string pUsuario)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJFuncionalidadeAplicacao5"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "Usuario", DbType.String, pUsuario);


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




    }
}
