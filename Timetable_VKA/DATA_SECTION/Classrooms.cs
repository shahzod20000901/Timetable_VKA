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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Timetable_VKA.DATA_SECTION
{
    public partial class Classrooms : Form
    {
        public Classrooms()
        {
            InitializeComponent();
        }
        DB db = new DB();
        MySqlCommand command1;

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;

        private void Classrooms_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            command1 = new MySqlCommand("SELECT `Subjects` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds = new DataSet();
            da.Fill(ds, "testTable");

            db.closeConnection();
            dt = ds.Tables["testTable"];
            int i;
            dataGridView1.DataSource = dt;
            


            DataGridViewTextBoxColumn classroom_cln = new DataGridViewTextBoxColumn();
            classroom_cln.HeaderText = "Номер аудитории"; // Заголовок
            classroom_cln.Name = "classroom_cln"; // Название столбца
            classroom_cln.ValueType = typeof(string); // Тип данных в столбце
            classroom_cln.Width = 150;

            dataGridView1.Columns.Add(classroom_cln);

            DataGridViewTextBoxColumn building_cln = new DataGridViewTextBoxColumn();
            building_cln.HeaderText = "Номер корпуса/факультета"; // Заголовок
            building_cln.Name = "building_cln"; // Название столбца
            building_cln.ValueType = typeof(string); // Тип данных в столбце
            building_cln.Width = 150;

            dataGridView1.Columns.Add(building_cln);


        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            int g;

            DB db = new DB();

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `classroms`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                g = 0;
            else

                g = 1;
            db.closeConnection();

            
            MySqlCommand command3;
            int d;


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {



                command3 = new MySqlCommand("INSERT INTO `classroms` (`subjects`, `classroom_number`,`building_number` ) VALUES(@log, @log" + i + ", @log" + i + 1 + ")", db.getConnection());

                command3.Parameters.Add("@log", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();

                command3.Parameters.Add("@log" + i + "", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();

                command3.Parameters.Add("@log" + i + 1 + "", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
               

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
    }
}
