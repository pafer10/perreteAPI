using Microsoft.EntityFrameworkCore;
using PerreteAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerreteAPI.Application.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        private const string Schema = "perrete";

        public DbSet<Perrete> Perrete {  get; set; }

        public DataBaseContext(DbContextOptions options) : base(options) { }
    }
}
