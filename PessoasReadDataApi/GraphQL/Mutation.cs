using HotChocolate;
using HotChocolate.Subscriptions;
using PessoasDataApi.Models;
using PessoasDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.GraphQL
{
    public class Mutation
    {
        private readonly IBotRetornoService _botService;

        public Mutation(IBotRetornoService botService)
        {
            _botService = botService;
        }

        public BotsRetorno CreateRetornoBot(CreateBotRetornoInput inpuBotRetorno)
        {
            return _botService.Create(inpuBotRetorno);
        }
        public BotsRetorno DeleteRetornoBot(DeleteBotRetornoInput inpuBotRetorno)
        {
            return _botService.Delete(inpuBotRetorno);
        }
        public async Task<string> AddNewRetornoBot([Service] ITopicEventSender eventSender, BotsRetorno bot)
        {
            await eventSender.SendAsync(nameof(SubscriptionObjectType.SubscribeBotExecution), bot);
            return bot.Nome;
        }

    }
}
