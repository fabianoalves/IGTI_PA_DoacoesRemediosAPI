using DoacoesRemedios.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoacoesRemedios.Data.EFConfigurations
{
    public class InstituicaoMap : IEntityTypeConfiguration<Instituicao>
    {
        public void Configure(EntityTypeBuilder<Instituicao> builder)
        {
            builder.ToTable("Instituicao");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(t => t.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(255)");

            builder.Property(t => t.Endereco).HasColumnName("Endereco").HasColumnType("varchar(255)");
            builder.Property(t => t.CEP).HasColumnName("CEP").HasColumnType("varchar(10)");
            builder.Property(t => t.Telefone).HasColumnName("Telefone").HasColumnType("varchar(50)");
            builder.Property(t => t.Email).HasColumnName("Email").HasColumnType("varchar(255)");

        }
    }
}
