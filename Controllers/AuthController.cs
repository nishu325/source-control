using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using NLog;

namespace Assignment.Controllers
{
    public class AuthController : Controller
    {
        private static Logger log = LogManager.GetLogger("EmployeeDBEntities");
        private Context db = new Context();
        

        [HttpGet]
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee employee)
        {

            if (ModelState.IsValid)
            {
                //Context db = new Context();
                var data = db.employees.FirstOrDefault(m => m.Email == employee.Email && m.Password == employee.Password);

                if (data != null)
                {
                    log.Info("User login with "+employee.Email+" id into web-site !");
                    Session["Email"] = employee.Email;
                    return RedirectToAction("DisplayData", "Display");
                }
                else
                {
                    log.Info("Wrong email-id or password.");
                    TempData["message"] = "Wrong Email-id or Password !";
                    return View("Login","Auth");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }



        private static Random random = new Random();
        public static string RandomString(int length)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(HttpPostedFileBase image, Employee employee)
        {
           // Context db = new Context();
            if (ModelState.IsValid)
            {
               
                log.Info("Check user is already exist or not !");
                var check = db.employees.FirstOrDefault(s => s.Email == employee.Email);
                if (check == null)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        try
                        {
                            log.Info("Random Image name is generated");
                            string filename = "_" + RandomString(10) + Path.GetFileName(image.FileName);
                            string path = Path.Combine(Server.MapPath("~/Images"), filename);
                            image.SaveAs(path);
                            employee.ImagePath = "/Images/" + filename;
                        }

                        catch (Exception e)
                        {
                            log.Error("Error " + e);
                            TempData["message"] = "Error" + e;
                        }
                    }

                    db.employees.Add(employee);
                    db.SaveChanges();
                    log.Info("User data is saved in database");
                    TempData["message"] = employee.Name + " Successfully Register ! ";
                    return RedirectToAction("Register", "Auth");
                }

                else
                {
                    log.Error("User mail id is already exist.");
                    TempData["message"] = employee.Email + " email id already exist ! ";
                }






            }
            return View();
        }


    }
}