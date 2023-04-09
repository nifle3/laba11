namespace app11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (StudentContext db = new StudentContext()) { }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationFrom form = new();
            form.Show();
        }
    }
}