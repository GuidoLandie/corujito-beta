using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade.Escola;


namespace Corujito.Entidade
{
    [Serializable]
    public class Usuario
    {
        public string UserLogin { get; set; }
                
        public string Senha { get; set; }
                
        public bool Ativo { get; set; }

        public CRJPessoa DadosPessoais { get; set; }
        
    }
}
