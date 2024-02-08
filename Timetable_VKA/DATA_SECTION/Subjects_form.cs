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
    public partial class Subjects_form : Form
    {
        public Subjects_form()
        {
            InitializeComponent();
        }

        private void Subjects_form_Load(object sender, EventArgs e)
        {
            this.MaximizeBox= false;
            this.MinimizeBox= false;
            listView1.Scrollable = true;
            listView1.View = View.Details;

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            adding_subject_name_form form =new adding_subject_name_form();
            form.Show();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(DataBank.subject_name);
            this.Refresh();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            listView1.FocusedItem.Remove();
        }
    }
}
