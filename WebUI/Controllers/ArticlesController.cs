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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = DbContext.Articles.Where(i => i.Id == id).FirstOrDefault();

            // handle requests asking for non-existing articles
            if(article == null)
            {
                return NotFound(new
                {
                    Error = String.Format("Data ID {0} has not been found",
                    id)
                });
            }

            return new JsonResult(
                article.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }


        /// <summary>
        /// Adds a new Article to the Database.
        /// </summary>
        /// <param name="model">The ArticleViewModel containing the data to insert</param>
        // PUT: api/Articles
        [HttpPut]
        public IActionResult Put([FromBody]ArticlesViewModel model)
        {
            // http status 500 (Server Error)
            if (model == null) return new StatusCodeResult(500);

            var artc = new Articles();

            // Properties
            artc.Title = model.Title;
            artc.Article_text = model.Article_text;
            artc.ArticleMid = model.ArticleMid;
            artc.Article_Btm = model.Article_Btm;
            artc.ArticleUrl = model.ArticleUrl;
            artc.LastModifiedDate = DateTime.Now;
            artc.LastModifiedBy = "CE1";

            // Add to db
            DbContext.Articles.Add(artc);
            _ = DbContext.SaveChanges();

            // Return
            return new JsonResult(artc.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });

        }

        /// <summary>
        /// Edit site data
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Articles
        [HttpPost]
        public IActionResult Post([FromBody]ArticlesViewModel model)
        {
            // http status 500 (Server Error)
            if (model == null) return new StatusCodeResult(500);

            // retrieve article by {id} to edit
            var artc = DbContext.Articles.Where(a => a.Id == model.Id).FirstOrDefault();

            // handle requests asking for non-existing articles
            if (artc == null)
            {
                return NotFound(new
                {
                    Error = String.Format("Data ID {0} has not been found",
                    model.Id)
                });
            }

            // handle maping
            artc.Title = model.Title;
            artc.Article_text = model.Article_text;
            artc.ArticleMid = model.ArticleMid;
            artc.Article_Btm = model.Article_Btm;
            artc.ArticleUrl = model.ArticleUrl;

            artc.LastModifiedDate = DateTime.Now;

            // persist changes
            _ = DbContext.SaveChangesAsync();

            return new JsonResult(artc.Adapt<ArticlesViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });

        }

      
        
        /// <summary>
        /// Deletes the Article with the given {id} from db
        /// </summary>
        /// <param name="id"></param>
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
