using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PessoasDataApi.Models;
using PessoasDataApi.Repository;
using PessoasDataApi.Services;
using PessoasDataApi.Services.Support;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using System.Diagnostics.CodeAnalysis;

namespace PessoasDataApi.Controller
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasService _pessoasService;
        private readonly IMessageService _messageService;
        private readonly IReturnStatusRepository _returnStatusRepository;
        private readonly IReturnStatusProvider _returnStatusProvider;


        public PessoasController(IPessoasService pessoasService, 
            IMessageService messageService, 
            IReturnStatusRepository returnStatusRepository, 
            IReturnStatusProvider returnStatusProvider)
        {
            _pessoasService = pessoasService;
            _messageService = messageService;
            _returnStatusRepository = returnStatusRepository;
            _returnStatusProvider = returnStatusProvider;
        }

        [HttpGet]
        [Route("Login")]
        [Authorize]
        public string Login() => string.Format("Usuario tem acesso a página");

        /// <summary>
        /// Traser todas as pessoas da base.
        /// </summary>
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

        /// <summary>
        /// Mostrar status dos bots em andamento.
        /// </summary>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(Cliente[]), 200)]
        public async Task<IActionResult> ListaRetornoBots()
        {
            try
            {
                return Ok(await _returnStatusProvider.Get());

            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });

            }
        }

        /// <summary>
        /// Traser pessoas de germany.
        /// </summary>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(PessoasGermany[]), 200)]
        public async Task<IActionResult> ListarPessoasGermany()
        {
            try
            {
                return Ok(await _pessoasService.ListarPessoasGermanyAsync());

            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });

            }
        }
        
        /// <summary>
        /// Inserir dados de pessoas na base.
        /// </summary>
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
        /// <summary>
        /// Inserir dados de pessoas na base germany.
        /// </summary>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> ExecutorBot([FromBody] Bot data)
        {
            try
            {
                //So funciona se estiver em IIS
                Console.WriteLine("Entrando no LogData!!");
                
                return Ok(_messageService.Enqueue(data));
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });

            }
        }

        /// <summary>
        /// Post de saida do bot.
        /// </summary>
        [HttpPost("[action]")]
        public async Task RetornoBotExecutor(Cliente product)
        {
            //_chatHub.SendMesssage(product.Description);
            await _returnStatusRepository.Create(product);
        
        }
        

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] User model)
        {
            //var user = UserRepository.Get(model.Username, model.Password);
            var user = CredencialUsuario.Get(model.Username, model.Password);

            if (user == null || user.Password == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };

        }

        /// <summary>
        /// Deletar dados pessoas.
        /// </summary>
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> DeletarPessoas(int id)
        {
            try
            {
                return Ok(await _pessoasService.DeletarPessoasAsync(id));

            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });

            }
        }

        [HttpDelete("[action]")]
        public async Task LimparExecucaoDeBots()
        {
            await _returnStatusRepository.Delete();
        }

        /// <summary>
        /// Deletar dados pessoas germany.
        /// </summary>
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> DeletarPessoasGermany(string id)
        {
            try
            {
                return Ok(await _pessoasService.DeletarPessoasGermanyAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atulizar dados pessoas da base.
        /// </summary>
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> AtualizarPessoas([FromBody] Pessoas[] step)
        {
            try
            {

                return Ok(await _pessoasService.AtualizarPessoasAsync(step));
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message });
            }
            
        }
        
    }
}