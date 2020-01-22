using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corujito.Entidade
{
    [Serializable]
    public class CRJProdutoVendido
    {
        public int IdProdutoVendido { get; set; }
        public int IdVendaProduto { get; set; }
        public CRJProduto Produto { get; set; }
        public int IdProduto { get; set; }
        public float ValorTotal { get; set; }
        public int Quantidade { get; set; }

        public string Nome { get; set; }
        public float Preco { get; set; }
    }
}
