using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpostforum.Entities
{
    public class Comment
    {
        [Key]
        public int CommId { get; set; }
        [Required(ErrorMessage = "Comments is Required")]
        [Display(Name = "Comment on Post")]
        public string CommentMsg { get; set; }
        [Display(Name = "Commented Date")]
        public DateTime CommentedDate { get; set; } = DateTime.Now;

        //EF relationships should pick this relationship between Blog and Comments tables:
        [Display(Name = "Post ID")]
        public virtual int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post posts { get; set; }
    }
}
