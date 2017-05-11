using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHE_Reporting
{
    class AnnualInstructor
    {
        //all private data names should match ADHE db Names
        private string college_id;
        private string ssn_id;
        private string title_code;
        private string soc_code;
        private string soc_detail;
        private string name;
        private string full_part_time;
        private string total_compensation;
        private string source_of_comp;
        private string sal_instruction;
        private string sal_dept_serv;
        private string sal_instu_admin;
        private string sal_res_scholar;
        private string sal_public_serv;
        private string sal_other;
        private string fringe_benefits;
        private string primary_role;

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
        public string PositionTitleCode
        {
            get { return title_code; }
            set { title_code = value; }
        }
        public string SOCCode
        {
            get { return soc_code; }
            set { soc_code = value; }
        }
        public string SOCDetail
        {
            get { return soc_detail; }
            set { soc_detail = value; }
        }
        public string InstructorName
        {
            get { return name; }
            set { name = value; }
        }
        public string ContractTerm
        {
            get { return full_part_time; }
            set { full_part_time = value; }
        }
        public string TotalAnnualSalary
        {
            get { return total_compensation; }
            set { total_compensation = value; }
        }
        public string SourceOfSalary
        {
            get { return source_of_comp; }
            set { source_of_comp = value; }
        }
        public string InstructionPercentOfSalary
        {
            get { return sal_instruction; }
            set { sal_instruction = value; }
        }
        public string DepartmentPercentOfSalary
        {
            get { return sal_dept_serv; }
            set { sal_dept_serv = value; }
        }
        public string InstitutionalAdministrationPercentOfSalary
        {
            get { return sal_instu_admin; }
            set { sal_instu_admin = value; }
        }
        public string ResearchScholarshipPercentOfSalary
        {
            get { return sal_res_scholar; }
            set { sal_res_scholar = value; }
        }
        public string PublicServicePercentOfSalary
        {
            get { return sal_public_serv; }
            set { sal_public_serv = value; }
        }
        public string OtherPercentOfSalary
        {
            get { return sal_other; }
            set { sal_other = value; }
        }
        public string FringeBenefits
        {
            get { return fringe_benefits; }
            set { fringe_benefits = value; }
        }
        public string InstructorPrimaryRole
        {
            get { return primary_role; }
            set { primary_role = value; }
        }

    }
}
