using Microsoft.EntityFrameworkCore;
using DoacoesRemedios.Data.EFConfigurations;
using DoacoesRemedios.Domain;

namespace DoacoesRemedios.Data
{
    public class GNLiteDbContext: DbContext
    {
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public GNLiteDbContext(DbContextOptions<GNLiteDbContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Instituicao>(new InstituicaoMap());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioMap());
        }
    }
}
