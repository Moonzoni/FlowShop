using FlowShop_INFRA.Context;
using FlowShop_INFRA.DTO;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlowShop_INFRA.Repository
{
    public class CompraRepository: BaseRepository<CompraEntity>, ICompraRepository
    {
        public CompraRepository(FlowShopContext baseContext) : base(baseContext)
        {       
        }

        public IEnumerable<CompraEntity> GetCompraByStatus(int id)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.COD_STATUS == id).ToList();
        }

        public IEnumerable<CompraEntity> GetCompraByCategoria(int id)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.COD_CATEGORIA == id).ToList();
        }

        public IEnumerable<CompraEntity> GetCompraByDescricao(string texto)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.DESCRICAO.Contains(texto)).ToList();
        }
    }
}
