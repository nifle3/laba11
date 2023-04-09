using System;

namespace app11
{
    public class Student
    {
        public int StudentId { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public DateTime Birthday { set; get; }
        public string Email { set; get; }
        public string NumberPhone { set; get; }
        public string Facility { set; get; }
        public int Group { set; get; }
        public int CourseOfEducation { set; get; }
        public DateTime DateOfEntryToEducation { set; get; }
        public string Password { set; get; }

        public Student(string firstName, string secondName, DateTime birthday, 
            string email, string numberPhone, string facility, int group, int courseOfEducation, 
            DateTime dateOfEntryToEducation, string password)
        {
            FirstName = firstName;
            SecondName = secondName;
            Birthday = birthday;
            Email = email;
            NumberPhone = numberPhone;
            Facility = facility;
            Group = group;
            CourseOfEducation = courseOfEducation;
            DateOfEntryToEducation = dateOfEntryToEducation;
            Password = password;
        }
    }
}
