using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;

namespace Corujito.Negocio
{
    public class UsuarioNegocio
    {
        public Usuario EfetuarLoginUsuario(string UserLogin, string UserPassword)
        {
            List<Usuario> User = new List<Usuario>();

            User = ObterUsuario(UserLogin, UserPassword);

            if ((User != null && User.Count == 1))
            {
                return User[0];
            }

            return null;

        }

        #region Métodos Privados

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtUsuario">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static Usuario PopularEntidade(DataTable dtUsuario, int i)
        {
            //Criando um objeto do tipo Usuario.
            Usuario objUsuario = new Usuario();

            if (dtUsuario.Columns.Contains("Ativo"))
            {
                if (dtUsuario.Rows[i]["Ativo"] != DBNull.Value)
                {
                    objUsuario.Ativo = Convert.ToBoolean(dtUsuario.Rows[i]["Ativo"]);
                }
            }

            if (dtUsuario.Columns.Contains("IdPessoa"))
            {
                if (dtUsuario.Rows[i]["IdPessoa"] != DBNull.Value)
                {
                    int IdPessoa = Convert.ToInt32(dtUsuario.Rows[i]["IdPessoa"].ToString());

                    objUsuario.DadosPessoais = new CRJPessoa();

                    CRJPessoaNegocio objPessoaDAO = new CRJPessoaNegocio();
                    objUsuario.DadosPessoais = objPessoaDAO.ObterCRJPessoaPorId(IdPessoa);

                }
            }

            if (dtUsuario.Columns.Contains("Usuario"))
            {
                if (dtUsuario.Rows[i]["Usuario"] != DBNull.Value)
                {
                    objUsuario.UserLogin = Convert.ToString(dtUsuario.Rows[i]["Usuario"].ToString());
                }
            }


            return objUsuario;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Método que Insere um Usuario no Banco de Dados.
        /// </summary>
        /// <param name="pUsuario">Objeto do Tipo Usuario que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        private string Incluir(Usuario pUsuario)
        {

            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJUsuarios;1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, pUsuario.UserLogin);
                db.AddInParameter(dbCommand, "pIdPessoa", DbType.Int32, pUsuario.DadosPessoais.IdPessoa);
                db.AddInParameter(dbCommand, "pSenha", DbType.String, pUsuario.Senha);
                db.AddInParameter(dbCommand, "pAtivo", DbType.Boolean, true);

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

        public string IncluirNovoUsuario(CRJPessoa pPessoa, string pSenha)
        {
            if (pPessoa != null && pPessoa.IdPessoa > 0)
            {
                Usuario pUsuario = new Usuario();
                pUsuario.Ativo = true;
                pUsuario.DadosPessoais = pPessoa;
                pUsuario.Senha = pSenha;
                pUsuario.UserLogin = pPessoa.Email;

                return Incluir(pUsuario);
            }
            else
            {
                return "Não se pode fazer um cadastro de um usuário que não existe.";
            }
        }

        /// <summary>
        /// Método que Altera um Usuario no Banco de Dados.
        /// </summary>
        /// <param name="pUsuario">Objeto do Tipo Usuario que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string AlterarSenha(Usuario pUsuario)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJUsuarios;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, pUsuario.UserLogin);
                db.AddInParameter(dbCommand, "pSenha", DbType.String, pUsuario.Senha);
                db.AddInParameter(dbCommand, "pAtivo", DbType.Boolean, pUsuario.Ativo);

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
        /// 
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public string DesativarUsuario(Usuario pUsuario)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public string AtivarUsuario(Usuario pUsuario)
        {
            return null;
        }

        /// <summary>
        /// Método que retorna os Usuario do Banco de Dados.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns>Lista Tipada da Entidade Usuario contendo os Usuario do Banco de Dados.</returns>
        public List<Usuario> ObterUsuario(string UserLogin, string UserPassword)
        {
            //Instânciando a Lista Tipada.
            List<Usuario> objUsuarioColecao = new List<Usuario>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJUsuarios03"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, UserLogin);
                db.AddInParameter(dbCommand, "pSenha", DbType.String, UserPassword);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtUsuario = ds.Tables[0];

                        for (int i = 0; i < dtUsuario.Rows.Count; i++)
                        {
                            Usuario objUsuario = PopularEntidade(dtUsuario, i);
                            objUsuarioColecao.Add(objUsuario);
                            objUsuario = null;
                        }
                    }
                }
            }

            return objUsuarioColecao;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Idgrupo"></param>
        /// <returns></returns>
        public List<Usuario> ObterUsuarioFromGrupo(int Idgrupo)
        {
            //Instânciando a Lista Tipada.
            List<Usuario> objUsuarioColecao = new List<Usuario>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJUsuarios;4"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "pIdGrupo", DbType.Int32, Idgrupo);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtUsuario = ds.Tables[0];

                        for (int i = 0; i < dtUsuario.Rows.Count; i++)
                        {
                            Usuario objUsuario = PopularEntidade(dtUsuario, i);
                            objUsuarioColecao.Add(objUsuario);
                            objUsuario = null;
                        }
                    }
                }
            }

            return objUsuarioColecao;
        }



        #endregion
    }
}
