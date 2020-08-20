using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Método para inserir registro no banco de dados.
        /// </summary>
        /// <param name="obj">Insere o objeto Seller</param>
        public void Insert(Seller obj) 
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
