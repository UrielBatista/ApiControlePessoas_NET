using PessoasDataApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace PessoasDataApi.Repository
{
    public static class CredencialUsuario
    {

        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "Uriel", Password = "teste123", Role = "Admin" });
            users.Add(new User { Id = 2, Username = "Ricardinho", Password = "321teste", Role = "cliente" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault<User>();
        }
    }
}
