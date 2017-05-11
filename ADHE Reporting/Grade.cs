using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    //Data fields defined in RFI_ABM_IR_GRADES query
    class Grade
    {
        private string ssn_id;
        private string sequence;
        private string grade;
        private string subjectArea;
        private string course_number;
        private string course_section_4;
        private string unitsTaken;
        private string locationCode;
        private string academicGroup;
        private string college_id;
        private string term;

        public string SSNID
        {
            get { return ssn_id; }
            set { ssn_id = value; }
        }

        public string Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }

        public string CourseGrade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string SubjectArea
        {
            get { return subjectArea; }
            set { subjectArea = value; }
        }

        public string Number
        {
            get { return course_number; }
            set { course_number = value; }
        }

        public string Section
        {
            get { return course_section_4; }
            set { course_section_4 = value; }
        }

        public string UnitsTaken
        {
            get { return unitsTaken; }
            set { unitsTaken = value; }
        }

        public string LocationCode
        {
            get { return locationCode; }
            set { locationCode = value; }
        }

        public string AcademicGroup
        {
            get { return academicGroup; }
            set { academicGroup = value; }
        }

        public string CollegeID
        {
            get { return college_id; }
            set { college_id = value; }
        }

        public string Term
        {
            get { return term; }
            set { term = value; }
        }


    }
}
