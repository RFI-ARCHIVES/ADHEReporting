using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class StudentTestGrades
    {
        private string test_type_math;
        private string test_math;
        private string math_placement_stat;
        private string test_type_english;
        private string test_english;
        private string english_placement_stat;
        private string test_type_reading;
        private string test_reading;
        private string reading_placement_stat;
        private string test_science;

 
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

    }
}
