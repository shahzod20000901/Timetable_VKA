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
    public partial class Lessons_menu : Form
    {
        public Lessons_menu()
        {
            InitializeComponent();
        }
        DB db = new DB();
        MySqlCommand command1;

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;

        private void Lessons_menu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            command1 = new MySqlCommand("SELECT `Subjects` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds = new DataSet();
            da.Fill(ds, "testTable");

            db.closeConnection();
            dt = ds.Tables["testTable"];
            int i;
            dataGridView1.DataSource = dt;
            


            DataGridViewTextBoxColumn lecture_cln = new DataGridViewTextBoxColumn();
            lecture_cln.HeaderText = "лекции"; // Заголовок
            lecture_cln.Name = "lecture"; // Название столбца
            lecture_cln.ValueType = typeof(string); // Тип данных в столбце
            lecture_cln.Width = 150;

            dataGridView1.Columns.Add(lecture_cln);

            DataGridViewTextBoxColumn practic_cln = new DataGridViewTextBoxColumn();
            practic_cln.HeaderText = "практическое занятие"; // Заголовок
            practic_cln.Name = "practic_cln"; // Название столбца
            practic_cln.ValueType = typeof(string); // Тип данных в столбце
            practic_cln.Width = 150;

            dataGridView1.Columns.Add(practic_cln);

            DataGridViewTextBoxColumn control_cln = new DataGridViewTextBoxColumn();
            control_cln.HeaderText = "контрольная работа"; // Заголовок
            control_cln.Name = "practic_cln"; // Название столбца
            control_cln.ValueType = typeof(string); // Тип данных в столбце
            control_cln.Width = 150;

            dataGridView1.Columns.Add(control_cln);

            dataGridView1.Columns[0].Width = 200;
            Random random = new Random();
            for(int m=1; m<dataGridView1.Columns.Count; m++)
            {
                for(int n=0; n<dataGridView1.Rows.Count-1; n++)
                {
                    dataGridView1[m, n].Value = random.Next(3, 10);
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<string> Subjects =new List<string>() { "", "", "", "","","","","","","","","","","","","","","","" };
        
        List<int> lecture =new List<int>() { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
        List<int> seminar = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> control_work = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> id = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

       

        private void ok_btn_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            int g = 0, d=0;

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `lessons_summary`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                g = 0;
            else

                g = 1;
            db.closeConnection();

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {

                Subjects[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();


                lecture[i] = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());


                seminar[i] = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

                control_work[i] = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());

                            


            }

            

            for(int i=0; i<Subjects.LongCount(); i++)
            {
                if (Subjects[i]=="")Subjects.RemoveAt(i);
            }

            for (int i = 0; i < lecture.LongCount(); i++)
            {
                if (lecture[i] == 0) lecture.RemoveAt(i) ;
            }
            for (int i = 0; i < seminar.LongCount(); i++)
            {
                if (seminar[i] == 0) seminar.RemoveAt(i);
            }
            for (int i = 0; i < control_work.LongCount(); i++)
            {
                if (control_work[i] == 0) control_work.RemoveAt(i);
            }
            int local = 1;
            for (int i = 0; i < Subjects.LongCount(); i++)
            {
                id[i] = local;
                local++;
            }

            for (int i = 0; i < id.LongCount(); i++)
            {
                if (id[i] == 0) id.RemoveAt(i);
            }

            int summa = 0;
            for(int i=0; i<lecture.LongCount(); i++)
            {
                summa+= lecture[i];
                summa+= seminar[i];
                summa+= control_work[i];
            }

            if(summa>300)
            {
                MessageBox.Show("Сумма всех занятий не должен превышать выше 400 пар");
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    command1 = new MySqlCommand("INSERT INTO `lessons_summary` (`id`, `Subjects`, `lectures`,`practic`,`control work`) VALUES(@log, @log" + i + ", @log" + i + 1 + ", @log" + i + 2 + ", @log" + i + 3 + ")", db.getConnection());

                    command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = id[i];
                    command1.Parameters.Add("@log" + i + "", MySqlDbType.VarChar).Value = Subjects[i];

                    command1.Parameters.Add("@log" + i + 1 + "", MySqlDbType.Int32).Value = lecture[i];

                    command1.Parameters.Add("@log" + i + 2 + "", MySqlDbType.Int32).Value = seminar[i];
                    command1.Parameters.Add("@log" + i + 3 + "", MySqlDbType.Int32).Value = control_work[i];

                    db.openConnection();


                    if (command1.ExecuteNonQuery() == 1)
                        d = 1;

                    else
                        d = 0;

                    db.closeConnection();

                }

                this.Close();
            }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
