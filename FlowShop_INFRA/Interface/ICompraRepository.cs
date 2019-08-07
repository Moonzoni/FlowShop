﻿using FlowShop_INFRA.DTO;
using FlowShop_INFRA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Interface
{
    public interface ICompraRepository: IBaseRepository<CompraEntity>
    {
        IEnumerable<CompraEntity> GetCompraByStatus(int id);
    }


}
