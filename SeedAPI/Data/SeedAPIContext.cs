using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeedAPI.Model;

namespace SeedAPI.Models
{
    public class SeedAPIContext : DbContext
    {
        public SeedAPIContext (DbContextOptions<SeedAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SeedAPI.Model.Usuario> Usuario { get; set; }

        public DbSet<SeedAPI.Model.Curso> Curso { get; set; }

        public DbSet<SeedAPI.Model.Disciplina> Disciplina { get; set; }

        public DbSet<SeedAPI.Model.CursoDisciplina> CursoDisciplina { get; set; }

        public DbSet<SeedAPI.Model.PlanoDeAula> PlanoDeAula { get; set; }

        public DbSet<SeedAPI.Model.PlanoDeEnsino> PlanoDeEnsino { get; set; }

        public DbSet<SeedAPI.Model.Turma> Turma { get; set; }

        public DbSet<SeedAPI.Model.Login> LoginViewModels { get; set; }
    }
}
