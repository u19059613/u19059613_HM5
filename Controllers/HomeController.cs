using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u19059613_HW5.Models;
using u19059613_HW5.Models.Dataservice;



namespace u19059613_HW5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataService dataService = DataService.getInstance();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult BookView()
        {
            List<Books> book = dataService.getBooks();
            return View(book);
        }

        public ActionResult BookDetailsView(int id)
        {
            List<booksdetails> bookdetails = dataService.getBorrows(id);
            return View(bookdetails);
        }

        public ActionResult ViewStudent()
        {
            List<Students> studentDetails = dataService.getStudents();
            return View(studentDetails);
        }
    }
}