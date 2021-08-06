using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Client.Data;
using Models.Client.Repositories;
using MoneyManager.Website.Infrastructure.Session;
using MoneyManager.Website.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ISessionManager _sessionManager;
        public AccountController(IAccountRepository accountRepository, ISessionManager sessionManager)
        {
            _accountRepository = accountRepository;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View(_accountRepository.Get());

        }

        public IActionResult Details(int id)
        {
            Account account = _accountRepository.GetAccount(id);
            if (account is null)
                return RedirectToAction("Index");

            return View(new DisplayDetailsAccount()
            {
                Id = account.Id,
                Description = account.Description,
                UserId = _sessionManager.User.Id
            });
        }

        public IActionResult Create()
        {
            CreateAccountForm form = new CreateAccountForm();
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            Account newAccount = new Account(_sessionManager.User.Id, form.Description);
            _accountRepository.Insert(newAccount);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Account account = _accountRepository.GetAccount(id);
            if (account is null)
                return RedirectToAction("Index");

            EditAccountForm form = new EditAccountForm()
            {
                Id = account.Id,
                Description = account.Description
            };
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EditAccountForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            _accountRepository.Update(id, new Account(_sessionManager.User.Id, form.Description));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Account account = _accountRepository.GetAccount(id);
            if (account is null)
                RedirectToAction("Index");
            return View(new DisplayDetailsAccount()
            {
                Id = account.Id,
                Description = account.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _accountRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
