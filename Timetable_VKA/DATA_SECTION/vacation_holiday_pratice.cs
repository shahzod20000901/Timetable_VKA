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
    public partial class vacation_holiday_pratice : Form
    {
        public vacation_holiday_pratice()
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
            ///////////////////////////////////////////////// вставка значения отпуска //////////////////////////////////
            textBox1.Text = "27";
            textBox2.Text = "декабря";
            textBox3.Text = "10";
            textBox4.Text = "январья";

            //////////////////////////////////////////////////   вставка значения стажировки ////////////////////////////////

            textBox5.Text = "11";
            textBox6.Text = "декабря";
            textBox7.Text = "15";
            textBox8.Text = "декабря";
           
            //////////////////////////////////////////////////  вставка значения праздников //////////////////////////////////
            for(int i=0; i<10;i++)
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


            DataBank.practic_dates[0] = textBox5.Text;
            DataBank.practic_dates[1]=textBox7.Text;

            DataBank.practic_mounth[0]=textBox6.Text.Substring(0, textBox6.Text.Length - 3);
            DataBank.practic_mounth[1]=textBox8.Text.Substring(0, textBox8.Text.Length - 3);



            for(int i=0; i<dataGridView1.Columns.Count; i++)
            {
                for(int j=0; j<dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1[i, j].Value != null)
                    {
                        if (dataGridView1[i, j].Value.ToString().ToLower() == "января") dataGridView1[i, j].Value = "янва";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "февраля") dataGridView1[i, j].Value = "февр";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "марта") dataGridView1[i, j].Value = "март";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "апреля") dataGridView1[i, j].Value = "апре";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "мая") dataGridView1[i, j].Value = "май";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "июня") dataGridView1[i, j].Value = "июнь";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "июля") dataGridView1[i, j].Value = "июль";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "августа") dataGridView1[i, j].Value = "авгу";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "сентября") dataGridView1[i, j].Value = "сент";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "октября") dataGridView1[i, j].Value = "октя";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "ноября") dataGridView1[i, j].Value = "нояб";
                        else if (dataGridView1[i, j].Value.ToString().ToLower() == "декабря") dataGridView1[i, j].Value = "дека";
                    }
                    

                }
            }
            
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Value != null)
                {
                    DataBank.hol_day[i] = dataGridView1[0, i].Value.ToString();
                    DataBank.hol_mounth[i] = dataGridView1[1, i].Value.ToString();
                }
                
            }

           

            this.Close();

        }
    }
}
