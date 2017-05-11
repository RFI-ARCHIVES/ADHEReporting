using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    //Uuse for registration records built from a query for completing a NEW Term file
    class NewRegistration
    {
        //all private data names should match ADHE db Names
        private string term;
        private string college_ID;
        private string ssn_id;
        private string course_section_4;
        private string course_number;
        private string sequence;
        private string free_tuition;
        private string grade;
        private string post_test_type_math;
        private string post_test_math;
        private string post_test_type_english;
        private string post_test_english;
        private string post_test_type_reading;
        private string post_test_reading;
        private string state_aid;
        private string att_crhrs_term_ug;
        private string earn_crhrs_term_ug;
        private string gpa_term_ug;
        private string att_crhrs_cumu_ug;
        private string earn_crhrs_cumu_ug;
        private string gpa_cumu_ug;
        private string att_crhrs_term_gr;
        private string earn_crhrs_term_gr;
        private string gpa_term_gr;
        private string att_crhrs_cumu_gr;
        private string earn_crhrs_cumu_gr;
        private string gpa_cumu_gr;


        public string Term
        {
            get { return term; }
            set { term = value; }
        }

        public string CollegeID
        {
            get { return college_ID; }
            set { college_ID = value; }
        }
        public string SSNID
        {
            get { return ssn_id; }
            set { ssn_id = value; }
        }
        public string CourseSection
        {
            get { return course_section_4; }
            set { course_section_4 = value; }
        }
        public string CourseNumber
        {
            get { return course_number; }
            set { course_number = value; }
        }
        public string CourseSequenceNumber
        {
            get { return sequence; }
            set { sequence = value; }
        }
        public string FreeTuition
        {
            get { return free_tuition; }
            set { free_tuition = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public string PostMathTestType
        {
            get { return post_test_type_math; }
            set { post_test_type_math = value; }
        }
        public string PostMathScore
        {
            get { return post_test_math; }
            set { post_test_math = value; }
        }
        public string PostEnglishTestType
        {
            get { return post_test_type_english; }
            set { post_test_type_english = value; }
        }
        public string PostEnglishScore
        {
            get { return post_test_english; }
            set { post_test_english = value; }
        }
        public string PostReadingTestType
        {
            get { return post_test_type_reading; }
            set { post_test_type_reading = value; }
        }
        public string PostReadingScore
        {
            get { return post_test_reading; }
            set { post_test_reading = value; }
        }
        public string StateAid
        {
            get { return state_aid; }
            set { state_aid = value; }
        }
        public string UndergraduateTermAttemptedCreditHours
        {
            get { return att_crhrs_term_ug; }
            set { att_crhrs_term_ug = value; }
        }
        public string UndergraduateTermEarnedCreditHours
        {
            get { return earn_crhrs_term_ug; }
            set { earn_crhrs_term_ug = value; }
        }
        public string UndergraduateTermGPA
        {
            get { return gpa_term_ug; }
            set { gpa_term_ug = value; }
        }
        public string UndergraduateCumulativeAttemptedCreditHours
        {
            get { return att_crhrs_cumu_ug; }
            set { att_crhrs_cumu_ug = value; }
        }
        public string UndergraduateCumulativeEarnedCreditHours
        {
            get { return earn_crhrs_cumu_ug; }
            set { earn_crhrs_cumu_ug = value; }
        }
        public string UndergraduateCumulativeGPA
        {
            get { return gpa_cumu_ug; }
            set { gpa_cumu_ug = value; }
        }
        public string GraduateTermAttemptedCreditHours
        {
            get { return att_crhrs_term_gr; }
            set { att_crhrs_term_gr = value; }
        }
        public string GraduateTermEarnedCreditHours
        {
            get { return earn_crhrs_term_gr; }
            set { earn_crhrs_term_gr = value; }
        }
        public string GraduateTermGPA
        {
            get { return gpa_term_gr; }
            set { gpa_term_gr = value; }
        }
        public string GraduateCumulativeAttemptedCreditHours
        {
            get { return att_crhrs_cumu_gr; }
            set { att_crhrs_cumu_gr = value; }
        }
        public string GraduateCumulativeEarnedCreditHours
        {
            get { return earn_crhrs_cumu_gr; }
            set { earn_crhrs_cumu_gr = value; }
        }
        public string GraduateCumulativeGPA
        {
            get { return gpa_cumu_gr; }
            set { gpa_cumu_gr = value; }
        }

    }
}
