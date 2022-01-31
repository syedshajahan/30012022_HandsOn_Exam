using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRecomendationWebApp.Models
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookViewModel
    {
        [DisplayName("Titile")]
        [Required(ErrorMessage = "Titile name should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Titile name must have only english letters")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Titile name should be between 10 and 20 characters")]
        public string title { get; set; }
        [DisplayName("Review")]
        public string review1 { get; set; }
        [DisplayName("Rating")]
        public int rating { get; set; }

    }
}