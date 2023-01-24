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
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Preco).HasPrecision(10,2).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Estoque).IsRequired();
            builder.Property(x => x.Image).IsRequired(false);


            builder.Property<int>("IdCategoria");
        }
    }
}

