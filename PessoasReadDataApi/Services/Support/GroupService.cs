using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Services.Support
{
    public class GroupService : IGroupService
    {
        private IList<Group> _groups;
        public GroupService()
        {
            _groups = new List<Group>()
            {
                new Group(){ GroupId = 1, Nome = "Teste", Processo = "Enviando dados"},
                new Group(){ GroupId = 2, Nome = "Teste 2", Processo = "Enviando dados 2"},
                new Group(){ GroupId = 3, Nome = "Teste 3", Processo = "Enviando dados 3"}
            };
        }
        public IQueryable<Group> GetAll()
        {
            return _groups.AsQueryable();
        }
    }
}
