using CriarVariavel.Entities;
using CriarVariavel.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        /// Cria e atribui valor a uma variável ou um conjunto de variáveis. Trata variáveis duplicadas renomeando-as automaticamente com adição de sufixos numéricos.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite a criação de variáveis a partir de uma lista de objetos contendo nome e valor.
        /// Caso existam variáveis com nomes duplicados, o serviço renomeia automaticamente adicionando sufixos numéricos para garantir unicidade (por exemplo, "variavel", "variavel1", "variavel2", etc.).
        /// </remarks>
        /// <param name="variaveis">Lista de variáveis a ser criada.</param>
        /// <response code="200">Variáveis criadas.</response>
        /// <response code="400">Parâmetro inválido ou mal formatado.</response>
        [ProducesResponseType(typeof(Dictionary<string, string>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("CriarVariavel")]
        public IActionResult CriarVariavel([FromBody] List<Variavel> variaveis)
        {
            return Ok(_criarVariavelService.CriarVariavel(variaveis));
        }
    }
}
