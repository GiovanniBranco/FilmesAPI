using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;

        public FilmeController( FilmeContext filmeContext )
        {
            this._context = filmeContext;
        }


        //Post
        [HttpPost]
        public IActionResult AdicionaFilmes( [FromBody] Filme filme )
        {
            _context.DbSetFilmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaFilmesPorID), new { Id = filme.Id }, filme);
        }

        //GetAll
        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.DbSetFilmes);
        }

        //GetByID
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorID( int id )
        {
            //Varre a lista e retorna o filme com o mesmo Id do parâmetro;
            Filme filme = _context.DbSetFilmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
