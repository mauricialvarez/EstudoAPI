using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs.SessaoDTO
{
    public class ReadSessaoDTO
    {
        public int ID { get; set; }
        public virtual Cinema Cinema { get; set; }

        public virtual Filme Filme { get; set; }

        public DateTime HorarioDeTerminoSessao { get; set; }
        public DateTime HorarioDeInicioSessao { get; set; }
    }
}
