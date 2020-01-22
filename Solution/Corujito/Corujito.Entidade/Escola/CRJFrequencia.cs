using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    public class CRJFrequencia
    {
        public int IdFrequencia { get; set; }
        public int IdCRJMatricula { get; set; }
        public int IdProfXMatXClasse { get; set; }
        public DateTime DataAula { get; set; }
        public bool Presente { get; set; }
        public int IdLancador { get; set; }
        public string NomeAluno { get; set; }

    }
}
