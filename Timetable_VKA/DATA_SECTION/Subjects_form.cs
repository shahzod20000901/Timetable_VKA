using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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

            //listView1.Columns.

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            adding_subject_name_form form =new adding_subject_name_form();
            form.Show();
        }

        ListViewItem listViewItem; 
        
        public int i = 0;
        public void Update_btn_Click(object sender, EventArgs e)
        {
            listViewItem = new ListViewItem(new string[] { DataBank.subject_name, DataBank.subject_reduction });

            listView1.Items.Add(listViewItem);
            
            DataBank.all_subjects[i] = DataBank.subject_name;
            ++i;

            this.Refresh();
            
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            listView1.FocusedItem.Remove();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            

            DB db = new DB();

                MySqlCommand command;
           
                    command = new MySqlCommand("INSERT INTO `subjects_table` (`Subjects`, `Subjects_reduction`) VALUES(@log, @log1)", db.getConnection());
                    command.Parameters.Add("@log", MySqlDbType.VarChar).Value = listViewItem.SubItems[0].Text.ToString();
                    command.Parameters.Add("@log1", MySqlDbType.VarChar).Value = listViewItem.SubItems[1].Text.ToString();
            


            

            db.openConnection();

            
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Сохранено в базу данных!");
            else
                MessageBox.Show("Не сохранено в базу данных!");
            db.closeConnection();
            
            this.Close();



        }
    }
}
