using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_CEP.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string dbPath) : base()
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }

        string _dbPath;

        public DbSet<Endereço> Endereço { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
            ////var connectionString = @"Data Source=DESKTOP-A6A2CDS\SQLEXPRESS;Initial Catalog=CepDB;Integrated Security=True";
            //optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereço>()
               .HasKey(k => k.Id);

            modelBuilder.Entity<Endereço>()
                .Property(p => p.Rua)
                .IsRequired();

            modelBuilder.Entity<Endereço>()
               .Property(p => p.Bairro)
               .IsRequired();

            modelBuilder.Entity<Endereço>()
               .Property(p => p.Cidade)
               .IsRequired();

            modelBuilder.Entity<Endereço>()
                .HasData(
                    new Endereço
                    {
                        Id = Guid.NewGuid(),
                        Rua = "Rua do Ouvidor",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        CEP = "20040030"
                    },
                    new Endereço
                    {
                        Id = Guid.NewGuid(),
                        Rua = "Rua Gonçalves Dias",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        CEP = "20050030"
                    }
                );
        }

        public async Task<IEnumerable<Endereço>> List(bool forceRefresh = false)
        {
            return await Endereço
                .OrderByDescending(l => l.CEP)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Endereço> Get(string cep)
        {
            var endereços = await Endereço.ToListAsync().ConfigureAwait(false);

            return await Task.FromResult(endereços.FirstOrDefault(l => l.CEP == cep));
        }

        public async Task<bool> Add(Endereço endereço)
        {
            await Endereço.AddAsync(endereço).ConfigureAwait(false);

            await SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
