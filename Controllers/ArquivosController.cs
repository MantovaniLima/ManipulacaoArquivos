using ManipulacaoArquivos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManipulacaoArquivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArquivosController : ControllerBase
    {
        private readonly IArquivoService _arquivoService;
        private readonly IArquivoRepository _arquivoRepository;

        public ArquivosController(IArquivoService arquivoService, IArquivoRepository arquivoRepository)
        {
            _arquivoService = arquivoService;
            _arquivoRepository = arquivoRepository;
        }

        [HttpGet("json")]
        public IActionResult LerJson()
        {
            var dados = _arquivoService.LerJson();
            _arquivoRepository.SalvarDadosJson(dados);
            return Ok(dados);
        }

        [HttpGet("xml")]
        public IActionResult LerXml()
        {
            var dados = _arquivoService.LerXml();
            _arquivoRepository.SalvarDadosXml(dados);
            return Ok(dados);
        }
    }
}
