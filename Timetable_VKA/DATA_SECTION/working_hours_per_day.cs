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
            listView1.Scrollable = true;
            listView1.View = View.Details;
            
           

        }
            public int i=0;
            string[] pairs = { "Первая пара", "Вторая пара", "Третья пара", "Четвертая пара" };
        private void Add_btn_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem;
            listViewItem = new ListViewItem(new string[] { pairs[i], pairs[i], pairs[i], pairs[i], pairs[i], pairs[i] });
            ++i;
            listView1.Items.Add(listViewItem);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            //listView1.FocusedItem.SubItems[listView1.FocusedItem.Index].Text = "";
        }

        private void Working_hours_per_day_Enter(object sender, EventArgs e)
        {
            listView1.FocusedItem.Selected = true;
        }
    }
}
