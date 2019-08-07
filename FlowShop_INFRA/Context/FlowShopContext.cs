using System;
using System.Collections.Generic;
using System.Text;
using FlowShop_INFRA.Entity;
using Microsoft.EntityFrameworkCore;

namespace FlowShop_INFRA.Context
{
    public class FlowShopContext : DbContext
    {
        public FlowShopContext(DbContextOptions<FlowShopContext> dbContextOptions) : base(dbContextOptions) { }
        

        public void SendChanges()
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PerfilEntity>()
                .HasKey(x => x.COD_PERFIL);
            modelBuilder.Entity<StatusEntity>()
                .HasKey(x => x.COD_STATUS);
            modelBuilder.Entity<CategoriaEntity>()
                .HasKey(x => x.COD_CATEGORIA);
            modelBuilder.Entity<CompraEntity>()
                .HasKey(x => x.COD_COMPRA);
             modelBuilder.Entity<OrcamentoEntity>()
                .HasKey(x => x.COD_ORCAMENTO);
            modelBuilder.Entity<UsuarioEntity>()
                .HasKey(x => x.COD_USUARIO);

        }
    }
}
