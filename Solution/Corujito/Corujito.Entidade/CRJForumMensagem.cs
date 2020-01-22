using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
  
    public class CRJForumMensagem
    {
           public int IdForumMensagem { get; set; }

           public string Mensagem { get; set; }

           public DateTime DataCriacao { get; set; }

           public int IdForumTopico { get; set; }

           public int IdCriador { get; set; }
    }
}
