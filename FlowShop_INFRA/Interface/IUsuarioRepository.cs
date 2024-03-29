﻿using FlowShop_INFRA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Interface
{
    public interface IUsuarioRepository: IBaseRepository<UsuarioEntity>
    {
        IEnumerable<UsuarioEntity> GetUsuarioPorPerfil(int id);
    }

    
}
