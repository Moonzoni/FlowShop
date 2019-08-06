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
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
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
        public CategoriaEntity Post([FromBody] CategoriaEntity categoria)
        {
            return _categoriaRepository.Add(categoria);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]

        public ActionResult<CategoriaEntity> Put([FromBody] CategoriaEntity categoriaEntity)
        {
            try
            {
                return new OkObjectResult(_categoriaRepository.Update(categoriaEntity));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new
                {
                    Status = false,
                    Message = e.Message,
                    Stack = e.StackTrace,
                    Description = "Erro"

                });

            }
        }
       

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoriaRepository.Delete(id);
        }
    }
}
