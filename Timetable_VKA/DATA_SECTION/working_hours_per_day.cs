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
    public partial class working_hours_per_day : Form
    {
        public working_hours_per_day()
        {
            InitializeComponent();
        }
        

        private void Working_hours_per_day_Load(object sender, EventArgs e)
        {
            this.MinimizeBox= false;
            this.MaximizeBox= false;
            
            
            dataGridView1.SelectionMode= DataGridViewSelectionMode.RowHeaderSelect;
           

        }
            public int i=0;
            string[] pairs = { "Первая пара", "Вторая пара", "Третья пара", "Четвертая пара" };
        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (i <= 3)
            {
                DataGridViewRow row0 = new DataGridViewRow();

                DataGridViewCell monday_ = new DataGridViewTextBoxCell();
                DataGridViewCell tuesday_ = new DataGridViewTextBoxCell();
                DataGridViewCell wednesday_ = new DataGridViewTextBoxCell();
                DataGridViewCell thursday_ = new DataGridViewTextBoxCell();
                DataGridViewCell friday_ = new DataGridViewTextBoxCell();
                DataGridViewCell saturday_ = new DataGridViewTextBoxCell();




                monday_.Value = pairs[i];
                tuesday_.Value = pairs[i];
                wednesday_.Value = pairs[i];
                thursday_.Value = pairs[i];
                friday_.Value = pairs[i];
                saturday_.Value = pairs[i];
                row0.Cells.AddRange(monday_, tuesday_, wednesday_, thursday_, friday_, saturday_);
                dataGridView1.Rows.AddRange(row0);
            }
            else
            {
                MessageBox.Show("Больше пар добавить невозможно!");
            }



            ++i;
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Working_hours_per_day_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
