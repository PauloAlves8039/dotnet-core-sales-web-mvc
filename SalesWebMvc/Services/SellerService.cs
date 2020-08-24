using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
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
        public async Task<List<Seller>> FindAllAsync() 
        {
            return await _context.Seller.ToListAsync();
        }

        /// <summary>
        /// Método para inserir registro no banco de dados.
        /// </summary>
        /// <param name="obj">Insere o objeto Seller</param>
        public async Task InsertAsync(Seller obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método para pesquisar vendedor por id.
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa do vendedor.</param>
        /// <returns>Registro de um vendedor.</returns>
        public async Task<Seller> FindByIdAsync(int id) 
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        /// <summary>
        /// Método para remover vendedor.
        /// </summary>
        /// <param name="id">parâmetro de remoção do vendedor.</param>
        public async Task RemoveAsync(int id) 
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método para atualizar vendedor.
        /// </summary>
        /// <param name="obj">parâmetro de atualização do vendedor.</param>
        public async Task UpdateAsync(Seller obj) 
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny) 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
