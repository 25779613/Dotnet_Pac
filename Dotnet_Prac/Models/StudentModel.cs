using System.ComponentModel.DataAnnotations;

namespace Dotnet_Prac.Models
{
    public class StudentModel
    {
        [Key]
        public int studentID{get;set;}
        public string studentName{get;set;}

        public string studentEmail{get;set;}

        public string studentNumber{get;set;}

        public string subject{get;set;}

        public string studentDetails{get;set;}

    }
}