using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebUI.Data.Models
{
    public class Articles
    {
        #region Constructor
        public Articles() { }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public string ArticleUrl { get; set; }

        [Required]
        public string Article_text { get; set; }

        [MaxLength(4000)]
        public string ArticleMid { get; set; }

        [MaxLength(4000)]
        public string Article_Btm { get; set; }


        [DefaultValue(true)]
        public bool Visible { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public string LastModifiedBy { get; set; }
        #endregion

        #region Lazy-Load Properties
        /// <summary>
        /// The article author:  it will be loaded
        /// EF Lazy-Loading
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Load the supArticle
        /// </summary>
        public virtual List<SubArticle> SubArticles { get; set; }  

        #endregion
    }
}
