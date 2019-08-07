using FlowShop_INFRA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.DTO
{
    public class CompraDTO
    {
        public int COD_COMPRA { get; set; }
        public string TITULO { get; set; }
        public string DESCRICAO { get; set; }
        public StatusEntity STATUS { get; set; }
        public DateTime DATA_SOLICITACAO { get; set; }
        public UsuarioEntity USUARIO { get; set; }
        public bool? APROVADO { get; set; }
        public bool FINALIZADO { get; set; }
    }
}
