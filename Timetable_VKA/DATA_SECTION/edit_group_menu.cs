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
    public partial class edit_group_menu : Form
    {
        Groups group;
        public edit_group_menu(Groups owner)
        {
            this.group = owner;
            InitializeComponent();
        }

        private void edit_group_menu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            textBox1.Text = DataBank.edit_group;
            textBox2.Text = DataBank.edit_department;
            textBox3.Text = DataBank.edit_faculty;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            group.listView1.FocusedItem.SubItems[0].Text = textBox1.Text;
            group.listView1.FocusedItem.SubItems[1].Text = textBox2.Text;
            group.listView1.FocusedItem.SubItems[2].Text = textBox3.Text;
            this.Close();
            
        }
    }
}
