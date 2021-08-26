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
    public class GroupType : ObjectType<Group>
    {
        protected override void Configure(IObjectTypeDescriptor<Group> descriptor)
        {
            descriptor.Field(x => x.GroupId).Type<IdType>();
            descriptor.Field(x => x.Nome).Type<StringType>();
            descriptor.Field(x => x.Processo).Type<StringType>();
            descriptor.Field<StudentResolver>(x => x.GetStudents(default, default));
        }
    }

    public class StudentResolver
    {
        private readonly IBotRetornoService _studentService;

        public StudentResolver([Service] IBotRetornoService studentService)
        {
            _studentService = studentService;
        }

        public IEnumerable<BotsRetorno> GetStudents(Group group, IResolverContext ctx)
        {
            return _studentService.GetAll().Where(x => x.GroupId == group.GroupId);
        }
    }
}
