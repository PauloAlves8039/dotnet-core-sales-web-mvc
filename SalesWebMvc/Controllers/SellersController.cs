using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    /// <summary>
    /// Controlador responsável pelas ações referentes aos vendedores.
    /// </summary>
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
