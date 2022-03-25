using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.FilmeDTO;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public  ReadFilmeDTO AdicionaFilme(CreateFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            _context.SaveChanges();

            ReadFilmeDTO dto = _mapper.Map<ReadFilmeDTO>(filme);

            return dto;
        }

        public  List<ReadFilmeDTO> RecuperarFilmes(string titulo, int? duracao)
        {
            List<Filme> filmes;
            if ((titulo == null) && (duracao == null))
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                if (titulo != null)
                    filmes = _context.Filmes.Where(f => f.Titulo.Contains(titulo)).ToList();
                else
                    filmes = _context.Filmes.ToList();

                if (duracao != null)
                    filmes = filmes.Where(f => f.Duracao <= duracao).ToList();
            }

            if (filmes != null)
            {
                var readDto = _mapper.Map<List<ReadFilmeDTO>>(filmes);

                return readDto;
            }

            return null;
        }

        public ReadFilmeDTO RecuperarFilmesPorId(Guid id)
        {
            var filme = _context.Filmes.Where(f => f.ID == id).FirstOrDefault();

            if (filme != null)
            {
                var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                //filmeDTO.DataHoraConsulta = new DateTime().Date;
                return filmeDTO;
            }
            return null;                 
        }

        public  Result DeletaFilme(Guid id)
        {
            var filme = _context.Filmes.Where(f => f.ID == id).FirstOrDefault();

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result AtualizaFilme(Guid id, UpdateFilmeDTO filmeDTO)
        {
            var filme = _context.Filmes.Where(f => f.ID == id).FirstOrDefault();

            if (filme == null)
            {

                return Result.Fail("Filme não encontrado");
            }

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
