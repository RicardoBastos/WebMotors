using System.Collections.Generic;
using WebMotors.App.AnuncioMS.Domain.Entities;

namespace WebMotors.App.AnuncioMS.Domain.Interfaces.Repositories
{
    public interface IAnuncioRepository
    {
        void Incluir(Anuncio anuncio);
        void Remover(int id);
        void Atualizar(Anuncio anuncio);
        Anuncio ConsultarPorId(int id);
        IEnumerable<Anuncio> ConsultarTodos();
        void SaveChanges();
    }
}


