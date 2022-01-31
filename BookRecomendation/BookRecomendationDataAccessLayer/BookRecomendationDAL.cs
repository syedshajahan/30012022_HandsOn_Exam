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
        SqlConnection connectionObject;
        BookRecomendationContext contextObject;
        SqlCommand commandObject;
        public BookRecomendationDAL()
        {
            connectionObject = new SqlConnection(ConfigurationManager.ConnectionStrings["BookRecomendationString"].ConnectionString);
            contextObject = new BookRecomendationContext();
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

        public void SaveReviewForBookToDB(BookDTO bookDtoObject)
        {
            try
            {
                commandObject = new SqlCommand();
                commandObject.CommandText = "uspAddNewDept";
                commandObject.CommandType = System.Data.CommandType.StoredProcedure;
                commandObject.Connection = connectionObject;
                commandObject.Parameters.AddWithValue("@book_isbn", newDeptObj.DeptName);
                commandObject.Parameters.AddWithValue("@deptGroupName", newDeptObj.DeptGroupName);
                commandObject.Parameters.AddWithValue("@deptDate", System.DateTime.Now);

                SqlParameter prcReturnValue = new SqlParameter();
                prcReturnValue.Direction = ParameterDirection.ReturnValue;
                prcReturnValue.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(prcReturnValue);

                conObj.Open();
                cmdObj.ExecuteNonQuery();
                newDeptId = Convert.ToInt32(prcDeptIDOut.Value);
                return Convert.ToInt32(prcReturnValue.Value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connectionObject.Close();
            }
        }

}
}
