using FlowShop_INFRA.DTO;
using FlowShop_INFRA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Interface
{
    public interface ICompraRepository: IBaseRepository<CompraEntity>
    {
        IEnumerable<CompraEntity> GetCompraByStatus(int id);
        IEnumerable<CompraEntity> GetCompraByCategoria(int id);
        IEnumerable<CompraEntity> GetCompraByDescricao(string desc);
        IEnumerable<CompraEntity> GetCompraByTitulo(string titul);
        IEnumerable<CompraEntity> GetCompraByAprovado(bool aprovado);
        IEnumerable<CompraEntity> GetCompraByFinalizado(bool finalizado);
        IEnumerable<CompraEntity> GetCompraByUsuario(int id);
        CompraEntity GetCompraByCodigo(int id);
    }
}
