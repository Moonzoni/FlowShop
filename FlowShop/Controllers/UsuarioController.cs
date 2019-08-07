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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController (IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioEntity> Get()
        {
            return _usuarioRepository.GetAll();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public UsuarioEntity Get(int id)
        {
            return _usuarioRepository.Get(id);
        }

        // POST: api/Usuario
        [HttpPost]
        public UsuarioEntity Post([FromBody] UsuarioEntity usuario)
        {
            return _usuarioRepository.Add(usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public ActionResult<UsuarioEntity> Put([FromBody] UsuarioEntity usuario)
        {
            try
            {
                return new OkObjectResult(_usuarioRepository.Update(usuario));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new
                {
                    Status = false,
                    Message = e.Message,
                    Stack = e.StackTrace,
                    Description = "Errrouuuuuuuuu"
                });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _usuarioRepository.Delete(id);
        }
    }
}
