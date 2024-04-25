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

namespace Timetable_VKA.FILE_SECTION
{
    public partial class change_exthisting_timetable : Form
    {
        public change_exthisting_timetable()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory("..\\..");
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
        
        string[] lesson_time = { "", "", "", "" };
        List<string> groups_list = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        int move_to_left = 0;
        int index = 0;
        int move_to_right = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView1);   
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView1);
        }

        private void change_exthisting_timetable_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            /////////////////////////////////////////////////////////////////////////////////////////
            /*---------------------------------- название учебной группы ----------------------------------*/

            adding_groups_name();
            //////////////////////////////////////////////////////////////////////////////////////
            /*------------------------------------ Чтение данных из файла -----------------------------------*/
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


            

            /*                            Закрашивание ячецки                   */


            colouring(dataGridView1);
            colouring(dataGridView2);
            colouring(dataGridView3);
            colouring(dataGridView4);
            colouring(dataGridView5);
            colouring(dataGridView6);
            colouring(dataGridView7);
            colouring(dataGridView8);
            colouring(dataGridView9);
            colouring(dataGridView10);
            colouring(dataGridView11);

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            /*                           Вставка названия месяца               */

            adding_mounth_name(dataGridView1);
            adding_mounth_name(dataGridView2);
            adding_mounth_name(dataGridView3);
            adding_mounth_name(dataGridView4);
            adding_mounth_name(dataGridView5);
            adding_mounth_name(dataGridView6);
            adding_mounth_name(dataGridView7);
            adding_mounth_name(dataGridView8);
            adding_mounth_name(dataGridView9);
            adding_mounth_name(dataGridView10);
            adding_mounth_name(dataGridView11);


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView1, DataBank.routes[0]);
            MessageBox.Show("Расписание сохранено!!!!");
           
        }
        public void saving_timetables(DataGridView dataGridView, string file)
        {


            using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
            {
                bw.Write(dataGridView.Columns.Count);
                bw.Write(dataGridView.Rows.Count);
                foreach (DataGridViewRow dgvR in dataGridView.Rows)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; ++j)
                    {
                        object val = dgvR.Cells[j].Value;
                        if (val == null)
                        {
                            bw.Write(false);
                            bw.Write(false);
                        }
                        else
                        {
                            bw.Write(true);
                            bw.Write(val.ToString());
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView2, DataBank.routes[1]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView3, DataBank.routes[2]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView4);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView4);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView4, DataBank.routes[3]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView5);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView5);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView5, DataBank.routes[4]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView6);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView6);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView6, DataBank.routes[5]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView7);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView7);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView7, DataBank.routes[6]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView8);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView8);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView8, DataBank.routes[7]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView9);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView9);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView9, DataBank.routes[8]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView10);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView10);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView10, DataBank.routes[9]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            moving_to_left(dataGridView11);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            moving_to_right(dataGridView11);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            saving_timetables(dataGridView11, DataBank.routes[10]);
            MessageBox.Show("Расписание сохранено!!!!");
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView2);
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView3);
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView4);
        }

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView5);
        }

        private void dataGridView6_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView6);
        }

        private void dataGridView7_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView7);
        }

        private void dataGridView8_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView8);
        }

        private void dataGridView9_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView9);
        }

        private void dataGridView10_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView10);
        }

        private void dataGridView11_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cutting_lessons(dataGridView11);
        }

        private void vuz_name2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = 0;
            for(int i=0; i<DataBank.selected_cells.Count; i++)
            {
                DataBank.selected_cells[i] = "";
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

        public void moving_to_right(DataGridView dataGridView)
        {
            int flag = 0;
            int column = move_to_right + 2;
            int row_1 = 24;
            Random random = new Random();


            for (int i = 0; i < DataBank.selected_cells.Count; i++)
            {

                if (column < dataGridView.Columns.Count)
                {
                    if (row_1 < dataGridView.Rows.Count)
                    {
                        if (dataGridView[column, row_1].Value == null)
                        {
                            if (DataBank.selected_cells[flag] != "")
                            {
                                dataGridView[column, row_1].Value = DataBank.selected_cells[flag];
                                dataGridView[column, row_1].Style.BackColor = Color.Cyan;
                                flag++;
                            }

                        }
                        else
                        {
                            --i;
                        }

                    }

                }

                column++;
                if (column == dataGridView.Columns.Count - 1)
                {
                    column = move_to_right + 2;
                }
                row_1 = random.Next(4, dataGridView.Rows.Count-1);

            }
        }

        public void moving_to_left(DataGridView dataGridView)
        {
            int flag = 0;
            int column = 4;
            int row_1 = 24;
            Random random = new Random();


            for (int i = 0; i < DataBank.selected_cells.Count; i++)
            {

                if (column < move_to_left)
                {
                    if (row_1 < dataGridView.Rows.Count)
                    {
                        if (dataGridView[column, row_1].Value == null)
                        {
                            if (DataBank.selected_cells[flag] != "")
                            {
                                dataGridView[column, row_1].Value = DataBank.selected_cells[flag];
                                dataGridView[column, row_1].Style.BackColor = Color.Cyan;
                                flag++;
                            }

                        }
                        else
                        {
                            --i;
                        }

                    }

                }

                column++;
                if (column == move_to_left-2)
                {
                    column = 4;
                }
                row_1 = random.Next(4, dataGridView.Rows.Count-1);

            }
        }
        public void cutting_lessons(DataGridView dataGridView)
        {
            
            
            if (index < DataBank.selected_cells.Count)
            {
                DataBank.selected_cells[index] = dataGridView.CurrentCell.Value.ToString();

                index++;
                dataGridView.CurrentCell.Value = null;
                move_to_right = dataGridView.CurrentCell.ColumnIndex;

                if(move_to_left==0)
                {
                    move_to_left = dataGridView.CurrentCell.ColumnIndex;

                }
            }
            else
            {
                MessageBox.Show("Больше занятий выбрать невозможно!!!");
            }
        }


    }
}
