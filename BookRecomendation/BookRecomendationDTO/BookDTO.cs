﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecomendationDTO
{
    public class BookDTO
    {
        public int book_isbn { get; set; }
        public string title { get; set; }
        public string review1 { get; set; }
        public int rating { get; set; }
    }
}
