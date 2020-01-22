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
    public class CRJProdutoNegocio
    {

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJProduto">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJProduto PopularEntidade(DataTable dtCRJProduto, int i)
        {
            //Criando um objeto do tipo CRJProduto.
            CRJProduto objCRJProduto = new CRJProduto();

            if (dtCRJProduto.Columns.Contains("IdProduto"))
            {
                if (dtCRJProduto.Rows[i]["IdProduto"] != DBNull.Value)
                {
                    objCRJProduto.IdProduto = Convert.ToInt32(dtCRJProduto.Rows[i]["IdProduto"].ToString());
                }
            }

            if (dtCRJProduto.Columns.Contains("IdTipoProduto"))
            {
                if (dtCRJProduto.Rows[i]["IdTipoProduto"] != DBNull.Value)
                {
                    int IdTipoProduto = Convert.ToInt32(dtCRJProduto.Rows[i]["IdTipoProduto"]);

                    CRJTipoProdutoNegocio objTipoProdDAO = new CRJTipoProdutoNegocio();
                    CRJTipoProduto objTipoProduto = new CRJTipoProduto();

                    objTipoProduto = objTipoProdDAO.ObterCRJTipoProdutoPorID(IdTipoProduto);


                    objCRJProduto.Tipo = objTipoProduto;

                }
            }

            if (dtCRJProduto.Columns.Contains("Cod_Barra"))
            {
                if (dtCRJProduto.Rows[i]["Cod_Barra"] != DBNull.Value)
                {
                    objCRJProduto.Cod_Barra = Convert.ToString(dtCRJProduto.Rows[i]["Cod_Barra"]);
                }
            }

            if (dtCRJProduto.Columns.Contains("Nome"))
            {
                if (dtCRJProduto.Rows[i]["Nome"] != DBNull.Value)
                {
                    objCRJProduto.Nome = Convert.ToString(dtCRJProduto.Rows[i]["Nome"]);
                }
            }

            if (dtCRJProduto.Columns.Contains("Descricao"))
            {
                if (dtCRJProduto.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJProduto.Descricao = Convert.ToString(dtCRJProduto.Rows[i]["Descricao"]);
                }
            }

            if (dtCRJProduto.Columns.Contains("Quantidade"))
            {
                if (dtCRJProduto.Rows[i]["Quantidade"] != DBNull.Value)
                {
                    objCRJProduto.Quantidade = Convert.ToInt32(dtCRJProduto.Rows[i]["Quantidade"]);
                }
            }

            if (dtCRJProduto.Columns.Contains("Preco"))
            {
                if (dtCRJProduto.Rows[i]["Preco"] != DBNull.Value)
                {
                    objCRJProduto.Preco = float.Parse(dtCRJProduto.Rows[i]["Preco"].ToString());
                }
            }

            if (dtCRJProduto.Columns.Contains("IdStatus"))
            {
                if (dtCRJProduto.Rows[i]["IdStatus"] != DBNull.Value)
                {
                    
                    
                    int  IdStatus = Convert.ToInt32(dtCRJProduto.Rows[i]["IdStatus"]);

                    CRJStatusNegocio objStatusDAO = new CRJStatusNegocio();
                    CRJStatus objStatus = new CRJStatus();

                    objStatus = objStatusDAO.ObterCRJStatusPorID(IdStatus);


                    objCRJProduto.Status = objStatus;

                }
            }



            return objCRJProduto;
        }

        /// <summary>
        /// Método que Insere um CRJProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProduto">Objeto do Tipo CRJProduto que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJProduto pCRJProduto)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProduto;1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdTipoProduto", DbType.Int32, pCRJProduto.Tipo.IdTipoProduto);
                db.AddInParameter(dbCommand, "Cod_Barra", DbType.String, pCRJProduto.Cod_Barra);
                db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJProduto.Nome);
                db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJProduto.Descricao);
                db.AddInParameter(dbCommand, "Quantidade", DbType.Int32, pCRJProduto.Quantidade);
                db.AddInParameter(dbCommand, "Preco", DbType.Double, pCRJProduto.Preco);
                db.AddInParameter(dbCommand, "IdStatus", DbType.Int32, pCRJProduto.Status.IdStatus);


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
        /// Método que Altera um CRJProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProduto">Objeto do Tipo CRJProduto que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJProduto pCRJProduto)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProduto;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdProduto", DbType.Double, pCRJProduto.IdProduto);
                db.AddInParameter(dbCommand, "IdTipoProduto", DbType.Int32, pCRJProduto.Tipo.IdTipoProduto);
                db.AddInParameter(dbCommand, "CodBarra", DbType.String, pCRJProduto.Cod_Barra);
                db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJProduto.Nome);
                db.AddInParameter(dbCommand, "Descricao", DbType.String, pCRJProduto.Descricao);
                db.AddInParameter(dbCommand, "Quantidade", DbType.Int32, pCRJProduto.Quantidade);
                db.AddInParameter(dbCommand, "Preco", DbType.Double, pCRJProduto.Preco);
                db.AddInParameter(dbCommand, "IdStatus", DbType.Boolean, pCRJProduto.Status.IdStatus);


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
        /// Método que Exclui um CRJProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJProduto">Objeto do Tipo CRJProduto que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int pIdProduto)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProduto;3"))
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
        /// Método que retorna os CRJProduto do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJProduto que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJProduto contendo os CRJProduto do Banco de Dados.</returns>
        public List<CRJProduto> ObterCRJProduto(string Nome = null, int? IdTipoProduto = null, int? IdStatus = null)
        {
            //Instânciando a Lista Tipada.
            List<CRJProduto> objCRJProdutoColecao = new List<CRJProduto>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProduto;4"))
            {
                db.AddInParameter(dbCommand, "@Nome", DbType.String, Nome);
                db.AddInParameter(dbCommand, "@IdTipoProduto", DbType.Int16, IdTipoProduto);
                db.AddInParameter(dbCommand, "@IdStatus", DbType.Int16, IdStatus);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJProduto = ds.Tables[0];

                        for (int i = 0; i < dtCRJProduto.Rows.Count; i++)
                        {
                            CRJProduto objCRJProduto = PopularEntidade(dtCRJProduto, i);
                            objCRJProdutoColecao.Add(objCRJProduto);
                            objCRJProduto = null;
                        }
                    }
                }
            }

            return objCRJProdutoColecao;
        }

        public CRJProduto ObterCRJProdutoPorId(int IdProduto)
        {
            //Instânciando a Lista Tipada.
            List<CRJProduto> objCRJProdutoColecao = new List<CRJProduto>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProduto;05"))
            {
                db.AddInParameter(dbCommand, "@IdProduto", DbType.Int32, IdProduto);
          

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJProduto = ds.Tables[0];

                        for (int i = 0; i < dtCRJProduto.Rows.Count; i++)
                        {
                            CRJProduto objCRJProduto = PopularEntidade(dtCRJProduto, i);
                            objCRJProdutoColecao.Add(objCRJProduto);
                            objCRJProduto = null;
                        }
                    }
                }
            }
            if (objCRJProdutoColecao.Count > 0)
            {
                return objCRJProdutoColecao[0];

            }
            else
            {
                return null;
            }


        }
      
    }
}
