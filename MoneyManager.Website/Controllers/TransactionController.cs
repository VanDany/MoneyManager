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
        private readonly ISessionManager _sessionManager;
        public TransactionController(ITransactionRepository transactionRepository, ISessionManager sessionManager, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            TransactionAccount TA = new TransactionAccount();
            TA.transaction = _transactionRepository.Get();
            TA.account = _accountRepository.Get();
            return View(TA);

        }
        [HttpPost]
        public JsonResult GetByAccount(int id)
        {
            if (id==0)
            {
                IEnumerable<Transaction> transactions = _transactionRepository.Get();
                return Json(transactions);
            }
            else
            {
                IEnumerable<Transaction> transactions = _transactionRepository.Get();
                return Json(transactions);
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
