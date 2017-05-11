using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class PerkinsI
    {
        //all private variables should match ADHE field names
        private string college_id;
        private string ssn_id;
        private string disabled;
        private string econ_disadv;
        private string sngl_parent;
        private string displ_homemaker;
        private string limited_english;
        private string degree_code;

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
        public string Disabled                   
        {
            get { return disabled; }
            set { disabled = value; }
        }
        public string EconomicDisadvantage
        {
            get { return econ_disadv; }
            set { econ_disadv = value; }
        }
        public string SingleParent
        {
            get { return sngl_parent; }
            set { sngl_parent = value; }
        }
        public string DisplacedHomemaker
        {
            get { return displ_homemaker; }
            set { displ_homemaker = value; }
        }
        public string LimitedEnglish
        {
            get { return limited_english; }
            set { limited_english = value; }
        }
        public string DegreeCode
        {
            get { return degree_code; }
            set { degree_code = value; }
        }

    }
}
