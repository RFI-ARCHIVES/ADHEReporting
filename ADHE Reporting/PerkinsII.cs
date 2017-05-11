using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class PerkinsII
    {
        //all private variables should match ADHE field names
        private string college_id;
        private string ssn_id;
        private string CTE_assesment_taken;
        private string CTE_assesment_passed;
        private string CTE_assesment_name;

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
        public string CTETaken
        {
            get { return CTE_assesment_taken; }
            set { CTE_assesment_taken = value; }
        }
        public string CTEPassed
        {
            get { return CTE_assesment_passed; }
            set { CTE_assesment_passed = value; }
        }
        public string CTEName
        {
            get { return CTE_assesment_name; }
            set { CTE_assesment_name = value; }
        }
    }
}
