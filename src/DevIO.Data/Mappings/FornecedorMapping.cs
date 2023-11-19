using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {

        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome");

            builder.Property(x => x.Documento)
                    .IsRequired()
                    .HasColumnType("varchar(14)")
                    .HasColumnName("Documento");

            builder.Property(x => x.TipoFornecedor)
                    .IsRequired()
                    .HasColumnType("int")
                    .HasColumnName("TipoFornecedor");
            
            builder.Property(x => x.Ativo)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasColumnName("Ativo");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
