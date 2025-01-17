﻿using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
    public partial class Subjects_form : Form
    {
        public Subjects_form()
        {
            InitializeComponent();
        }

        private void Subjects_form_Load(object sender, EventArgs e)
        {
            this.MaximizeBox= false;
            this.MinimizeBox= false;
            listView1.Scrollable = true;
            listView1.View = View.Details;

            //listView1.Columns.

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            new adding_subject_name_form(this).Show();
            
        }

        ListViewItem listViewItem; 
        
        
        public void Update_btn_Click(object sender, EventArgs e)
        {
            
            
           
           
            this.Refresh();
            
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            listView1.FocusedItem.Remove();
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            

            DB db = new DB();

            MySqlCommand command1;
            command1 = new MySqlCommand("TRUNCATE TABLE `subjects_table`", db.getConnection());
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
                MessageBox.Show("Список дисциплин не обновлено!");
            else

                MessageBox.Show("Список дисциплин обновлено!");
            db.closeConnection();

            MySqlCommand command;
            int j;


            for (int i=0; i< listView1.Items.Count;i++)
            {            
                command = new MySqlCommand("INSERT INTO `subjects_table` (`Subjects`, `Subjects_reduction`) VALUES(@log"+i+", @log1"+i+")", db.getConnection());
                command.Parameters.Add("@log" + i + "", MySqlDbType.VarChar).Value = listView1.Items[i].SubItems[0].Text;
                command.Parameters.Add("@log1"+i+"", MySqlDbType.VarChar).Value = listView1.Items[i].SubItems[1].Text;
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    j = 0;               
                else
                    j = 1;            
            db.closeConnection();
            }
            this.Close();



        }
    }
}
