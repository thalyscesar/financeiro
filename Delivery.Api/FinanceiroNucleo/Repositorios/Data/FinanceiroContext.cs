using FinanceiroNucleo.Negocio;
using FinanceiroNucleo.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceiroNucleo.Repositorios.Data
{
    public class FinanceiroContext:DbContext, IUnitOfWork
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> options) : base(options) { }

        public DbSet<ContaAPagar> ContasAPagar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceiroContext).Assembly);
        }

        public bool Commit()
        {
            return SaveChanges() > 0;
        }

    }
}
