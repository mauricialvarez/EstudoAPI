using AutoMapper;
using FilmesAPI.Data.DTOs.SessaoDTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeInicioSessao, opts => opts
                    .MapFrom(dto => dto.HorarioDeTerminoSessao.AddMinutes(dto.Filme.Duracao*(-1))));
        }
    }
}
