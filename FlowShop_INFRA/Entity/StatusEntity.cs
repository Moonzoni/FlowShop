using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowShop_INFRA.Entity
{
    [Table("_STATUS")]
    public class StatusEntity
    {
        [Key]
        public int COD_STATUS { get; set; }
        public string NOME { get; set; }
    }
}
