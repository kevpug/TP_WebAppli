using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class ContexteAutoLoco : DbContext, ReadMe
    {
        public ContexteAutoLoco(DbContextOptions<ContexteAutoLoco> p_options) : base(p_options) { }

       public DbSet<Voiture> Voitures { get; set; }
       public DbSet<Succursale> Succursales { get; set; }
    }
}
