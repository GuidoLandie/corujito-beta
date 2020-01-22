using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade.Escola;

namespace Corujito.Entidade
{
    public class CRJVendaProduto
    {
        public int      IdVendaProduto { get; set; }
        public int      IdPessoa       { get; set; }
        public DateTime DataVenda      { get; set; }
        public double    ValorTotal     { get; set; }
        public CRJPessoa Pessoa        { get; set; }
    }
}
