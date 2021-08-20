using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using PessoasDataApi.Queries;
using System;

namespace GraphQueryLanguage.Demo.Demo
{
    /// <summary>
    /// Descreve a funcionalidade disponível para os clientes que se conectam a ele.
    /// </summary>
    public class ClienteScheme : Schema
    {
        public ClienteScheme(IServiceProvider serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ClientQuery>();

        }
    }
}

