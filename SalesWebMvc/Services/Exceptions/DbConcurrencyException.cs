using System;

namespace SalesWebMvc.Services.Exceptions
{
    /// <summary>
    /// Classe responsável por tratamento de exceção personalizada referente a conexão com o banco de dados.
    /// </summary>
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
