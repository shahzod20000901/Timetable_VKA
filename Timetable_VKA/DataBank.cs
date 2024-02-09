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
        public static string[] all_subjects=new string[summ_of_subjects];
        public static int i = 0;
        public static int selected_subject_index=0;

        public static string defined_teacher = "ффффффффффффф";
        public static string defined_subject = "ыыыыыыыыыыыыы";
        
    }
}
