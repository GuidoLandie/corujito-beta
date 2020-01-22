using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade.Escola
{
    public class CRJAtividade
    {
        public int IdAtividade { get; set; }
        public string NomeAtividade { get; set; }
        public CRJTipoAtividade TipoAtividade { get; set; }
        public int IdProfXMatxEns { get; set; }
        public DateTime Datainicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Descricao { get; set; }

        public string NomeMateria { get; set; }
    }
}
