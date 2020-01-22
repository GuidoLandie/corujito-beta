using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    public class CRJMatricula
    {
        public int idCRJMatricula { get; set; }
        public int idClasses { get; set; }
        public int CRJSeriesXEnsino_idAnoXEnsino { get; set; }
        public int CRJEscola_idEscola { get; set; }
        public int CRJAluno_RA { get; set; }
        public int DateMatricula { get; set; }
    }
}
