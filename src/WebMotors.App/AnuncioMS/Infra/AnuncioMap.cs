using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMotors.App.AnuncioMS.Domain.Entities;

namespace WebMotors.App.AnuncioMS.Infra
{
    public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {

            builder.ToTable("Anuncio");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Marca).IsRequired().HasColumnType("varchar(45)");
            builder.Property(t => t.Modelo).IsRequired().HasColumnType("varchar(45)");
            builder.Property(t => t.Versao).IsRequired().HasColumnType("varchar(45)");
            builder.Property(t => t.Ano).IsRequired().HasColumnType("integer");
            builder.Property(t => t.Quilometragem).IsRequired().HasColumnType("integer");
            builder.Property(t => t.Observacao).IsRequired().HasColumnType("text");

        }
    }
}
