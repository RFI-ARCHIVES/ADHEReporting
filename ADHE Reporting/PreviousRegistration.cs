using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class PreviousRegistration
    {
        private string recordType;
        private string dataType;
        private string registrationTerm;
        private string collegeID;
        private string ssnID;
        private string courseSection;
        private string courseNumber;
        private string courseSequenceNumber;
        private string freeTuition;

        public string RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }

        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        public string RegistrationTerm
        {
            get { return registrationTerm; }
            set { registrationTerm = value; }
        }

        public string CollegeID
        {
            get { return collegeID; }
            set { collegeID = value; }
        }

        public string SSNID
        {
            get { return ssnID; }
            set { ssnID = value; }
        }

        public string CourseSection
        {
            get { return courseSection; }
            set { courseSection = value; }
        }

        public string CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value; }
        }

        public string CourseSequenceNumber
        {
            get { return courseSequenceNumber; }
            set { courseSequenceNumber = value; }
        }

        public string FreeTuition
        {
            get { return freeTuition; }
            set { freeTuition = value; }
        }

    }
}
