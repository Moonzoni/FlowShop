using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
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
        public StatusEntity Post([FromBody] StatusEntity status)
        {
            return _statusRepository.Add(status);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public ActionResult<StatusEntity> Put([FromBody] StatusEntity status)
        {
            try
            {
                return new OkObjectResult(_statusRepository.Update(status));
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
            _statusRepository.Delete(id);
        }
    }
}
