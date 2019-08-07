using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowShop_INFRA.Entity
{
    [Table("COMPRA")]
    public class CompraEntity
    {
        [Key]
        public int COD_COMPRA { get; set; }
        public string TITULO { get; set; }
        public string DESCRICAO { get; set; }
        public int COD_STATUS { get; set; }
        public DateTime DATA_SOLICITACAO { get; set; }
        public int COD_USUARIO { get; set; }
        public bool? APROVADO { get; set; }
        public bool FINALIZADO { get; set; }

    }
}
