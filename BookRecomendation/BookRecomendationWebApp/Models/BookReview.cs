using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRecomendationWebApp.Models
{
    public class BookReview
    {
        [DisplayName("Book ISBN")]
        [Required(ErrorMessage = "Book ISBN name should not be empty.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Book ISBN must have only numbers")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Book ISBN number should be length of max length 10")]
        public int book_isbn { get; set; }
        [DisplayName("Review")]
        [Required(ErrorMessage = "Review name should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Review name must have only english letters")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Review name should be between 10 and 200 characters")]
        public string review1 { get; set; }
        [DisplayName("Rating")]
        [Required(ErrorMessage = "Rating name should not be empty.")]
        [RegularExpression(@"^[0-5]+$", ErrorMessage = "Rating is only in numbers")]
        public int rating { get; set; }
    }
}