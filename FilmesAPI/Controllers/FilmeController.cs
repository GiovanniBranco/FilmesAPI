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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        //Post
        [HttpPost]
        public IActionResult AdicionaFilmes( [FromBody] Filme filme )
        {
            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFilmesPorID), new { Id = filme.Id }, filme);
        }

        //GetAll
        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        }

        //GetByID
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorID( int id )
        {
            //Varre a lista e retorna o filme com o mesmo Id do parâmetro;
            Filme filme = filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
