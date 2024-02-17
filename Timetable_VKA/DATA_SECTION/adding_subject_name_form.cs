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
        Subjects_form form1;
        public adding_subject_name_form(Subjects_form owner)
        {
            InitializeComponent();
            form1 = owner;
        }

        private void Adding_subject_name_form_Load(object sender, EventArgs e)
        {
            this.MinimizeBox= false;
            this.MaximizeBox= false;
        }
        public int i = 0;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            
            
            DataBank.all_subjects[DataBank.i]=textBox1.Text;
            DataBank.all_subjects_reduction[DataBank.i]=textBox2.Text;
            ++DataBank.i;
            
            string[] sub_red = {textBox1.Text,textBox2.Text};
            ListViewItem listViewItem = new ListViewItem ( sub_red );
            form1.listView1.Items.Add(listViewItem);

            DataBank.all_subjects[i] = textBox1.Text;
            ++i;
            //this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
