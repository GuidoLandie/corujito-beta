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
    public class CRJMensagem
    {
        #region Propriedades

            public int IdMensagem { get; set; }

            public int IdLancador { get; set; }

            public int IdAluno { get; set; }

            public string Mensagem { get; set; }

            public DateTime DataMensagem { get; set; }

        #endregion
    }
}
