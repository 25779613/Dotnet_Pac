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
             return View();
         }

         public IActionResult List()
         {
             return View();
         }
    }
}