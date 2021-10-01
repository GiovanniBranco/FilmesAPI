using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI
{
    public class FilmeContext : DbContext
    {
        public DbSet<Filme> DbSetFilmes { get; set; }
        public FilmeContext(DbContextOptions options ) : base(options)
        {
        }
    }
}
