using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Corujito.Negocio.Escola
{
    public class CRJAlunoNegocio
    {


         /// <summary>
            /// Método que retorna os CRJPessoa do Banco de Dados.
            /// </summary>
            /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
            /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
        public DataTable ObterCRJAluno(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null, string pIdAluno = null)
            {

                Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
                using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJAluno6"))
                {
                    //Parâmetros da Stored Procedure.
                    if (!string.IsNullOrEmpty(pIdAluno))
                        db.AddInParameter(dbCommand, "pIdAluno", DbType.String, pIdAluno);

                    if (!string.IsNullOrEmpty(pNome))
                        db.AddInParameter(dbCommand, "pNome", DbType.String, pNome);

                    if (!string.IsNullOrEmpty(pEmail))
                        db.AddInParameter(dbCommand, "pEmail", DbType.String, pEmail);

                    if (!string.IsNullOrEmpty(pCPF))
                        db.AddInParameter(dbCommand, "pCPF", DbType.String, pCPF);

                    if (!string.IsNullOrEmpty(pTelefone))
                        db.AddInParameter(dbCommand, "pTelefone", DbType.String, pTelefone);

                    if (!string.IsNullOrEmpty(pRA))
                        db.AddInParameter(dbCommand, "pRA", DbType.String, pRA);

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

        /// <summary>
        /// Método que retorna os CRJOcorrencia do Banco de Dados.
        /// </summary>
        /// <param name="pIdOcorrencia">IdOcorrencia da CRJOcorrencia que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJOcorrencia contendo os CRJOcorrencia do Banco de Dados.</returns>
        public DataTable ObterResponsaveisByAluno(int pIdAluno)
        {

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJResponsavel1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdAluno", DbType.Int32, pIdAluno);

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

