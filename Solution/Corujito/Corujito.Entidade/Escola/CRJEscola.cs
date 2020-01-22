using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    public class CRJEscola
    {
        public int idEscola { get; set; }
        public CRJStatus Status { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Logradouro { get; set; }
        public string Missao { get; set; }
        public string CNPJ { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataAbertura { get; set; }
        public string InscEstadual { get; set; }
        public string TelefonePrincipal { get; set; }
        public string TelefoneSecundario { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }

    }
}
