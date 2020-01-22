using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
    public class Aplicacao
    {
        public int IdAplicacao { get; set; }         
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }
        public Aplicacao AplicacaoPai { get; set; }
        public bool FlagSelecao { get; set; }		
    }
}
