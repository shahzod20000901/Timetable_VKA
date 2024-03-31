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
using Timetable_VKA.DATA_SECTION;

namespace Timetable_VKA.TIMETABLE_SECTION
{
    public partial class reading_timetable_new : Form
    {
        public reading_timetable_new()
        {
            InitializeComponent();
        }

        DB db = new DB();
        MySqlCommand command1;

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;


        MySqlCommand command2, command_vuz_name, command_group_name;
        DataTable dtt, dt_vuz_name, dt_group_name;
        MySqlDataAdapter daa, da_vuz_name, da_group_name;
        DataSet dss, ds_vuz_name, ds_group_name;
        int index = 0;

        string[] lesson_time = { "", "", "", "" };
        List<string> groups_list = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        private void reading_timetable_new_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ////////////////////////////////////////////////////////////////////////////////////////////
            /*--------------------------------- Получение данных -----------------------------------*/
            reading_timetables(dataGridView1, DataBank.routes[0]);
            colouring(dataGridView1);
            adding_mounth_name(dataGridView1);

            reading_timetables(dataGridView2, DataBank.routes[1]);
            colouring(dataGridView2);
            adding_mounth_name(dataGridView2);

            reading_timetables(dataGridView3, DataBank.routes[2]);
            colouring(dataGridView3);
            adding_mounth_name(dataGridView3);

            reading_timetables(dataGridView4, DataBank.routes[3]);
            colouring(dataGridView4);
            adding_mounth_name(dataGridView4);

            reading_timetables(dataGridView5, DataBank.routes[4]);
            colouring(dataGridView5);
            adding_mounth_name(dataGridView5);

            reading_timetables(dataGridView6, DataBank.routes[5]);
            colouring(dataGridView6);
            adding_mounth_name(dataGridView6);

            reading_timetables(dataGridView7, DataBank.routes[6]);
            colouring(dataGridView7);
            adding_mounth_name(dataGridView7);

            reading_timetables(dataGridView8, DataBank.routes[7]);
            colouring(dataGridView8);
            adding_mounth_name(dataGridView8);

            reading_timetables(dataGridView9, DataBank.routes[8]);
            colouring(dataGridView9);
            adding_mounth_name(dataGridView9);

            reading_timetables(dataGridView10, DataBank.routes[9]);
            colouring(dataGridView10);
            adding_mounth_name(dataGridView10);

            reading_timetables(dataGridView11, DataBank.routes[10]);
            colouring(dataGridView11);
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
