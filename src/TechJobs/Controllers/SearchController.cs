using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string SearchType, string SearchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            if (SearchType == "all")
            {
                List<Dictionary<string, string>> Job = JobData.FindByValue(SearchTerm);
                ViewBag.Jobs = Job;
                return View("Index");
            }

                else
                {
                    List<Dictionary<string, string>> Job = JobData.FindByColumnAndValue(SearchType, SearchTerm);
                    ViewBag.Jobs = Job;
                    return View("Index");         
                }
                            
        }
    }

    
}
