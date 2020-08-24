using System;

namespace SalesWebMvc.Services.Exceptions
{
    /// <summary>
    /// Classe responsável pelo tratamento de exceção relacionada a integridade referencial.
    /// </summary>
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {

        }
    }
}
