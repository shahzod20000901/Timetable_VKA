using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timetable_VKA.DATA_SECTION;

namespace Timetable_VKA
{
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }

        private void ИмпортИзВидовЗаныятийИзCSVФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СоздатьCTRLOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ВыходCTRLQToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        }

        private void НазваниеУчебногоЗаведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vuz_name newForm =new Vuz_name();
            newForm.Show();
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
        }

        private void vacation_holiday_Click(object sender, EventArgs e)
        {
            new vacation_holiday_pratice().Show();
        }
    }
}
