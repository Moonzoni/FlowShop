using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowShop_INFRA.Entity
{
    [Table("ORCAMENTO")]
    public class OrcamentoEntity
    {
        [Key]
        public int COD_ORCAMENTO { get; set; }
        public string NOME { get; set; }
        public string LINK { get; set; }        
        public int COD_COMPRA { get; set; }
    }
}
