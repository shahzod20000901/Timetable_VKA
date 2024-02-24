using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Timetable_VKA.DATA_SECTION
{
    public partial class working_hours_per_day : Form
    {
       
        public working_hours_per_day()
        {
            InitializeComponent();
        }

        

        

        private void Working_hours_per_day_Load(object sender, EventArgs e)
        {
            this.MinimizeBox= false;
            this.MaximizeBox= false;
            
            
            dataGridView1.SelectionMode= DataGridViewSelectionMode.RowHeaderSelect;
           


        }

            
            public int i=0;
            public int j=0;
            string[] monday_sum = { "", "", "", "" };
            string[] tuesday_sum = { "", "", "", "" };
            string[] wednesday_sum = { "", "", "", "" };
            string[] thursday_sum = { "", "", "", "" };
            string[] friday_sum = { "", "", "", "" };
            string[] saturday_sum = { "", "", "", "" };

        string[] pairs = { "Первая пара", "Вторая пара", "Третья пара", "Четвертая пара" };





        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (i <= 3)
            {
                DataGridViewRow row0 = new DataGridViewRow();

                DataGridViewCell monday_ = new DataGridViewTextBoxCell();
                DataGridViewCell tuesday_ = new DataGridViewTextBoxCell();
                DataGridViewCell wednesday_ = new DataGridViewTextBoxCell();
                DataGridViewCell thursday_ = new DataGridViewTextBoxCell();
                DataGridViewCell friday_ = new DataGridViewTextBoxCell();
                DataGridViewCell saturday_ = new DataGridViewTextBoxCell();




                monday_.Value = pairs[i];
                tuesday_.Value = pairs[i];
                wednesday_.Value = pairs[i];
                thursday_.Value = pairs[i];
                friday_.Value = pairs[i];
                saturday_.Value = pairs[i];
                row0.Cells.AddRange(monday_, tuesday_, wednesday_, thursday_, friday_, saturday_);
                dataGridView1.Rows.AddRange(row0);

                
                
                
            }
            else
            {
                MessageBox.Show("Больше пар добавить невозможно!");
            }



            ++i;
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Working_hours_per_day_Enter(object sender, EventArgs e)
        {
           
        }


        
        public void Ok_btn_Click(object sender, EventArgs e)
        {


            int g;



            DB db = new DB();

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `working_hours_in_pairs`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                g = 0;
            else

                g = 1;
            db.closeConnection();

            MySqlCommand command;
            int j;  

                command = new MySqlCommand("INSERT INTO `working_hours_in_pairs` (`first_pair`, `second_pair`,`third_pair`,`fourth_pair` ) VALUES(@log, @log1, @log2, @log3)", db.getConnection());
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@log1", MySqlDbType.VarChar).Value = textBox2.Text;
                command.Parameters.Add("@log2", MySqlDbType.VarChar).Value = textBox3.Text;
                command.Parameters.Add("@log3", MySqlDbType.VarChar).Value = textBox4.Text;


                db.openConnection();


                if (command.ExecuteNonQuery() == 1)
                    j = 0;

                else
                    j = 1;

                db.closeConnection();


            MySqlCommand command2;
            command2 = new MySqlCommand("TRUNCATE TABLE `working_hours_per_day`", db.getConnection());
            db.openConnection();
            if (command2.ExecuteNonQuery() == 1)
                MessageBox.Show("Длительность пар не обновлено!");
            else

                MessageBox.Show("Длительность пар обновлено!");
            db.closeConnection();

           
            
            MySqlCommand command3;
            int d;



            for (int i = 0; i < 4; i++)
            {

                monday_sum[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();


                tuesday_sum[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();


                wednesday_sum[i] = dataGridView1.Rows[i].Cells[2].Value.ToString();

                thursday_sum[i] = dataGridView1.Rows[i].Cells[3].Value.ToString();


                friday_sum[i] = dataGridView1.Rows[i].Cells[4].Value.ToString();

                saturday_sum[i] = dataGridView1.Rows[i].Cells[5].Value.ToString();


            }


            for (int i=0; i<dataGridView1.Rows.Count-1; i++)
            {

                
                
                command3 = new MySqlCommand("INSERT INTO `working_hours_per_day` (`monday`, `tuesday`,`wednesday`,`thursday`, `friday`, `saturday` ) VALUES(@log, @log"+i+", @log"+i+1+", @log"+i+2+ ",@log"+i+3+ ",@log"+i+4+")", db.getConnection());

                command3.Parameters.Add("@log", MySqlDbType.VarChar).Value = monday_sum[i];
             
                command3.Parameters.Add("@log" + i + "", MySqlDbType.VarChar).Value = tuesday_sum[i];

                command3.Parameters.Add("@log" + i + 1 + "", MySqlDbType.VarChar).Value = wednesday_sum[i];
                command3.Parameters.Add("@log" + i + 2 + "", MySqlDbType.VarChar).Value = thursday_sum[i];
                command3.Parameters.Add("@log" + i + 3 + "", MySqlDbType.VarChar).Value = friday_sum[i];
                command3.Parameters.Add("@log" + i + 4 + "", MySqlDbType.VarChar).Value = saturday_sum[i];

                





                db.openConnection();


                if (command3.ExecuteNonQuery() == 1)
                    d = 1;

                else
                    d = 0;
                    
                      db.closeConnection();
                
            }


            MessageBox.Show("Данные загружены! ");



            this.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

       
    }
}

    
