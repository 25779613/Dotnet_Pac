using Dotnet_Prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Prac.Controllers
{
    public class StudentController: Controller
    {
         public IActionResult Index()
         {
            string[] subjects ={"math","science","english"};
            ViewData["subjects"] = subjects;
             return View();
         }

         public IActionResult Index(string studentName,string studentEmail, string studentNumber,string subject,string studentDetails)
         {
            
             return View();
         }


         public IActionResult List()
         {
             return View();
         }
    }
}