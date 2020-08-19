using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    /// <summary>
    /// Classe responsável por representar a entidade vendedor.
    /// </summary>
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        /// <summary>
        /// Método responsável por adicionar venda.
        /// </summary>
        /// <param name="sr">Recebe o registro de adição da venda.</param>
        public void AddSales(SalesRecord sr) 
        {
            Sales.Add(sr);
        }

        /// <summary>
        /// Método responsável por remover venda.
        /// </summary>
        /// <param name="sr">Recebe o registro de remoção da venda.</param>
        public void RemoveSales(SalesRecord sr) 
        {
            Sales.Remove(sr);
        }

        /// <summary>
        /// Método responsável por retornar o total de vendas do vendedor.
        /// </summary>
        /// <param name="initial">Recebe o período inicial da venda do vendedor.</param>
        /// <param name="final">Recebe o período final da venda do vendedor.</param>
        /// <returns></returns>
        public double TotalSales(DateTime initial, DateTime final) 
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
