using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Logradouro");

            builder.Property(x => x.Numero)
               .IsRequired()
               .HasColumnType("varchar(50)")
               .HasColumnName("Numero");

            builder.Property(x => x.Cep)
               .IsRequired()
               .HasColumnType("varchar(8)")
               .HasColumnName("Cep");

            builder.Property(x => x.Complemento)
               .IsRequired(false)
               .HasColumnType("varchar(250)")
               .HasColumnName("Complemento");

            builder.Property(x => x.Bairro)
               .IsRequired()
               .HasColumnType("varchar(100)")
               .HasColumnName("Bairro");

            builder.Property(x => x.Cidade)
               .IsRequired()
               .HasColumnType("varchar(100)")
               .HasColumnName("Cidade");

            builder.Property(x => x.Estado)
               .IsRequired()
               .HasColumnType("varchar(50)")
               .HasColumnName("Estado");

            builder.ToTable("Enderecos");
        }
    }
}
