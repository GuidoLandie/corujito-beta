using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade.Escola;

namespace Corujito.Entidade
{
    public class GrupoPermissao
    {
        public GrupoPermissao()
        {
            IdGrupo = 0;
            IdEscola = 1;
            Descricao = string.Empty;
            TipoPessoa = new CRJTipoPessoa();
        }

        public int IdGrupo { get; set; }
        public int IdEscola { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CRJTipoPessoa TipoPessoa { get; set; }
    }
}
