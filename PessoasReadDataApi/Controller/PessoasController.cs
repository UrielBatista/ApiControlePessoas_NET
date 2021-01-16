using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PessoasDataApi.Domain;
using PessoasDataApi.Repository;
using PessoasDataApi.Services;
using PessoasDataApi.Services.Support;

namespace PessoasDataApi.Controller
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasService _pessoasService;

        public PessoasController(IPessoasService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(Pessoas[]), 200)]
        public async Task<IActionResult> ListarPessoas()
        {
            try
            {
                return Ok(await _pessoasService.ListarPessoasAsync());

            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
               
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> InserirPessoas([FromBody]Pessoas[] step)
        {
            try
            {
                return Ok(await _pessoasService.InserirPessoasAsync(step));
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
               
            }
        }
    }
}