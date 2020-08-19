using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    /// <summary>
    /// Classe responsável pela regra de negócio referente ao vendedor.
    /// </summary>
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método responsável por atribuir uma lista de vendedores.
        /// </summary>
        /// <returns>Lista de vendedores.</returns>
        public List<Seller> FindAll() 
        {
            return _context.Seller.ToList();
        }
    }
}
