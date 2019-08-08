using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FlowShop_INFRA.Entity;
using FlowShop_INFRA.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public PerfilController(IUsuarioRepository usuarioRepository, 
            IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Perfil
        [HttpGet]
        public IEnumerable<PerfilEntity> Get()
        {
            return _perfilRepository.GetAll(); ;
        }

        // GET: api/Perfil/5
        [HttpGet("{id}")]
        public PerfilEntity Get(int id)
        {
            return _perfilRepository.Get(id);
        }

        // POST: api/Perfil
        [HttpPost]
        public PerfilEntity Post([FromBody] PerfilEntity perfil)
        {
            return _perfilRepository.Add(perfil);
        }

        // PUT: api/Perfil/5
        [HttpPut("{id}")]
        public ActionResult<PerfilEntity> Put([FromBody] PerfilEntity perfil)
        {
            try
            {
                return new OkObjectResult(_perfilRepository.Update(perfil));
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
        public ActionResult Delete(int id)
        {
            var perfil = _usuarioRepository.GetUsuarioPorPerfil(id).Count();
            
            if (perfil != 0)
            {
                return BadRequest("Impossivel excluir registros já referenciados.");

            }
            else
            {
                _perfilRepository.Delete(id);
                return Ok();
            }
            
        }
    }
}
