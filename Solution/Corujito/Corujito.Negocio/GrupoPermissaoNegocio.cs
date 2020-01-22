using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Corujito.Negocio.Escola;

namespace Corujito.Negocio
{
    public class GrupoPermissaoNegocio
    {

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtGrupoPermissao">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static GrupoPermissao PopularEntidade(DataTable dtGrupoPermissao, int i)
        {
            //Criando um objeto do tipo GrupoPermissao.
            GrupoPermissao objGrupoPermissao = new GrupoPermissao();

            if (dtGrupoPermissao.Columns.Contains("IdGrupo"))
            {
                if (dtGrupoPermissao.Rows[i]["IdGrupo"] != DBNull.Value)
                {
                    objGrupoPermissao.IdGrupo = Convert.ToInt32(dtGrupoPermissao.Rows[i]["IdGrupo"].ToString());
                }
            }

            if (dtGrupoPermissao.Columns.Contains("IdEscola"))
            {
                if (dtGrupoPermissao.Rows[i]["IdEscola"] != DBNull.Value)
                {
                    objGrupoPermissao.IdEscola = Convert.ToInt32(dtGrupoPermissao.Rows[i]["IdEscola"].ToString());
                }
            }

            if (dtGrupoPermissao.Columns.Contains("Nome"))
            {
                if (dtGrupoPermissao.Rows[i]["Nome"] != DBNull.Value)
                {
                    objGrupoPermissao.Nome = Convert.ToString(dtGrupoPermissao.Rows[i]["Nome"].ToString());
                }
            }

            if (dtGrupoPermissao.Columns.Contains("Descricao"))
            {
                if (dtGrupoPermissao.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objGrupoPermissao.Descricao = Convert.ToString(dtGrupoPermissao.Rows[i]["Descricao"].ToString());
                }
            }

            if (dtGrupoPermissao.Columns.Contains("IdTipoPessoa"))
            {
                if (dtGrupoPermissao.Rows[i]["IdTipoPessoa"] != DBNull.Value)
                {
                    int IdTipoPessoa = Convert.ToInt32(dtGrupoPermissao.Rows[i]["IdTipoPessoa"].ToString());
                    objGrupoPermissao.TipoPessoa = (new CRJTipoPessoaNegocio().ObterCRJTipoPessoaPorId(IdTipoPessoa));
                }
            }


            return objGrupoPermissao;
        }

        /// <summary>
        /// Método que Insere um GrupoPermissao no Banco de Dados.
        /// </summary>
        /// <param name="pGrupoPermissao">Objeto do Tipo GrupoPermissao que será armazenado no Banco de Dados.</param>
        /// <param name="pRUGrupoPermissaoLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(GrupoPermissao pGrupoPermissao)
        {

            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJGrupoPermissao;1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdEscola", DbType.Int32, pGrupoPermissao.IdEscola);
                db.AddInParameter(dbCommand, "pNome", DbType.String, pGrupoPermissao.Nome);
                db.AddInParameter(dbCommand, "pDescricao", DbType.String, pGrupoPermissao.Descricao);
                if (pGrupoPermissao.TipoPessoa.IdTipoPessoa > 0)
                    db.AddInParameter(dbCommand, "pIdTipoPessoa", DbType.String, pGrupoPermissao.TipoPessoa.IdTipoPessoa);



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
        /// Método que Altera um GrupoPermissao no Banco de Dados.
        /// </summary>
        /// <param name="pGrupoPermissao">Objeto do Tipo GrupoPermissao que será atualizado no Banco de Dados.</param>
        /// <param name="pRUGrupoPermissaoLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(GrupoPermissao pGrupoPermissao)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJGrupoPermissao;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdGrupo", DbType.Int32, pGrupoPermissao.IdGrupo);
                db.AddInParameter(dbCommand, "pNome", DbType.String, pGrupoPermissao.Nome);
                db.AddInParameter(dbCommand, "pDescricao", DbType.String, pGrupoPermissao.Descricao);
                if (pGrupoPermissao.TipoPessoa.IdTipoPessoa > 0)
                    db.AddInParameter(dbCommand, "pIdTipoPessoa", DbType.String, pGrupoPermissao.TipoPessoa.IdTipoPessoa);

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
        /// Método que Altera um GrupoPermissao no Banco de Dados.
        /// </summary>
        /// <param name="pGrupoPermissao">Objeto do Tipo GrupoPermissao que será atualizado no Banco de Dados.</param>
        /// <param name="pRUGrupoPermissaoLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int pIdGrupo)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJGrupoPermissao;3"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdGrupo", DbType.Int32, pIdGrupo);


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
        /// Método que retorna os GrupoPermissao do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade GrupoPermissao contendo os GrupoPermissao do Banco de Dados.</returns>
        public List<GrupoPermissao> ObterGrupoPermissao(int? pIdEscola = null, int? pIdGrupo = null, string pNome = null, string pDescricao = null)
        {
            //Instânciando a Lista Tipada.
            List<GrupoPermissao> objGrupoPermissaoColecao = new List<GrupoPermissao>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJGrupoPermissao;4"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "pIdEscola", DbType.Int32, pIdEscola);
                db.AddInParameter(dbCommand, "pIdGrupo", DbType.Int32, pIdGrupo);
                db.AddInParameter(dbCommand, "pNome", DbType.String, pNome);
                db.AddInParameter(dbCommand, "pDescricao", DbType.String, pDescricao);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtGrupoPermissao = ds.Tables[0];

                        for (int i = 0; i < dtGrupoPermissao.Rows.Count; i++)
                        {
                            GrupoPermissao objGrupoPermissao = PopularEntidade(dtGrupoPermissao, i);
                            objGrupoPermissaoColecao.Add(objGrupoPermissao);
                            objGrupoPermissao = null;
                        }
                    }
                }
            }

            return objGrupoPermissaoColecao;
        }

        public GrupoPermissao ObterGrupoPermissaoPorId(int IdGrupo)
        {

            List<GrupoPermissao> listGrupo = ObterGrupoPermissao(null, IdGrupo);

            if (listGrupo != null && listGrupo.Count > 0)
                return listGrupo[0];
            else
                return null;



        }

        /// <summary>
        /// Método que Insere um GrupoPermissao no Banco de Dados.
        /// </summary>
        /// <param name="pGrupoPermissao">Objeto do Tipo GrupoPermissao que será armazenado no Banco de Dados.</param>
        /// <param name="pRUGrupoPermissaoLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string IncluirUsuarioGrupo(int IdGrupo, string Usuario)
        {

            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJGrupoPermissao;5"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdGrupo", DbType.Int32, IdGrupo);
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);


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
        /// Método que Altera um GrupoPermissao no Banco de Dados.
        /// </summary>
        /// <param name="pGrupoPermissao">Objeto do Tipo GrupoPermissao que será atualizado no Banco de Dados.</param>
        /// <param name="pRUGrupoPermissaoLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string ExcluirUsuarioGrupo(int IdGrupo, string Usuario)
        {
            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJGrupoPermissao;6"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdGrupo", DbType.Int32, IdGrupo);
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);


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





        public static string Validar(GrupoPermissao pGrupoPermissao)
        {
            string Mensagem = null;

            return Mensagem;
        }

        public string IncluirNovo(GrupoPermissao pGrupoPermissao)
        {
            string Mensagem = Validar(pGrupoPermissao);

            pGrupoPermissao.IdEscola = 1;

            if (string.IsNullOrEmpty(Mensagem))
                return this.Incluir(pGrupoPermissao);
            else
                return Mensagem;
        }

        public string AlterarGrupo(GrupoPermissao pGrupoPermissao)
        {
            string Mensagem = Validar(pGrupoPermissao);

            if (string.IsNullOrEmpty(Mensagem))
                return this.Alterar(pGrupoPermissao);
            else
                return Mensagem;

        }

        public string ExcluirGrupo(int pIdGrupo)
        {
            return this.Excluir(pIdGrupo);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public string IncluirNovoUsuarioGrupo(int IdGrupo, string Usuario)
        {
            return this.IncluirUsuarioGrupo(IdGrupo, Usuario);
        }

    }
}
