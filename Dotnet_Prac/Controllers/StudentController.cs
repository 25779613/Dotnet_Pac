using Dotnet_Prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Prac.Controllers
{
    public class StudentController: Controller
    {
        MySqlConnection connection = null;
        MySqlCommand mySqlCommand = null;

        public StudentController(IConfiguration configuration )
        {
            connection = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Default").Value); 
        }

         public IActionResult Index()
         {
            return View();
         }

        [HttpPost]
         public async Task<IActionResult> Index(string studentName,string studentEmail, string studentNumber,string subject,string studentDetails)
         { 
            await connection.OpenAsync();
            mySqlCommand = new MySqlCommand("INSERT INTO students_table(studentName,studentEmail,studentNumber,subject,studentDetails) VALUES('" + studentName + "'," + studentEmail + "," + studentNumber + ",'" + subject + "','" + studentDetails + "')", connection);
            //mySqlCommand = new MySqlCommand("INSERT INTO (studentName,studentEmail,studentNumber,subject,studentDetails) VALUES('" + studentName + "'," + studentEmail + "," + studentNumber + ",'" + subject + "','" + studentDetails + "')",connection);
            var result = await mySqlCommand.ExecuteReaderAsync();
            await connection.CloseAsync();
            return View();
         }


         public IActionResult List()
         {
             string[] subjects ={"math","science","english"};
             ViewData["subjects"] = subjects;
             return View();
             
         }
    }
}