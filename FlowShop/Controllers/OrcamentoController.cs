using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public OrcamentoEntity Post([FromBody] OrcamentoEntity orcamento)
        {
            return _orcamentoRepository.Add(orcamento);
        }

        // PUT: api/Perfil/5
        [HttpPut("{id}")]
        public ActionResult<OrcamentoEntity> Put([FromBody] OrcamentoEntity orcamento)
        {
            try
            {
                return new OkObjectResult(_orcamentoRepository.Update(orcamento));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new
                {
                    Status = false,
                    Message = e.Message,
                    Stack = e.StackTrace,
                    Description = "Errou"
                });
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

