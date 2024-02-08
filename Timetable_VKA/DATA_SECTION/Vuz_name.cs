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

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `vuzname` (`id`, `vuzName`) VALUES (NULL, @log);", db.getConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = textBox1.Text;
            

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Военный ВУЗ был создан");
            else
                MessageBox.Show("Военный ВУЗ не был создан");
            db.closeConnection();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
