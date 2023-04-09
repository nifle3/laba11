using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace app11
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            string newPassword = PasswordGenerator.GetPassword();

            if (UnfindEmailInDb(newPassword))
            {
                Error.Text = "Mail doesn't exist";
                return;
            }

            string email = textBox1.Text;
            EmailSender.SendNewPass(email, newPassword);
            this.Close();
        }

        private bool UnfindEmailInDb(string pass)
        {
            if (CheckIncorrectEmail())
                return true;

            bool a = true;
            using (StudentContext db = new())
            {
                foreach (Student student in db.Users.ToArray<Student>())
                {
                    if (student.Email == textBox1.Text)
                    {
                        student.Password = HashPassword.GetHashString(pass);
                        db.Users.Update(student);
                        db.SaveChanges();
                        a = false;
                        break;
                    }
                }
            }

            return a;
        }

        private bool CheckIncorrectEmail() =>
            !Regex.IsMatch(textBox1.Text, @"\S+[@]\S+[.]");

    }
}
