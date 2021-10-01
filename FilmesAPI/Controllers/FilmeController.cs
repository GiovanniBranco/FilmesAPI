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
        public Filme AdicionaFilmes([FromBody]Filme filme )
        {
            filme.Id = id++;
            filmes.Add(filme);

            return filme;
        }

        //GetAll
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return filmes;
        }

        //GetByID
        [HttpGet("{id}")]
        public Filme RecuperaFilmesPorID(int id )
        {
            //Varre a lista e retorna o filme com o mesmo Id do parâmetro;
            return filmes.FirstOrDefault(f => f.Id == id);
        }
    }
}
