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
        private readonly ICategoriaRepository _categoriaRepository;

        public CompraController(ICompraRepository compraRepository, 
            IStatusRepository statusRepository,
            IUsuarioRepository usuarioRepository,
            ICategoriaRepository categoriaRepository)
        {
            _statusRepository = statusRepository;
            _usuarioRepository = usuarioRepository;
            _compraRepository = compraRepository;
            _categoriaRepository = categoriaRepository;
        }
        // GET: api/Compra
        [HttpGet]
        public IEnumerable<CompraDTO> Get()
        {
            return _compraRepository.GetAll().Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                TITULO = x.TITULO,
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
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
                DATA_SOLICITACAO = compra.DATA_SOLICITACAO,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = compra.FINALIZADO,
                TITULO = compra.TITULO,
                STATUS = _statusRepository.Get(compra.COD_STATUS),
                USUARIO = _usuarioRepository.Get(compra.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(compra.COD_CATEGORIA)
            };
        }

        [HttpGet("Status/{stat}")]
        public IEnumerable<CompraDTO> GetCompraByStatus(int stat)
        {
            return _compraRepository.GetCompraByStatus(stat).Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                TITULO = x.TITULO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
            });
        }

        [HttpGet("Categoria/{cat}")]
        public IEnumerable<CompraDTO> GetCompraByCategoria(int cat)
        {
            return _compraRepository.GetCompraByCategoria(cat).Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                TITULO = x.TITULO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
            });
        }

        [HttpGet("Descricao/{desc}")]
        public IEnumerable<CompraDTO> GetCompraByDescricao(string desc)
        {
            return _compraRepository.GetCompraByDescricao(desc).Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                TITULO = x.TITULO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
            });
        }

        [HttpGet("Titulo/{titul}")]
        public IEnumerable<CompraDTO> GetCompraByTitulo(string titul)
        {
            return _compraRepository.GetCompraByTitulo(titul).Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                TITULO = x.TITULO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
            });
        }

        [HttpGet("Aprovado/{aprovado}")]
        public IEnumerable<CompraDTO> GetCompraByAprovado(bool aprovado)
        {
            return _compraRepository.GetCompraByAprovado(aprovado).Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                TITULO = x.TITULO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
            });
        }

        [HttpGet("Finalizado/{finalizado}")]
        public IEnumerable<CompraDTO> GetCompraByFinalizado(bool finalizado)
        {
            return _compraRepository.GetCompraByFinalizado(finalizado).Select(x => new CompraDTO()
            {
                APROVADO = x.APROVADO,
                COD_COMPRA = x.COD_COMPRA,
                DATA_SOLICITACAO = x.DATA_SOLICITACAO,
                DESCRICAO = x.DESCRICAO,
                FINALIZADO = x.FINALIZADO,
                TITULO = x.TITULO,
                STATUS = _statusRepository.Get(x.COD_STATUS),
                USUARIO = _usuarioRepository.Get(x.COD_USUARIO),
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA)
            });
        }

        // POST: api/Compra
        [HttpPost]
        public CompraEntity Post([FromBody] CompraEntity compra)
        {
            var comp = new CompraEntity()
            {
                APROVADO = compra.APROVADO,               
                DATA_SOLICITACAO = compra.DATA_SOLICITACAO,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = compra.FINALIZADO,
                TITULO = compra.TITULO,
                COD_USUARIO = compra.COD_USUARIO,
                COD_STATUS = compra.COD_STATUS,
                COD_CATEGORIA = compra.COD_CATEGORIA
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
                DATA_SOLICITACAO = compra.DATA_SOLICITACAO,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = compra.FINALIZADO,
                TITULO = compra.TITULO,
                COD_USUARIO = compra.USUARIO.COD_USUARIO,
                COD_STATUS = compra.STATUS.COD_STATUS,
                COD_CATEGORIA = compra.CATEGORIA.COD_CATEGORIA
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
