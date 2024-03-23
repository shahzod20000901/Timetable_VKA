using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    //DataGridView1.Rows[rowIndex].Cells[columnIndex].Value
    public partial class All_timetable : Form
    {
        public All_timetable()
        {
            InitializeComponent();
        }

        DB db = new DB();
        MySqlCommand command1;

        DataTable dt;
        MySqlDataAdapter da;
        DataSet ds;


        MySqlCommand command2, command_vuz_name;
        DataTable dtt, dt_vuz_name;
        MySqlDataAdapter daa, da_vuz_name;
        DataSet dss, ds_vuz_name;


        MySqlCommand command_reduc, command_classroms, command_lesson_sum, command_practic, command_con_work;
        DataTable dt_reduc, dt_classroms, dt_lesson_sum, dt_practic, dt_con_work;
        MySqlDataAdapter da_reduc, da_classroms, da_lesson_sum, da_practic, da_con_work;
        DataSet ds_reduc, ds_classroms, ds_lesson_sum, ds_practic, ds_con_work;

        private void All_timetable_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dataGridView1.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;

            /////////////////////////////////////////////////////////////////////////////////////////////
            /*                         Получение название ВУЗа                                */

            command_vuz_name = new MySqlCommand("SELECT `vuzName` FROM `vuzname`", db.getConnection());
            db.openConnection();
            da_vuz_name = new MySqlDataAdapter(command_vuz_name);
            ds_vuz_name = new DataSet();
            da_vuz_name.Fill(ds_vuz_name, "testTable");
            db.closeConnection();
            dt_vuz_name = ds_vuz_name.Tables["testTable"];
            

            vuz_name.Text= dt_vuz_name.Rows[0].ItemArray[0].ToString();


            ///////////////////////////////////////////////////////////////////////////////////////////


            for (int i=0; i<dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Font = new Font("Times New Roman", 7);

            }
            dataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Times New Roman", 6);

           

            //////////////////////////////////////////////////////////////////////////////////////////////////
            /*                       Получение данных из базы данных                      */

            List<string> all_subjects = new List<string> { "", "", "", "", "", "", "", "","","","","","","","","","" };
            /*-------------------------------------------------------------------------------------------------------*/
            command_reduc = new MySqlCommand("SELECT `Subjects_reduction` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da_reduc = new MySqlDataAdapter(command_reduc);
            ds_reduc = new DataSet();
            da_reduc.Fill(ds_reduc, "testTable");
            db.closeConnection();
            dt_reduc = ds_reduc.Tables["testTable"];

            for(int i=0; i<dt_reduc.Rows.Count; i++)
            {
                all_subjects[i] = dt_reduc.Rows[i].ItemArray[0].ToString();
                all_subjects[i] += "\t";
                
            }

            for(int i=0; i<all_subjects.Count; i++)
            {
                if (all_subjects[i] =="")all_subjects.RemoveAt(i);
            }

            
            /*--------------------------------------------------------------------------------------------------------*/
            command_classroms = new MySqlCommand("SELECT `classroom_number` FROM `classroms`", db.getConnection());
            db.openConnection();
            da_classroms = new MySqlDataAdapter(command_classroms);
            ds_classroms = new DataSet();
            da_classroms.Fill(ds_classroms, "testTable");
            db.closeConnection();
            dt_classroms = ds_classroms.Tables["testTable"];

            for (int i = 0; i < dt_classroms.Rows.Count; i++)
            {
                all_subjects[i] += dt_classroms.Rows[i].ItemArray[0].ToString();
                all_subjects[i] += "\tлек";

            }

            /*--------------------------------------------------------------------------------------------------------*/
            /*                         получение кол. лекции практики и контрольных работ */

            List<int> subjects_lecture = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<int> subjects_practic = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<int> subjects_con_work = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            command_lesson_sum = new MySqlCommand("SELECT `lectures` FROM `lessons_summary`", db.getConnection());
            db.openConnection();
            da_lesson_sum = new MySqlDataAdapter(command_lesson_sum);
            ds_lesson_sum = new DataSet();
            da_lesson_sum.Fill(ds_lesson_sum, "testTable");
            db.closeConnection();
            dt_lesson_sum = ds_lesson_sum.Tables["testTable"];


            for (int i = 0; i < dt_lesson_sum.Rows.Count; i++)
            {
                subjects_lecture[i] = int.Parse(dt_lesson_sum.Rows[i].ItemArray[0].ToString());


            }

            for (int i = 0; i < subjects_lecture.Count; i++)
            {
                if (subjects_lecture[i] == 0) subjects_lecture.RemoveAt(i);
            }


            /*-------------------------------------------------------------------------------------------*/
            command_practic = new MySqlCommand("SELECT `practic` FROM `lessons_summary`", db.getConnection());
            db.openConnection();
            da_practic = new MySqlDataAdapter(command_practic);
            ds_practic = new DataSet();
            da_practic.Fill(ds_practic, "testTable");
            db.closeConnection();
            dt_practic = ds_practic.Tables["testTable"];

            
            for (int i = 0; i < dt_practic.Rows.Count; i++)
            {
                subjects_practic[i] = int.Parse(dt_practic.Rows[i].ItemArray[0].ToString());


            }

            for (int i = 0; i < subjects_practic.Count; i++)
            {
                if (subjects_practic[i] == 0) subjects_practic.RemoveAt(i);
            }

            /*-------------------------------------------------------------------------------------------*/
            command_con_work = new MySqlCommand("SELECT `control work` FROM `lessons_summary`", db.getConnection());
            db.openConnection();
            da_con_work = new MySqlDataAdapter(command_con_work);
            ds_con_work = new DataSet();
            da_con_work.Fill(ds_con_work, "testTable");
            db.closeConnection();
            dt_con_work = ds_con_work.Tables["testTable"];


            for (int i = 0; i < dt_con_work.Rows.Count; i++)
            {
                subjects_con_work[i] = int.Parse(dt_con_work.Rows[i].ItemArray[0].ToString());


            }

            for (int i = 0; i < subjects_con_work.Count; i++)
            {
                if (subjects_con_work[i] == 0) subjects_con_work.RemoveAt(i);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
           




            //////////////////////////////////////////////////////////////////////////////////////////

            /*                 Вставка рабочего времени                 */

            string[] pairs_ = { "first_pair", "second_pair", "third_pair", "fourth_pair" };
            string[] lesson_time = { "", "", "", "" };

            for (int i=0; i<4; i++)
            {
                command2 = new MySqlCommand("SELECT `"+pairs_[i]+"` FROM `working_hours_in_pairs`", db.getConnection());
                db.openConnection();
                daa = new MySqlDataAdapter(command2);
                dss = new DataSet();
                daa.Fill(dss, "testTable");

                db.closeConnection();
                dtt = dss.Tables["testTable"];




                lesson_time[i] = dtt.Rows[0].ItemArray[0].ToString();
            }
            

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            /*                       Встака дня недели                         */
            
            int a = 1;
            int j = 0;
            int g = 0;
            for (int i = 0; i < 33; i++)
            {

                DataGridViewCell monday_ = new DataGridViewTextBoxCell();
                DataGridViewCell pair = new DataGridViewTextBoxCell();
                DataGridViewCell first_lesson_time = new DataGridViewTextBoxCell();
                first_lesson_time.Style.WrapMode=DataGridViewTriState.True;
                string[] pairs = { "1-2", "3-4", "5-6", "7-8" };


                DataGridViewRow row = new DataGridViewRow();


                row.Height = 45;

                if (i==0 || i==1 || i==2 || i == 3 || i == 8 || i == 13 || i == 18 || i == 23 || i == 28 || i == 32)
                {
                    row.Height = 15;
                }





                if (i == 4 || i == 5 || i == 6 || i == 7)
                {
                    monday_.Value = "Пн";
                    pair.Value = pairs[g];
                    first_lesson_time.Value = lesson_time[g];
                    
                    g++;
                    row.Cells.AddRange(monday_, pair, first_lesson_time);
                    
                    if (g == 4) g = 0;
                }



                if (i == 9 || i == 10 || i == 11 || i == 12)
                {
                    monday_.Value = "Вт";
                    pair.Value = pairs[g];
                    first_lesson_time.Value = lesson_time[g];

                    g++;
                    row.Cells.AddRange(monday_, pair, first_lesson_time);
                    if (g == 4) g = 0;
                }


                if (i == 14 || i == 15 || i == 16 || i == 17)
                {
                    monday_.Value = "Ср";
                    pair.Value = pairs[g];
                    first_lesson_time.Value = lesson_time[g];

                    g++;
                    row.Cells.AddRange(monday_, pair, first_lesson_time);
                    if (g == 4) g = 0;
                }


                if (i == 19 || i == 20 || i == 21 || i == 22)
                {
                    monday_.Value = "Чт";
                    pair.Value = pairs[g];
                    first_lesson_time.Value = lesson_time[g];

                    g++;
                    row.Cells.AddRange(monday_, pair, first_lesson_time);
                    if (g == 4) g = 0;
                }



                if (i == 24 || i == 25 || i == 26 || i == 27)
                {
                    monday_.Value = "Пт";
                    pair.Value = pairs[g];
                    first_lesson_time.Value = lesson_time[g];

                    g++;
                    row.Cells.AddRange(monday_, pair, first_lesson_time);
                    if (g == 4) g = 0;
                }


                if (i == 29 || i == 30 || i == 31 || i == 32)
                {
                    monday_.Value = "Сб";
                    pair.Value = pairs[g];
                    first_lesson_time.Value = lesson_time[g];

                    g++;
                    row.Cells.AddRange(monday_, pair, first_lesson_time);
                    if (g == 4) g = 0;
                }

                
                dataGridView1.Rows.Add(row);
                

            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /*                        Вставка даты                            */

            int m = 23; ;
            int d = 1;
            int s = 0;
            int[] date = { 30, 31, 30, 31, 31, 29 };


            for (int i=3; i<dataGridView1.Columns.Count; i++)
            {
                DataGridViewRow row_date = new DataGridViewRow();

                

                for(; m<dataGridView1.Rows.Count; m++)
                {
                    DataGridViewCell cell = new DataGridViewTextBoxCell();

                    if (!(s > 5))
                    {
                        if (d > date[s])
                        {
                            ++s; d = 1;
                        }
                        cell.Value = d.ToString();

                       
                        dataGridView1[i, m] = cell;
                        m = m + 4;
                        ++d;
                    }
                   
                }
                m = 3;
                

            }
            /*                            Закрашивание ячецки                   */

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1[i, 3].Style.BackColor = Color.Red;
                dataGridView1[i, 8].Style.BackColor = Color.Red;
                dataGridView1[i, 13].Style.BackColor = Color.Red;
                dataGridView1[i, 18].Style.BackColor = Color.Red;
                dataGridView1[i, 23].Style.BackColor = Color.Red;
                dataGridView1[i, 28].Style.BackColor = Color.Red;
                dataGridView1[i, 33].Style.BackColor = Color.Red;
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            /*                           Вставка названия месяца               */

            for (int i=4; i<dataGridView1.Columns.Count;i++)
            {
                
                if(i>=4 && i<8)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Tan;
                    dataGridView1[i, 2].Value = "Сент";

                }
                if(i>=8 && i<12)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Aquamarine;
                    dataGridView1[i, 2].Value = "Октя";

                }
                if (i>=12 && i < 16)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Blue;
                    dataGridView1[i, 2].Value = "Нояб";

                }

                if (i>=16 && i < 21)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Brown;
                    dataGridView1[i, 2].Value = "Дека";

                }

                if (i>=21 && i <26)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Azure;
                    dataGridView1[i, 2].Value = "Янва";

                }

                if (i>=26 && i < 30)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Chocolate;
                    dataGridView1[i, 2].Value = "Февр";

                }

                

            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////


            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*                                            Вставка отпуска и праздников                                   */
            int vac_start_column = 0;
            int vac_start_row = 0;

            int vac_end_column = 0;
            int vac_end_row = 0;

            /*----------------------------------- Определение началы даты  ------------------------------------------------------------*/
            for (int i = 4; i < dataGridView1.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView1[i, loc].Value != null)
                {
                    if (dataGridView1[i, loc].Value.ToString().ToLower() == DataBank.vac_mounth[0].ToLower())
                    {
                        ++loc;


                        for (; loc < dataGridView1.Rows.Count; loc++)
                        {
                            if (dataGridView1[i, loc].Value != null)
                            {
                                if (dataGridView1[i, loc].Value.ToString().ToLower() == DataBank.vac_dates[0].ToLower())
                                {
                                    vac_start_column = i;
                                    vac_start_row = loc;


                                }
                            }


                        }

                    }
                }


            }
            faculty_name.Text = vac_start_column.ToString();
            group_name.Text = vac_start_row.ToString();

            /*----------------------------------- Определение конец даты  ------------------------------------------------------------*/

            for (int i = 4; i < dataGridView1.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView1[i, loc].Value != null)
                {
                    if (dataGridView1[i, loc].Value.ToString().ToLower() == DataBank.vac_mounth[1].ToLower())
                    {
                        ++loc;


                        for (; loc < dataGridView1.Rows.Count; loc++)
                        {
                            if (dataGridView1[i, loc].Value != null)
                            {
                                if (dataGridView1[i, loc].Value.ToString().ToLower() == DataBank.vac_dates[1].ToLower())
                                {
                                    vac_end_column = i;
                                    vac_end_row = loc;


                                }
                            }


                        }

                    }
                }


            }
            the_end_of_column.Text = vac_end_column.ToString();
            the_end_of_row.Text = vac_end_row.ToString();   

            /* --------------------------------- Вставка отпусков ------------------------------------------------- */
            for (; vac_start_column <= vac_end_column; vac_start_column++)
            {
                if (vac_start_column < vac_end_column)
                {
                    for (; vac_start_row <= dataGridView1.Rows.Count-1; vac_start_row++)
                    {
                        if (dataGridView1[vac_start_column, vac_start_row].Value == null)
                        {
                            dataGridView1[vac_start_column, vac_start_row].Value = "Вых";
                            dataGridView1[vac_start_column, vac_start_row].Style.BackColor =Color.DarkGray;
                            
                        }
                    }
                    vac_start_row = 4;
                }
                
                 if (vac_start_column == vac_end_column)
                {
                    for (; vac_start_row <= vac_end_row+4; vac_start_row++)
                    {
                        if (dataGridView1[vac_start_column, vac_start_row].Value == null)
                        {
                            dataGridView1[vac_start_column, vac_start_row].Value = "Вых";
                            dataGridView1[vac_start_column, vac_start_row].Style.BackColor = Color.DarkGray;
                        }
                    }
                }
                
            }
            /*-------------------------------  Определение праздничные дни ------------------------------------- */

            int flag = 0;
            for (int i = 4; i < dataGridView1.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView1[i, loc].Value != null)
                {
                    if (dataGridView1[i, loc].Value.ToString().ToLower() == DataBank.hol_mounth[flag].ToLower())
                    {
                        ++loc;

                        MessageBox.Show(DataBank.hol_mounth[flag]);
                        for (; loc < dataGridView1.Rows.Count; loc++)
                        {
                            if (dataGridView1[i, loc].Value != null)
                            {
                                if (dataGridView1[i, loc].Value.ToString().ToLower() == DataBank.hol_day[flag].ToLower())
                                {
                                    if (dataGridView1[i, loc+1].Value==null)
                                    {
                                        dataGridView1[i, loc + 1].Value = "Вых";
                                        dataGridView1[i, loc + 1].Style.BackColor = Color.DarkGray; 
                                    }
                                    if (dataGridView1[i, loc + 2].Value == null)
                                    {
                                        dataGridView1[i, loc + 2].Value = "Вых";
                                        dataGridView1[i, loc + 2].Style.BackColor = Color.DarkGray;
                                    }
                                    if (dataGridView1[i, loc + 3].Value == null)
                                    {
                                        dataGridView1[i, loc + 3].Value = "Вых";
                                        dataGridView1[i, loc + 3].Style.BackColor = Color.DarkGray;
                                    }
                                    if (dataGridView1[i, loc + 4].Value == null)
                                    {
                                        dataGridView1[i, loc + 4].Value = "Вых";
                                        dataGridView1[i, loc + 4].Style.BackColor = Color.DarkGray;
                                    }

                                }
                            }


                        }

                    }
                }
                if(flag==1)
                {
                    flag = 0;
                }
                flag++;
                

            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            dataGridView1.Rows.RemoveAt(32);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*                                      распределение расписаний                             */




            int subject = 0;
            int summa = 0;
            for (int r = 0; r < all_subjects.Count; r++)
            {
                int column = 3;
                int row__ = 24;
                Random random = new Random();


                for (int i = 0; i < subjects_lecture[summa] + subjects_practic[summa] + subjects_con_work[summa]; i++)
                {



                    if (!(column > dataGridView1.Columns.Count))
                    {

                        if (dataGridView1[column, row__].Value == null)
                        {
                            dataGridView1[column, row__].Value = all_subjects[subject].ToString();

                        }
                        else
                        {
                            --i;
                        }
                    }

                    ++column;
                    row__ = random.Next(4, dataGridView1.Rows.Count);
                }
                ++summa;
                ++subject;
            }









        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
            
 

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
