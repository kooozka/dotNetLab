using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.Controllers
{
        //[Authorize(Roles = "Admin")]
        [EnableCors]
        [Route("api/categories")]
        [ApiController]
        public class CategoriesApiController : ControllerBase
        {
            private ICategoryRepository _repository;

            public CategoriesApiController(ICategoryRepository repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public IEnumerable<Category> Get() => _repository.GetAll();

            [HttpGet("{id}")]
            public Category Get(int id) => _repository.GetById(id);

            [HttpPost]
            [EnableCors]
            public Category Post([FromBody] Category category) => _repository.Add(category);

            [HttpPut]
            public IActionResult Put([FromBody] Category category)
            {
                var categoryToBeUpdated = _repository.Update(category);
                if (categoryToBeUpdated == null)
                {
                    return NotFound("Id given does not exist in a data base");
                }
                return Ok(categoryToBeUpdated);
            }
            [HttpDelete("{id}")]
            public void Delete(int id) => _repository.Delete(id);

    }
}
