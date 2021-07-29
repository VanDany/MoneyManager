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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }


        // GET: api/<CategoryController>/1
        [HttpGet("{userId}")]
        public IEnumerable<Category> Get(int userId)
        {
            return _category.Get(userId);
        }

        // GET api/<CategoryController>/1/1
        [HttpGet("{userId}/{id}")]
        public Category Get(int userId, int id)
        {
            return _category.GetCat(userId, id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryForm categoryform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category(categoryform.Name, categoryform.BudgetLimit, categoryform.UserId);

            _category.Insert(category);

            return Ok();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryForm categoryForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category(categoryForm.Name, categoryForm.BudgetLimit, categoryForm.UserId);

            _category.Update(id, category);

            return Ok();
        }

        //DELETE api/<CategoryController>/5
        [HttpDelete("{userId}/{id}")]
        public IActionResult Delete(int userId, int id)
        {
            _category.Delete(userId, id);
            return NoContent();
        }
    }
}
