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
        
        public static List<string> hol_day=new List<string>{"","","","","","","","","" };
        public static List<string> hol_mounth=new List<string> {"","","","","","","","","" };
        

    }
}
