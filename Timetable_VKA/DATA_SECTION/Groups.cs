using MySql.Data.MySqlClient;
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
    public partial class Groups : Form
    {
        public Groups()
        {
            InitializeComponent();
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            listView1.Scrollable = true;
            listView1.View = View.Details;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            new add_group_menu(this).Show();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            listView1.FocusedItem.Remove();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            DataBank.edit_group = listView1.FocusedItem.SubItems[0].Text;
            DataBank.edit_department = listView1.FocusedItem.SubItems[1].Text;
            DataBank.edit_faculty = listView1.FocusedItem.SubItems[2].Text;
            new edit_group_menu(this).Show();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `groups_table`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                MessageBox.Show("Список групп не обновлено!");
            else

                MessageBox.Show("Список групп обновлено!");
            db.closeConnection();

            MySqlCommand command;
            int j;


            for (int i = 0; i < listView1.Items.Count; i++)
            {


                command = new MySqlCommand("INSERT INTO `groups_table` (`groups`, `department`, `faculty`) VALUES(@log" + i + ", @log1" + i + ", @log2"+i+")", db.getConnection());
                command.Parameters.Add("@log" + i + "", MySqlDbType.VarChar).Value = listView1.Items[i].SubItems[0].Text;
                command.Parameters.Add("@log1" + i + "", MySqlDbType.VarChar).Value = listView1.Items[i].SubItems[1].Text;
                command.Parameters.Add("@log2" + i + "", MySqlDbType.VarChar).Value = listView1.Items[i].SubItems[2].Text;





                db.openConnection();


                if (command.ExecuteNonQuery() == 1)
                    j = 0;

                else
                    j = 1;

                db.closeConnection();
            }
            this.Close();

        }
    }
}
