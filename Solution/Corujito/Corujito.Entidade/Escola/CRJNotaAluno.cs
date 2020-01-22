using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    public class CRJNotaAluno
    {

        public int IdNotaAluno { get; set; }
        public int IdAtividade { get; set; }
        public int IdMatricula { get; set; }
        public int IdProfXMatXClasse { get; set; }
        public float Nota { get; set; }
        public DateTime DataNota { get; set; }
        public int Atribuidor { get; set; }
        public string NomeAluno { get; set; }
        public string Atividade { get; set; }


    }
}
