using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            if (UnfindEmailInDb())
                return;

            string email = textBox1.Text;
            string newPassword = PasswordGenerator.GetPassword();


        }

        private bool UnfindEmailInDb()
        {
            if (CheckIncorrectEmail())
                return true;

            bool a = true;
            using (StudentContext db = new())
            {
                foreach(Student student in db.Users.ToArray<Student>())
                {
                    if (student.Email == textBox1.Text)
                    {
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
