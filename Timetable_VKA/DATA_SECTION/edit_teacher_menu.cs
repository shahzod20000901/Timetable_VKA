using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Timetable_VKA.DATA_SECTION
{
    public partial class edit_teacher_menu : Form
    {

        readonly add_teachers_form form1;
        public edit_teacher_menu(add_teachers_form owner)
        {
            form1=owner;
            InitializeComponent();
        }

        private void Edit_teacher_menu_Load(object sender, EventArgs e)
        {
            label2.Text = DataBank.edit_defined_subject;
            textBox1.Text = DataBank.edit_teacher;
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Ok_btn_Click(object sender, EventArgs e)
        {
            DataBank.edit_defined_subject= label2.Text;
            DataBank.edit_teacher= textBox1.Text;



            form1.listView1.SelectedItems[0].SubItems[1].Text=textBox1.Text;
            

           
            this.Close();
        }
    }
}
