using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
  
    public class CRJLancamentoCartao
    {
        #region Propriedades

            public int IdLancamentoCartao { get; set; }

            public int IdCartao { get; set; }

            public int IdLancador { get; set; }

            public double Valor { get; set; }

            public DateTime DataLancamento { get; set; }

            public string Descricao { get; set; }

        #endregion
    }
}
