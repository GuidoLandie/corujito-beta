using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    public class CRJProfXMateriaXClasse
    {
        public int idProfXMateriaXClasse { get; set; }
        public CRJPessoa Pessoa { get; set; }
        public CRJMateria Materia { get; set; }
        public CRJClasses Classe { get; set; }

    }
}
