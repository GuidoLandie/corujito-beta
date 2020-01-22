using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
    public static class Constantes
    {
        public static class Permissao
        {
            public const int CadastrarEscola = 1;
        }

        public enum TipoPessoa
        { 
            Secretaria = 1,
            Cantineiro = 2,
            Professor  = 3,
            Coordenador= 4,
            Diretor    = 5,
            Responsavel= 6,
            Aluno      = 7
        }
    }
}
