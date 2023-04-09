using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app11
{
    public partial class InfoForm : Form
    {
        private static InfoForm? form;
        private Student std;

        private InfoForm(Student std)
        {
            InitializeComponent();
            this.std = std;
        }

        public static InfoForm Init(Student std)
        {
            if (form is null)
                form = new InfoForm(std);

            return form;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form = null;
        }
    }
}
