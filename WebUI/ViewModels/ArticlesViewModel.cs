using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class ArticlesViewModel
    {
        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string ArticleUrl { get; set; }

        public string Title { get; set; }

        [Required]
       // [MaxLength()]
        public string Article_text { get; set; }

        public string ArticleMid { get; set; }

        public string Article_Btm { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public string LastModifiedBy { get; set; }
        #endregion
    }
}
        