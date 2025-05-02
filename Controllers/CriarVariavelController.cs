using CriarVariavel.Entities;
using CriarVariavel.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriarVariavel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriarVariavelController : ControllerBase
    {
        private readonly CriarVariavelService _criarVariavelService;

        public CriarVariavelController(CriarVariavelService criarVariavelService)
        {
            _criarVariavelService = criarVariavelService;
        }

        [HttpPost("CriarVariavel")]
        public IActionResult CriarVariavel([FromBody] List<Variavel> variaveis)
        {
            return Ok(_criarVariavelService.CriarVariavel(variaveis));
        }
    }
}
