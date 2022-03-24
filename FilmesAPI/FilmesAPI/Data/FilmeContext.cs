using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(e => e.Cinema)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Cinema>(c => c.EnderecoID);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }        
        public DbSet<Gerente> Gerentes { get; set; }
    }
}
