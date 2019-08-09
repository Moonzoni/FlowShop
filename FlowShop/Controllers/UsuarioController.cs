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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICompraRepository _compraRepository;
        public UsuarioController (IUsuarioRepository usuarioRepository, ICompraRepository compraRepository)
        {
            _usuarioRepository = usuarioRepository;
            _compraRepository = compraRepository;
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
        public ActionResult<UsuarioEntity> Post([FromBody] UsuarioEntity usuario)
        {
            usuario.NOME = usuario.NOME.Trim(' ');
            if (String.IsNullOrEmpty(usuario.NOME))
            {
                return BadRequest("Nome vazio");
            }
            var nome = Validacoes.StringValidation(usuario.NOME);
            var email = Validacoes.EmailValidation(usuario.EMAIL);

            if (nome && email == true)
            {
                return _usuarioRepository.Add(usuario);
            }
            else
            {
                return BadRequest("Não foi possível atualizar este usuário. Por favor, digite um nome ou email válido.");
            }
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public ActionResult<UsuarioEntity> Put([FromBody] UsuarioEntity usuario)
        {
            usuario.NOME = usuario.NOME.Trim(' ');
            if (String.IsNullOrEmpty(usuario.NOME))
            {
                return BadRequest("Nome vazio");
            }
            var nome = Validacoes.StringValidation(usuario.NOME);
            var email = Validacoes.EmailValidation(usuario.EMAIL);

            if (email && nome == true)
            {
                return new OkObjectResult(_usuarioRepository.Update(usuario));
            }
            else
            {
                return BadRequest("Não foi possível atualizar este usuário. Por favor, digite um nome válido.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var compra = _compraRepository.GetCompraByUsuario(id).Count();

            if (compra != 0)
            {
                return BadRequest("Impossivel excluir registros já referenciados.");
            }
            else
            {
                _usuarioRepository.Delete(id);
                return Ok();
            }
        }
    }
}
