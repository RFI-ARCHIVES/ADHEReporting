using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class TestGrade
    {
        private string collegeID;
        private string testID;
        private string component;
        private string testDate;
        private string dataSource;
        private string score;

        public string CollegeID
        {
            get { return collegeID; }
            set { collegeID = value; }
        }
        public string TestID
        {
            get { return testID; }
            set { testID = value; }
        }
        public string Component
        {
            get { return component; }
            set { component = value; }
        }
        public string TestDate
        {
            get { return testDate; }
            set { testDate = value; }
        }
        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }
        public string Score
        {
            get { return score; }
            set { score = value; }
        }

    }
}
