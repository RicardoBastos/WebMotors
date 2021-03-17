using System.Collections.Generic;
using System.Linq;
using WebMotors.App.AnuncioMS.Domain.Entities;
using WebMotors.App.AnuncioMS.Domain.Interfaces.Repositories;

namespace WebMotors.App.AnuncioMS.Infra.Repositories
{
    public class AnuncioRepository:IAnuncioRepository
    {
        private readonly AnuncioContext _context;

        public AnuncioRepository(AnuncioContext context) => _context = context;

        public void Atualizar(Anuncio anuncio)
        {
            _context.Entry(anuncio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Anuncio ConsultarPorId(int id)
        {
            return _context.Anuncio.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Anuncio> ConsultarTodos()
        {
            return _context.Anuncio.ToList();
        }

        public void Incluir(Anuncio anuncio)
        {
            _context.Anuncio.Add(anuncio);
        }

        public void Remover(int id)
        {
            var entityToDelete = _context.Anuncio.FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null)
            {
                _context.Anuncio.Remove(entityToDelete);
            }
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}
