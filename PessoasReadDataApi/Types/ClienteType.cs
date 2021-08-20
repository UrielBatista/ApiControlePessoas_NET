using GraphQL.Types;
using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Types
{
    public class ClienteType : ObjectGraphType<Cliente>
    {
        public ClienteType()
        {
            Name = "Cliente";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id cliente");
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.Processo).Description("Telefone do cliente");
        }
    }
}
