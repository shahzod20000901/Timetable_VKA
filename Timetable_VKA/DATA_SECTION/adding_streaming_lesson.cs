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
    public partial class adding_streaming_lesson : Form
    {
        public adding_streaming_lesson()
        {
            InitializeComponent();
        }
        DB db = new DB();
        MySqlCommand command1;

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;
        private void adding_streaming_lesson_Load(object sender, EventArgs e)
        {

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            for(int i=0; i<20; i++)
            {
                dataGridView1.Rows.Add();
            }

            

            command1 = new MySqlCommand("SELECT `Subjects_reduction` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            db.closeConnection();
            dt = ds.Tables["testTable"];
            

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dataGridView1[0, i].Value=dt.Rows[i].ItemArray[0].ToString();
            }

            command1 = new MySqlCommand("SELECT `Subjects` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            db.closeConnection();
            dt = ds.Tables["testTable"];


            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dataGridView1[1, i].Value = dt.Rows[i].ItemArray[0].ToString();
            }

            command1 = new MySqlCommand("SELECT `groups` FROM `groups_table`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            db.closeConnection();
            dt = ds.Tables["testTable"];

            string groups="" ;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                groups+=dt.Rows[i].ItemArray[0].ToString();
            }
            comboBox1.Items.Add(groups);


        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = comboBox1.SelectedItem.ToString();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
           
            for(int i=0; i<dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[2, i].Value!=null)
                {
                    DataBank.stream_subjetcs[i] = dataGridView1[0, i].Value.ToString();
                }
            }
            MessageBox.Show("Потоковое занятие добавлено!!!");
            
            this.Close();
        }
    }
}
