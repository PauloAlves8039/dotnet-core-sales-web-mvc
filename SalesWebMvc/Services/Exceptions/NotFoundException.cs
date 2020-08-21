using System;

namespace SalesWebMvc.Services.Exceptions
{
    /// <summary>
    /// Classe responsável por tratamento de exceção personalizada referente a busca de objeto.
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
