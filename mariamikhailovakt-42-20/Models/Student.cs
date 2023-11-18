using System.Text.RegularExpressions;

namespace mariamikhailovakt_42_20.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int GroupId { get; set; }
        public int LessonsId { get; set; }
        public Group Group { get; set; }
        public Lessons Lessons { get; set; }
    }
}
