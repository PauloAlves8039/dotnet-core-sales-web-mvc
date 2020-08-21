using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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

        /// <summary>
        /// Método para pesquisar vendedor por id.
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do vendedor.</param>
        /// <returns>Registro de um vendedor.</returns>
        public Seller FindById(int id) 
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        /// <summary>
        /// Método para remover vendedor.
        /// </summary>
        /// <param name="id">parâmetro de remoção do vendedor.</param>
        public void Remove(int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para atualizar vendedor.
        /// </summary>
        /// <param name="obj">parâmetro de atualização do vendedor.</param>
        public void Update(Seller obj) 
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id)) 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
