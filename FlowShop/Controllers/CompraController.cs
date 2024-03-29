﻿using System;
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
        private readonly IOrcamentoRepository _orcamentoRepository;

        public CompraController(ICompraRepository compraRepository, 
            IStatusRepository statusRepository,
            IUsuarioRepository usuarioRepository,
            ICategoriaRepository categoriaRepository,
            IOrcamentoRepository orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
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
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA),
                ORCAMENTO = _orcamentoRepository.GetOrcamentoByCompra(x.COD_COMPRA).ToList()

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
                CATEGORIA = _categoriaRepository.Get(compra.COD_CATEGORIA),
                ORCAMENTO = _orcamentoRepository.GetOrcamentoByCompra(compra.COD_COMPRA).ToList()
                
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
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA),
                ORCAMENTO = _orcamentoRepository.GetOrcamentoByCompra(x.COD_COMPRA).ToList()
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
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA),
                ORCAMENTO = _orcamentoRepository.GetOrcamentoByCompra(x.COD_COMPRA).ToList()
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
                CATEGORIA = _categoriaRepository.Get(x.COD_CATEGORIA),
                ORCAMENTO = _orcamentoRepository.GetOrcamentoByCompra(x.COD_COMPRA).ToList()
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
        public ActionResult<CompraDTO> Post([FromBody] CompraDTO compra)
        {
            var comp = new CompraEntity()
            {
                APROVADO = null,               
                DATA_SOLICITACAO = compra.DATA_SOLICITACAO,
                DESCRICAO = compra.DESCRICAO,
                FINALIZADO = false,
                TITULO = compra.TITULO,
                COD_USUARIO = compra.USUARIO.COD_USUARIO,
                COD_STATUS = 1,
                COD_CATEGORIA = compra.CATEGORIA.COD_CATEGORIA
            };

            comp.TITULO = comp.TITULO.Trim(' ');
            if (string.IsNullOrEmpty(comp.TITULO))
            {

                return BadRequest("Por Favor preencha um título válido");
                
            }

            var newComp = _compraRepository.Add(comp);
            compra.COD_COMPRA = newComp.COD_COMPRA;
            for (int i = 0; i < compra.ORCAMENTO.Count; i++)
            {
                compra.ORCAMENTO.ToArray()[i].COD_COMPRA = compra.COD_COMPRA;
                _orcamentoRepository.Add(compra.ORCAMENTO.ToArray()[i]);
            }           

            return Ok(comp);
        }

        // PUT: api/Compra/5
        [HttpPut("{id}")]
        public CompraEntity Put([FromBody] CompraEntity compraEntity, int id)
        {
            var compra = _compraRepository.Get(id);
            compra.TITULO = compraEntity.TITULO;
            compra.DESCRICAO = compraEntity.DESCRICAO;

            _compraRepository.Update(compra);
            return compra;
        }

        [HttpPut("Aprovar/{id}/{cod_perfil}/{state}")]
        public ActionResult<CompraEntity> PutAprovar([FromBody] CompraEntity comp, int cod_perfil, int id,bool state)
        {
            if (cod_perfil == 1 || cod_perfil ==4)
            {
                var compra = _compraRepository.GetCompraByCodigo(id);
                if (compra.FINALIZADO == false)
                {
                    compra.APROVADO = state;
                    if (state == true)
                    {
                        compra.COD_STATUS = 2;
                    }                    
                    else if (state != true)
                    {
                        compra.COD_STATUS = 3;
                    }
                    _compraRepository.Update(compra);
                    return Ok(compra);
                }
                else
                {
                    return BadRequest("Compra já finalizada, não pode ser alterada");
                }
            }

            else
            {
                return BadRequest("Você não tem permissão");
            }            
            
        }

        [HttpPut("Finalizar/{id}/{cod_perfil}/{state}")]
        public ActionResult<CompraEntity> PutFinalizar([FromBody] CompraEntity comp, int cod_perfil, int id, bool state)
        {
            if (cod_perfil == 1 || cod_perfil == 3 || cod_perfil == 4 )
            {
                var compra = _compraRepository.GetCompraByCodigo(id);
                
                compra.FINALIZADO = state;
                compra.COD_STATUS = 4;
                _compraRepository.Update(compra);
                return compra;
            }
            else
            {
                return BadRequest("Você não tem permissão");
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {


            var orc = _orcamentoRepository.GetOrcamentoByCompra(id).Count();

            if (orc != 0)
            {
                return BadRequest("Impossivel excluir registros já referenciados.");
            }
            else
            {
                _compraRepository.Delete(id);
                return Ok();
            }

        }
    }
}
