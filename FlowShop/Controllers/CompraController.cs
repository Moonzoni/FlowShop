using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowShop_INFRA.DTO;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public CompraController(ICompraRepository compraRepository, 
            IStatusRepository statusRepository,
            IUsuarioRepository usuarioRepository)
        {
            _statusRepository = statusRepository;
            _usuarioRepository = usuarioRepository;
            _compraRepository = compraRepository;
        }
        // GET: api/Compra
        [HttpGet]
        public IEnumerable<CompraDTO> Get()
        {
            return _compraRepository.GetAll().Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA = x.DATA,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                TITULO = x.TITULO

            });
        }

        // GET: api/Compra/5
        [HttpGet("{id}")]
        public CompraDTO Get(int id)
        {
            var compra = _compraRepository.Get(id);
            return new CompraDTO()
            {
                APROVADO = compra.APROVADO,
                COD_COMPRA = compra.COD_COMPRA,
                DATA = compra.DATA,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = compra.FINALIZADO,
                TITULO = compra.TITULO,
                STATUS = _statusRepository.Get(compra.COD_STATUS),
                USUARIO = _usuarioRepository.Get(compra.COD_USUARIO)
            };
        }

        // POST: api/Compra
        [HttpPost]
        public CompraDTO Post([FromBody] CompraDTO compra)
        {
            var comp = new CompraEntity()
            {
                APROVADO = compra.APROVADO,               
                DATA = compra.DATA,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = compra.FINALIZADO,
                TITULO = compra.TITULO,
                COD_USUARIO = compra.USUARIO.COD_USUARIO,
                COD_STATUS = compra.STATUS.COD_STATUS
            };

            var newComp = _compraRepository.Add(comp);
            compra.COD_COMPRA = newComp.COD_COMPRA;
            return compra;

        }

        // PUT: api/Compra/5
        [HttpPut("{id}")]
        public CompraDTO Put([FromBody] CompraDTO compra)
        {
            var comp = new CompraEntity()
            {
                APROVADO = compra.APROVADO,
                COD_COMPRA = compra.COD_COMPRA,
                DATA = compra.DATA,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = compra.FINALIZADO,
                TITULO = compra.TITULO,
                COD_USUARIO = compra.USUARIO.COD_USUARIO,
                COD_STATUS = compra.STATUS.COD_STATUS
            };

            _compraRepository.Update(comp);            
            return compra;

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _compraRepository.Delete(id);
        }
    }
}
