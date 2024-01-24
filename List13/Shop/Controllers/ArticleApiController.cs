using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
   // [Authorize(Roles = "Admin")]
    [EnableCors]
    [Route("api/article")]
    [ApiController]
    public class ArticleApiController : ControllerBase
    {
        private IArticleRepository _repository;
        private IArticleService _articleService;

        public ArticleApiController(IArticleRepository repository, IArticleService articleService)
        {
            _repository = repository;
            _articleService = articleService;
        }

        [HttpGet]
        public IEnumerable<Article> Get() => _repository.GetAll();

        [HttpGet("{id}")]
        public Article Get(int id) => _repository.GetById(id);

        [HttpPost]
        [EnableCors]
        public Article Post([FromBody] Article article) => _repository.Add(article);

        [HttpPut]
        public IActionResult Put([FromBody] Article article)
        {
            var articleToBeUpdated = _repository.Update(article);
            if (articleToBeUpdated == null)
            {
                return NotFound("Id given does not exist in a data base");
            }
            return Ok(articleToBeUpdated);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _repository.Delete(id);

        [HttpGet("getarticles")]
        public IEnumerable<Article> GetArticles()
        {
            var articles = _repository.GetArticles(_articleService.GetArticlesCount(), _articleService.GetPageSize());
            var size = articles.Count();
            _articleService.IncreaseCount(size);
            return articles;
        }

        [HttpGet("hasmore")] 
        public IActionResult HasMoreArticles()
        {
            return Ok(_repository.GetArticles(_articleService.GetArticlesCount(), 1).Count() > 0);
        }
    }
}
