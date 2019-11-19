using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Article_Review_MVC.Models
{
    //Article details 
    public class Article
    {

        
        //Article Id 
        public int Id { get; set; }

        //Article name 
        public string Name { get; set; }

        //Author Id 
        public int AuthorId { get; set; }

        //Reviewer Id 
        public int ReviewerId { get; set; }

        //Link to Author 
        public Author Author { get; set; }

        //Link to reviewer
        public Reviewer Reviewer { get; set; }

        //Comment from review.
        public string ReviewComment { get; set; }


        //Rating for the article.
        [Range(0, 5,
       ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Rating { get; set; }



    }
}
