using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_VKA
{
    static class DataBank
    {
        public static string edit_day = "edit";
        public static int check;
        public static string subject_name;
        public static string edit_subject_name="";
        public static string subject_reduction = "";
        public static string teachers = "";
        public static int summ_of_subjects = 100;
        public static string[] all_subjects = {"","","","","","","","","","","","","","","",""};
        public static string[] all_subjects_reduction= { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };


        public static int i = 0;
        public static int selected_subject_index=0;

        public static string defined_teacher = "";
        public static string defined_subject = "";


        public static string edit_teacher = "";
        public static string edit_defined_subject = "";

        public static string selected_subject = "";


        public static string edit_group = "";
        public static string edit_department = "";
        public static string edit_faculty = "";

        public static string[] vac_dates = { "", "" };
        public static string[] vac_mounth = { "", "" };

        public static string[] practic_dates = { "", "" };
        public static string[] practic_mounth = { "", "" };


        
        public static List<string> hol_day=new List<string>{"","","","","","","","","" };
        public static List<string> hol_mounth=new List<string> {"","","","","","","","","" };

        public static List<string> stream_subjetcs = new List<string> { "", "", "", "","","", "", "", "","","","","","", "", "", "", "", "", "", "", "", "" };
        public static List<string> unstreamed_subjetcs = new List<string> { "", "", "", "","","", "", "", "","","","","","", "", "", "", "", "", "", "", "", "" };
        public static List<DataGridView> all_tables=new List<DataGridView> ();

        public static List<string> selected_cells = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        public static List<string> for_teachers_new = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static List<string> for_teachers = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static List<DataGridView> saved_tables = new List<DataGridView>();

        public static DataGridView dataGridView=new DataGridView();
        
        public static List<string> routes= new List<string> { "C:\\time_tables\\timetableVKA.txt", "C:\\time_tables\\timetableVKA1.txt",
        "C:\\time_tables\\timetableVKA2.txt","C:\\time_tables\\timetableVKA3.txt","C:\\time_tables\\timetableVKA4.txt","C:\\time_tables\\timetableVKA5.txt",
        "C:\\time_tables\\timetableVKA6.txt","C:\\time_tables\\timetableVKA7.txt","C:\\time_tables\\timetableVKA8.txt","C:\\time_tables\\timetableVKA9.txt",
        "C:\\time_tables\\timetableVKA10.txt", "C:\\time_tables\\timetableVKA11.txt"};

        public static List<string> stream_subjects_for_reading= new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static List<string> stream_subjects_for_reading1 = new List<string>(1000);
    }
}
