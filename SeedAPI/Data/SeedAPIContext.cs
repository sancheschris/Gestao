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
    }
}
