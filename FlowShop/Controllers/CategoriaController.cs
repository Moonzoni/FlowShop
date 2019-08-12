using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowShop_INFRA;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICompraRepository _compraRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository, ICompraRepository compraRepository)
        {
            _categoriaRepository = categoriaRepository;
            _compraRepository = compraRepository;
        }
        // GET: api/Categoria
        [HttpGet]
        public IEnumerable<CategoriaEntity> Get()
        {
            return _categoriaRepository.GetAll();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public CategoriaEntity Get(int id)
        {
            return _categoriaRepository.Get(id);
        }

        // POST: api/Categoria
        [HttpPost]
        public ActionResult<CategoriaEntity> Post([FromBody] CategoriaEntity categoria)
        {
            var nome = Validacoes.StringValidation(categoria.NOME);

            if (nome == true)
            {
                return _categoriaRepository.Add(categoria);
            }
            else
            {
                return BadRequest("Não foi possível atualizar esta categoria. Por favor, digite um nome válido.");
            }
        }

        // PUT: api/Categoria/5
        [HttpPut]
        public ActionResult<CategoriaEntity> Put([FromBody] CategoriaEntity categoria)
        {
            var nome = Validacoes.StringValidation(categoria.NOME);

            if (nome == true)
            {
                return _categoriaRepository.Update(categoria);
            }
            else
            {
                return BadRequest("Não foi possível atualizar esta categoria. Por favor, digite um nome válido.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var perfil = _compraRepository.GetCompraByCategoria(id).Count();

            if (perfil != 0)
            {
                return BadRequest("Impossivel excluir categorias já referenciadas.");
            }
            else
            {
                _categoriaRepository.Delete(id);
                return Ok();
            }
        }
    }
}
