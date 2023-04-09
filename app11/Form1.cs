namespace app11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationFrom form = new();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPasswordForm form = new();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1 == null || textBox2 == null)
                return;

            string password = HashPassword.GetHashString(textBox2.Text);
            Student? student = FindStudent(password);

            if (student is null)
                return;

            InfoForm form = InfoForm.Init(student);
            form.Show();
        }

        private Student? FindStudent(string pass)
        {
            Student? anw = null;
            using (StudentContext db = new())
            {
                foreach(Student student in db.Users)
                {
                    if (student.Email == textBox1.Text. && student.Password == pass)
                        anw = student;
                }
            }

            return anw;
        }
    }
}