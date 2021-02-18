using System;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=M120Connectionstring")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.Context, M120Projekt.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Entity<KlasseA>().ToTable("KlasseA"); // Damit kein "s" angehängt wird an Tabelle
        }
        public DbSet<KlasseA> KlasseA { get; set; }
    }
}
