using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController( FilmeContext filmeContext, IMapper mapper )
        {
            this._context = filmeContext;
            this._mapper = mapper;
        }


        //Post
        [HttpPost]
        public IActionResult AdicionaFilmes( [FromBody] CreateFilmeDto filmeDto )
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

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
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now;

                return Ok(filmeDto);
            }
            return NotFound();
        }


        //Update
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme( int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filmeDb = _context.DbSetFilmes.FirstOrDefault(f => f.Id == id);

            if (filmeDb != null)
            {
                _mapper.Map(filmeDto, filmeDb);
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
