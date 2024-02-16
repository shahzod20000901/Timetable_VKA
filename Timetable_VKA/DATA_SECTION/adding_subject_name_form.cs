using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_VKA.DATA_SECTION
{
    public partial class adding_subject_name_form : Form
    {
        public adding_subject_name_form()
        {
            InitializeComponent();
        }

        private void Adding_subject_name_form_Load(object sender, EventArgs e)
        {
            this.MinimizeBox= false;
            this.MaximizeBox= false;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            
            DataBank.subject_name=textBox1.Text;
            DataBank.subject_reduction=textBox2.Text;
            DataBank.all_subjects[DataBank.i]=textBox1.Text;
            DataBank.all_subjects_reduction[DataBank.i]=textBox2.Text;
            ++DataBank.i;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
