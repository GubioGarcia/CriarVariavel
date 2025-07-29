using CriarVariavel.Entities;
using CriarVariavel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriarVariavel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriarVariavelController : ControllerBase
    {
        private readonly ICriarVariavelService _criarVariavelService;

        public CriarVariavelController(ICriarVariavelService criarVariavelService)
        {
            _criarVariavelService = criarVariavelService;
        }

        /// <summary>
        /// Cria e atibui valor a uma variável ou um conjunto de variáveis. Trata variáveis duplicadas renomeando-as automaticamente com adição de sufixos numéricos.
        /// </summary>
        /// <param name="variaveis">Objeto correspondente a chave e valor da variável a ser criada.</param>
        /// <returns>Resultado da operação</returns>
        [HttpPost("CriarVariavel")]
        public IActionResult CriarVariavel([FromBody] List<Variavel> variaveis)
        {
            return Ok(_criarVariavelService.CriarVariavel(variaveis));
        }
    }
}
