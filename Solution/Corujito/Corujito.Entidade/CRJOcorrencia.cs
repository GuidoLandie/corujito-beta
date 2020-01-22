using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
  
    /// <summary>
    /// Classe gerada automaticamente pelo Gerador de Código. [Versão: 2.0]
    /// Tipo...........: Entidade
    /// Data de Criação: 23/08/2012 12:36:59
    /// Responsável....: guidolandie
    /// Observações....: 
    /// </summary>
    public class CRJOcorrencia
    {
        #region Propriedades

            public int IdOcorrencia { get; set; }

            public int IdLancador { get; set; }

            public int IdAluno { get; set; }

            public string Natureza { get; set; }

            public string Ocorrencia { get; set; }

            public string Providencias { get; set; }

            public DateTime DataOcorrencia { get; set; }

        #endregion
    }
}
