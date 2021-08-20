using GraphQL;
using GraphQueryLanguage.Demo.Demo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PessoasDataApi.Controller
{
    [Route("graphql")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ClienteScheme _schema;

        public ClienteController(ILogger<ClienteController> logger, ClienteScheme schema)
        {
            _logger = logger;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryDTO query)
        {
            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = (Inputs)query.Variables; ;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
