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
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISessionManager _sessionManager;
        public TransactionController(ITransactionRepository transactionRepository, ISessionManager sessionManager, IAccountRepository accountRepository, ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _sessionManager = sessionManager;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            TransactionAccount TA = new TransactionAccount();
            TA.transaction = _transactionRepository.Get();
            TA.account = _accountRepository.Get();
            return View(TA);

        }
        [HttpPost]
        public JsonResult GetCategories()
        {
            IEnumerable<Category> categories = _categoryRepository.Get();
            return Json(categories);
        }
        [HttpPost]
        public JsonResult GetByAccount(int id)
        {
            if (id==0)
            {
                IEnumerable<Transaction> transactions = _transactionRepository.Get();
                IEnumerable<Account> accounts = _accountRepository.Get();
                IEnumerable<Category> categories = _categoryRepository.Get();
                
                var innerJoin = transactions.Join(
                    accounts,
                    transactions => transactions.UserAccountId,
                    accounts => accounts.Id,
                    (transactions, accounts) => new
                    {
                        Transaction = transactions,
                        Id = transactions.Id,
                        UserAccountId = transactions.UserAccountId,
                        UserAccount = accounts.Description,
                        DateTransact = transactions.DateTransact,
                        Description = transactions.Description,
                        ExpenseOrIncome = transactions.ExpenseOrIncome,
                        Amount = transactions.Amount,
                        CategoryId = transactions.CategoryId
                    }).Join(categories,
                    transactions => transactions.CategoryId,
                    categories => categories.Id,
                    (transactions, categories) => new
                    {
                        Id = transactions.Id,
                        UserAccountId = transactions.UserAccountId,
                        UserAccount = transactions.UserAccount,
                        DateTransact = transactions.DateTransact,
                        Description = transactions.Description,
                        ExpenseOrIncome = transactions.ExpenseOrIncome,
                        Amount = transactions.Amount,
                        CategoryId = transactions.CategoryId,
                        Name = categories.Name
                    });
                return Json(innerJoin);
            }
            else
            {
                IEnumerable<Transaction> transactions = _transactionRepository.Get();
                IEnumerable<Account> accounts = _accountRepository.Get();
                IEnumerable<Category> categories = _categoryRepository.Get();
                var innerJoin = transactions.Join(
                    accounts,
                    transactions => transactions.UserAccountId,
                    accounts => accounts.Id,
                    (transactions, accounts) => new
                    {
                        Transaction = transactions,
                        Id = transactions.Id,
                        UserAccountId = transactions.UserAccountId,
                        UserAccount = accounts.Description,
                        DateTransact = transactions.DateTransact,
                        Description = transactions.Description,
                        ExpenseOrIncome = transactions.ExpenseOrIncome,
                        Amount = transactions.Amount,
                        CategoryId = transactions.CategoryId
                    }).Join(categories,
                    transactions => transactions.CategoryId,
                    categories => categories.Id,
                    (transactions, categories) => new
                    {
                        Id = transactions.Id,
                        UserAccountId = transactions.UserAccountId,
                        UserAccount = transactions.UserAccount,
                        DateTransact = transactions.DateTransact,
                        Description = transactions.Description,
                        ExpenseOrIncome = transactions.ExpenseOrIncome,
                        Amount = transactions.Amount,
                        CategoryId = transactions.CategoryId,
                        Name = categories.Name
                    }).Where(f => f.UserAccountId == id); 
                return Json(innerJoin);
            }
            
        }
        public IActionResult Details(int id)
        {
            Transaction transaction = _transactionRepository.GetTransact(id);
            if (transaction is null)
                return RedirectToAction("Index");

            return View(new DisplayDetailsTransaction() { 
                Id = transaction.Id, 
                UserAccountId = transaction.UserAccountId, 
                Description = transaction.Description, 
                ExpenseOrIncome = transaction.ExpenseOrIncome, 
                Amount = transaction.Amount, 
                CategoryId = transaction.CategoryId 
            });
        }

        public IActionResult Create(int id)
        {
            CreateTransactionForm form = new CreateTransactionForm();
            form.UserAccountId = id;
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTransactionForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            Transaction newTransaction = new Transaction(form.UserAccountId, form.Description, form.ExpenseOrIncome, form.Amount, form.CategoryId);
            _transactionRepository.Insert(newTransaction);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Transaction transaction = _transactionRepository.GetTransact(id);
            if (transaction is null)
                return RedirectToAction("Index");

            EditTransactionForm form = new EditTransactionForm()
            {
                Id = transaction.Id,
                UserAccountId = transaction.UserAccountId,
                Description = transaction.Description,
                ExpenseOrIncome = transaction.ExpenseOrIncome,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId
            };
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EditTransactionForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            _transactionRepository.Update(id, new Transaction(form.UserAccountId, form.Description, form.ExpenseOrIncome, form.Amount, form.CategoryId));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Transaction transaction = _transactionRepository.GetTransact(id);
            if (transaction is null)
                RedirectToAction("Index");
            return View(new DisplayDetailsTransaction() { 
                Id = transaction.Id,
                UserAccountId = transaction.UserAccountId,
                Description = transaction.Description,
                ExpenseOrIncome = transaction.ExpenseOrIncome,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _transactionRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
