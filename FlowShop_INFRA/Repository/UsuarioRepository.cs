using FlowShop_INFRA.Context;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Repository
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository (FlowShopContext baseContext) : base(baseContext)
        {
        }
    }
}
