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

		internal readonly static string DELETE_PESSOAS_DATA = @"DELETE FROM PESSOAS WHERE ID_PESSOA = @ID";

		internal readonly static string UPDATE_PESSOAS_DATA = @"UPDATE PESSOAS SET 
																PRIMEIRO_NOME = @nome,
																SEGUNDO_NOME = @sobrenome,
																IDADE = @idade,
																ENDERESSO = @enderesso,
																TELEFONE = @telefone,
																EMAIL_VALIDACAO = @email
															WHERE ID_PESSOA = @ID";

		internal readonly static string SELECT_GERMANY_PESSOAS = @"SELECT  
																	NOME_PESSOA nomes,
																	ADDRESS_PESSOA enderessos,
																	CITY cidade,
																	POSTCODE codigoPostal,
																	IBAN_NUMERO iban
																FROM IBAN_PESSOAS";

		internal readonly static string INSERT_GERMANY_PESSOAS = @"INSERT INTO IBAN_PESSOAS (
																	NOME_PESSOA, 
																	ADDRESS_PESSOA, 
																	CITY, 
																	POSTCODE, 
																	IBAN_NUMERO) 
																VALUES (
																	@nomes, 
																	@enderessos,
																	@cidade, 
																	@codigoPostal, 
																	@iban)";

		internal readonly static string DELETE_GERMANY_PESSOAS = @"DELETE FROM IBAN_PESSOAS WHERE IBAN_NUMERO = @iban";

		internal readonly static string SELECT_USUARIO_CADASTRADO = @"SELECT 
																		ID Id,
																		NOME Username,
																		SENHA Password,
																		PRIVILEGIO Role
																	FROM USUARIOS_CADASTRADOS WHERE NOME = @Username and SENHA = @Password";

		internal readonly static string SELECT_DB_BOTS = @"SELECT * FROM DataStatus";
	}
}
