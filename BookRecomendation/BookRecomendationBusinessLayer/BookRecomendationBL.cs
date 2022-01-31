using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDataAccessLayer;
using BookRecomendationDTO;

namespace BookRecomendationBusinessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required. 
    public class BookRecomendationBL
    {
        BookRecomendationDAL dalObject;
        public BookRecomendationBL()
        {
            dalObject = new BookRecomendationDAL();
        }

        public List<BookDTO> ShowReviewsForBook(string bookName)
        {
            try
            {
                List<BookDTO> lstBookDetails = dalObject.FetchReviewsForBook(bookName);
                return lstBookDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddReviewForBook(BookDTO bookDtoObject)
        {
            try
            {
                return dalObject.SaveReviewForBookToDB(bookDtoObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
      
    }
}
