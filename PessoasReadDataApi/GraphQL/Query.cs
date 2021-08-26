using HotChocolate.Types;
using PessoasDataApi.Models;
using PessoasDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.GraphQL
{
    public class Query
    {
        private readonly IGroupService _groupService;
        private readonly IBotRetornoService _botService;

        public Query(IGroupService groupService, IBotRetornoService botService)
        {
            _groupService = groupService;
            _botService = botService;
        }
        [UsePaging(SchemaType = typeof(GroupType))]
        [UseFiltering]
        public IQueryable<Group> Groups => _groupService.GetAll();

        [UsePaging(SchemaType = typeof(BotsRetornoType))]
        [UseFiltering]
        public IQueryable<BotsRetorno> BotsRetornoClients => _botService.GetAll();

    }
}
