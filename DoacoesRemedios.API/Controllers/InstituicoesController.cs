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
    public class InstituicoesController : ControllerBase
    {
        private readonly IRepository<Instituicao> _repo;

        public InstituicoesController(IRepository<Instituicao> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult ListaTodos()
        {
            var lista = _repo.All.ToList();
            //.Where(x => x.Status == 1)
            //.Include(f => f.Children).ThenInclude(f => f.Parent)

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
        public IActionResult Incluir([FromBody] Instituicao model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(model);
                var uri = Url.Action("Recuperar", new { id = model.Id });
                return Created(uri, model); //201
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Instituicao model)
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
            //_repo.Update(model);
            _repo.Delete(model);
            return NoContent(); //203
        }
    }
}