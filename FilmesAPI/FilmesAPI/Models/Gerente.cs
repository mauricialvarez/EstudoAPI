using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
