using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;

namespace BookRecomendationDataAccessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookRecomendationDAL
    {
        SqlConnection connectionString;
        BookRecomendationContext contextObject;
        public BookRecomendationDAL()
        {
            connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["BookRecomendationString"].ConnectionString);
        }

        public List<BookDTO> FetchReviewsForBook(string bookName)
        {
            try
            {
                var listOfBookReviews = (from book in contextObject.Books
                                         from bookReview in book.Reviews
                                         where book.title == bookName && book.book_isbn == bookReview.book_isbn
                                         select new
                                         {
                                             book.title,
                                             bookReview.rating,
                                             bookReview.review1
                                         }).ToList();
                List<BookDTO> listOfBookReview = new List<BookDTO>();
                foreach (var bookReviewDetails in listOfBookReviews)
                {
                    listOfBookReview.Add(new BookDTO()
                    {
                        title = bookReviewDetails.title,
                        rating = bookReviewDetails.rating,
                        review1 = bookReviewDetails.review1
                    });
                }
                return listOfBookReview;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveReviewForBookToDB()
        {
        }

}
}
