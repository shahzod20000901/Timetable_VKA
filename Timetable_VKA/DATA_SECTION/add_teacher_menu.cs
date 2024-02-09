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
    public partial class add_teacher_menu : Form
    {
        public add_teacher_menu()
        {
            InitializeComponent();
        }

        private void Add_teacher_menu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox= false;
            this.MinimizeBox= false;
          
            label2.Text = DataBank.all_subjects[DataBank.selected_subject_index];
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            DataBank.defined_teacher=textBox1.Text;
            DataBank.defined_subject = label2.Text;
            this.Close();
        }
    }
}
