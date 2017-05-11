using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class Course
    {
        //all private data names should match ADHE db Names

        private string sequence;
        private string tech_inst_funding;
        private string course_name;
        private string course_number;
        private string cip_2010_code;
        private string cip_2010_detail;
        private string course_type;
        private string delv_method;
        private string technology;
        private string credit_hours;
        private string course_level;
        private string remedial_level;
        private string acts_course;
        private string ssn_id;
        private string link_indicator;
        private string link_sequence;
        private string enrollment;
        private string academic_type;
        private string dept_code;
        private string recv_locn;
        private string in_district;
        private string location;
        private string county_code;
        private string acts_course_number;
        private string college_id;
        private string course_section_4;

        public string UniqueCourseSequenceNumber
        {
            get { return sequence; }
            set { sequence = value; }
        }
        public string TechnicalInstituteFunding
        {
            get { return tech_inst_funding; }
            set { tech_inst_funding = value; }
        }
        public string CourseName
        {
            get { return course_name; }
            set { course_name = value; }
        }
        public string CourseNumber
        {
            get { return course_number; }
            set { course_number = value; }
        }
        public string CourseProgramLevel
        {
            get { return cip_2010_code; }
            set { cip_2010_code = value; }
        }
        public string CourseDetailLevel
        {
            get { return cip_2010_detail; }
            set { cip_2010_detail = value; }
        }
        public string CourseType
        {
            get { return course_type; }
            set { course_type = value; }
        }
        public string CourseMethod
        {
            get { return delv_method; }
            set { delv_method = value; }
        }
        public string TechnologyType
        {
            get { return technology; }
            set { technology = value; }
        }
        public string CourseCreditHours
        {
            get { return credit_hours; }
            set { credit_hours = value; }
        }
        public string CourseLevel
        {
            get { return course_level; }
            set { course_level = value; }
        }
        public string RemedialCourseLevel
        {
            get { return remedial_level; }
            set { remedial_level = value; }
        }
        public string ACTCourse
        {
            get { return acts_course; }
            set { acts_course = value; }
        }
        public string SSNID
        {
            get { return ssn_id; }
            set { ssn_id = value; }
        }
        public string LinkedCourseIndicator
        {
            get { return link_indicator; }
            set { link_indicator = value; }
        }
        public string LinkedUniqueCourseSequenceNumber
        {
            get { return link_sequence; }
            set { link_sequence = value; }
        }
        public string Enrollment
        {
            get { return enrollment; }
            set { enrollment = value; }
        }
        public string AcademicType
        {
            get { return academic_type; }
            set { academic_type = value; }
        }
        public string DepartmentCode
        {
            get { return dept_code; }
            set { dept_code = value; }
        }
        public string ReceivingCourseLocation
        {
            get { return recv_locn; }
            set { recv_locn = value; }
        }
        public string InOutOfDistrict
        {
            get { return in_district; }
            set { in_district = value; }
        }
        public string NonTraditionalSite
        {
            get { return location; }
            set { location = value; }
        }
        public string CountyCode
        {
            get { return county_code; }
            set { county_code = value; }
        }
        public string ACTSCourseNumber
        {
            get { return acts_course_number; }
            set { acts_course_number= value; }
        }
        public string CollegeInstructorID
        {
            get { return college_id; }
            set { college_id = value; }
        }
        public string CourseSectionNumber
        {
            get { return course_section_4; }
            set { course_section_4 = value; }
        }




    }
}
