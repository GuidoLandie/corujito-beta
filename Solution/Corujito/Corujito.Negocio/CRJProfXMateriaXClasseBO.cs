using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Corujito.Entidade.Escola;
using Corujito.Negocio.Escola;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio
{
    public class CRJProfXMateriaXClasseBO
    {
        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJProfXMateriaXClasse">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJProfXMateriaXClasse PopularEntidade(DataTable dtCRJProfXMateriaXClasse, int i)
        {
            //Criando um objeto do tipo CRJProfXMateriaXClasse.
            CRJProfXMateriaXClasse objCRJProfXMateriaXClasse = new CRJProfXMateriaXClasse();

            if (dtCRJProfXMateriaXClasse.Columns.Contains("IdProfXMatXClasse"))
            {
                if (dtCRJProfXMateriaXClasse.Rows[i]["IdProfXMatXClasse"] != DBNull.Value)
                {
                    objCRJProfXMateriaXClasse.idProfXMateriaXClasse = Convert.ToInt32(dtCRJProfXMateriaXClasse.Rows[i]["IdProfXMatXClasse"].ToString());
                }
            }

            if (dtCRJProfXMateriaXClasse.Columns.Contains("IdPessoa"))
            {
                if (dtCRJProfXMateriaXClasse.Rows[i]["IdPessoa"] != DBNull.Value)
                {
                    int IdPessoa = Convert.ToInt32(dtCRJProfXMateriaXClasse.Rows[i]["IdPessoa"].ToString());

                    objCRJProfXMateriaXClasse.Pessoa = (new CRJPessoaNegocio().ObterCRJPessoaPorId(IdPessoa));
                }
            }

            if (dtCRJProfXMateriaXClasse.Columns.Contains("IdClasse"))
            {
                if (dtCRJProfXMateriaXClasse.Rows[i]["IdClasse"] != DBNull.Value)
                {
                    int IdClasse = Convert.ToInt32(dtCRJProfXMateriaXClasse.Rows[i]["IdClasse"].ToString());

                    objCRJProfXMateriaXClasse.Classe = (new CRJClassesNegocio().ObterCRJClasses(IdClasse));

                }
            }

            if (dtCRJProfXMateriaXClasse.Columns.Contains("IdMateria"))
            {
                if (dtCRJProfXMateriaXClasse.Rows[i]["IdMateria"] != DBNull.Value)
                {
                    int IdMateria = Convert.ToInt32(dtCRJProfXMateriaXClasse.Rows[i]["IdMateria"].ToString());

                    objCRJProfXMateriaXClasse.Materia = (new CRJMateriaNegocio().ObterCRJMateriaPorID(IdMateria));
                }
            }




            return objCRJProfXMateriaXClasse;
        }

        /// <summary>
        /// Método que Insere um CRJProfXMateriaXClasse no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProfXMateriaXClasse">Objeto do Tipo CRJProfXMateriaXClasse que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJProfXMateriaXClasse pCRJProfXMateriaXClasse)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProfXMateriaXClasse;1"))
            {
                //Parâmetros da Stored Procedure.
                //db.AddInParameter(dbCommand, "IdTipoProduto", DbType.Int32, pCRJProfXMateriaXClasse.Tipo.IdTipoProduto);
                //db.AddInParameter(dbCommand, "CodBarra", DbType.String, pCRJProfXMateriaXClasse.Cod_Barra);
                //db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJProfXMateriaXClasse.Nome);
                //db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJProfXMateriaXClasse.Descricao);
                //db.AddInParameter(dbCommand, "Quantidade", DbType.Int32, pCRJProfXMateriaXClasse.Quantidade);
                //db.AddInParameter(dbCommand, "Preco", DbType.Double, pCRJProfXMateriaXClasse.Preco);
                //db.AddInParameter(dbCommand, "IdStatus", DbType.Int32, pCRJProfXMateriaXClasse.Status.IdStatus);


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
        /// Método que Altera um CRJProfXMateriaXClasse no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProfXMateriaXClasse">Objeto do Tipo CRJProfXMateriaXClasse que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJProfXMateriaXClasse pCRJProfXMateriaXClasse)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProfXMateriaXClasse;2"))
            {
                //Parâmetros da Stored Procedure.
                //db.AddInParameter(dbCommand, "IdProduto", DbType.Double, pCRJProfXMateriaXClasse.IdProduto);
                //db.AddInParameter(dbCommand, "IdTipoProduto", DbType.Int32, pCRJProfXMateriaXClasse.Tipo.IdTipoProduto);
                //db.AddInParameter(dbCommand, "CodBarra", DbType.String, pCRJProfXMateriaXClasse.Cod_Barra);
                //db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJProfXMateriaXClasse.Nome);
                //db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJProfXMateriaXClasse.Descricao);
                //db.AddInParameter(dbCommand, "Quantidade", DbType.Int32, pCRJProfXMateriaXClasse.Quantidade);
                //db.AddInParameter(dbCommand, "Preco", DbType.Double, pCRJProfXMateriaXClasse.Preco);
                //db.AddInParameter(dbCommand, "IdStatus", DbType.Boolean, pCRJProfXMateriaXClasse.Status.IdStatus);


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
        /// Método que Exclui um CRJProfXMateriaXClasse no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProfXMateriaXClasse">Objeto do Tipo CRJProfXMateriaXClasse que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int pIdProduto)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProfXMateriaXClasse;3"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdProduto", DbType.Int32, pIdProduto);


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
        /// Método que retorna os CRJProfXMateriaXClasse do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJProfXMateriaXClasse que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJProfXMateriaXClasse contendo os CRJProfXMateriaXClasse do Banco de Dados.</returns>
        public List<CRJProfXMateriaXClasse> ObterCRJProfXMateriaXClasse(string Nome = null, int? IdTipoProduto = null, int? IdStatus = null)
        {
            //Instânciando a Lista Tipada.
            List<CRJProfXMateriaXClasse> objCRJProfXMateriaXClasseColecao = new List<CRJProfXMateriaXClasse>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProfXMateriaXClasse;4"))
            {
                db.AddInParameter(dbCommand, "@Nome", DbType.String, Nome);
                db.AddInParameter(dbCommand, "@IdTipoProduto", DbType.Int16, IdTipoProduto);
                db.AddInParameter(dbCommand, "@IdStatus", DbType.Int16, IdStatus);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJProfXMateriaXClasse = ds.Tables[0];

                        for (int i = 0; i < dtCRJProfXMateriaXClasse.Rows.Count; i++)
                        {
                            CRJProfXMateriaXClasse objCRJProfXMateriaXClasse = PopularEntidade(dtCRJProfXMateriaXClasse, i);
                            objCRJProfXMateriaXClasseColecao.Add(objCRJProfXMateriaXClasse);
                            objCRJProfXMateriaXClasse = null;
                        }
                    }
                }
            }

            return objCRJProfXMateriaXClasseColecao;
        }

        /// <summary>
        /// Método que retorna os CRJProfXMateriaXClasse do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJProfXMateriaXClasse que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJProfXMateriaXClasse contendo os CRJProfXMateriaXClasse do Banco de Dados.</returns>
        public List<CRJProfXMateriaXClasse> ObterCRJProfXMateriaXClassePorProfessor(int IdProfessor)
        {
            //Instânciando a Lista Tipada.
            List<CRJProfXMateriaXClasse> objCRJProfXMateriaXClasseColecao = new List<CRJProfXMateriaXClasse>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProfxMatXClasse;4"))
            {
                db.AddInParameter(dbCommand, "IdProfessor", DbType.Int16, IdProfessor);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJProfXMateriaXClasse = ds.Tables[0];

                        for (int i = 0; i < dtCRJProfXMateriaXClasse.Rows.Count; i++)
                        {
                            CRJProfXMateriaXClasse objCRJProfXMateriaXClasse = PopularEntidade(dtCRJProfXMateriaXClasse, i);
                            objCRJProfXMateriaXClasseColecao.Add(objCRJProfXMateriaXClasse);
                            objCRJProfXMateriaXClasse = null;
                        }
                    }
                }
            }

            return objCRJProfXMateriaXClasseColecao;
        }

        public CRJProfXMateriaXClasse ObterCRJProfXMateriaXClassePorId(int idProfXMateriaXClasse)
        {
            //Instânciando a Lista Tipada.
            List<CRJProfXMateriaXClasse> objCRJProfXMateriaXClasseColecao = new List<CRJProfXMateriaXClasse>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProfXMateriaXClasse;05"))
            {
                db.AddInParameter(dbCommand, "@IdProduto", DbType.Int32, idProfXMateriaXClasse);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJProfXMateriaXClasse = ds.Tables[0];

                        for (int i = 0; i < dtCRJProfXMateriaXClasse.Rows.Count; i++)
                        {
                            CRJProfXMateriaXClasse objCRJProfXMateriaXClasse = PopularEntidade(dtCRJProfXMateriaXClasse, i);
                            objCRJProfXMateriaXClasseColecao.Add(objCRJProfXMateriaXClasse);
                            objCRJProfXMateriaXClasse = null;
                        }
                    }
                }
            }
            if (objCRJProfXMateriaXClasseColecao.Count > 0)
            {
                return objCRJProfXMateriaXClasseColecao[0];

            }
            else
            {
                return null;
            }


        }
    }
}
