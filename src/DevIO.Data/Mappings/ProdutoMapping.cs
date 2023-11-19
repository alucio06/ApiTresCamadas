using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)")
                .HasColumnName("Descricao");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,4)")
                .HasColumnName("Valor");

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("Ativo");

            builder.ToTable("Produtos");
        }
    }
}
