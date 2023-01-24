using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.MapeamentoEntidades
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();

            builder
                .HasMany(c => c.Produtos) // uma categoria pode ter varios produtos
                .WithOne(p => p.Categoria) // um produto pode ter uma categoria
                .HasForeignKey("IdCategoria"); // chave strangeira fica em produtos com essse nome especificado

            builder.HasData(
           new Categoria(1, "Material Escolar"),
                new Categoria(2, "Eletrônicos"),
                new Categoria(3, "Acessórios")
                );
        }

    }
}
