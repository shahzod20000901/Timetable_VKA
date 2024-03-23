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

        public void vacation_holiday_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            textBox1.Text = "27";
            textBox2.Text = "декабря";
            textBox3.Text = "10";
            textBox4.Text = "январья";


           

            for(int i=0; i<7;i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);

            }

            dataGridView1[0, 0].Value = "4";
            dataGridView1[1, 0].Value = "ноября";
            dataGridView1[0, 1].Value = "23";
            dataGridView1[1, 1].Value = "февраля";


        }

        public void ok_btn_Click(object sender, EventArgs e)
        {
            

            DataBank.vac_dates[0]=textBox1.Text;
            DataBank.vac_dates[1]=textBox3.Text;

            DataBank.vac_mounth[0] = textBox2.Text.Substring(0, textBox2.Text.Length - 3);
            DataBank.vac_mounth[1] = textBox4.Text.Substring(0, textBox4.Text.Length - 3);


            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (dataGridView1[0, j].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(j);

                }
            }
            MessageBox.Show(dataGridView1.Rows.Count.ToString());

                int flag = 0;
                for(int j=0; j<dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1[0, j].Value!=null)
                    {
                        DataBank.hol_day[flag] = dataGridView1[0, j].Value.ToString();
                        DataBank.hol_mounth[flag] = dataGridView1[1, j].Value.ToString();
                    flag++;

                    }
                }

           

            for (int j = 0; j < DataBank.hol_day.Count; j++)
            {
                if (DataBank.hol_day[j]=="")DataBank.hol_day.RemoveAt(j);
            }


           
           

            
            
            for (int j = 0; j < 2; j++)
            {
                DataBank.hol_mounth[j] = DataBank.hol_mounth[j].Substring(0, DataBank.hol_mounth[j].Length - 3);
            }

            MessageBox.Show(DataBank.hol_mounth[0]);
            DataBank.hol_mounth[0] = "Нояб";
            
           


           

            this.Close();

        }
    }
}
