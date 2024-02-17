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

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `work_days`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                MessageBox.Show("Список рабочие дни не обновлено!");
            else

                MessageBox.Show("Список рабочие дни обновлено!");
            db.closeConnection();

            MySqlCommand command;
            int j;


            for (int i = 0; i < listView1.Items.Count; i++)
            {


                command = new MySqlCommand("INSERT INTO `work_days` (`work_days_name`) VALUES(@log" + i + ")", db.getConnection());
                command.Parameters.Add("@log" + i + "", MySqlDbType.VarChar).Value = listView1.Items[i].SubItems[0].Text;
                

                db.openConnection();


                if (command.ExecuteNonQuery() == 1)
                    j = 0;

                else
                    j = 1;

                db.closeConnection();
            }
            this.Close();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
