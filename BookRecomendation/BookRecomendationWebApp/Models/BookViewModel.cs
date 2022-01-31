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
        public string title { get; set; }
        public string review1 { get; set; }
        public int rating { get; set; }

    }
}