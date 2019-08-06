using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowShop_INFRA.Entity
{
    [Table("CATEGORIA")]
    public class CategoriaEntity
    {
        [Key]
        public int COD_CATEGORIA { get; set; }
        public string NOME { get; set; }

    }
}


