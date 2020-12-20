using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AplicationContext context;

        public CategoriaController(AplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return context.Categorias.ToList();
        }

        [HttpGet("{id}", Name = "categoriaCriada")]
        public IActionResult GetById( int id)
        {
            var cat = context.Categorias.FirstOrDefault(x=> x.Id == id);
            if(cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return new CreatedAtRouteResult("categoriaCriada", new { id = categoria.Id}, categoria);
            }

            return BadRequest(ModelState);
        }
    }
}
