using FlowShop_INFRA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Interface
{
    public interface IOrcamentoRepository : IBaseRepository<OrcamentoEntity>
    {
        IEnumerable<OrcamentoEntity> GetOrcamentoByCompra(int id);
    }
}
