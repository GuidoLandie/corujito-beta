using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    
    public class CRJEnsino
    {
        #region Propriedades

            public int idEnsino { get; set; }

            public CRJEscola idEscola { get; set; }

            public string DescEnsino { get; set; }

        #endregion
    }
}
