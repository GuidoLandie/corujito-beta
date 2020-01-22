using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
    public class MenuItem
    {
        public Aplicacao Item { get; set; }

        public List<MenuItem> SubItem { get; set; }
    }
}
