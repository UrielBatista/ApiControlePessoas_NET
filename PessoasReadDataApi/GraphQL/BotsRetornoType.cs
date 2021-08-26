using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using PessoasDataApi.Models;
using PessoasDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.GraphQL
{
    public class BotsRetornoType : ObjectType<BotsRetorno>
    {
        protected override void Configure(IObjectTypeDescriptor<BotsRetorno> descriptor)
        {
            descriptor.Field(x => x.RetornoId).Type<IdType>();
            descriptor.Field(x => x.Nome).Type<StringType>();
            descriptor.Field(x => x.Processo).Type<StringType>();
            descriptor.Field<GroupResolver>(x => x.GetGroup(default, default));

        }
    }
    public class GroupResolver
    {
        private readonly IGroupService _groupService;

        public GroupResolver([Service] IGroupService groupService)
        {
            _groupService = groupService;
        }

        public Group GetGroup(BotsRetorno bot, IResolverContext ctx)
        {
            return _groupService.GetAll().Where(x => x.GroupId == bot.GroupId).FirstOrDefault();
        }
    }
}

