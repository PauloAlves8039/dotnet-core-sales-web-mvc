using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    /// <summary>
    /// Classe responsável pela regra de negócio referente ao departamento.
    /// </summary>
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método responsável por atribuir uma lista de todos os departamentos.
        /// </summary>
        /// <returns>Retorna todos os departamentos.</returns>
        public List<Department> FindAll() 
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }


    }
}
