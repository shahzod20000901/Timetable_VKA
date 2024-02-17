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
    public partial class add_teacher_menu : Form
    {
        add_teachers_form form1;
        public add_teacher_menu(add_teachers_form owner)
        {
            InitializeComponent();
            form1=owner;
        }

        private void Add_teacher_menu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox= false;
            this.MinimizeBox= false;
          
            label2.Text = DataBank.selected_subject;
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        ListViewItem listViewItem;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            DataBank.defined_teacher=textBox1.Text;
            DataBank.defined_subject = label2.Text;

            listViewItem = new ListViewItem(new string[] { DataBank.defined_subject, DataBank.defined_teacher });
            form1.listView1.Items[form1.listView1.FocusedItem.Index].SubItems.Add(DataBank.defined_teacher);

            this.Close();
        }
    }
}
