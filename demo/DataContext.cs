using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace d2d.Models.repositorios
{
    public class DataContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DataContext()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}