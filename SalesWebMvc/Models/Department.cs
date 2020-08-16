using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    /// <summary>
    /// Classe responsável por representar a entidade departamento.
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Método responsável por adicionar vendedor.
        /// </summary>
        /// <param name="seller">Recebe isntância da entidade vendedor.</param>
        public void AddSeller(Seller seller) 
        {
            Sellers.Add(seller);
        }

        /// <summary>
        /// Método responsável por retornar o total de vendas do departamento.
        /// </summary>
        /// <param name="initial">Recebe o período inicial da venda do departamento.</param>
        /// <param name="final">Recebe o período final da venda do departamento.</param>
        /// <returns></returns>
        public double TotalSales(DateTime initial, DateTime final) 
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
