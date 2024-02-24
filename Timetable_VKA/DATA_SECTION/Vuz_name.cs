using MySql.Data.MySqlClient;
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
    public partial class Vuz_name : Form
    {
        
        public Vuz_name()
        {
            InitializeComponent();
        }
        int i = 1;
        int g;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `vuzname`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                g = 0;
            else
                g = 1;
            db.closeConnection();


            
            MySqlCommand command = new MySqlCommand("INSERT INTO `vuzname` (`id`, `vuzName`) VALUES ("+i+", @log);", db.getConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = textBox1.Text;
            ++i;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Военный ВУЗ был создан");
            else
                MessageBox.Show("Военный ВУЗ не был создан");
            db.closeConnection();
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Vuz_name_Load(object sender, EventArgs e)
        {

        }
    }
}
