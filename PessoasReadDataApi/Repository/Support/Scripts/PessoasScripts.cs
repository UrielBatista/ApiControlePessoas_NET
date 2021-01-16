using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Repository.Support.Scripts
{
    static class PessoasScripts
    {
		internal readonly static string SELECT_PESSOAS_DATA =
													@"SELECT 
														ID_PESSOA ID,
														PRIMEIRO_NOME nome,
														SEGUNDO_NOME sobrenome,
														IDADE idade,
														ENDERESSO enderesso,
														TELEFONE telefone,
														EMAIL_VALIDACAO email
													FROM PESSOAS";

		internal readonly static string INSERT_PESSOAS_DATA =
													@"INSERT INTO PESSOAS (
														PRIMEIRO_NOME, 
														SEGUNDO_NOME, 
														IDADE, 
														ENDERESSO, 
														TELEFONE, 
														EMAIL_VALIDACAO)
													VALUES (
														@nome,
														@sobrenome,
														@idade,
														@enderesso,
														@telefone,
														@email)";

	}
}
