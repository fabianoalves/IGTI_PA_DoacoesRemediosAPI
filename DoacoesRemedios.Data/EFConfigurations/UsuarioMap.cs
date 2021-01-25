using DoacoesRemedios.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoacoesRemedios.Data.EFConfigurations
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(t => t.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(255)");         

            builder.Property(t => t.Email).HasColumnName("Email").HasColumnType("varchar(255)");
            builder.Property(t => t.Senha).HasColumnName("Senha").HasColumnType("varchar(255)");
        }
    }
}
