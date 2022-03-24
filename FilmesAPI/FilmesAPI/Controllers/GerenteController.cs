using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.GerenteDTO;
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
    public class GerenteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public IActionResult AdicionaGerente(CreateGerenteDTO dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaGerentePorID), new { id = gerente.ID }, gerente);
        }

        private IActionResult RecuperaGerentePorID(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(f => f.ID == id);

            if (gerente != null)
            {
                var gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
                return Ok(gerenteDTO);
            }
            return NotFound();
        }
    }
}
