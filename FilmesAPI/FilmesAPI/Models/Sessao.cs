using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Filme Filme { get; set; }

        public Guid FilmeID { get; set; }

        public int CinemaID { get; set; }

        public DateTime HorarioDeTerminoSessao { get; set; }


    }
}
