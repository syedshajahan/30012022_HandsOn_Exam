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
        // GET: RecomendBook
        public ActionResult Index()
        {
            return View();
        }
        public void AddReviews()
        {

        }
        public async Task<ActionResult> DisplayResultsUsingWebAPIAsync()
        {
            try
            {
                string baseURL = $"https://localhost:44304/";
                string routeURL = $"api/BookReviews/GetRatingsForBook";
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