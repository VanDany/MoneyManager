﻿using Microsoft.AspNetCore.Mvc;
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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transaction;
        private int UserId
        {
            get { return (int)ControllerContext.RouteData.Values["userId"]; }
        }
        public TransactionController(ITransactionRepository transaction)
        {
            _transaction = transaction;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_transaction.Get(UserId));
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_transaction.GetTransact(id, UserId));
        }

        // POST api/<TransactionController>
        [HttpPost]
        public IActionResult Post([FromBody] TransactionForm transactionForm)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            Transaction transaction = new Transaction(UserId, transactionForm.Description, transactionForm.ExpenseOrIncome, transactionForm.Amount, transactionForm.CategoryId);
            _transaction.Insert(transaction);
            return Ok();
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTransactionForm updateTransactionForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Transaction transaction = new Transaction(UserId, updateTransactionForm.Description,updateTransactionForm.ExpenseOrIncome, updateTransactionForm.Amount, updateTransactionForm.CategoryId);

            _transaction.Update(id, transaction);
            return Ok();
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _transaction.Delete(id);
            return NoContent();
        }
    }
}