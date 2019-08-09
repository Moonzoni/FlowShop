using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using FlowShop;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlowShop_INFRA;

namespace FlowShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController: ControllerBase
    {
        private readonly IOrcamentoRepository _orcamentoRepository;
        public OrcamentoController(IOrcamentoRepository orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        // GET: api/Perfil
        [HttpGet]
        public IEnumerable<OrcamentoEntity> Get()
        {
            return _orcamentoRepository.GetAll(); 
        }

        // GET: api/Perfil/5
        [HttpGet("{id}")]
        public OrcamentoEntity Get(int id)
        {
            return _orcamentoRepository.Get(id);
        }

        // POST: api/Perfil
        [HttpPost]
        public ActionResult<OrcamentoEntity> Post([FromBody] OrcamentoEntity orcamento)
        {
            var nome = Validacoes.StringValidation(orcamento.NOME);

            if (nome == true)
            {
                return Ok(_orcamentoRepository.Add(orcamento));
            }
            else
            {
                return BadRequest("Não foi possível atualizar este orçamento. Por favor, digite um nome válido.");
            }
        }

        // PUT: api/Perfil/5
        [HttpPut("{id}")]
        public ActionResult<OrcamentoEntity> Put([FromBody] OrcamentoEntity orcamento)
        {
            var nome = Validacoes.StringValidation(orcamento.NOME);

            if (nome == true)
            {
                    return Ok(_orcamentoRepository.Update(orcamento));
            }
            else
            {
                return BadRequest("Não foi possível atualizar este orçamento. Por favor, digite um nome válido.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orcamentoRepository.Delete(id);
        }
    }
}