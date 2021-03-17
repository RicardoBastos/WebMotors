using WebMotors.App.AnuncioMS.Domain.Commands;
using WebMotors.App.AnuncioMS.Domain.Entities;
using WebMotors.App.AnuncioMS.Domain.Interfaces.Repositories;
using WebMotors.App.AnuncioMS.Domain.Interfaces.Services;
using WebMotors.App.Shared.Domain;

namespace WebMotors.App.AnuncioMS.Domain.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;

        private Anuncio anuncio = new Anuncio();
        private RetornoService retornoService = new RetornoService();

        public AnuncioService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public RetornoService Atualizar(AtualizarCmd anuncioCmd, int id)
        {
            //Validacoes que não foram implementadas, poderia fazer com FluentValidation
            anuncio.SetAnuncio(anuncioCmd.Marca, anuncioCmd.Modelo, anuncioCmd.Versao, anuncioCmd.Ano, anuncioCmd.Quilometragem, anuncioCmd.Observacao);
            anuncio.SetId(id);

            //Posso add erros com comando abaixo
            //retornoService.AddError("Mensagem de erro");

            _anuncioRepository.Atualizar(anuncio);
            _anuncioRepository.SaveChanges();

            retornoService.Mensagem = "Atualizado com sucesso";
            return retornoService;
        }

        public RetornoService ConsultarPorId(int id)
        {
            var anuncioUnico = _anuncioRepository.ConsultarPorId(id);

            //Mapeamento para Queries
            retornoService.Retorno = anuncioUnico;
            return retornoService;
        }

        public RetornoService ConsultarTodos()
        {
            var lstAnuncios = _anuncioRepository.ConsultarTodos();

            //Mapeamento para Queries
            retornoService.Retorno = lstAnuncios;
            return retornoService;
        }

        public RetornoService Incluir(IncluirCmd anuncioCmd)
        {
            //Validacoes que não foram implementadas, poderia fazer com FluentValidation
            //Tamanhos de varchar no banco, verificar se já possui o registro cadastrado etc
            anuncio.SetAnuncio(anuncioCmd.Marca, anuncioCmd.Modelo, anuncioCmd.Versao, anuncioCmd.Ano, anuncioCmd.Quilometragem, anuncioCmd.Observacao);


            //Posso add erros com comando abaixo
            //retornoService.AddError("Mensagem de erro");

            _anuncioRepository.Incluir(anuncio);
            _anuncioRepository.SaveChanges();

            retornoService.Mensagem = "Incluído com sucesso";
            return retornoService;
        }

        public RetornoService Remover(int id)
        {
            _anuncioRepository.Remover(id);
            _anuncioRepository.SaveChanges();

            retornoService.Mensagem = "Excluído com sucesso";
            return retornoService;
        }
    }
}
