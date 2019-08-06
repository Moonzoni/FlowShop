using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowShop_INFRA.Entity
{
    [Table("PERFIL")]
    public class PerfilEntity
    {
        [Key]
        public int COD_PERFIL { get; set; }
        public string NOME { get; set; }
    }
}
