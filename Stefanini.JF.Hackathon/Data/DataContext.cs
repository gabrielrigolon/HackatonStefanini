using Stefanini.JF.Hackathon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Stefanini.JF.Hackathon.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=GABRIELRIGOEA9D\\SQLEXPRESS;Integrated Security=False;Initial Catalog=enem;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Avaliador> Avaliadores { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
    }
}
