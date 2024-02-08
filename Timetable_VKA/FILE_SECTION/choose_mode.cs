using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_VKA
{
    public partial class choose_mode : Form
    {
        public choose_mode()
        {
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            help_mode newForm = new help_mode();
            newForm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}