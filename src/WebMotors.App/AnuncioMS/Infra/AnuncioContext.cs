using Microsoft.EntityFrameworkCore;
using WebMotors.App.AnuncioMS.Domain.Entities;

namespace WebMotors.App.AnuncioMS.Infra
{
    public class AnuncioContext : DbContext
    {
        public AnuncioContext(DbContextOptions<AnuncioContext> options)
          : base(options)
        { }

        public virtual DbSet<Anuncio> Anuncio { get; set; }
    }

}

