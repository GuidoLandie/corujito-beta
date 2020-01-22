using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
    [Serializable]
    public class Funcionalidade
    {

        public bool PossuiPermissao { get; set; }
        
        public int IdFuncionalidade { get; set; }

        public int  IdAplicacao { get; set; }

        public string NomeAplicacao { get; set; }

        public string Descricao { get; set; }
    }
}
