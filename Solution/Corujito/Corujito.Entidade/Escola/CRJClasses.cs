using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{


    public class CRJClasses
    {
        #region Propriedades

        public int idClasses { get; set; }
        public CRJSerie Serie { get; set; }
        public CRJEnsino Ensino { get; set; }
        public CRJTurno Turno { get; set; }
        public string NomeTurma { get; set; }
        #endregion
    }
}
