using FlowShop_INFRA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.DTO
{
     public class OrcamentoDTO
    {
        public int COD_ORCAMENTO { get; set; }
        public string NOME { get; set; }
        public string LINK { get; set; }
        public CategoriaEntity CATEGORIA  { get; set; }
        public CompraEntity COMPRA { get; set; }
    }
}
