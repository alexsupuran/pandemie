using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pandemie.Models;

namespace pandemie.Data
{
    public class pandemieContext : DbContext
    {
        public pandemieContext (DbContextOptions<pandemieContext> options)
            : base(options)
        {
        }

        public DbSet<pandemie.Models.Producator> Producator { get; set; } = default!;

        public DbSet<pandemie.Models.Vaccin>? Vaccin { get; set; }

        public DbSet<pandemie.Models.Tara>? Tara { get; set; }

        public DbSet<pandemie.Models.Tip>? Tip { get; set; }

        public DbSet<pandemie.Models.Fond>? Fond { get; set; }

        public DbSet<pandemie.Models.Membru>? Membru { get; set; }

        public DbSet<pandemie.Models.Achizitie>? Achizitie { get; set; }
    }
}
