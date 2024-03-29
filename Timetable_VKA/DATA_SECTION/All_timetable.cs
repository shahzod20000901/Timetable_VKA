using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        MySqlCommand command2, command_vuz_name, command_group_name;
        DataTable dtt, dt_vuz_name, dt_group_name;
        MySqlDataAdapter daa, da_vuz_name, da_group_name;
        DataSet dss, ds_vuz_name, ds_group_name;

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        MySqlCommand command_reduc, command_classroms, command_lesson_sum, command_practic, command_con_work;
        DataTable dt_reduc, dt_classroms, dt_lesson_sum, dt_practic, dt_con_work;

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        MySqlDataAdapter da_reduc, da_classroms, da_lesson_sum, da_practic, da_con_work;

        private void group_name5_Click(object sender, EventArgs e)
        {

        }

        private void group_name2_Click(object sender, EventArgs e)
        {

        }

        DataSet ds_reduc, ds_classroms, ds_lesson_sum, ds_practic, ds_con_work;

        string[] lesson_time = { "", "", "", "" };
        List<string> groups_list = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        List<string> all_subjects = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        List<int> subjects_lecture = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> subjects_practic = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> subjects_con_work = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        private void All_timetable_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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


            ///////////////////////////////////////////////////////////////////////////////////////////
            /*------------------------------------  Размер ячейки ------------------------------------------------*/

            adding_the_size_of_text(dataGridView1);
            adding_the_size_of_text(dataGridView2);
            adding_the_size_of_text(dataGridView3);
            adding_the_size_of_text(dataGridView4);
            adding_the_size_of_text(dataGridView5);
            adding_the_size_of_text(dataGridView6);
            adding_the_size_of_text(dataGridView7);
            adding_the_size_of_text(dataGridView8);
            adding_the_size_of_text(dataGridView9);
            adding_the_size_of_text(dataGridView10);
            adding_the_size_of_text(dataGridView11);



            //////////////////////////////////////////////////////////////////////////////////////////////////
            /*                       Получение данных из базы данных                      */


            /*-------------------------------------------------------------------------------------------------------*/
            command_reduc = new MySqlCommand("SELECT `Subjects_reduction` FROM `subjects_table`", db.getConnection());
            db.openConnection();
            da_reduc = new MySqlDataAdapter(command_reduc);
            ds_reduc = new DataSet();
            da_reduc.Fill(ds_reduc, "testTable");
            db.closeConnection();
            dt_reduc = ds_reduc.Tables["testTable"];

            for (int i = 0; i < dt_reduc.Rows.Count; i++)
            {
                all_subjects[i] = dt_reduc.Rows[i].ItemArray[0].ToString();


            }

            for (int i = 0; i < all_subjects.Count; i++)
            {
                if (all_subjects[i] == "") all_subjects.RemoveAt(i);
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

                all_subjects[i] += "\n" + dt_classroms.Rows[i].ItemArray[0].ToString();
                
                DataBank.unstreamed_subjetcs[i]+= "\n" + dt_classroms.Rows[i].ItemArray[0].ToString();
                
                DataBank.stream_subjetcs[i] += "\n" + dt_classroms.Rows[i].ItemArray[0].ToString();



            }

            /*--------------------------------------------------------------------------------------------------------*/
            /*                         получение кол. лекции практики и контрольных работ */


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


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /*                       Встака дня недели                         */

            adding_the_day_of_week(dataGridView1);
            adding_the_day_of_week(dataGridView2);
            adding_the_day_of_week(dataGridView3);
            adding_the_day_of_week(dataGridView4);
            adding_the_day_of_week(dataGridView5);
            adding_the_day_of_week(dataGridView6);
            adding_the_day_of_week(dataGridView7);
            adding_the_day_of_week(dataGridView8);
            adding_the_day_of_week(dataGridView9);
            adding_the_day_of_week(dataGridView10);
            adding_the_day_of_week(dataGridView11);


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /*                        Вставка даты                            */

            adding_dates(dataGridView1);
            adding_dates(dataGridView2);
            adding_dates(dataGridView3);
            adding_dates(dataGridView4);
            adding_dates(dataGridView5);
            adding_dates(dataGridView6);
            adding_dates(dataGridView7);
            adding_dates(dataGridView8);
            adding_dates(dataGridView9);
            adding_dates(dataGridView10);
            adding_dates(dataGridView11);


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





            ///////////////////////////////////////////////////////////////////////////////////////////////////////


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


            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            /*                                      Вставка стажировки                                         */

            if (tabControl1.TabPages[0].Text != "") adding_practices(dataGridView1);
            if (tabControl1.TabPages[1].Text != "") adding_practices(dataGridView2);
            if (tabControl1.TabPages[2].Text != "") adding_practices(dataGridView3);
            if (tabControl1.TabPages[3].Text != "") adding_practices(dataGridView4);
            if (tabControl1.TabPages[4].Text != "") adding_practices(dataGridView5);
            if (tabControl1.TabPages[5].Text != "") adding_practices(dataGridView6);
            if (tabControl1.TabPages[6].Text != "") adding_practices(dataGridView7);
            if (tabControl1.TabPages[7].Text != "") adding_practices(dataGridView8);
            if (tabControl1.TabPages[8].Text != "") adding_practices(dataGridView9);
            if (tabControl1.TabPages[9].Text != "") adding_practices(dataGridView10);
            if (tabControl1.TabPages[10].Text != "") adding_practices(dataGridView11);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*                                            Вставка отпуска                                  */

            if (tabControl1.TabPages[0].Text != "") adding_vacation(dataGridView1);
            if (tabControl1.TabPages[1].Text != "") adding_vacation(dataGridView2);
            if (tabControl1.TabPages[2].Text != "") adding_vacation(dataGridView3);
            if (tabControl1.TabPages[3].Text != "") adding_vacation(dataGridView4);
            if (tabControl1.TabPages[4].Text != "") adding_vacation(dataGridView5);
            if (tabControl1.TabPages[5].Text != "") adding_vacation(dataGridView6);
            if (tabControl1.TabPages[6].Text != "") adding_vacation(dataGridView7);
            if (tabControl1.TabPages[7].Text != "") adding_vacation(dataGridView8);
            if (tabControl1.TabPages[8].Text != "") adding_vacation(dataGridView9);
            if (tabControl1.TabPages[9].Text != "") adding_vacation(dataGridView10);
            if (tabControl1.TabPages[10].Text != "") adding_vacation(dataGridView11);

            /*-------------------------------  Определение праздничные дни ------------------------------------- */


            if (tabControl1.TabPages[0].Text != "") adding_holidays(dataGridView1);
            if (tabControl1.TabPages[1].Text != "") adding_holidays(dataGridView2);
            if (tabControl1.TabPages[2].Text != "") adding_holidays(dataGridView3);
            if (tabControl1.TabPages[3].Text != "") adding_holidays(dataGridView4);
            if (tabControl1.TabPages[4].Text != "") adding_holidays(dataGridView5);
            if (tabControl1.TabPages[5].Text != "") adding_holidays(dataGridView6);
            if (tabControl1.TabPages[6].Text != "") adding_holidays(dataGridView7);
            if (tabControl1.TabPages[7].Text != "") adding_holidays(dataGridView8);
            if (tabControl1.TabPages[8].Text != "") adding_holidays(dataGridView9);
            if (tabControl1.TabPages[9].Text != "") adding_holidays(dataGridView10);
            if (tabControl1.TabPages[10].Text != "") adding_holidays(dataGridView11);


            /*--------------------------------------------  Удаление последней строки ------------------------------------*/

            dataGridView1.Rows.RemoveAt(30);
            dataGridView2.Rows.RemoveAt(30);
            dataGridView3.Rows.RemoveAt(30);
            dataGridView4.Rows.RemoveAt(30);
            dataGridView5.Rows.RemoveAt(30);
            dataGridView6.Rows.RemoveAt(30);
            dataGridView7.Rows.RemoveAt(30);
            dataGridView8.Rows.RemoveAt(30);
            dataGridView9.Rows.RemoveAt(30);
            dataGridView10.Rows.RemoveAt(30);
            dataGridView11.Rows.RemoveAt(30);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            /* -----------------------------------    Распределение занятий --------------------------------------------*/
            int subject = 0;
            int summa = 0;



            for (int r = 0; r < all_subjects.Count; r++)
            {
                int column = 3;
                int row_1 = 24;
                Random random = new Random();


                for (int i = 1; i <= subjects_lecture[summa] + subjects_practic[summa] + subjects_con_work[summa]; i++)
                {



                    if (column < dataGridView1.Columns.Count)
                    {
                        if (row_1 < dataGridView1.Rows.Count)
                        {
                            if (dataGridView1[column, row_1].Value == null)
                            {
                                if (tabControl1.TabPages[0].Text != "") dataGridView1[column, row_1].Value = all_subjects[subject].ToString() + "\n";

                                /*-Вставка дисциплин-*/
                                for (int m = 0; m < DataBank.stream_subjetcs.Count; m++)
                                {
                                    if (all_subjects[subject] == DataBank.stream_subjetcs[m])
                                    {
                                        if (tabControl1.TabPages[1].Text != "") dataGridView2[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";

                                        if (tabControl1.TabPages[2].Text != "") dataGridView3[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[3].Text != "") dataGridView4[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[4].Text != "") dataGridView5[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[5].Text != "") dataGridView6[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[6].Text != "") dataGridView7[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[7].Text != "") dataGridView8[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[8].Text != "") dataGridView9[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[9].Text != "") dataGridView10[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        if (tabControl1.TabPages[10].Text != "") dataGridView11[column, row_1].Value = DataBank.stream_subjetcs[m] + "\n";
                                        /*---------------------------------- Вставка цвета потоковых занятий -------------------------------------*/
                                        if (tabControl1.TabPages[0].Text != "") dataGridView1[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[1].Text != "") dataGridView2[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[2].Text != "") dataGridView3[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[3].Text != "") dataGridView4[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[4].Text != "") dataGridView5[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[5].Text != "") dataGridView6[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[6].Text != "") dataGridView7[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[7].Text != "") dataGridView8[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[8].Text != "") dataGridView9[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[9].Text != "") dataGridView10[column, row_1].Style.BackColor = Color.LightGreen;
                                        if (tabControl1.TabPages[10].Text != "") dataGridView11[column, row_1].Style.BackColor = Color.LightGreen;
                                    }



                                }



                                if (i < subjects_lecture[summa] || i == subjects_lecture[summa])
                                {
                                    if (tabControl1.TabPages[0].Text != "") dataGridView1[column, row_1].Value += "лек";

                                    /*-Вставка лек-*/
                                    for (int m = 0; m < DataBank.stream_subjetcs.Count; m++)
                                    {

                                        if (all_subjects[subject] == DataBank.stream_subjetcs[m])
                                        {
                                            if (tabControl1.TabPages[1].Text != "") dataGridView2[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[2].Text != "") dataGridView3[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[3].Text != "") dataGridView4[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[4].Text != "") dataGridView5[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[5].Text != "") dataGridView6[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[6].Text != "") dataGridView7[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[7].Text != "") dataGridView8[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[8].Text != "") dataGridView9[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[9].Text != "") dataGridView10[column, row_1].Value += "лек";
                                            if (tabControl1.TabPages[10].Text != "") dataGridView11[column, row_1].Value += "лек";


                                        }



                                    }



                                }



                                if (i > subjects_lecture[summa] && i < subjects_lecture[summa] + subjects_practic[summa] || i == subjects_lecture[summa] + subjects_practic[summa])
                                {
                                    if (tabControl1.TabPages[0].Text != "") dataGridView1[column, row_1].Value += "пр";

                                    /*- Вставка пр -*/
                                    for (int m = 0; m < DataBank.stream_subjetcs.Count; m++)
                                    {

                                        if (all_subjects[subject] == DataBank.stream_subjetcs[m])
                                        {
                                            if (tabControl1.TabPages[1].Text != "") dataGridView2[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[2].Text != "") dataGridView3[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[3].Text != "") dataGridView4[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[4].Text != "") dataGridView5[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[5].Text != "") dataGridView6[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[6].Text != "") dataGridView7[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[7].Text != "") dataGridView8[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[8].Text != "") dataGridView9[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[9].Text != "") dataGridView10[column, row_1].Value += "пр";
                                            if (tabControl1.TabPages[10].Text != "") dataGridView11[column, row_1].Value += "пр";
                                        }


                                    }



                                }
                                if (i > subjects_lecture[summa] + subjects_practic[summa] && i < subjects_lecture[summa] + subjects_practic[summa] + subjects_con_work[summa] || i == subjects_lecture[summa] + subjects_practic[summa] + subjects_con_work[summa])
                                {
                                    if (tabControl1.TabPages[0].Text != "") dataGridView1[column, row_1].Value += "зк";

                                    /*- Вставка зк -*/
                                    for (int m = 0; m < DataBank.stream_subjetcs.Count; m++)
                                    {

                                        if (all_subjects[subject] == DataBank.stream_subjetcs[m])
                                        {
                                            if (tabControl1.TabPages[1].Text != "") dataGridView2[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[2].Text != "") dataGridView3[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[3].Text != "") dataGridView4[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[4].Text != "") dataGridView5[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[5].Text != "") dataGridView6[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[6].Text != "") dataGridView7[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[7].Text != "") dataGridView8[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[8].Text != "") dataGridView9[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[9].Text != "") dataGridView10[column, row_1].Value += "зк";
                                            if (tabControl1.TabPages[10].Text != "") dataGridView11[column, row_1].Value += "зк";
                                        }

                                    }



                                }

                            }
                            else
                            {
                                --i;
                            }

                        }

                    }

                    ++column;
                    row_1 = random.Next(4, dataGridView1.Rows.Count);

                }
                ++summa;
                ++subject;
            }

            

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            /* ------------------------------------ Распределение расписаний для других учебных групп ------------*/
            if (tabControl1.TabPages[1].Text != "") adding_lessons_for_other_groups(dataGridView2, all_subjects);
            if (tabControl1.TabPages[2].Text != "") adding_lessons_for_other_groups(dataGridView3, all_subjects);
            if (tabControl1.TabPages[3].Text != "") adding_lessons_for_other_groups(dataGridView4, all_subjects);
            if (tabControl1.TabPages[4].Text != "") adding_lessons_for_other_groups(dataGridView5, all_subjects);
            if (tabControl1.TabPages[5].Text != "") adding_lessons_for_other_groups(dataGridView6, all_subjects);
            if (tabControl1.TabPages[6].Text != "") adding_lessons_for_other_groups(dataGridView7, all_subjects);
            if (tabControl1.TabPages[7].Text != "") adding_lessons_for_other_groups(dataGridView8, all_subjects);
            if (tabControl1.TabPages[8].Text != "") adding_lessons_for_other_groups(dataGridView9, all_subjects);
            if (tabControl1.TabPages[9].Text != "") adding_lessons_for_other_groups(dataGridView10, all_subjects);
            if (tabControl1.TabPages[10].Text != "") adding_lessons_for_other_groups(dataGridView11, all_subjects);

           

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
                dataGridView[i, 33].Style.BackColor = Color.Red;


            }
        }

        public void adding_the_day_of_week(DataGridView dataGridView)
        {
            int a = 1;
            int j = 0;
            int g = 0;
            for (int i = 0; i < 33; i++)
            {

                DataGridViewCell monday_ = new DataGridViewTextBoxCell();
                DataGridViewCell pair = new DataGridViewTextBoxCell();
                DataGridViewCell first_lesson_time = new DataGridViewTextBoxCell();
                first_lesson_time.Style.WrapMode = DataGridViewTriState.True;
                string[] pairs = { "1-2", "3-4", "5-6", "7-8" };


                DataGridViewRow row = new DataGridViewRow();


                row.Height = 45;

                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 8 || i == 13 || i == 18 || i == 23 || i == 28 || i == 32)
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


                dataGridView.Rows.Add(row);



            }
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

                        m = m + 4;
                        ++d;
                    }

                }
                m = 3;


            }
        }

        public void adding_practices(DataGridView dataGridView)
        {
            int vac_start_column_p = 0;
            int vac_start_row_p = 0;

            int vac_end_column_p = 0;
            int vac_end_row_p = 0;

            /*----------------------------------- Определение началы даты стажировки ------------------------------------------------------------*/
            for (int i = 4; i < dataGridView.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView[i, loc].Value != null)
                {
                    if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.practic_mounth[0].ToLower())
                    {
                        ++loc;


                        for (; loc < dataGridView.Rows.Count; loc++)
                        {
                            if (dataGridView[i, loc].Value != null)
                            {
                                if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.practic_dates[0].ToLower())
                                {
                                    vac_start_column_p = i;
                                    vac_start_row_p = loc;


                                }
                            }


                        }

                    }
                }


            }

            /*----------------------------------- Определение конец даты стажировки ------------------------------------------------------------*/

            for (int i = 4; i < dataGridView.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView[i, loc].Value != null)
                {
                    if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.practic_mounth[1].ToLower())
                    {
                        ++loc;


                        for (; loc < dataGridView.Rows.Count; loc++)
                        {
                            if (dataGridView[i, loc].Value != null)
                            {
                                if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.practic_dates[1].ToLower())
                                {
                                    vac_end_column_p = i;
                                    vac_end_row_p = loc;


                                }
                            }


                        }

                    }
                }


            }

            /* --------------------------------- Вставка стажировки ------------------------------------------------- */
            for (; vac_start_column_p <= vac_end_column_p; vac_start_column_p++)
            {
                if (vac_start_column_p < vac_end_column_p)
                {
                    for (; vac_start_row_p <= dataGridView.Rows.Count - 1; vac_start_row_p++)
                    {
                        if (dataGridView[vac_start_column_p, vac_start_row_p].Value == null)
                        {
                            dataGridView[vac_start_column_p, vac_start_row_p].Value = "Стаж";
                            dataGridView[vac_start_column_p, vac_start_row_p].Style.BackColor = Color.DarkOrange;

                        }
                    }
                    vac_start_row_p = 4;
                }

                if (vac_start_column_p == vac_end_column_p)
                {
                    for (; vac_start_row_p <= vac_end_row_p + 4; vac_start_row_p++)
                    {
                        if (dataGridView[vac_start_column_p, vac_start_row_p].Value == null)
                        {
                            dataGridView[vac_start_column_p, vac_start_row_p].Value = "Стаж";
                            dataGridView[vac_start_column_p, vac_start_row_p].Style.BackColor = Color.DarkOrange;
                        }
                    }
                }

            }
        }

        public void adding_vacation(DataGridView dataGridView)
        {
            int vac_start_column = 0;
            int vac_start_row = 0;

            int vac_end_column = 0;
            int vac_end_row = 0;

            /*----------------------------------- Определение началы даты  ------------------------------------------------------------*/
            for (int i = 4; i < dataGridView.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView[i, loc].Value != null)
                {
                    if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.vac_mounth[0].ToLower())
                    {
                        ++loc;


                        for (; loc < dataGridView.Rows.Count; loc++)
                        {
                            if (dataGridView[i, loc].Value != null)
                            {
                                if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.vac_dates[0].ToLower())
                                {
                                    vac_start_column = i;
                                    vac_start_row = loc;


                                }
                            }


                        }

                    }
                }


            }


            /*----------------------------------- Определение конец даты  ------------------------------------------------------------*/

            for (int i = 4; i < dataGridView.Columns.Count; i++)
            {
                int loc = 2;

                if (dataGridView[i, loc].Value != null)
                {
                    if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.vac_mounth[1].ToLower())
                    {
                        ++loc;


                        for (; loc < dataGridView.Rows.Count; loc++)
                        {
                            if (dataGridView[i, loc].Value != null)
                            {
                                if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.vac_dates[1].ToLower())
                                {
                                    vac_end_column = i;
                                    vac_end_row = loc;


                                }
                            }


                        }

                    }
                }


            }


            /* --------------------------------- Вставка отпусков ------------------------------------------------- */
            for (; vac_start_column <= vac_end_column; vac_start_column++)
            {
                if (vac_start_column < vac_end_column)
                {
                    for (; vac_start_row <= dataGridView.Rows.Count - 1; vac_start_row++)
                    {
                        if (dataGridView[vac_start_column, vac_start_row].Value == null)
                        {
                            dataGridView[vac_start_column, vac_start_row].Value = "Отп";
                            dataGridView[vac_start_column, vac_start_row].Style.BackColor = Color.DarkGray;

                        }
                    }
                    vac_start_row = 4;
                }

                if (vac_start_column == vac_end_column)
                {
                    for (; vac_start_row <= vac_end_row + 4; vac_start_row++)
                    {
                        if (dataGridView[vac_start_column, vac_start_row].Value == null)
                        {
                            dataGridView[vac_start_column, vac_start_row].Value = "Отп";
                            dataGridView[vac_start_column, vac_start_row].Style.BackColor = Color.DarkGray;
                        }
                    }
                }

            }
        }

        public void adding_holidays(DataGridView dataGridView)
        {
            int mounths = 0;
            int hol_days = 0;

            for (int local = 0; local < DataBank.hol_mounth.Count; local++)
            {
                for (int i = 4; i < dataGridView.Columns.Count; i++)
                {
                    int loc = 2;

                    if (dataGridView[i, loc].Value != null)
                    {
                        if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.hol_mounth[mounths].ToLower())
                        {
                            ++loc;


                            for (; loc < dataGridView.Rows.Count; loc++)
                            {
                                if (dataGridView[i, loc].Value != null)
                                {
                                    if (dataGridView[i, loc].Value.ToString().ToLower() == DataBank.hol_day[hol_days].ToLower())
                                    {

                                        if (dataGridView[i, loc + 1].Value == null)
                                        {
                                            dataGridView[i, loc + 1].Value = "Вых";
                                            dataGridView[i, loc + 1].Style.BackColor = Color.DarkGray;

                                        }
                                        if (dataGridView[i, loc + 2].Value == null)
                                        {
                                            dataGridView[i, loc + 2].Value = "Вых";
                                            dataGridView[i, loc + 2].Style.BackColor = Color.DarkGray;

                                        }
                                        if (dataGridView[i, loc + 3].Value == null)
                                        {
                                            dataGridView[i, loc + 3].Value = "Вых";
                                            dataGridView[i, loc + 3].Style.BackColor = Color.DarkGray;

                                        }
                                        if (dataGridView[i, loc + 4].Value == null)
                                        {
                                            dataGridView[i, loc + 4].Value = "Вых";
                                            dataGridView[i, loc + 4].Style.BackColor = Color.DarkGray;

                                        }

                                    }
                                }


                            }

                        }
                    }



                }

                mounths++;
                hol_days++;
            }

        }

        public void adding_the_size_of_text(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].DefaultCellStyle.Font = new Font("Times New Roman", 7);


            }
            dataGridView.Columns[2].DefaultCellStyle.Font = new Font("Times New Roman", 6);

        }

       
        public void adding_lessons_for_other_groups(DataGridView dataGridView1, List<string> all_subjects)
        {
            int col2 = 3;
            int row2 = 24;
            int summa_all = 0;
            for (int i = 0; i < all_subjects.Count; i++)
            {

                
                for (int m = 1; m <= subjects_lecture[summa_all] + subjects_practic[summa_all] + subjects_con_work[summa_all]; m++)
                {
                    if (DataBank.unstreamed_subjetcs[i] == all_subjects[i])
                    {
                        if (col2 < dataGridView1.Columns.Count && row2 < dataGridView1.Rows.Count)
                        {

                            if (dataGridView1[col2, row2].Value == null)
                                dataGridView1[col2, row2].Value = all_subjects[i] + "\n";

                        }

                        if (m < subjects_lecture[summa_all] || m == subjects_lecture[summa_all])
                        {
                            dataGridView1[col2, row2].Value += "лек";


                        }



                        if (m > subjects_lecture[summa_all] && m < subjects_lecture[summa_all] + subjects_practic[summa_all] || m == subjects_lecture[summa_all] + subjects_practic[summa_all])
                        {
                            dataGridView1[col2, row2].Value += "пр";


                        }
                        if (m > subjects_lecture[summa_all] + subjects_practic[summa_all] && m < subjects_lecture[summa_all] + subjects_practic[summa_all] + subjects_con_work[summa_all] || m == subjects_lecture[summa_all] + subjects_practic[summa_all] + subjects_con_work[summa_all])
                        {
                            dataGridView1[col2, row2].Value += "зк";
                        }
                            

                        do
                        {
                            Random random = new Random();
                            row2 = random.Next(4, dataGridView1.Rows.Count);
                            col2 = random.Next(3, dataGridView1.Columns.Count);
                        } while (dataGridView1[col2, row2].Value != null);

                    }




                }
                summa_all++;

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
