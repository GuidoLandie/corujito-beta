using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade.Escola;

namespace Corujito.Entidade
{
    [Serializable]
    public class CRJProduto
    {
        public int IdProduto { get; set; }
        public string Cod_Barra { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }
        public CRJStatus Status { get; set; }

        public CRJTipoProduto Tipo { get; set; }
    }
}
