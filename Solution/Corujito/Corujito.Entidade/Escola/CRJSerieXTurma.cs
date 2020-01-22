using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{     
    public class CRJSerieXTurma
    {
        #region Propriedades

            public int idSerieXTurma { get; set; }

            public CRJSerie idSerie { get; set; }

            public CRJTurma idTurma { get; set; }

        #endregion
    }
}
