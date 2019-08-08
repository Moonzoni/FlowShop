using FlowShop_INFRA.Context;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowShop_INFRA.Repository
{
    public class OrcamentoRepository : BaseRepository<OrcamentoEntity>, IOrcamentoRepository
    {
        public OrcamentoRepository(FlowShopContext baseContext): base(baseContext)
        { }
        public IEnumerable<OrcamentoEntity> GetOrcamentoByCompra(int id)
        {
            return _baseContext.Set<OrcamentoEntity>().Where(x => x.COD_COMPRA == id).ToList();
        }


    }
}
