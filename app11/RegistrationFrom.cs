using System;
using System.Text.RegularExpressions;

namespace app11
{
    public partial class RegistrationFrom : Form
    {
        public RegistrationFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Error.Text = string.Empty;
            Student? student = CreateStudent();

            if (student == null)
                return;

            AddStudentToDb(student);
            this.Close();
        }

        public Student? CreateStudent()
        {
            string firstName = textBox1.Text;
            string secondName = textBox2.Text;

            if (IsInvalidValueDate(CheckDateTimeInput(textBox3.Text), "birthday"))
                return null;

            DateTime birthday = ReformDateTimeInput(textBox3.Text);

            if (!(CorrectEmailCheck() && CheckUniqueEmail()))
                return null;

            string email = emailbox.Text;

            if (!CheckCorrectPhoneNumber())
            {
                Error.Text = "Phone number has invalid value";
                return null;
            }

            string phoneNumber = phoneBox.Text;
            string facility = textBox6.Text;

            if (IsInvalidValueInt(textBox8.Text, "group"))
                return null;

            int group = int.Parse(textBox8.Text);


            if (IsInvalidValueInt(textBox7.Text, "course"))
                return null;

            int course = int.Parse(textBox7.Text);

            if (IsInvalidValueDate(CheckDateTimeInput(textBox9.Text), "start of education"))
                return null;

            DateTime startOfEducation = ReformDateTimeInput(textBox9.Text);
            string password = HashPassword.GetHashString(textBox10.Text);
            Student student = new(firstName, secondName, birthday, email, phoneNumber,
                facility, group, course, startOfEducation, password);

            return student;
        }

        private bool CheckDateTimeInput(string input) =>
            Regex.IsMatch(input, @"[0-31].[0-12].[1900-2023]");

        private DateTime ReformDateTimeInput(string input)
        {
            string[] date = input.Split(new char[] { '.' });
            int[] dateInt = StringToInt(date);

            return new DateTime(dateInt[2], dateInt[1], dateInt[0]);
        }

        private int[] StringToInt(string[] date)
        {
            int[] dateInt = new int[date.Length];

            for (int i = 0; i < date.Length; i++)
            {
                dateInt[i] = int.Parse(date[i]);
            }

            return dateInt;
        }

        private bool CorrectEmailCheck() =>
            Regex.IsMatch(emailbox.Text, @"\S+@\S+.\S+", RegexOptions.None);

        private bool CheckUniqueEmail() 
        {
            using(StudentContext db = new())
            {
                foreach (Student checkStudent in db.Users)
                {
                    if (checkStudent.Email == emailbox.Text)
                        return false;
                }
            }

            return true;
        }

        private bool CheckCorrectPhoneNumber()=>
            Regex.IsMatch(phoneBox.Text, @"[+][0-9]\d+", RegexOptions.None) ||
            Regex.IsMatch(phoneBox.Text, @"\d+", RegexOptions.None);

        private bool IsInvalidValueDate(bool a, string whatIsIt)
        {
            if (a)
            {
                Error.Text = $"{whatIsIt} has invalid value";
                return true;
            }

            return false;
        }

        private bool IsInvalidValueInt(string text, string whatIsIt)
        {
            if (!int.TryParse(text, out _)) 
            {
                Error.Text = $"{whatIsIt} has invalid value";
                return true;
            }

            return false;
        }

        private void AddStudentToDb(Student st)
        {
            using (StudentContext db = new())
            {
                db.Add(st);
                db.SaveChanges();
            }
        }
    }
}
