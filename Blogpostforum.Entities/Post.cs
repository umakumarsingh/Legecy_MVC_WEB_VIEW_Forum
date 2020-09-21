using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpostforum.Entities
{
    public class Post
    {
        [Key]
        public virtual int PostId { get; set; }
        [Display(Name = "Blog Title")]
        [Required(ErrorMessage = "Post Title is Required")]
        public virtual string Title { get; set; }

        [Display(Name = "Blog Abstract")]
        [Required(ErrorMessage = "Post Abstract is Required")]
        public virtual string Abstract { get; set; }

        [Display(Name = "Blog Description")]
        [Required(ErrorMessage = "Post description is required")]
        public string Description { get; set; }
        [Display(Name = "Posted Date")]
        public virtual DateTime PostedDate { get; set; } = DateTime.Now;
    }
}
