using HotChocolate;
using HotChocolate.Types;
using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.GraphQL
{
    public class SubscriptionObjectType
    {

        [Topic]
        [Subscribe]
        public BotsRetorno SubscribeBotExecution([EventMessage] BotsRetorno bot)
        {
            return bot;
        }
    }
}
