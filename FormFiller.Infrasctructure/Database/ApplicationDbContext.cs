using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormFiller.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace FormFiller.Infrasctructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<Generator> Generators { get; set; }
        public DbSet<Param> Params { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
