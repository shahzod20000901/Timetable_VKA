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
    public partial class add_group_menu : Form
    {
        Groups group;

        
        public add_group_menu(Groups owner)
        {
            this.group = owner;
            InitializeComponent();
        }

        private void add_group_menu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            string[] sub_red = { textBox1.Text+" группа", textBox2.Text+" кафедра", textBox3.Text+" факультет" };
            ListViewItem listViewItem = new ListViewItem(sub_red);
            group.listView1.Items.Add(listViewItem);
        }
    }
}
