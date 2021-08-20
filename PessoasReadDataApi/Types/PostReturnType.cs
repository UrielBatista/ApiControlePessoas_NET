using GraphQL.Types;
using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Types
{
    public class PostReturnType : ObjectGraphType<PostReturn>
    {
        public PostReturnType()
        {
            Name = "PostReturn";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id cliente");
            Field(x => x.Status);
        }
    }
}
