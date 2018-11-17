using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using Mapster;
using Newtonsoft.Json;
using WebUI.Data.Models;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        #region Private Fields
        private ApplicationDbContext DbContext;
        #endregion

        #region Constructor
        public ArticlesController(ApplicationDbContext context)
        {
            // Instantiate the ApplicationDbContext through DI
            DbContext = context;
        }
        #endregion Constructor


        //GET: api/Articles
       [HttpGet("[action]")]
        public IActionResult Get()
        {
            Articles articles = DbContext.Articles.Where(i => i.Id == 4).FirstOrDefault();
            return new JsonResult(
                articles.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }


        #region RESTful conventions methods
        /// <summary>
        /// GET: api/Articles/{id}
        /// Retrieve the Article with the given {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Articles/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var article = DbContext.Articles.Where(i => i.Id == id).FirstOrDefault();
            return new JsonResult(
                article.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        // POST: api/Articles
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Articles/5
        /// <summary>
        /// Adds a new Article to the Database.
        /// </summary>
        /// <param name="model">The ArticleViewModel containing the data to insert</param>
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

        #region Attribute-based routing methods

        #endregion
    }
}
