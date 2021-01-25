using System;
using System.Collections.Generic;
using System.Linq;
using DoacoesRemedios.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoacoesRemedios.Domain;

namespace DoacoesRemedios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepository<Usuario> _repo;

        public UsuariosController(IRepository<Usuario> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult ListaTodos()
        {
            var lista = _repo.All.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var model = _repo.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                if (_repo.All.Where(x => x.Email == model.Email).Count() > 0) {
                    return BadRequest("Usuario já cadastrado!");
                }
                model.Senha = Encryption.Encrypt(model.Senha);
                _repo.Add(model);
                var uri = Url.Action("Recuperar", new { id = model.Id });
                return Created(uri, model); //201
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(model);
                return Ok(); //200
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var model = _repo.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Delete(model);
            return NoContent(); //203
        }
    }
}