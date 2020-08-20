using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    /// <summary>
    /// classe responsável por conter os dados do formulário de cadastro do vendedor.
    /// </summary>
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
