using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    //Data fields as definded in RFI_ABM_IR_EOT_GPA query
    class GPA
    {
        private string ssn_id;
        private string term;
        private string att_crhrs_term_ug;
        private string earn_crhrs_term_ug;
        private string gpa_term_ug;
        private string att_crhrs_cumu_ug;
        private string earn_crhrs_cumu_ug;
        private string gpa_cumu_ug;
        private string college_id;
        private string name;

        public string SSNID
        {
            get { return ssn_id; }
            set { ssn_id = value; }
        }

        public string Term
        {
            get { return term; }
            set { term = value; }
        }

        public string TermAttemptedHours
        {
            get { return att_crhrs_term_ug; }
            set { att_crhrs_term_ug = value; }
        }

        public string TermEarnedHours
        {
            get { return earn_crhrs_term_ug; }
            set { earn_crhrs_term_ug = value; }
        }

        public string TermGPA
        {
            get { return gpa_term_ug; }
            set { gpa_term_ug = value; }
        }

        public string CumuAttemptedHours
        {
            get { return att_crhrs_cumu_ug; }
            set { att_crhrs_cumu_ug = value; }
        }
        public string CumuEarnedHours
        {
            get { return earn_crhrs_cumu_ug; }
            set { earn_crhrs_cumu_ug = value; }
        }

        public string CumulativeGPA
        {
            get { return gpa_cumu_ug; }
            set { gpa_cumu_ug = value; }
        }
        public string CollegeID
        {
            get { return college_id; }
            set { college_id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
