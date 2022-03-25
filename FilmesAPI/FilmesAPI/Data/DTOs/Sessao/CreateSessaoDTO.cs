using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs.SessaoDTO
{
    public class CreateSessaoDTO
    {
        public Guid FilmeID { get; set; }

        public int CinemaID { get; set; }

        public DateTime HorarioDeTerminoSessao { get; set; }
    }
}
