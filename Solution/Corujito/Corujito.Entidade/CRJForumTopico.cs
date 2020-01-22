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
    public class CRJForumTopico
    {
        public int IdForumTopico { get; set; }

        public string Titulo { get; set; }

        public string Mensagem { get; set; }

        public DateTime DataCriacao { get; set; }

        public int IdClasse { get; set; }

        public int IdCriador { get; set; }
    }
}
