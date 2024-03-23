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
    public partial class vacation_holiday : Form
    {
        public vacation_holiday()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vacation_holiday_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            textBox1.Text = "27";
            textBox2.Text = "декабря";
            textBox3.Text = "10";
            textBox4.Text = "январья";


           

            for(int i=0; i<12;i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);

            }

            dataGridView1[0, 0].Value = "4";
            dataGridView1[1, 0].Value = "ноября";
            dataGridView1[0, 1].Value = "23";
            dataGridView1[1, 1].Value = "февраля";


        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            

            DataBank.vac_dates[0]=textBox1.Text;
            DataBank.vac_dates[1]=textBox3.Text;

            DataBank.vac_mounth[0] = textBox2.Text.Substring(0, textBox2.Text.Length - 3);
            DataBank.vac_mounth[1] = textBox4.Text.Substring(0, textBox4.Text.Length - 3);



            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1[i, j].Value == null) dataGridView1.Rows.RemoveAt(i);

                }

            }
            /*
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               
                dataGridView1[1, i].Value = dataGridView1[1, i].Value.ToString().Substring(0, dataGridView1[1, i].Value.ToString().Length - 3);


            }
            
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    DataBank.dataGridView[i, j].Value = dataGridView1[i,j].ToString();
                }

            }
*/
            this.Close();

        }
    }
}
