using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Corujito.Entidade.Escola;
using Corujito.Negocio;

namespace Corujito.Negocio.Escola
{
    public class CRJPessoaNegocio
    {

        /// <summary>
        /// Validar informações os dados enviados pelo usuário.
        /// </summary>
        /// <param name="pCRJPessoa">Objeto do Tipo CRJPessoa que será armazenado no Banco de Dados.</param>
        /// <returns>String contendo a consistência da Validação (caso existam inconsitências. Ou retorna NULL caso o formulário esteja valido.</returns>
        private string Validar(CRJPessoa pCRJPessoa)
        {
            //Validar Obrigatoriedade do campo IdPessoa.
            if (pCRJPessoa.IdPessoa == null)
            {
                return "Campo IdPessoa não pode ser vazio.";
            }





            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Nome possui mais caracteres do que o permitido.
            if (pCRJPessoa.Nome.Length > 50)
            {
                return "Campo Nome possui mais caracteres do que o permitido.";
            }

            //Validar Obrigatoriedade do campo Nome.
            if (pCRJPessoa.Nome == null || pCRJPessoa.Nome.ToString() == "")
            {
                return "Campo Nome não pode ser vazio.";
            }



            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Email possui mais caracteres do que o permitido.
            if (pCRJPessoa.Email.Length > 255)
            {
                return "Campo Email possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo DataNascimento é uma data.
            if (pCRJPessoa.DataNascimento != null)
            {

                return "Campo DataNascimento não possui uma data válida.";

            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo CPF possui mais caracteres do que o permitido.
            if (pCRJPessoa.CPF.Length > 255)
            {
                return "Campo CPF possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Telefone possui mais caracteres do que o permitido.
            if (pCRJPessoa.Telefone.Length > 255)
            {
                return "Campo Telefone possui mais caracteres do que o permitido.";
            }

            //Validar Obrigatoriedade do campo Telefone.
            if (pCRJPessoa.Telefone == null || pCRJPessoa.Telefone.ToString() == "")
            {
                return "Campo Telefone não pode ser vazio.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Celular possui mais caracteres do que o permitido.
            if (pCRJPessoa.Celular.Length > 255)
            {
                return "Campo Celular possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo CEP possui mais caracteres do que o permitido.
            if (pCRJPessoa.CEP.Length > 255)
            {
                return "Campo CEP possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Logradouro possui mais caracteres do que o permitido.
            if (pCRJPessoa.Logradouro.Length > 255)
            {
                return "Campo Logradouro possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Numero possui mais caracteres do que o permitido.
            if (pCRJPessoa.Numero.Length > 255)
            {
                return "Campo Numero possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Bairro possui mais caracteres do que o permitido.
            if (pCRJPessoa.Bairro.Length > 255)
            {
                return "Campo Bairro possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Estado possui mais caracteres do que o permitido.
            if (pCRJPessoa.Estado.Length > 255)
            {
                return "Campo Estado possui mais caracteres do que o permitido.";
            }


            // TODO: Verificar as validações do lado server. Alterar a descrição das mensagens.

            //Validar se o campo Pais possui mais caracteres do que o permitido.
            if (pCRJPessoa.Pais.Length > 255)
            {
                return "Campo Pais possui mais caracteres do que o permitido.";
            }


            //Se não houveram inconsistências retorna Null.
            return null;
        }

        /// <summary>
        /// Popular a Entidade.
        /// </summary>
        /// <param name="dtCRJPessoa">Datatable contendo os dados.</param>
        /// <param name="i">Índice no DataTable</param>
        /// <returns>Entidade Populada.</returns>
        private static CRJPessoa PopularEntidade(DataTable dtCRJPessoa, int i)
        {
            //Criando um objeto do tipo CRJPessoa.
            CRJPessoa objCRJPessoa = new CRJPessoa();

            if (dtCRJPessoa.Columns.Contains("IdPessoa"))
            {
                if (dtCRJPessoa.Rows[i]["IdPessoa"] != DBNull.Value)
                {
                    objCRJPessoa.IdPessoa = Convert.ToInt32(dtCRJPessoa.Rows[i]["IdPessoa"].ToString());
                    objCRJPessoa.TiposPessoa = new CRJTipoPessoaNegocio().ObterCRJTipoPessoaPorIdPessoa(objCRJPessoa.IdPessoa);

                }
            }



            if (dtCRJPessoa.Columns.Contains("IdStatus"))
            {
                if (dtCRJPessoa.Rows[i]["IdStatus"] != DBNull.Value)
                {
                    int IdStatus = Convert.ToInt32(dtCRJPessoa.Rows[i]["IdStatus"]);

                    objCRJPessoa.Status = (new CRJStatusNegocio()).ObterCRJStatusPorID(IdStatus);
                }
            }


            if (dtCRJPessoa.Columns.Contains("Nome"))
            {
                if (dtCRJPessoa.Rows[i]["Nome"] != DBNull.Value)
                {
                    objCRJPessoa.Nome = Convert.ToString(dtCRJPessoa.Rows[i]["Nome"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("CPF"))
            {
                if (dtCRJPessoa.Rows[i]["CPF"] != DBNull.Value)
                {
                    objCRJPessoa.CPF = Convert.ToString(dtCRJPessoa.Rows[i]["CPF"].ToString());
                }
            }

            if (dtCRJPessoa.Columns.Contains("RG"))
            {
                if (dtCRJPessoa.Rows[i]["RG"] != DBNull.Value)
                {
                    objCRJPessoa.RG = Convert.ToString(dtCRJPessoa.Rows[i]["RG"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Sexo"))
            {
                if (dtCRJPessoa.Rows[i]["Sexo"] != DBNull.Value)
                {
                    string sexo = Convert.ToString(dtCRJPessoa.Rows[i]["Sexo"]);

                    objCRJPessoa.Sexo = sexo == "F" ? CRJPessoa.TipoSexo.F : CRJPessoa.TipoSexo.M;
                }
            }

            if (dtCRJPessoa.Columns.Contains("Email"))
            {
                if (dtCRJPessoa.Rows[i]["Email"] != DBNull.Value)
                {
                    objCRJPessoa.Email = Convert.ToString(dtCRJPessoa.Rows[i]["Email"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("DataNascimento"))
            {
                if (dtCRJPessoa.Rows[i]["DataNascimento"] != DBNull.Value)
                {
                    objCRJPessoa.DataNascimento = Convert.ToDateTime(dtCRJPessoa.Rows[i]["DataNascimento"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Telefone"))
            {
                if (dtCRJPessoa.Rows[i]["Telefone"] != DBNull.Value)
                {
                    objCRJPessoa.Telefone = Convert.ToString(dtCRJPessoa.Rows[i]["Telefone"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Celular"))
            {
                if (dtCRJPessoa.Rows[i]["Celular"] != DBNull.Value)
                {
                    objCRJPessoa.Celular = Convert.ToString(dtCRJPessoa.Rows[i]["Celular"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("CEP"))
            {
                if (dtCRJPessoa.Rows[i]["CEP"] != DBNull.Value)
                {
                    objCRJPessoa.CEP = Convert.ToString(dtCRJPessoa.Rows[i]["CEP"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Logradouro"))
            {
                if (dtCRJPessoa.Rows[i]["Logradouro"] != DBNull.Value)
                {
                    objCRJPessoa.Logradouro = Convert.ToString(dtCRJPessoa.Rows[i]["Logradouro"]);
                }
            }


            if (dtCRJPessoa.Columns.Contains("Numero"))
            {
                if (dtCRJPessoa.Rows[i]["Numero"] != DBNull.Value)
                {
                    objCRJPessoa.Numero = Convert.ToString(dtCRJPessoa.Rows[i]["Numero"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Bairro"))
            {
                if (dtCRJPessoa.Rows[i]["Bairro"] != DBNull.Value)
                {
                    objCRJPessoa.Bairro = Convert.ToString(dtCRJPessoa.Rows[i]["Bairro"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Cidade"))
            {
                if (dtCRJPessoa.Rows[i]["Cidade"] != DBNull.Value)
                {
                    objCRJPessoa.Cidade = Convert.ToString(dtCRJPessoa.Rows[i]["Cidade"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Estado"))
            {
                if (dtCRJPessoa.Rows[i]["Estado"] != DBNull.Value)
                {
                    objCRJPessoa.Estado = Convert.ToString(dtCRJPessoa.Rows[i]["Estado"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Pais"))
            {
                if (dtCRJPessoa.Rows[i]["Pais"] != DBNull.Value)
                {
                    objCRJPessoa.Pais = Convert.ToString(dtCRJPessoa.Rows[i]["Pais"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("Complemento"))
            {
                if (dtCRJPessoa.Rows[i]["Complemento"] != DBNull.Value)
                {
                    objCRJPessoa.Complemento = Convert.ToString(dtCRJPessoa.Rows[i]["Complemento"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("URL"))
            {
                if (dtCRJPessoa.Rows[i]["URL"] != DBNull.Value)
                {
                    objCRJPessoa.URL = Convert.ToString(dtCRJPessoa.Rows[i]["URL"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("IdResponsavelXAluno"))
            {
                if (dtCRJPessoa.Rows[i]["IdResponsavelXAluno"] != DBNull.Value)
                {
                    objCRJPessoa.IdResponsavelXAluno = Convert.ToInt32(dtCRJPessoa.Rows[i]["IdResponsavelXAluno"]);
                }
            }

            if (dtCRJPessoa.Columns.Contains("IdAluno"))
            {
                if (dtCRJPessoa.Rows[i]["IdAluno"] != DBNull.Value)
                {
                    objCRJPessoa.IdAluno = Convert.ToInt32(dtCRJPessoa.Rows[i]["IdAluno"]);
                }
            }


            return objCRJPessoa;
        }

        /// <summary>
        /// Método que Insere um CRJPessoa no Banco de Dados.
        /// </summary>
        /// <param name="pCRJPessoa">Objeto do Tipo CRJPessoa que será armazenado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Incluir(CRJPessoa pCRJPessoa, string pSenha)
        {

            if (!string.IsNullOrEmpty(pCRJPessoa.CPF))
            {
                List<CRJPessoa> listPessoas = ObterCRJPessoa(null, null, pCRJPessoa.CPF);

                if (listPessoas != null && listPessoas.Count > 0)
                {
                    return "Já existe uma pessoa com o cpf " + pCRJPessoa.CPF;
                }

            }


            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;1"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "IdStatus", DbType.Int32, pCRJPessoa.Status.IdStatus);
                db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJPessoa.Nome);
                db.AddInParameter(dbCommand, "CPF", DbType.String, pCRJPessoa.CPF);
                db.AddInParameter(dbCommand, "RG", DbType.String, pCRJPessoa.RG);
                db.AddInParameter(dbCommand, "Sexo", DbType.String, pCRJPessoa.Sexo);
                db.AddInParameter(dbCommand, "Email", DbType.String, pCRJPessoa.Email);
                db.AddInParameter(dbCommand, "DataNascimento", DbType.DateTime, pCRJPessoa.DataNascimento);
                db.AddInParameter(dbCommand, "Telefone", DbType.String, pCRJPessoa.Telefone);
                db.AddInParameter(dbCommand, "Celular", DbType.String, pCRJPessoa.Celular);
                db.AddInParameter(dbCommand, "CEP", DbType.String, pCRJPessoa.CEP);
                db.AddInParameter(dbCommand, "Logradouro", DbType.String, pCRJPessoa.Logradouro);
                db.AddInParameter(dbCommand, "Numero", DbType.String, pCRJPessoa.Numero);
                db.AddInParameter(dbCommand, "Bairro", DbType.String, pCRJPessoa.Bairro);
                db.AddInParameter(dbCommand, "Cidade", DbType.String, pCRJPessoa.Cidade);
                db.AddInParameter(dbCommand, "Estado", DbType.String, pCRJPessoa.Estado);
                db.AddInParameter(dbCommand, "Pais", DbType.String, pCRJPessoa.Pais);
                db.AddInParameter(dbCommand, "Complemento", DbType.String, pCRJPessoa.Complemento);
                db.AddInParameter(dbCommand, "URL", DbType.String, pCRJPessoa.URL);

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

            int Codigo = 0;

            if (int.TryParse(Retorno, out Codigo) == true && Codigo > 0)
            {
                UsuarioNegocio objUsusarioBO = new UsuarioNegocio();
                pCRJPessoa.IdPessoa = Codigo;

                objUsusarioBO.IncluirNovoUsuario(pCRJPessoa, pSenha);
                SalvarTipoPessoa(Codigo, pCRJPessoa.TiposPessoa);

                return Codigo.ToString();
            }

            return Retorno;

        }

        /// <summary>
        /// Método que Altera um CRJPessoa no Banco de Dados.
        /// </summary>
        /// <param name="pCRJPessoa">Objeto do Tipo CRJPessoa que será atualizado no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Alterar(CRJPessoa pCRJPessoa)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;2"))
            {

                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdPessoa", DbType.Int32, pCRJPessoa.IdPessoa);
                db.AddInParameter(dbCommand, "IdStatus", DbType.Int32, pCRJPessoa.Status.IdStatus);
                db.AddInParameter(dbCommand, "Nome", DbType.String, pCRJPessoa.Nome);
                db.AddInParameter(dbCommand, "CPF", DbType.String, pCRJPessoa.CPF);
                db.AddInParameter(dbCommand, "RG", DbType.String, pCRJPessoa.RG);
                db.AddInParameter(dbCommand, "Sexo", DbType.String, pCRJPessoa.Sexo);
                db.AddInParameter(dbCommand, "Email", DbType.String, pCRJPessoa.Email);
                db.AddInParameter(dbCommand, "DataNascimento", DbType.DateTime, pCRJPessoa.DataNascimento);
                db.AddInParameter(dbCommand, "Telefone", DbType.String, pCRJPessoa.Telefone);
                db.AddInParameter(dbCommand, "Celular", DbType.String, pCRJPessoa.Celular);
                db.AddInParameter(dbCommand, "CEP", DbType.String, pCRJPessoa.CEP);
                db.AddInParameter(dbCommand, "Logradouro", DbType.String, pCRJPessoa.Logradouro);
                db.AddInParameter(dbCommand, "Numero", DbType.String, pCRJPessoa.Numero);
                db.AddInParameter(dbCommand, "Bairro", DbType.String, pCRJPessoa.Bairro);
                db.AddInParameter(dbCommand, "Cidade", DbType.String, pCRJPessoa.Cidade);
                db.AddInParameter(dbCommand, "Estado", DbType.String, pCRJPessoa.Estado);
                db.AddInParameter(dbCommand, "Pais", DbType.String, pCRJPessoa.Pais);
                db.AddInParameter(dbCommand, "Complemento", DbType.String, pCRJPessoa.Complemento);
                db.AddInParameter(dbCommand, "URL", DbType.String, pCRJPessoa.URL);

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

            SalvarTipoPessoa(pCRJPessoa.IdPessoa, pCRJPessoa.TiposPessoa);


            return Retorno;

        }

        /// <summary>
        /// Método que Exclui um CRJPessoa no Banco de Dados.
        /// </summary>
        /// <param name="pCRJPessoa">Objeto do Tipo CRJPessoa que será excluído no Banco de Dados.</param>
        /// <param name="pRUUsuarioLogado">RU do Usuário que está usando o Sistema para armazenar suas ações no Log.</param>
        /// <returns>String contendo a quantidade de linhas afetadas ou o erro ocorrido ao persistir as informações no Banco de Dados.</returns>
        public string Excluir(int pIdPessoa)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;3"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdPessoa", DbType.Int32, pIdPessoa);


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
        /// Método que retorna os CRJPessoa do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
        public List<CRJPessoa> ObterCRJPessoa(string pNome = null, string pEmail = null, string pCPF = null, string pTelefone = null, string pRA = null)
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> objCRJPessoaColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;4"))
            {
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
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            objCRJPessoaColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            return objCRJPessoaColecao;
        }

        /// <summary>
        /// Método que retorna os CRJPessoa do Banco de Dados.
        /// </summary>
        /// <param name="pIdPessoa">IdPessoa da CRJPessoa que consultado no Banco de Dados.</param>
        /// <returns>Lista Tipada da Entidade CRJPessoa contendo os CRJPessoa do Banco de Dados.</returns>
        public CRJPessoa ObterCRJPessoaPorId(int pIdPessoa)
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> objCRJPessoaColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;4"))
            {
                //Parâmetros da Stored Procedure.                
                db.AddInParameter(dbCommand, "pIdPessoa", DbType.Int32, pIdPessoa);

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            objCRJPessoaColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            if (objCRJPessoaColecao != null && objCRJPessoaColecao.Count() == 1)
            {
                return objCRJPessoaColecao[0];
            }
            else
                return null;


        }

        public List<CRJPessoa> ObterCRJProfessor()
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> TipoProfessorColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;4"))
            {

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            TipoProfessorColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            return TipoProfessorColecao;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPessoa"></param>
        /// <param name="listTipoPessoa"></param>
        private void SalvarTipoPessoa(int IdPessoa, List<CRJTipoPessoa> listTipoPessoa)
        {
            string Retorno = string.Empty;
            object ret = null;

            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            //Removoe todo mundo
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoaXTipo;02"))
            {

                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "pIdPessoa", DbType.Int32, IdPessoa);

                //Executar Comando no Banco.
                ret = db.ExecuteNonQuery(dbCommand);
            }

            if (listTipoPessoa != null && listTipoPessoa.Count > 0)
            {

                foreach (CRJTipoPessoa item in listTipoPessoa)
                {
                    //Insere todo mundo
                    using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoaXTipo;01"))
                    {

                        //Parâmetros da Stored Procedure.
                        db.AddInParameter(dbCommand, "pIdPessoa", DbType.Int32, IdPessoa);
                        db.AddInParameter(dbCommand, "pIdTipoPessoa", DbType.Int32, item.IdTipoPessoa);

                        //Executar Comando no Banco.
                        ret = db.ExecuteNonQuery(dbCommand);

                    }

                    if (item.IdTipoPessoa == (int)Constantes.TipoPessoa.Aluno)
                    {

                    }

                }
            }

        }


        public void InserirResponsaveisXAluno(int IdAluno, int IdResponsvel)
        {
            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;7"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdAluno", DbType.Int32, IdAluno);
                db.AddInParameter(dbCommand, "IdResponsvel", DbType.Int32, IdResponsvel);

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
        }
        
        public void ExcluirResponsavelXAluno(int IdResponsavelAluno)
        {

            string Retorno = string.Empty;
            object ret = null;


            //Iniciando Persistência no Banco de Dados.
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");

            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;8"))
            {
                //Parâmetros da Stored Procedure.
                db.AddInParameter(dbCommand, "IdResponsavelAluno", DbType.Int32, IdResponsavelAluno);


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
        }

        public List<CRJPessoa> ObterResponsaveisPorDependente(int IdDependente)
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> objCRJPessoaColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;5"))
            {

                db.AddInParameter(dbCommand, "pIdAluno", DbType.String, IdDependente);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            objCRJPessoaColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            return objCRJPessoaColecao;
        }

        public List<CRJPessoa> ObterDependentesPorResponsavel(int IdResponsavel)
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> objCRJPessoaColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;6"))
            {

                db.AddInParameter(dbCommand, "pIdResponsavel", DbType.String, IdResponsavel);


                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            objCRJPessoaColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            return objCRJPessoaColecao;
        }

        public List<CRJPessoa> ObterResponsaveisDisponiveis()
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> TipoProfessorColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;9"))
            {

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            TipoProfessorColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            return TipoProfessorColecao;
        }

        public List<CRJPessoa> ObterDependentesDisponiveis()
        {
            //Instânciando a Lista Tipada.
            List<CRJPessoa> TipoProfessorColecao = new List<CRJPessoa>();

            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("BancoSistema");
            using (DbCommand dbCommand = db.GetStoredProcCommand("STPCRJPessoa;10"))
            {

                using (DataSet ds = db.ExecuteDataSet(dbCommand))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dtCRJPessoa = ds.Tables[0];

                        for (int i = 0; i < dtCRJPessoa.Rows.Count; i++)
                        {
                            CRJPessoa objCRJPessoa = PopularEntidade(dtCRJPessoa, i);
                            TipoProfessorColecao.Add(objCRJPessoa);
                            objCRJPessoa = null;
                        }
                    }
                }
            }

            return TipoProfessorColecao;
        }


    }
}

