﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Client.Data;
using Models.Client.Repositories;
using MoneyManager.Website.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: CategoryController
        public IActionResult Index()
        {
            return View(_categoryRepository.Get());

        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            Category category = _categoryRepository.GetCat(id);
            if (category is null)
                return RedirectToAction("Index");
            return View(new DisplayDetailsCategory() { Id = category.Id, Name = category.Name, BudgetLimit = category.BudgetLimit });
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            CreateCategoryForm form = new CreateCategoryForm();
            return View(form);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            Category newCategory = new Category(form.Name, form.BudgetLimit);
            _categoryRepository.Insert(newCategory);
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            Category category = _categoryRepository.GetCat(id);
            if (category is null)
                return RedirectToAction("Index");

            EditCategoryForm form = new EditCategoryForm()
            {
                Id = category.Id,
                Name = category.Name,
                BudgetLimit = category.BudgetLimit
            };
            return View(form);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            _categoryRepository.Update(id, new Category(form.Name, form.BudgetLimit));
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetCat(id);
            if (category is null)
                RedirectToAction("Index");
            return View(new DisplayDetailsCategory() { Id = category.Id, Name = category.Name, BudgetLimit = category.BudgetLimit });
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            Category category = _categoryRepository.GetCat(id);
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}