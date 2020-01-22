using System;
using System.Collections.Generic;
using System.Text;


namespace Corujito.Entidade.Escola
{
    

    public class CRJSeriesXEnsino
    {
        #region Propriedades

            public int idAnoXEnsino { get; set; }

            public CRJSerie idSerie { get; set; }

            public CRJEnsino idEnsino { get; set; }

        #endregion
    }
}
