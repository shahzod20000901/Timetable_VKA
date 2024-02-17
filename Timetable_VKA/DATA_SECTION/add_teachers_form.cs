using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_VKA.DATA_SECTION
{
    public partial class add_teachers_form : Form
    {
        DB db=new DB();
        MySqlCommand command1;
        
        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;
        public add_teachers_form()
        {
            InitializeComponent();
        }

        ListViewItem listViewItem;

        private void Add_teachers_form_Load(object sender, EventArgs e)
        {
            
            this.MaximizeBox= false;
            this.MinimizeBox= false;
            listView1.Scrollable = true;
            listView1.View = View.Details;
          

            command1 = new MySqlCommand("SELECT `Subjects` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds=new DataSet();
            da.Fill(ds, "testTable");
            db.closeConnection();
            dt = ds.Tables["testTable"];
            int i;

            for(i=0; i<=dt.Rows.Count-1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }



        }
        public void Update_btn_Click(object sender, EventArgs e)
        {
            listViewItem = new ListViewItem(new string[] { DataBank.defined_subject, DataBank.defined_teacher });

            /*
            
            */
            listView1.Items[listView1.FocusedItem.Index].SubItems.Add(DataBank.defined_teacher);
            this.Refresh();

        }

        public void edit(string teachers)
        {
            
            listView1.FocusedItem.SubItems[1].Text = teachers;
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            DataBank.selected_subject_index = listView1.FocusedItem.Index;
            add_teacher_menu form=new add_teacher_menu();
            
            form.Show();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            listView1.FocusedItem.Remove();
        }
        public int index;

        void Edit_btn_Click(object sender, EventArgs e)
        {
            DataBank.selected_subject_index = listView1.FocusedItem.Index;
            DataBank.edit_teacher = listView1.FocusedItem.SubItems[1].Text;
            DataBank.edit_defined_subject = listView1.FocusedItem.Text;
            new edit_teacher_menu(this).Show();
            
        }
    }
}
