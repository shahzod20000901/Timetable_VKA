using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_VKA.TIMETABLE_SECTION
{
    public partial class reading_timetable_for_teachers : Form
    {
        public reading_timetable_for_teachers()
        {
            InitializeComponent();
        }
        DB db = new DB();
        MySqlCommand command1;

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;


        MySqlCommand command2, command_vuz_name, command_group_name, command_for_teachers;
        DataTable dtt, dt_vuz_name, dt_group_name, dt_for_teachers;
        MySqlDataAdapter daa, da_vuz_name, da_group_name, da_for_teachers;
        DataSet dss, ds_vuz_name, ds_group_name, ds_for_teachers;
        int index = 0;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            label3.Text = teachers_list[comboBox1.SelectedIndex];
            showing_teachers_timetable(dataGridView1, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView2, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView3, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView4, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView5, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView6, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView7, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView8, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView9, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView10, for_teachers, comboBox1.SelectedIndex);
            showing_teachers_timetable(dataGridView11, for_teachers, comboBox1.SelectedIndex);

            
        }

        string[] lesson_time = { "", "", "", "" };
        string[] teachers_list = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        List<string> groups_list = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        List<string> for_teachers = new List<string>  { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        private void reading_timetable_for_teachers_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //////////////////////////////////////////////////////////////////////////////////////////
            /*----------------------------------- Получение список дисциплин -------------------*/
            command1 = new MySqlCommand("SELECT `subjects_name` FROM `subjects_teachers`", db.getConnection());
            db.openConnection();
            da = new MySqlDataAdapter(command1);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            db.closeConnection();
            dt = ds.Tables["testTable"];

            
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                 
            }
            //////////////////////////////////////////////////////////////////////////////////////////
            /*----------------------------------- Получение список преподователей -------------------*/
            command2 = new MySqlCommand("SELECT `teachers_name` FROM `subjects_teachers`", db.getConnection());
            db.openConnection();
            daa = new MySqlDataAdapter(command2);
            dss = new DataSet();
            daa.Fill(dss, "testTable");
            db.closeConnection();
            dtt = dss.Tables["testTable"];


            for (int i = 0; i <= dtt.Rows.Count - 1; i++)
            {
                teachers_list[i]=dtt.Rows[i].ItemArray[0].ToString();

            }
            //////////////////////////////////////////////////////////////////////////////////////////
            /*----------------------------------- Получение список занятий для преподователей -------------------*/
            command_for_teachers = new MySqlCommand("SELECT `lessons` FROM `for_techers`", db.getConnection());
            db.openConnection();
            da_for_teachers = new MySqlDataAdapter(command_for_teachers);
            ds_for_teachers = new DataSet();
            da_for_teachers.Fill(ds_for_teachers, "testTable");
            db.closeConnection();
            dt_for_teachers = ds_for_teachers.Tables["testTable"];


            for (int i = 0; i <= dt_for_teachers.Rows.Count-1; i++)
            {
                for_teachers[i] = dt_for_teachers.Rows[i].ItemArray[0].ToString();

            }



            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ////////////////////////////////////////////////////////////////////////////////////////////
            /*--------------------------------- Получение данных -----------------------------------*/
            reading_timetables(dataGridView1, DataBank.routes[0]);
            reading_timetables(dataGridView2, DataBank.routes[1]);
            reading_timetables(dataGridView3, DataBank.routes[2]);
            reading_timetables(dataGridView4, DataBank.routes[3]);
            reading_timetables(dataGridView5, DataBank.routes[4]);
            reading_timetables(dataGridView6, DataBank.routes[5]);
            reading_timetables(dataGridView7, DataBank.routes[6]);
            reading_timetables(dataGridView8, DataBank.routes[7]);
            reading_timetables(dataGridView9, DataBank.routes[8]);
            reading_timetables(dataGridView10, DataBank.routes[9]);
            reading_timetables(dataGridView11, DataBank.routes[10]);


            colouring(dataGridView1);
            colouring(dataGridView2);
            colouring(dataGridView3);
            colouring(dataGridView4);
            colouring(dataGridView6);
            colouring(dataGridView5);
            colouring(dataGridView7);
            colouring(dataGridView8);
            colouring(dataGridView9);
            colouring(dataGridView10);
            colouring(dataGridView11);


            adding_mounth_name(dataGridView2);
            adding_mounth_name(dataGridView1);
            adding_mounth_name(dataGridView3);
            adding_mounth_name(dataGridView4);
            adding_mounth_name(dataGridView5);
            adding_mounth_name(dataGridView6);
            adding_mounth_name(dataGridView7);
            adding_mounth_name(dataGridView8);
            adding_mounth_name(dataGridView9);
            adding_mounth_name(dataGridView10);
            adding_mounth_name(dataGridView11);









            /////////////////////////////////////////////////////////////////////////////////////////
            /*---------------------------------- название учебной группы ----------------------------------*/



            adding_groups_name();

            /////////////////////////////////////////////////////////////////////////////////////////////
            /*                         Получение название ВУЗа                                */
            if (tabControl1.TabPages[0].Text != "") adding_vuz_name(vuz_name1);
            if (tabControl1.TabPages[1].Text != "") adding_vuz_name(vuz_name2);
            if (tabControl1.TabPages[2].Text != "") adding_vuz_name(vuz_name3);
            if (tabControl1.TabPages[3].Text != "") adding_vuz_name(vuz_name4);
            if (tabControl1.TabPages[4].Text != "") adding_vuz_name(vuz_name5);
            if (tabControl1.TabPages[5].Text != "") adding_vuz_name(vuz_name6);
            if (tabControl1.TabPages[6].Text != "") adding_vuz_name(vuz_name7);
            if (tabControl1.TabPages[7].Text != "") adding_vuz_name(vuz_name8);
            if (tabControl1.TabPages[8].Text != "") adding_vuz_name(vuz_name9);
            if (tabControl1.TabPages[9].Text != "") adding_vuz_name(vuz_name10);
            if (tabControl1.TabPages[10].Text != "") adding_vuz_name(vuz_name11);



            /*                 Вставка рабочего времени                 */

            string[] pairs_ = { "first_pair", "second_pair", "third_pair", "fourth_pair" };


            for (int i = 0; i < 4; i++)
            {
                command2 = new MySqlCommand("SELECT `" + pairs_[i] + "` FROM `working_hours_in_pairs`", db.getConnection());
                db.openConnection();
                daa = new MySqlDataAdapter(command2);
                dss = new DataSet();
                daa.Fill(dss, "testTable");

                db.closeConnection();
                dtt = dss.Tables["testTable"];




                lesson_time[i] = dtt.Rows[0].ItemArray[0].ToString();
            }

            

        }
        public void showing_teachers_timetable(DataGridView dataGridView, List<string> teach, int index)
        {
            int subject_lecture = 0;
            int subject_practic = 0;
            int subject_control_work = 0;
            if(index==0)
            {
                subject_lecture = 0;
                subject_practic = 1;
                subject_control_work = 2;
            }
            else if(index==1)
            {
                subject_lecture = 3;
                subject_practic = 4;
                subject_control_work = 5;
            }
            else if (index == 2)
            {
                subject_lecture = 6;
                subject_practic = 7;
                subject_control_work = 8;
            }
            else if (index == 3)
            {
                subject_lecture = 9;
                subject_practic = 10;
                subject_control_work = 11;
            }
            else if (index == 4)
            {
                subject_lecture = 12;
                subject_practic = 13;
                subject_control_work = 14;
            }
            else if (index == 5)
            {
                subject_lecture = 15;
                subject_practic = 16;
                subject_control_work = 17;
            }
            else if (index == 6)
            {
                subject_lecture = 18;
                subject_practic = 19;
                subject_control_work = 20;
            }
            else if (index == 7)
            {
                subject_lecture = 21;
                subject_practic = 22;
                subject_control_work = 23;
            }
            else if (index == 8)
            {
                subject_lecture = 24;
                subject_practic = 25;
                subject_control_work = 26;
            }
            else if (index == 9)
            {
                subject_lecture = 27;
                subject_practic = 28;
                subject_control_work = 29;
            }
            else if (index == 10)
            {
                subject_lecture = 30;
                subject_practic = 31;
                subject_control_work = 32;
            }
            else if (index == 11)
            {
                subject_lecture = 33;
                subject_practic = 34;
                subject_control_work = 35;
            }
            for (int i = 3; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (dataGridView[i, j].Style.BackColor == Color.Chocolate)
                    {
                        //dataGridView[i, j].Value = null;
                        dataGridView[i, j].Style.BackColor = Color.White;
                        dataGridView[i, j].Style.ForeColor = Color.White;
                    }



                }
            }
            for (int i = 3; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count-1; j++)
                {
                    
                        //dataGridView[i, j].Value = null;
                        dataGridView[i, j].Style.BackColor = Color.White;
                        dataGridView[i, j].Style.ForeColor = Color.Black;
                    



                }
            }
            List<string> for_teachers = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            for (int i=0; i<teach.Count; i++)
            {
                for_teachers[i] = teach[i];
            }


           

            for (int i = 3; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (dataGridView[i, j].Value != null)
                    {
                        if (dataGridView[i, j].Value.ToString() == for_teachers[subject_lecture] || dataGridView[i, j].Value.ToString() == for_teachers[subject_practic] || dataGridView[i, j].Value.ToString() == for_teachers[subject_control_work])
                        {
                            dataGridView[i, j].Style.BackColor = Color.Chocolate;
                        }
                    }



                }
            }
            for (int i = 3; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count-1; j++)
                {
                    if (dataGridView[i, j].Style.BackColor != Color.Chocolate)
                    {
                        //dataGridView[i, j].Value = null;
                        dataGridView[i, j].Style.BackColor = Color.White;
                        dataGridView[i, j].Style.ForeColor = Color.White;
                    }



                }
            }


            for (int j = 0; j < dataGridView.Rows.Count; j++)
            {
                if (dataGridView[2, j].Style.BackColor == Color.Red)
                {

                    dataGridView[3, j].Style.BackColor = Color.Red;
                    

                }



            }
            for(int i=0; i<dataGridView.Columns.Count; i++)
            {
                                   
                dataGridView[i, dataGridView.Rows.Count-1].Style.BackColor = Color.Red;


                    



                
            }
            



            adding_mounth_name(dataGridView);
            adding_dates(dataGridView);
        }
        public void adding_vuz_name(Label label)
        {
            command_vuz_name = new MySqlCommand("SELECT `vuzName` FROM `vuzname`", db.getConnection());
            db.openConnection();
            da_vuz_name = new MySqlDataAdapter(command_vuz_name);
            ds_vuz_name = new DataSet();
            da_vuz_name.Fill(ds_vuz_name, "testTable");
            db.closeConnection();
            dt_vuz_name = ds_vuz_name.Tables["testTable"];


            label.Text = dt_vuz_name.Rows[0].ItemArray[0].ToString();

        }
        public void adding_dates(DataGridView dataGridView)
        {
            int m = 23; ;
            int d = 1;
            int s = 0;
            int[] date = { 30, 31, 30, 31, 31, 29 };


            for (int i = 3; i < dataGridView.Columns.Count; i++)
            {
                DataGridViewRow row_date = new DataGridViewRow();



                for (; m < dataGridView.Rows.Count; m++)
                {
                    DataGridViewCell cell = new DataGridViewTextBoxCell();

                    if (!(s > 5))
                    {
                        if (d > date[s])
                        {
                            ++s; d = 1;
                        }
                        cell.Value = d.ToString();


                        dataGridView[i, m] = cell;
                        dataGridView[i, m].Style.BackColor=Color.Red;

                        m = m + 4;
                        ++d;
                    }

                }
                m = 3;


            }

            dataGridView[29, dataGridView.Rows.Count - 1].Value = "3";
            dataGridView[29, dataGridView.Rows.Count - 6].Value = "2";
            dataGridView.AllowUserToAddRows = false;
        }
        public void adding_groups_name()
        {
            command_group_name = new MySqlCommand("SELECT `groups` FROM `groups_table`", db.getConnection());
            db.openConnection();
            da_group_name = new MySqlDataAdapter(command_group_name);
            ds_group_name = new DataSet();
            da_group_name.Fill(ds_group_name, "testTable");
            db.closeConnection();
            dt_group_name = ds_group_name.Tables["testTable"];





            for (int i = 0; i < dt_group_name.Rows.Count; i++)
            {
                groups_list[i] = dt_group_name.Rows[i].ItemArray[0].ToString();

            }



            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {

                tabControl1.TabPages[i].Text = groups_list[i].ToString();

            }

            group_name1.Text = groups_list[0].ToString();
            group_name2.Text = groups_list[1].ToString();
            group_name3.Text = groups_list[2].ToString();
            group_name4.Text = groups_list[3].ToString();
            group_name5.Text = groups_list[4].ToString();
            group_name6.Text = groups_list[5].ToString();
            group_name7.Text = groups_list[6].ToString();
            group_name8.Text = groups_list[7].ToString();
            group_name9.Text = groups_list[8].ToString();
            group_name10.Text = groups_list[9].ToString();
            group_name11.Text = groups_list[10].ToString();

        }


        public void colouring(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView[i, 3].Style.BackColor = Color.Red;
                dataGridView[i, 8].Style.BackColor = Color.Red;
                dataGridView[i, 13].Style.BackColor = Color.Red;
                dataGridView[i, 18].Style.BackColor = Color.Red;
                dataGridView[i, 23].Style.BackColor = Color.Red;
                dataGridView[i, 28].Style.BackColor = Color.Red;
                dataGridView[i, 32].Style.BackColor = Color.Red;


            }

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (dataGridView[i, j].Value != null)
                    {
                        if (dataGridView[i, j].Value.ToString() == "Стаж") dataGridView[i, j].Style.BackColor = Color.DarkOrange;
                        else if (dataGridView[i, j].Value.ToString() == "Отп") dataGridView[i, j].Style.BackColor = Color.DarkGray;
                        else if (dataGridView[i, j].Value.ToString() == "Вых") dataGridView[i, j].Style.BackColor = Color.DarkGray;


                    }

                }
            }
        }



        public void adding_mounth_name(DataGridView dataGridView)
        {
            for (int i = 4; i < dataGridView.Columns.Count; i++)
            {

                if (i >= 4 && i < 8)
                {
                    dataGridView[i, 2].Style.BackColor = Color.Tan;
                    dataGridView[i, 2].Value = "Сент";

                }
                if (i >= 8 && i < 12)
                {
                    dataGridView[i, 2].Style.BackColor = Color.Aquamarine;
                    dataGridView[i, 2].Value = "Октя";

                }
                if (i >= 12 && i < 16)
                {
                    dataGridView[i, 2].Style.BackColor = Color.Blue;
                    dataGridView[i, 2].Value = "Нояб";

                }

                if (i >= 16 && i < 21)
                {
                    dataGridView[i, 2].Style.BackColor = Color.Brown;
                    dataGridView[i, 2].Value = "Дека";

                }

                if (i >= 21 && i < 26)
                {
                    dataGridView[i, 2].Style.BackColor = Color.Azure;
                    dataGridView[i, 2].Value = "Янва";

                }

                if (i >= 26 && i < 30)
                {
                    dataGridView[i, 2].Style.BackColor = Color.Chocolate;
                    dataGridView[i, 2].Value = "Февр";

                }



            }
        }
        
        public void reading_timetables(DataGridView dataGridView, string file)
        {


            using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int n = bw.ReadInt32();
                int m = bw.ReadInt32();
                for (int i = 0; i < m; ++i)
                {
                    dataGridView.Rows.Add();
                    for (int j = 0; j < n; ++j)
                    {
                        if (bw.ReadBoolean())
                        {
                            dataGridView.Rows[i].Cells[j].Value = bw.ReadString();
                        }
                        else bw.ReadBoolean();
                    }
                }
            }

        }
    }
}
