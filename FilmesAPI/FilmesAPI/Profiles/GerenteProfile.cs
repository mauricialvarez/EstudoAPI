using AutoMapper;
using FilmesAPI.Data.DTOs.GerenteDTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(g => g.Cinemas, opts => opts
                    .MapFrom(gerente => gerente.Cinemas.Select
                    (c => new { c.Id, c.Nome, c.EnderecoID})));
        }
    }
}
