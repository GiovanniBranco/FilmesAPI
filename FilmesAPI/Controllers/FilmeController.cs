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


        //Update
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme( int id, [FromBody]Filme filme)
        {
            Filme filmeDb = _context.DbSetFilmes.FirstOrDefault(f => f.Id == id);

            if (filmeDb != null)
            {
                filmeDb.Titulo = filme.Titulo;
                filmeDb.Diretor = filme.Diretor;
                filmeDb.Genero = filme.Genero;
                filmeDb.Duracao = filme.Duracao;

                _context.SaveChanges();
                //return Accepted(filmeDb);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme (int id )
        {
            Filme filmeDb = _context.DbSetFilmes.FirstOrDefault(f => f.Id == id);

            if(filmeDb != null)
            {
                _context.Remove(filmeDb);
                _context.SaveChanges();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
