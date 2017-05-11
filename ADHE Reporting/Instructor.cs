using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class Instructor
    {
        //all private data names should match ADHE db Names
        private string ssn_id;
        private string name;
        private string contract_term;
        private string contract_salary;
        private string include_pos_report;
        private string max_salary_auth;
        private string gender;
        private string non_resident_alien;
        private string highest_degree;
        private string terminal_degree;
        private string date_of_birth;
        private string acad_rank;
        private string tenure_status;
        private string cip_2010_code;
        private string proportion_emp;
        private string credit_hours;
        private string pct_instruction;
        private string title_code;
        private string ethnicity;
        private string asian;
        private string black;
        private string hispanic;
        private string amind;
        private string white;
        private string hawaiian;
        private string college_id;

        public string SSNID
        {
            get { return ssn_id; }
            set { ssn_id = value; }
        }
        public string InstructorName
        {
            get { return name; }
            set { name = value; }
        }
        public string ContractTerm
        {
            get { return contract_term; }
            set { contract_term = value; }
        }
        public string ContractSalary
        {
            get { return contract_salary; }
            set { contract_salary = value; }
        }
        public string AcademicPositionSource
        {
            get { return include_pos_report; }
            set { include_pos_report = value; }
        }
        public string MaximumSalary
        {
            get { return max_salary_auth; }
            set { max_salary_auth = value; }
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
        public string HishestDegreeAttained
        {
            get { return highest_degree; }
            set { highest_degree = value; }
        }
        public string TerminalDegree
        {
            get { return terminal_degree; }
            set { terminal_degree = value; }
        }
        public string DateOfBirth
        {
            get { return date_of_birth; }
            set { date_of_birth = value; }
        }
        public string AcademicRank
        {
            get { return acad_rank; }
            set { acad_rank = value; }
        }
        public string FacultyCategory
        {
            get { return tenure_status; }
            set { tenure_status = value; }
        }
        public string PrimaryCIPCode
        {
            get { return cip_2010_code; }
            set { cip_2010_code = value; }
        }
        public string PercentOfTimeEmployed
        {
            get { return proportion_emp; }
            set { proportion_emp = value; }
        }
        public string CourseCreditHours
        {
            get { return credit_hours; }
            set { credit_hours = value; }
        }
        public string InstructionalAssignment
        {
            get { return pct_instruction; }
            set { pct_instruction = value; }
        }
        public string PositionTitleCode
        {
            get { return title_code; }
            set { title_code = value; }
        }
        public string Ethnicity
        {
            get { return ethnicity; }
            set { ethnicity = value; }
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
        public string Amind
        {
            get { return amind; }
            set { amind = value; }
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
        public string CollegeID
        {
            get { return college_id; }
            set { college_id = value; }
        }

 


    }
}
