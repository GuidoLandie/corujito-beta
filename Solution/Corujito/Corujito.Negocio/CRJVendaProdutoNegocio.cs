using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Corujito.Entidade;
using Corujito.Negocio.Escola;
using Corujito.Entidade.Escola;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio
{
    public class CRJVendaProdutoNegocio
    {

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJVendaProduto">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJVendaProduto PopularEntidade(DataTable dtCRJVendaProduto, int i)
        {
            //Criando um objeto do tipo CRJVendaProduto.
            CRJVendaProduto objCRJVendaProduto = new CRJVendaProduto();

            if (dtCRJVendaProduto.Columns.Contains("IdVendaProduto"))
            {
                if (dtCRJVendaProduto.Rows[i]["IdVendaProduto"] != DBNull.Value)
                {
                    objCRJVendaProduto.IdVendaProduto = Convert.ToInt32(dtCRJVendaProduto.Rows[i]["IdVendaProduto"].ToString());
                }
            }

            if (dtCRJVendaProduto.Columns.Contains("IdPessoa"))
            {
                if (dtCRJVendaProduto.Rows[i]["IdPessoa"] != DBNull.Value)
                {
                    int IdPessoa = Convert.ToInt32(dtCRJVendaProduto.Rows[i]["IdPessoa"]);

                    CRJPessoaNegocio objPessoa = new CRJPessoaNegocio();

                    objCRJVendaProduto.Pessoa = objPessoa.ObterCRJPessoaPorId(IdPessoa);
                    objCRJVendaProduto.IdPessoa = IdPessoa;

                }
            }

            if (dtCRJVendaProduto.Columns.Contains("DataVenda"))
            {
                if (dtCRJVendaProduto.Rows[i]["DataVenda"] != DBNull.Value)
                {
                    objCRJVendaProduto.DataVenda = Convert.ToDateTime(dtCRJVendaProduto.Rows[i]["DataVenda"]);
                }
            }

            if (dtCRJVendaProduto.Columns.Contains("ValorTotal"))
            {
                if (dtCRJVendaProduto.Rows[i]["ValorTotal"] != DBNull.Value)
                {
                    objCRJVendaProduto.ValorTotal = Convert.ToDouble(dtCRJVendaProduto.Rows[i]["ValorTotal"].ToString());
                }
            }




            return objCRJVendaProduto;
        }

        /// <summary>
        /// Método que Insere um CRJVendaProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJVendaProduto">Objeto do Tipo CRJVendaProduto que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJVendaProduto pCRJVendaProduto, List<CRJProdutoVendido> pProdutos)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProdutoVendido;1"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "IdPessoa", DbType.String, pCRJVendaProduto.IdPessoa);
                db.AddInParameter(dbCommand, "ValorTotal", DbType.Double, pCRJVendaProduto.ValorTotal);


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

            int id = 0;

            if (int.TryParse(Retorno, out id) == true)
            {

                foreach (CRJProdutoVendido item in pProdutos)
                {
                    item.IdVendaProduto = id;
                    InserirItem(item);
                }
            }





            return Retorno;

        }

        /// <summary>
        /// Método que Altera um CRJVendaProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJVendaProduto">Objeto do Tipo CRJVendaProduto que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJVendaProduto pCRJVendaProduto)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJVendaProduto;2"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdVendaProduto", DbType.Int32, pCRJVendaProduto.IdVendaProduto);
                db.AddInParameter(dbCommand, "IdPessoa", DbType.String, pCRJVendaProduto.IdPessoa);
                db.AddInParameter(dbCommand, "DataVenda", DbType.String, pCRJVendaProduto.DataVenda);
                db.AddInParameter(dbCommand, "ValorTotal", DbType.String, pCRJVendaProduto.ValorTotal);

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
        /// Método que Exclui um CRJVendaProduto no Banco de Dados.
        /// </summary>
        /// <param name="pCRJVendaProduto">Objeto do Tipo CRJVendaProduto que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int pIdVendaProduto)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJVendaProduto;3"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdVendaProduto", DbType.Int32, pIdVendaProduto);


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
        /// Método que retorna os CRJVendaProduto do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJVendaProduto que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJVendaProduto contendo os CRJVendaProduto do Banco de Dados.</returns>
        public List<CRJVendaProduto> ObterCRJVendaProduto(string Nome = null, int? IdTipoProduto = null, int? IdStatus = null)
        {
            //Instânciando a Lista Tipada.
            List<CRJVendaProduto> objCRJVendaProdutoColecao = new List<CRJVendaProduto>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJVendaProduto;4"))
            {
                db.AddInParameter(dbCommand, "@Nome", DbType.String, Nome);
                db.AddInParameter(dbCommand, "@IdTipoProduto", DbType.Int16, IdTipoProduto);
                db.AddInParameter(dbCommand, "@IdStatus", DbType.Int16, IdStatus);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJVendaProduto = ds.Tables[0];

                        for (int i = 0; i < dtCRJVendaProduto.Rows.Count; i++)
                        {
                            CRJVendaProduto objCRJVendaProduto = PopularEntidade(dtCRJVendaProduto, i);
                            objCRJVendaProdutoColecao.Add(objCRJVendaProduto);
                            objCRJVendaProduto = null;
                        }
                    }
                }
            }

            return objCRJVendaProdutoColecao;
        }

        public CRJVendaProduto ObterCRJVendaProdutoPorId(int IdProduto)
        {
            //Instânciando a Lista Tipada.
            List<CRJVendaProduto> objCRJVendaProdutoColecao = new List<CRJVendaProduto>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJVendaProduto;05"))
            {
                db.AddInParameter(dbCommand, "@IdProduto", DbType.Int32, IdProduto);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJVendaProduto = ds.Tables[0];

                        for (int i = 0; i < dtCRJVendaProduto.Rows.Count; i++)
                        {
                            CRJVendaProduto objCRJVendaProduto = PopularEntidade(dtCRJVendaProduto, i);
                            objCRJVendaProdutoColecao.Add(objCRJVendaProduto);
                            objCRJVendaProduto = null;
                        }
                    }
                }
            }
            if (objCRJVendaProdutoColecao.Count > 0)
            {
                return objCRJVendaProdutoColecao[0];

            }
            else
            {
                return null;
            }


        }

        private void InserirItem(CRJProdutoVendido item)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProdutoVendido;6"))
            {
                //Parâmetros da Stored Procedure.

                db.AddInParameter(dbCommand, "Quantidade", DbType.Int32, item.Quantidade);
                db.AddInParameter(dbCommand, "IdVendaProduto", DbType.Int32, item.IdVendaProduto);
                db.AddInParameter(dbCommand, "IdProduto", DbType.Int16, item.IdProduto);
                db.AddInParameter(dbCommand, "Valor", DbType.Double, item.ValorTotal);



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
        }

        public DataTable ObterAlimentacaoByPessoa(int IdPessoa)
        {

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJProdutoVendido;7"))
            {
                db.AddInParameter(dbCommand, "IdPessoa", DbType.Int16, IdPessoa);
             

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJVendaProduto = ds.Tables[0];
                        return dtCRJVendaProduto;                        
                    }
                }
            }

            return new DataTable();
                     
        }

    }
}
