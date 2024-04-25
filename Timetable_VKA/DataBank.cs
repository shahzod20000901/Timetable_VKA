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
        
        public static List<string> routes= new List<string> { "Saved_timetables\\timetableVKA.txt",
            "Saved_timetables\\timetableVKA1.txt",
        "Saved_timetables\\timetableVKA2.txt",
            "Saved_timetables\\timetableVKA3.txt",
            "Saved_timetables\\timetableVKA4.txt",
            "Saved_timetables\\timetableVKA5.txt",
        "Saved_timetables\\timetableVKA6.txt",
            "Saved_timetables\\timetableVKA7.txt",
            "Saved_timetables\\timetableVKA8.txt",
            "Saved_timetables\\timetableVKA9.txt",
        "Saved_timetables\\timetableVKA10.txt",
            "Saved_timetables\\timetableVKA11.txt"};

        public static List<string> stream_subjects_for_reading= new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static List<string> stream_subjects_for_reading1 = new List<string>(1000);
    }
}
