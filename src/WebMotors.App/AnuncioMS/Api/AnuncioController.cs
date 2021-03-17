using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMotors.App.AnuncioMS.Domain.Commands;
using WebMotors.App.AnuncioMS.Domain.Interfaces.Services;
using WebMotors.App.Shared.Api;
using WebMotors.App.Shared.Domain;

namespace WebMotors.App.AnuncioMS.Api
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }


        [HttpGet(Routes.Anuncio.ConsultarAnuncion)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RetornoService))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAll()
        {
            var retornoService = _anuncioService.ConsultarTodos();
            return Ok(retornoService);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RetornoService))]
        [HttpGet(Routes.Anuncio.ConsultarAnuncioPorId)]
        public IActionResult GetById(int id)
        {
            var retornoService = _anuncioService.ConsultarPorId(id);
            return Ok(retornoService);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RetornoService))]
        [HttpPost(Routes.Anuncio.IncluirAnuncio)]
        public IActionResult Post([FromBody]IncluirCmd anuncio)
        {
            var retornoService = _anuncioService.Incluir(anuncio);
            return Created(string.Empty, retornoService);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RetornoService))]
        [HttpPut(Routes.Anuncio.AtualizarAnuncio)]
        public IActionResult Put(int id, [FromBody]AtualizarCmd anuncio)
        {
            var retornoService = _anuncioService.Atualizar(anuncio, id);
            return Ok(retornoService);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RetornoService))]
        [HttpDelete(Routes.Anuncio.RemoverAnuncio)]
        public IActionResult Delete(int id)
        {
            var retornoService = _anuncioService.Remover(id);
            return Ok(retornoService);
        }
    }
}
