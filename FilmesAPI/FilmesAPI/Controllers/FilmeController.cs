using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.FilmeDTO;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
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
        FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            ReadFilmeDTO dto = _filmeService.AdicionaFilme(filmeDTO);

            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { ID = dto.ID }, dto);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] string titulo = null, [FromQuery] int? duracao = null)
        {
            var dto = _filmeService.RecuperarFilmes(titulo, duracao);
            if (dto != null) 
                return Ok(dto);
            return NotFound();            
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(Guid id)
        {
            ReadFilmeDTO dto = _filmeService.RecuperarFilmesPorId(id);
            if (dto != null)
                return Ok(dto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(Guid id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Result retorno = _filmeService.AtualizaFilme(id, filmeDTO);
            if (retorno.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(Guid id)
        {
            Result retorno = _filmeService.DeletaFilme(id);
            if (retorno.IsFailed)
                return NotFound();

            return NoContent();
        }

    }
}
