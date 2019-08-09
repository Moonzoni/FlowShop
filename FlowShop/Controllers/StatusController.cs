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
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ICompraRepository _compraRepository;
        public StatusController(IStatusRepository statusRepository, ICompraRepository compraRepository)
        {
            _statusRepository = statusRepository;
            _compraRepository = compraRepository;
        }

        // GET: api/Status
        [HttpGet]
        public IEnumerable<StatusEntity> Get()
        {
            return _statusRepository.GetAll();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public StatusEntity Get(int id)
        {
            return _statusRepository.Get(id);
        }

        // POST: api/Status
        [HttpPost]
        public ActionResult<StatusEntity> Post([FromBody] StatusEntity status)
        {
            var nome = Validacoes.StringValidation(status.NOME);

            if (nome == true)
            {
                return _statusRepository.Add(status);
            }
            else
            {
                return BadRequest("Não foi possível atualizar este status. Por favor, digite um nome válido.");
            }

            
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public ActionResult<StatusEntity> Put([FromBody] StatusEntity status)
        {
            var nome = Validacoes.StringValidation(status.NOME);

            if (nome == true)
            {
                return _statusRepository.Update(status);
            }
            else
            {
                return BadRequest("Não foi possível atualizar este status. Por favor, digite um nome válido.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var perfil = _compraRepository.GetCompraByStatus(id).Count();

            if (perfil != 0)
            {
                return BadRequest("Impossivel excluir status já referenciadas.");
            }
            else
            {
                _statusRepository.Delete(id);
                return Ok();
            }
        }
    }
}
