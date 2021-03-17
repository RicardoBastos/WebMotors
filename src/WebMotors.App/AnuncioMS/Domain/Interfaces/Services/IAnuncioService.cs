using WebMotors.App.AnuncioMS.Domain.Commands;
using WebMotors.App.Shared.Domain;

namespace WebMotors.App.AnuncioMS.Domain.Interfaces.Services
{
    public interface IAnuncioService
    {
        RetornoService ConsultarTodos();
        RetornoService ConsultarPorId(int id);
        RetornoService Incluir(IncluirCmd anuncioCmd);
        RetornoService Atualizar(AtualizarCmd anuncioCmd, int id);

        RetornoService Remover(int id);

    }
}
