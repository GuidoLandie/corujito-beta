using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    [Serializable]
    public class CRJPessoa
    {
        public enum TipoPessoa
        {
            Professor = 1,
            Cantineiro = 2,
            Diretor = 3,
            Coordenador = 4,
            Secretaria = 5,
            Aluno = 6,
            Responsavel = 7
        }

        public enum TipoSexo
        {
            /// <summary>
            /// Masculino
            /// </summary>
            M = 1,

            /// <summary>
            /// Feminino
            /// </summary>
            F = 2
        }

        public string SexoDescricao
        {
            get
            {
                if (Sexo == TipoSexo.F) return "Feminino";
                else if (Sexo == TipoSexo.M) return "Masculino";
                else return "Não informado.";
            }
        }
        
        public CRJStatus Status { get; set; }
        public TipoSexo Sexo { get; set; }
        public List<TipoPessoa> Tipo { get; set; }
        public List<CRJTipoPessoa> TiposPessoa { get; set; }
        public List<CRJPessoa> Responsaveis { get; set; }
        public List<CRJPessoa> Dependentes { get; set; }



        public int IdResponsavelXAluno { get; set; }
        public int IdAluno { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Complemento { get; set; }
        public string URL { get; set; }








    }
}
