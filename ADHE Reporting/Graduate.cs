using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class Graduate
    {
        private string college_id;
        private string ssn_id;
        private string reverse_transfer;
        private string init_enroll_status;
        private string init_attend_status;
        private string init_admit_date;
        private string gender;
        private string non_resident_alien;
        private string completed_hours;
        private string graduation_date;
        private string degree_level;
        private string cip_2010_code;
        private string cip_2010_detail;
        private string degree_1;
        private string degree_2;
        private string degree_3;
        private string ee_cip_code;
        private string ee_cip_detail;
        private string asian;
        private string black;
        private string hispanic;
        private string amerind;
        private string white;
        private string hawaiian;
        private string age;

        public string CollegeID
        {
            get { return college_id; }
            set { college_id = value; }
        }
        public string SSNID
        {
            get { return ssn_id; }
            set { ssn_id = value; }
        }
        public string ReverseTransfer
        {
            get { return reverse_transfer; }
            set { reverse_transfer = value; }
        }
        public string InitialEnrollmentStatus
        {
            get { return init_enroll_status; }
            set { init_enroll_status = value; }
        }
        public string InitialAttendanceStatus
        {
            get { return init_attend_status; }
            set { init_attend_status = value; }
        }
        public string InitialAdmissionDate
        {
            get { return init_admit_date; }
            set { init_admit_date = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string NonResidentAlien
        {
            get { return non_resident_alien; }
            set { non_resident_alien = value; }
        }
        public string CompletedHours
        {
            get { return completed_hours; }
            set { completed_hours = value; }
        }
        public string GraduationDate
        {
            get { return graduation_date; }
            set { graduation_date = value; }
        }
        public string DegreeLevel
        {
            get { return degree_level; }
            set { degree_level = value; }
        }
        public string CIPCode
        {
            get { return cip_2010_code; }
            set { cip_2010_code = value; }
        }
        public string CIPDetail
        {
            get { return cip_2010_detail; }
            set { cip_2010_detail = value; }
        }
        public string Degree1
        {
            get { return degree_1; }
            set { degree_1 = value; }
        }
        public string Degree2
        {
            get { return degree_2; }
            set { degree_2 = value; }
        }
        public string Degree3
        {
            get { return degree_3; }
            set { degree_3 = value; }
        }
        public string EECIPCode
        {
            get { return ee_cip_code; }
            set { ee_cip_code = value; }
        }
        public string EECIPDetail
        {
            get { return ee_cip_detail; }
            set { ee_cip_detail = value; }
        }
        public string Asian
        {
            get { return asian; }
            set { asian = value; }
        }
        public string Black
        {
            get { return black; }
            set { black = value; }
        }
        public string Hispanic
        {
            get { return hispanic; }
            set { hispanic = value; }
        }
        public string AmericanIndian
        {
            get { return amerind; }
            set { amerind = value; }
        }
        public string White
        {
            get { return white; }
            set { white = value; }
        }
        public string Hawaiian
        {
            get { return hawaiian; }
            set { hawaiian = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }


    }
}
