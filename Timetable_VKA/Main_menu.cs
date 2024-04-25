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
using Timetable_VKA.FILE_SECTION;
using Timetable_VKA.TIMETABLE_SECTION;
using System.IO;

namespace Timetable_VKA
{
    public partial class main_menu : Form
    {
        
        public main_menu()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory("..\\..");
            MessageBox.Show(this, Directory.GetCurrentDirectory(), "Init directory", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ИмпортИзВидовЗаныятийИзCSVФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СоздатьCTRLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new reading_timetable_new().Show();


        }

        private void ВыходCTRLQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_menu_Load(object sender, EventArgs e)
        {
            
        }

        private void УдалитьИзбыточноеОграничениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ПланированиеЗанятийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СостоваитьНовоеCTRLGToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choose_mode newForm = new choose_mode();
            newForm.Show();
        }

        private void Main_menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                choose_mode newForm = new choose_mode();
                newForm.Show();
            }

            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            {
                new reading_timetable_new().Show();
            }
            if (e.KeyCode == Keys.Q && e.Modifiers == Keys.Control)
            {
                Application.Exit();
            }
        }

        private void НазваниеУчебногоЗаведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Create_Click(object sender, EventArgs e)
        {
            choose_mode mode = new choose_mode();
            mode.Show();
               
        }

        private void ДниНеделиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Work_day_of_week form=new Work_day_of_week();
            form.Show();
        }

        private void ДисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subjects_form form =new Subjects_form();
            form.Show();
        }

        private void ПреподователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_teachers_form form=new add_teachers_form();
            form.Show();
        }

        private void MenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void РасписаниеЗвонковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            working_hours_per_day form=new working_hours_per_day();
            form.Show();
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Groups().Show();
        }

        private void аудиторииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Classrooms().Show();
        }

        private void занятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Lessons_menu().Show();
        }

        private void generate_timetable_btn_Click(object sender, EventArgs e)
        {
            new All_timetable().Show();
           
            MessageBox.Show("Генерация выполнено!!!");

        }

        private void vacation_holiday_Click(object sender, EventArgs e)
        {
            new vacation_holiday_pratice().Show();
        }

        private void data_subject_btn_Click(object sender, EventArgs e)
        {
            Subjects_form form = new Subjects_form();
            form.Show();
        }

        private void data_students_btn_Click(object sender, EventArgs e)
        {
            new Groups().Show();
        }

        private void data_teachers_btn_Click(object sender, EventArgs e)
        {
            add_teachers_form form = new add_teachers_form();
            form.Show();
        }

        private void data_class_btn_Click(object sender, EventArgs e)
        {
            new Classrooms().Show();
        }

        private void data_lessons_btn_Click(object sender, EventArgs e)
        {
            new Lessons_menu().Show();
        }

        private void ogr_timeout_btn_Click(object sender, EventArgs e)
        {
            working_hours_per_day form = new working_hours_per_day();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Work_day_of_week form = new Work_day_of_week();
            form.Show();
        }

        private void информацияОбУчебномЗаведенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vuz_name newForm = new Vuz_name();
            newForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Vuz_name newForm = new Vuz_name();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            working_hours_per_day form = new working_hours_per_day();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Groups().Show();
        }

        private void просмотрпоГруппамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new reading_timetable_new().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new vacation_holiday_pratice().Show();
        }

        private void потокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new adding_streaming_lesson().Show();
        }

        private void ogr_r_students_btn_Click(object sender, EventArgs e)
        {

        }

        private void утроВечерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new change_exthisting_timetable().Show();
        }

        private void официальныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для создания нового расписания введите все необходимые данные в разделе 'Данные'");
            this.Close();
        }

        private void сохранитьCTRLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            MessageBox.Show("Сохранено!");
            this.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            new adding_streaming_lesson().Show();
        }

        private void недавноОткрытыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new reading_timetable_new().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new reading_timetable_new().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new change_exthisting_timetable().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для создания нового расписания введите все необходимые данные в разделе 'Данные'");
            this.Close();
        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            new reading_timetable_new().Show();
        }

        private void просмотрпоПреподователямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new reading_timetable_for_teachers().Show();    
        }
    }
}
