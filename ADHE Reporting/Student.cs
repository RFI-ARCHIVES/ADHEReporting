using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class Student
    {
        //all private data names should match ADHE db Names
        private string college_id;
        private string ssn_id;
        private string student_name;
        private string resident_state;
        private string geo_county;
        private string geo_state;
        private string res_tuition_status;
        private string tuition_waiver;
        private string gender;
        private string non_resident_alien;
        private string date_of_birth;
        private string enroll_status;
        private string transfer_fice;
        private string student_level;
        private string degree_intent;
        private string attend_status;
        private string total_cr_hours; //non-ADHE spelling, for consistency with other names
        private string high_school_gpa;
        private string ethnicity;
        private string hs_code;
        private string hs_grad_year;
        private string diploma_ged;
        private string ent_exam_type;
        private string ent_exam_score;
        private string test_type_math;
        private string test_math; //score
        private string math_placement_stat;
        private string test_type_english;
        private string test_english; //score
        private string english_placement_stat;
        private string test_type_reading;
        private string test_reading; //score
        private string reading_placement_stat;
        private string test_science;
        private string career_readiness;
        private string degree_1;
        private string degree_2;
        private string uteach;
        private string ged_test_score;

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
        public string StudentName
        {
            get { return student_name; }
            set { student_name = value; }
        }
        public string CurrentLegalResidence
        {
            get { return resident_state; }
            set { resident_state = value; }
        }
        public string CountyOfOrigin
        {
            get { return geo_county; }
            set { geo_county = value; }
        }
        public string StateOfOrigin
        {
            get { return geo_state; }
            set { geo_state = value; }
        }
        public string TuitionStatus
        {
            get { return res_tuition_status; }
            set { res_tuition_status = value; }
        }
        public string BorderCountyWaiver
        {
            get { return tuition_waiver; }
            set { tuition_waiver = value; }
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
        public string DateOfBirth
        {
            get { return date_of_birth; }
            set { date_of_birth = value; }
        }
        public string EnrollmentStatus  
        {
            get { return enroll_status; }
            set { enroll_status = value; }
        }
        public string TransferFICECode
        {
            get { return transfer_fice; }
            set { transfer_fice = value; }
        }
        public string StudentLevel
        {
            get { return student_level; }
            set { student_level = value; }
        }
        public string DegreeIntent
        {
            get { return degree_intent; }
            set { degree_intent = value; }
        }
        public string AttendStatus
        {
            get { return attend_status; }
            set { attend_status = value; }
        }
        public string TotalCreditHours
        {
            get { return total_cr_hours; }
            set { total_cr_hours = value; }
        }
        public string HighSchoolGPA
        {
            get { return high_school_gpa; }
            set { high_school_gpa = value; }
        }
        public string Ethnicity
        {
            get { return ethnicity; }
            set { ethnicity = value; }
        }
        public string HighSchoolCode
        {
            get { return hs_code; }
            set { hs_code = value;  }
        }
         public string HighSchoolGraduationYear
        {
            get { return hs_grad_year; }
            set { hs_grad_year = value; }
        }
        //*******************************
        //*******************************
        public string HighSchoolCompletionStatus
        {
            get { return diploma_ged; }
            set { diploma_ged = value; }
        }
        public string EntranceExamTestType
        {
            get { return ent_exam_type; }
            set { ent_exam_type = value; }
        }
        public string EntranceExamScore
        {
            get { return ent_exam_score; }
            set { ent_exam_score = value; }
        }
        public string MathTestType
        {
            get { return test_type_math; }
            set { test_type_math = value; }
        }
        public string MathScore
        {
            get { return test_math; }
            set { test_math = value; }
        }
        public string MathPlacementStatus
        {
            get { return math_placement_stat; }
            set { math_placement_stat = value; }
        }
        public string EnglishTestType
        {
            get { return test_type_english; }
            set { test_type_english = value; }
        }
        public string EnglishScore
        {
            get { return test_english; }
            set { test_english = value; }
        }
        public string EnglishPlacementStatus
        {
            get { return english_placement_stat; }
            set { english_placement_stat = value; }
        }
        public string ReadingTestType
        {
            get { return test_type_reading; }
            set { test_type_reading = value; }
        }
        public string ReadingScore
        {
            get { return test_reading; }
            set { test_reading = value; }
        }
        public string ReadingPlacementStatus
        {
            get { return reading_placement_stat; }
            set { reading_placement_stat = value; }
        }
        public string ACTScienceReasoningScore
        {
            get { return test_science; }
            set { test_science = value; }
        }
        public string CareerReadiness
        {
            get { return career_readiness; }
            set { career_readiness = value; }
        }
        public string FirstDegreeMajorCode
        {
            get { return degree_1; }
            set { degree_1 = value; }
        }
        public string SecondDegreeMajorCode
        {
            get { return degree_2; }
            set { degree_2 = value; }
        }
        public string UTeach
        {
            get { return uteach; }
            set { uteach = value; }
        }
        public string GEDTestScore
        {
            get { return ged_test_score; }
            set { ged_test_score = value; }
        }
 
    }
}
