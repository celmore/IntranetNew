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


        /// <summary>
        /// Edit the article with given {id}
        /// </summary>
        /// <param name="model">The ArticleViewModel containing the data to update</param>
        // POST: api/Articles
        [HttpPost]
        public IActionResult Post([FromBody]ArticlesViewModel model)
        {
            // return generic HTTP status
            if (model == null) return new StatusCodeResult(500);

            // retrieve article to edit
            var artcl = DbContext.Articles.Where(a => a.Id == model.Id).FirstOrDefault();

            if (artcl == null)
            {
                return NotFound(new
                {
                    Error = String.Format("Article ID {0} has not been found",
                     model.Id)
                });
            }

            //artcl.SubArticles = model.SubArticle;
            artcl.Article = model.Article;
            artcl.ArticleUrl = model.ArticleUrl;

            // Server-Side
            artcl.LastModifiedDate = DateTime.Now;

            // persist changes to DB
            DbContext.SaveChanges();

            // return updated data
            return new JsonResult(artcl.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });


        }

        // PUT: api/Articles/5
        /// <summary>
        /// Adds a new Article to the Database.
        /// </summary>
        /// <param name="model">The ArticleViewModel containing the data to insert</param>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]ArticlesViewModel model)
        {
            if (model == null) return new StatusCodeResult(500);

            //Insert
            var artcl = new Articles();

            artcl.Article = model.Article;
            artcl.ArticleUrl = model.ArticleUrl;
            artcl.Visible = model.Visible;
            artcl.LastModifiedBy = model.LastModifiedBy;

            //Server set properties
            artcl.LastModifiedDate = DateTime.Now;
            //artcl.User = DbContext.Users.Where(u => u.UserName).FirstOrDefault().Id;

            // add the Article
            DbContext.Articles.Add(artcl);
            DbContext.SaveChanges();


            // return the new article
            return new JsonResult(artcl.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });




        }

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
