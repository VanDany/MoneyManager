﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Client.Data;
using Models.Client.Repositories;
using MoneyManager.Website.Infrastructure.Session;
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
        private readonly ISessionManager _sessionManager;
        public CategoryController(ICategoryRepository categoryRepository, ISessionManager sessionManager)
        {
            _categoryRepository = categoryRepository;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.Get());

        }

        public IActionResult Details(int id)
        {
            Category category = _categoryRepository.GetCat(id);
            if (category is null)
                return RedirectToAction("Index");
            return View(new DisplayDetailsCategory() { Id = category.Id, Name = category.Name, BudgetLimit = category.BudgetLimit, UserId = _sessionManager.User.Id });
        }

        public IActionResult Create()
        {
            CreateCategoryForm form = new CreateCategoryForm();
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            Category newCategory = new Category(form.Name, form.BudgetLimit, _sessionManager.User.Id);
            _categoryRepository.Insert(newCategory);
            return RedirectToAction("Index");
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, EditCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            _categoryRepository.Update(id, new Category(form.Name, form.BudgetLimit, _sessionManager.User.Id));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetCat(id);
            if (category is null)
                RedirectToAction("Index");
            return View(new DisplayDetailsCategory() { Id = category.Id, Name = category.Name, BudgetLimit = category.BudgetLimit });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
