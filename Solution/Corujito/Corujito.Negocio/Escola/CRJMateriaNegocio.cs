using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Corujito.Entidade;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using Corujito.Entidade.Escola;


namespace Corujito.Negocio.Escola
{


    public class CRJMateriaNegocio
    {



        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJMateria">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJMateria PopularEntidade(DataTable dtCRJMateria, int i)
        {
            //Criando um objeto do tipo CRJMateria.
            CRJMateria objCRJMateria = new CRJMateria();

            if (dtCRJMateria.Columns.Contains("idMateria"))
            {
                if (dtCRJMateria.Rows[i]["idMateria"] != DBNull.Value)
                {
                    objCRJMateria.idMateria = Convert.ToInt32(dtCRJMateria.Rows[i]["idMateria"].ToString());
                }
            }

            if (dtCRJMateria.Columns.Contains("Descricao"))
            {
                if (dtCRJMateria.Rows[i]["Descricao"] != DBNull.Value)
                {
                    objCRJMateria.Descricao = Convert.ToString(dtCRJMateria.Rows[i]["Descricao"]);
                }
            }

            if (dtCRJMateria.Columns.Contains("TipoMateria"))
            {
                if (dtCRJMateria.Rows[i]["TipoMateria"] != DBNull.Value)
                {
                    objCRJMateria.TipoMateria = Convert.ToString(dtCRJMateria.Rows[i]["TipoMateria"]);
                }
            }

            return objCRJMateria;
        }
      
        /// <summary>
        /// Método que retorna todos os CRJMateria do Banco de Dados.
        /// </summary>
        /// <returns>Lista Tipada da Entidade CRJMateria contendo os CRJMateria do Banco de Dados.</returns>
        public List<CRJMateria> ObterCRJMateria()
        {
            //Instânciando a Lista Tipada.
            List<CRJMateria> objCRJMateriaColecao = new List<CRJMateria>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMateria1"))
            {
                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJMateria = ds.Tables[0];

                        for (int i = 0; i < dtCRJMateria.Rows.Count; i++)
                        {
                            CRJMateria objCRJMateria = PopularEntidade(dtCRJMateria, i);
                            objCRJMateriaColecao.Add(objCRJMateria);
                            objCRJMateria = null;
                        }
                    }
                }
            }

            return objCRJMateriaColecao;
        }
        
        /// <summary>
        /// Método que retorna os CRJMateria do Banco de Dados.
        /// </summary>
        /// <param name="p"> da CRJMateria que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJMateria contendo os CRJMateria do Banco de Dados.</returns>
        public CRJMateria ObterCRJMateriaPorID(int pID)
        {
            //Instânciando a Lista Tipada.
            CRJMateria objCRJMateriaColecao = new CRJMateria();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJMateria1"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "@idMateria", DbType.Int32, pID);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJMateria = ds.Tables[0];

                        for (int i = 0; i < dtCRJMateria.Rows.Count; i++)
                        {
                            CRJMateria objCRJMateria = PopularEntidade(dtCRJMateria, i);
                            return objCRJMateria;
                            
                        }
                    }
                }
            }

            return null;
        }

    }

           
}


