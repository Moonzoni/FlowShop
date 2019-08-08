using FlowShop_INFRA.Context;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowShop_INFRA.Repository
{
    public class PerfilRepository : BaseRepository<PerfilEntity>, IPerfilRepository
    {
        public PerfilRepository(FlowShopContext baseContext) : base(baseContext)
        { }

      
    }
}
