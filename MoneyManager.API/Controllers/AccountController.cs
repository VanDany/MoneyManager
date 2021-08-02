using Microsoft.AspNetCore.Mvc;
using ModelsAPI.Client.Data;
using ModelsAPI.Client.Repositories;
using MoneyManager.API.Infrastructure.Security;
using MoneyManager.API.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthRequired]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private int UserId
        {
            get { return (int)ControllerContext.RouteData.Values["userId"]; }
        }
        public AccountController(IAccountRepository account)
        {
            _account = account;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_account.Get(UserId));
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_account.GetAccount(id, UserId));
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post([FromBody] AccountForm accountForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Account account = new Account(UserId, accountForm.Description);
            _account.Insert(account);
            return Ok();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateAccountForm updateAccountForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account account = new Account(UserId, updateAccountForm.Description);

            _account.Update(id, account);
            return Ok();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _account.Delete(id);
            return NoContent();
        }
    }
}
