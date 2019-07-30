﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
	public class SellersController : Controller
	{
		private readonly SellerService _sellerService;
		private readonly DepartmentService _departmentService;

		public SellersController(SellerService sellerService, DepartmentService departmentService)
		{
			_sellerService = sellerService;
			_departmentService = departmentService;
		}

		public IActionResult Index()
		{
			// Através do MODEL que fez o acesso ao BD,
			// retorna a lista de seller e manda pra VIEW
			var list = _sellerService.FindAll();
			return View(list);
		}

		public IActionResult Create()
		{
			var departments = _departmentService.findAll();
			var viewModel = new SellerFormViewModel { Departments = departments };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Seller seller)
		{
			//Chama o serviço de inclusão 
			_sellerService.Insert(seller);
			return RedirectToAction(nameof(Index));
		}

		/// <summary>
		/// Método que retorna para a view o seller, se existir.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var obj = _sellerService.FindById(id.Value);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			_sellerService.Remove(id);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var obj = _sellerService.FindById(id.Value);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}
	}
}