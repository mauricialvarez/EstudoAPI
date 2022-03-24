using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs.GerenteDTO
{
    public class ReadGerenteDTO
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
