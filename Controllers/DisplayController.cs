using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class DisplayController : Controller
    {
       
        // GET: Display
        public ActionResult DisaplayData()
        {
            
            return View();
        }
    }
}