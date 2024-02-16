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
    public partial class add_teachers_form : Form
    {
        public add_teachers_form()
        {
            InitializeComponent();
        }

        ListViewItem listViewItem;

        private void Add_teachers_form_Load(object sender, EventArgs e)
        {
            //ListViewItem listViewItem = new ListViewItem(new string[] {DataBank.subject_name, DataBank.teachers });
            this.MaximizeBox= false;
            this.MinimizeBox= false;
            listView1.Scrollable = true;
            listView1.View = View.Details;

            for (int i=0; i<DataBank.all_subjects.Length; i++)
            {
                listView1.Items.Add(DataBank.all_subjects[i]);
            }
            //listViewItem = new ListViewItem(new string[] { DataBank.defined_subject, DataBank.defined_teacher });

           
            
        }
        public void Update_btn_Click(object sender, EventArgs e)
        {
            listViewItem = new ListViewItem(new string[] { DataBank.defined_subject, DataBank.defined_teacher });

            listView1.Items.Add(listViewItem);
            
            this.Refresh();

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            DataBank.selected_subject_index = listView1.FocusedItem.Index;
            add_teacher_menu form=new add_teacher_menu();
            listView1.FocusedItem.Remove();
            form.Show();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
