using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.GerenteDTO;
using FilmesAPI.Data.DTOs.SessaoDTO;
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
    public class SessaoController  : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDTO dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaSessaoPorID), new { id = sessao.ID }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorID(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(f => f.ID == id);

            if (sessao != null)
            {
                var dto = _mapper.Map<ReadSessaoDTO>(sessao);
                return Ok(dto);
            }
            return NotFound();
        }


    }
}
