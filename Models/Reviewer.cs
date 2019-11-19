using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article_Review_MVC.Models
{
    //Reviewer information.
    public class Reviewer
    {
        //Reviewer id 
        public int Id { get; set; }

        //Reviewer name
        public string Name { get; set; }

        //Email of the reviewer
        public string Email { get; set; }

    }
}
