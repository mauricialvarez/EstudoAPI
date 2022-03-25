using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.CinemaDTO;
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
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto dto = _cinemaService.AdicionaCinema(cinemaDto);
            
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = dto.Id }, dto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> dtos = _cinemaService.RecuperaCinemas(nomeDoFilme);            

            if (dtos != null)
                return Ok(dtos);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto dto = _cinemaService.RecuperaCinemasPorId(id);

            if (dto != null)
                return Ok(dto);
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result retorno = _cinemaService.AtualizaCinema(id, cinemaDto);

            if (retorno.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result retorno = _cinemaService.DeletaCinema(id);

            if (retorno.IsFailed)
                return NotFound();
            
            return NoContent();
        }

    }
}
