using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookRecomendationBusinessLayer;
using BookRecomendationDTO;
using BookRecomendationWebApp.Models;
using Newtonsoft.Json;

namespace BookRecomendationWebApp.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class RecomendBookController : Controller
    {
        BookRecomendationBL blObject;
        public RecomendBookController()
        {
            blObject = new BookRecomendationBL();
        }
        // GET: RecomendBook
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddReviews()
        {
            try
            {
                try
                {
                    return View();
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult AddReviews(BookReview bookReviewDetails)
        {
            try
            {
                BookDTO bookDtoObject = new BookDTO();
                bookDtoObject.book_isbn = bookReviewDetails.book_isbn;
                bookDtoObject.rating = bookReviewDetails.rating;
                bookDtoObject.review1 = bookReviewDetails.review1;
                int retVal = blObject.AddReviewForBook(bookDtoObject);
                if (retVal == 1)
                {
                    return RedirectToAction("DisplayResultsUsingWebAPIAsync");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        [HttpGet]
        public async Task<ActionResult> DisplayResultsUsingWebAPIAsync(string bookName)
        {
            try
            {
                string baseURL = $"http://localhost:60398/";
                string routeURL = $"api/BookReviews/GetRatingsForBook/{bookName}";
                var apiClient = new HttpClient();
                apiClient.BaseAddress = new Uri(baseURL);
                apiClient.DefaultRequestHeaders.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage apiResponse = await apiClient.GetAsync(routeURL);
                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = apiResponse.Content.ReadAsStringAsync().Result;
                    var finalResult = JsonConvert.DeserializeObject<List<BookViewModel>>(result);
                    return View(finalResult);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

    }
}