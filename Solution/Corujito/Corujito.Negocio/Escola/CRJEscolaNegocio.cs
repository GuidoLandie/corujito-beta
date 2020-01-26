using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using Corujito.Entidade;
using Corujito.Entidade.Escola;

namespace Corujito.Negocio.Escola
{
    public class CRJEscolaNegocio
    {     

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJEscola">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJEscola PopularEntidade(DataTable dtCRJEscola, int i)
        {
            //Criando um objeto do tipo CRJEscola.
            CRJEscola objCRJEscola = new CRJEscola();

            if (dtCRJEscola.Columns.Contains("idEscola"))
            {
                if (dtCRJEscola.Rows[i]["idEscola"] != DBNull.Value)
                {
                    objCRJEscola.idEscola = Convert.ToInt32(dtCRJEscola.Rows[i]["idEscola"].ToString());
                }
            }

            if (dtCRJEscola.Columns.Contains("Nome"))
            {
                if (dtCRJEscola.Rows[i]["Nome"] != DBNull.Value)
                {
                    objCRJEscola.Nome = Convert.ToString(dtCRJEscola.Rows[i]["Nome"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("CNPJ"))
            {
                if (dtCRJEscola.Rows[i]["CNPJ"] != DBNull.Value)
                {
                    objCRJEscola.CNPJ = Convert.ToString(dtCRJEscola.Rows[i]["CNPJ"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("InscEstadual"))
            {
                if (dtCRJEscola.Rows[i]["InscEstadual"] != DBNull.Value)
                {
                    objCRJEscola.InscEstadual = Convert.ToString(dtCRJEscola.Rows[i]["InscEstadual"]);
                }
            }


            if (dtCRJEscola.Columns.Contains("Bairro"))
            {
                if (dtCRJEscola.Rows[i]["Bairro"] != DBNull.Value)
                {
                    objCRJEscola.Bairro = Convert.ToString(dtCRJEscola.Rows[i]["Bairro"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("Cidade"))
            {
                if (dtCRJEscola.Rows[i]["Cidade"] != DBNull.Value)
                {
                    objCRJEscola.Cidade = Convert.ToString(dtCRJEscola.Rows[i]["Cidade"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("Estado"))
            {
                if (dtCRJEscola.Rows[i]["Estado"] != DBNull.Value)
                {
                    objCRJEscola.Estado = Convert.ToString(dtCRJEscola.Rows[i]["Estado"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("CEP"))
            {
                if (dtCRJEscola.Rows[i]["CEP"] != DBNull.Value)
                {
                    objCRJEscola.CEP = Convert.ToString(dtCRJEscola.Rows[i]["CEP"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("TelefonePrincipal"))
            {
                if (dtCRJEscola.Rows[i]["TelefonePrincipal"] != DBNull.Value)
                {
                    objCRJEscola.TelefonePrincipal = Convert.ToString(dtCRJEscola.Rows[i]["TelefonePrincipal"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("TelefoneSecundario"))
            {
                if (dtCRJEscola.Rows[i]["TelefoneSecundario"] != DBNull.Value)
                {
                    objCRJEscola.TelefoneSecundario = Convert.ToString(dtCRJEscola.Rows[i]["TelefoneSecundario"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("Email"))
            {
                if (dtCRJEscola.Rows[i]["Email"] != DBNull.Value)
                {
                    objCRJEscola.Email = Convert.ToString(dtCRJEscola.Rows[i]["Email"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("DataAbertura"))
            {
                if (dtCRJEscola.Rows[i]["DataAbertura"] != DBNull.Value)
                {
                    objCRJEscola.DataAbertura = Convert.ToDateTime(dtCRJEscola.Rows[i]["DataAbertura"].ToString());
                }
            }

            if (dtCRJEscola.Columns.Contains("IdStatus"))
            {
                if (dtCRJEscola.Rows[i]["IdStatus"] != DBNull.Value)
                {
                    objCRJEscola.Status = (new CRJStatusNegocio().ObterCRJStatusPorID(1)); 
                }
            }

            if (dtCRJEscola.Columns.Contains("Observacao"))
            {
                if (dtCRJEscola.Rows[i]["Observacao"] != DBNull.Value)
                {
                    objCRJEscola.Observacao = Convert.ToString(dtCRJEscola.Rows[i]["Observacao"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("Missao"))
            {
                if (dtCRJEscola.Rows[i]["Missao"] != DBNull.Value)
                {
                    objCRJEscola.Missao = Convert.ToString(dtCRJEscola.Rows[i]["Missao"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("Logradouro"))
            {
                if (dtCRJEscola.Rows[i]["Logradouro"] != DBNull.Value)
                {
                    objCRJEscola.Logradouro = Convert.ToString(dtCRJEscola.Rows[i]["Logradouro"]);
                }
            }

            if (dtCRJEscola.Columns.Contains("RazaoSocial"))
            {
                if (dtCRJEscola.Rows[i]["RazaoSocial"] != DBNull.Value)
                {
                    objCRJEscola.RazaoSocial = Convert.ToString(dtCRJEscola.Rows[i]["RazaoSocial"]);
                }
            }

            return objCRJEscola;
        }
              
        /// <summary>
        /// Método que Altera um CRJEscola no Banco de Dados.
        /// </summary>
        /// <param name="pCRJEscola">Objeto do Tipo CRJEscola que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJEscola pCRJEscola)
        {           
            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJEscola1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "idEscola", DbType.Int32, 1);

                db.AddInParameter(dbCommand, "RazaoSocial", DbType.String, pCRJEscola.RazaoSocial);
                db.AddInParameter(dbCommand, "Logradouro", DbType.String, pCRJEscola.Logradouro); 
                db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJEscola.Nome);
                db.AddInParameter(dbCommand, "CNPJ", DbType.String, pCRJEscola.CNPJ);
                db.AddInParameter(dbCommand, "InscEstadual", DbType.String, pCRJEscola.InscEstadual);

                db.AddInParameter(dbCommand, "Bairro", DbType.String, pCRJEscola.Bairro);
                db.AddInParameter(dbCommand, "Cidade", DbType.String, pCRJEscola.Cidade);
                db.AddInParameter(dbCommand, "Estado", DbType.String, pCRJEscola.Estado);
                db.AddInParameter(dbCommand, "CEP", DbType.String, pCRJEscola.CEP);
                db.AddInParameter(dbCommand, "TelefonePrincipal", DbType.String, pCRJEscola.TelefonePrincipal);
                db.AddInParameter(dbCommand, "TelefoneSecundario", DbType.String, pCRJEscola.TelefoneSecundario);
                db.AddInParameter(dbCommand, "Email", DbType.String, pCRJEscola.Email);
                db.AddInParameter(dbCommand, "DataAbertura", DbType.DateTime, pCRJEscola.DataAbertura);

                db.AddInParameter(dbCommand, "IdStatus", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "Observacao", DbType.String, pCRJEscola.Observacao);
                db.AddInParameter(dbCommand, "Missao", DbType.String, pCRJEscola.Missao);                

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
        /// Método que retorna os CRJEscola do Banco de Dados.
        /// </summary>
        /// <param name="pidEscola">idEscola da CRJEscola que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJEscola contendo os CRJEscola do Banco de Dados.</returns>
        public CRJEscola ObterCRJEscola(int pidEscola)
        {
            //Instânciando a Lista Tipada.
            List<CRJEscola> objCRJEscolaColecao = new List<CRJEscola>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJEscola02"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "p_idEscola", DbType.Int32, pidEscola);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJEscola = ds.Tables[0];

                        for (int i = 0; i < dtCRJEscola.Rows.Count; i++)
                        {
                            CRJEscola objCRJEscola = PopularEntidade(dtCRJEscola, i);
                            objCRJEscolaColecao.Add(objCRJEscola);
                            objCRJEscola = null;
                        }
                    }
                }
            }

            if (objCRJEscolaColecao.Count > 0)
                return objCRJEscolaColecao[0];
            else
                return null;
        }



    }


}
