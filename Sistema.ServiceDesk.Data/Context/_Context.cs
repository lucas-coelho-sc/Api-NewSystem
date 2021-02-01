using Microsoft.EntityFrameworkCore;
using Sistema.ServiceDesk.Data.Tabelas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.ServiceDesk.Data.Context
{
    public class _Context : DbContext
    {
        public DbSet<TblDeltaLog> AtendimentosDeltaLog { get; set; }
        public DbSet<TblFilial> Filiais { get; set; }
        public DbSet<TblGeral> AtendimentosGerais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ServiceDesk;Data Source=ALBR-3WGPDQ2-L\LUCAS_DB_LOCAL");
        }



    }

    
}
