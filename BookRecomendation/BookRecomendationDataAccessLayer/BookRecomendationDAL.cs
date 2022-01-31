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
            connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString);
        }

        public void FetchReviewsForBook()
        {
        }

        public void SaveReviewForBookToDB()
        {
        }

}
}
