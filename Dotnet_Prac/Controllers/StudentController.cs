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
using System.Data;

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
            mySqlCommand = new MySqlCommand("INSERT INTO students(studentName,studentEmail,studentNumber,subject,studentDetails) VALUES('" + studentName + "','" + studentEmail + "','" + studentNumber + "','" + subject + "','" + studentDetails + "')", connection);
            //mySqlCommand = new MySqlCommand("INSERT INTO (studentName,studentEmail,studentNumber,subject,studentDetails) VALUES('" + studentName + "'," + studentEmail + "," + studentNumber + ",'" + subject + "','" + studentDetails + "')",connection);
            var result = await mySqlCommand.ExecuteReaderAsync();
            await connection.CloseAsync();
            return View();
         }


         public async Task<IActionResult> List()
         {
            await connection.OpenAsync();
            mySqlCommand = new MySqlCommand("SELECT * FROM students",connection);
            var result = await mySqlCommand.ExecuteReaderAsync();
        
            List<StudentModel> students = new List<StudentModel>();
            while(await result.ReadAsync())
            {
                students.Add(new StudentModel()
                {
                    studentID = Int16.Parse(result.GetValue("studentID").ToString()),
                    studentName = result.GetValue("studentName").ToString(),
                    studentEmail = result.GetValue("studentEmail").ToString(),
                    studentNumber = result.GetValue("studentNumber").ToString(),
                    subject = result.GetValue("subject").ToString(),
                    studentDetails = result.GetValue("studentDetails").ToString(),

                }); ; 
                
            }
            ViewData["students"]=students;
            await connection.CloseAsync();
             return View();
             
         }

        public async Task<IActionResult> Delete(string studentID)
        {
            await connection.OpenAsync();
             mySqlCommand = new MySqlCommand("DELETE FROM studentsWHERE studentID = '"+Int16.Parse(studentID)+"'",connection);
             var result = await mySqlCommand.ExecuteReaderAsync();

             await connection.CloseAsync();
            Console.WriteLine("StudentID:"+studentID);
          return RedirectToAction("List");
        }

        public IActionResult Update(string studentID, string studentName, string studentEmail, string studentNumber, string subject, string studentDetails)
        {
            Console.WriteLine(studentID + studentName+"CINT");
            StudentModel student = new StudentModel();
            student.studentID = Convert.ToInt16(studentID);
            student.studentName = studentName;
            student.studentEmail = studentEmail;
            student.studentNumber = studentNumber;
            student.subject = subject;
            student.studentDetails = studentDetails;
            ViewData["updateStudent"] = student;
            return View();
        }

    }
}