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

        public IEnumerable<CompraEntity> GetCompraByUsuario(int id)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.COD_USUARIO == id).ToList();
        }
                     

        public IEnumerable<CompraEntity> GetCompraByDescricao(string desc)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.DESCRICAO.Contains(desc)).ToList();
        }

        public IEnumerable<CompraEntity> GetCompraByAprovado(bool aprovado)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.APROVADO == aprovado).ToList();
        }

        public IEnumerable<CompraEntity> GetCompraByFinalizado(bool finalizado)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.FINALIZADO == finalizado).ToList();
        }

        public IEnumerable<CompraEntity> GetCompraByTitulo(string titul)
        {
            return _baseContext.Set<CompraEntity>().Where(x => x.TITULO.Contains(titul)).ToList();
        }

        public CompraEntity GetCompraByCodigo(int id)
        {
            return _baseContext.Set<CompraEntity>().FirstOrDefault(x => x.COD_COMPRA == id);
        }

    }
}
