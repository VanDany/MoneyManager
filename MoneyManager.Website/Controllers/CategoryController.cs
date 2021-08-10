using Microsoft.AspNetCore.Http;
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
        private readonly ITransactionRepository _transactionRepository;
        public CategoryController(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository, ISessionManager sessionManager)
        {
            _categoryRepository = categoryRepository;
            _sessionManager = sessionManager;
            _transactionRepository = transactionRepository;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.Get());
        }

        //public IActionResult Details(int id)
        //{
        //    Category category = _categoryRepository.GetCat(id);
        //    if (category is null)
        //        return RedirectToAction("Index");
        //    return View(new DisplayDetailsCategory() { Id = category.Id, Name = category.Name, BudgetLimit = category.BudgetLimit, UserId = _sessionManager.User.Id });
        //}
        public IActionResult BudgetLimit()
        {
            IEnumerable<Transaction> transactions = _transactionRepository.Get();
            IEnumerable<Category> categories = _categoryRepository.Get();
            IEnumerable<Category> catWithBudget = categories.Where(c => c.BudgetLimit != null);
            var budget = transactions.Select(t => new
            {
                Amount = (t.ExpenseOrIncome) ? t.Amount * -1 : t.Amount,
                CategoryId = t.CategoryId

            }).GroupBy(g => g.CategoryId).Join(catWithBudget, g => g.Key, c => c.Id, (g, c) => new BudgetLimitForm()
            {
                CategoryId = g.Key,
                CategoryName = c.Name,
                Sum = g.Sum(i=> i.Amount),
                Max = c.BudgetLimit
            });
            return View(budget);
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
