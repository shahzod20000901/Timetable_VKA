using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Timetable_VKA.DATA_SECTION
{
    public partial class Work_day_of_week : Form
    {
        public Work_day_of_week()
        {
            InitializeComponent();
        }

        private void NumericUpDown1_MouseDown(object sender, MouseEventArgs e)
        {
            int j = 5;
            
        }

        private void NumericUpDown1_MouseUp(object sender, MouseEventArgs e)
        {
            add_work_day();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            
            add_work_day();
        }


        public int i = 0;
        public void add_work_day()
        {
            string[] work_days = { "1. Понедельник", "2. Вторник", "3. Среда", "4. Четверг", "5. Пятница", "6. Суббота", "7. Воскресенье" };

            if (i > 6)
            {
                MessageBox.Show("Больше рабочих дней создать невозможно!");

            }
            else
            {
                listView1.Items.Add(work_days[i]);

            }
                                         
            ++i;
        }

        private void Work_day_of_week_Load(object sender, EventArgs e)
        {
            listView1.Scrollable = true;
            listView1.View = View.Details;
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            
            listView1.FocusedItem.Remove();
        }

        

        private void OK_btn_Click(object sender, EventArgs e)
        {
           
            
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `work_days` (`1`, `2`, `3`, `4`, `5`, `6`) VALUES (@log, @log1, @log2, @log3, @log4, @log5)", db.getConnection());
             
            


            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = listView1.Items[0].Text.ToString();
            command.Parameters.Add("@log1", MySqlDbType.VarChar).Value = listView1.Items[1].Text.ToString();
            command.Parameters.Add("@log2", MySqlDbType.VarChar).Value = listView1.Items[2].Text.ToString();
            command.Parameters.Add("@log3", MySqlDbType.VarChar).Value = listView1.Items[3].Text.ToString();
            command.Parameters.Add("@log4", MySqlDbType.VarChar).Value = listView1.Items[4].Text.ToString();
            command.Parameters.Add("@log5", MySqlDbType.VarChar).Value = listView1.Items[5].Text.ToString();






            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Сохранено в базу данных!");
            else
                MessageBox.Show("Не сохранено в базу данных!");
            db.closeConnection();
            this.Close();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
