using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Data.Models
{
    public class SubArticle
    {
        #region Constructor
        public SubArticle()
        {

        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public string Text { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        #region Lazy-Load Properties
        /// <summary>
        /// The parent Article
        /// </summary>
        [ForeignKey("ArticleId")]
        public virtual Articles Articles { get; set; }

        #endregion

    }
}
