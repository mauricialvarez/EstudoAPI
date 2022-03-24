using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { ID = filme.ID }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(Guid id)
        {
            var filme = _context.Filmes.Where(f => f.ID == id).FirstOrDefault();

            if (filme != null)
            {
                var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                //filmeDTO.DataHoraConsulta = new DateTime().Date;
                return Ok(filmeDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(Guid id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            var filme = _context.Filmes.Where(f => f.ID == id).FirstOrDefault();

            if (filme == null)
            {
                
                return NotFound();
            }

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(Guid id)
        {
            var filme = _context.Filmes.Where(f => f.ID == id).FirstOrDefault();

            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
