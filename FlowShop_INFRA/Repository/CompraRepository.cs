using FlowShop_INFRA.Context;
using FlowShop_INFRA.DTO;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Repository
{
    public class CompraRepository: BaseRepository<CompraEntity>, ICompraRepository
    {
        protected readonly FlowShopContext _flowShopContext;
        public CompraRepository(FlowShopContext baseContext) : base(baseContext)
        {            
        }

        public List<CompraEntity> GetStatus(int id)
        {
            var list = _flowShopContext.wherer<CompraEntity>().
            return 
        }


    }
}
