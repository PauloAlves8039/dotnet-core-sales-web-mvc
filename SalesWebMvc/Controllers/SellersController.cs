using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using SalesWebMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    /// <summary>
    /// Controlador responsável pelas ações referentes aos vendedores.
    /// </summary>
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        /// <summary>
        /// Action responsável pela listagem dos vendedores.
        /// </summary>
        /// <returns>Lista de vendedores.</returns>
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        /// <summary>
        /// Action responsável por adicionar vendedor por GET.
        /// </summary>
        /// <returns>View com dados inseridos do vendedor.</returns>
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        /// <summary>
        /// Action responsável por adicionar vendedor por POST.
        /// </summary>
        /// <param name="seller">Representa o objeto vendedor.</param>
        /// <returns>View com dados inseridos do vendedor.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Action responsável pela exclusão de vendedor por GET.
        /// </summary>
        /// <param name="id">Parâmetro de exclusão do vendedor.</param>
        /// <returns>View com dados atualizados após exclusão do vendedor.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            return View(obj);
        }

        /// <summary>
        /// Action responsável pela exclusão de vendedor por POST.
        /// </summary>
        /// <param name="id">Parâmetro de exclusão do vendedor.</param>
        /// <returns>View com dados atualizados após exclusão do vendedor.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }            
        }

        /// <summary>
        /// Action responsável pela exibição dos detalhes do vendedor selecionado.
        /// </summary>
        /// <param name="id">Parâmetro de exibição dos detalhes do vendedor.</param>
        /// <returns>View com dados do vendedor selecionado.</returns>
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            return View(obj);
        }

        /// <summary>
        /// Action responsável pela edição do vendedor por GET.
        /// </summary>
        /// <param name="id">Parâmetro de edição do vendedor.</param>
        /// <returns>View com dados atualizados após edição do vendedor.</returns>
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments  };
            return View(viewModel);
        }

        /// <summary>
        /// Action responsável pela edição do vendedor por POST.
        /// </summary>
        /// <param name="id">Parâmetro de edição do vendedor.</param>
        /// <param name="seller">Representa o objeto vendedor.</param>
        /// <returns>View com dados atualizados após edição do vendedor.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller) 
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id) 
            {
                return RedirectToAction(nameof(Error), new {message = "Id mismatch"});
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new {message = e.Message});
            }
            
        }

        /// <summary>
        /// Action responsável por exibir mensagem de tratamento de erro.
        /// </summary>
        /// <param name="message">Parâmetro de exibição de mensagem de erro.</param>
        /// <returns>View com dados do vendedor.</returns>
        public IActionResult Error(string message) 
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
