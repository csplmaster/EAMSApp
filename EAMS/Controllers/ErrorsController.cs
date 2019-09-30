using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            //Response.StatusCode = 404;  //you may want to set this to 200
            return View("Error");
        }
        public ViewResult ServerError()
        {
            //Response.StatusCode = 500;
            return View("Error");
        }
    }
}