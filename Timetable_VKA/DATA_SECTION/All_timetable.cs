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


        MySqlCommand command2;
        DataTable dtt;
        MySqlDataAdapter daa;
        DataSet dss;


        MySqlCommand command_reduc, command_classroms, command_lesson_sum;
        DataTable dt_reduc, dt_classroms, dt_lesson_sum;
        MySqlDataAdapter da_reduc, da_classroms, da_lesson_sum;
        DataSet ds_reduc, ds_classroms, ds_lesson_sum;

        private void All_timetable_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dataGridView1.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Times New Roman", 6);
            label3.Text = "Сформировано: 12.08.2023";

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

            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            /*                                распределение расписаний                                     */

            command_lesson_sum = new MySqlCommand("SELECT `lecture` FROM `lessons_sum`", db.getConnection());
            db.openConnection();
            da_lesson_sum = new MySqlDataAdapter(command_lesson_sum);
            ds_lesson_sum = new DataSet();
            da_lesson_sum.Fill(ds_lesson_sum, "testTable");
            db.closeConnection();
            dt_lesson_sum = ds_lesson_sum.Tables["testTable"];

            List<string> subjects_lecture = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            for (int i = 0; i < dt_reduc.Rows.Count; i++)
            {
                subjects_lecture[i] = dt_lesson_sum.Rows[i].ItemArray[0].ToString();


            }

            for (int i = 0; i < subjects_lecture.Count; i++)
            {
                if (subjects_lecture[i] == "") subjects_lecture.RemoveAt(i);
            }

            List<int> subjetc_lecture_int = new List<int>(subjects_lecture.Count);


            for (var i = 0; i < subjects_lecture.Count; i++)
            {
                subjetc_lecture_int.Add(int.Parse(subjects_lecture[i]));
            }
            /*-------------------------------------------------------------------------------------------*/




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


                row.Height = 30;

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

                        //row_date.Cells.AddRange(cell);
                        dataGridView1[i, m] = cell;
                        m = m + 4;
                        ++d;
                    }
                   
                }
                m = 3;
                

            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            
            /*                           Вставка названия месяца               */

            for (int i=4; i<dataGridView1.Columns.Count;i++)
            {
                
                if(i>=4 && i<8)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Tan;
                    dataGridView1[i, 2].Value = "Сентябрь";

                }
                if(i>=8 && i<12)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Aquamarine;
                    dataGridView1[i, 2].Value = "Октябрь";

                }
                if (i>=12 && i < 16)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Blue;
                    dataGridView1[i, 2].Value = "Ноябрь";

                }

                if (i>=16 && i < 21)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Brown;
                    dataGridView1[i, 2].Value = "Декабрь";

                }

                if (i>=21 && i <26)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Azure;
                    dataGridView1[i, 2].Value = "Январь";

                }

                if (i>=26 && i < 30)
                {
                    dataGridView1[i, 2].Style.BackColor = Color.Chocolate;
                    dataGridView1[i, 2].Value = "Февраль";

                }

                

            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            
            /*                            Закрашивание ячецки                   */

            for(int i=0; i<dataGridView1.Columns.Count; i++)
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
