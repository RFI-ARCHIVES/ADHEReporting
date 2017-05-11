using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ADHE_Reporting
{
    public partial class Form1 : Form
    {

        #region variable definitions
        List<PreviousRegistration> PrevRegRecords = new List<PreviousRegistration>();
        List<Grade> GradeRecords = new List<Grade>();
        List<GPA> GPARecords = new List<GPA>();
        List<Student> StudRecords = new List<Student>();
        List<TestGrade> TestGradeRecords = new List<TestGrade>();
        List<Instructor> InstRecords = new List<Instructor>();
        List<Course> CrseRecords = new List<Course>();
        List<NewRegistration> NewRegRecords = new List<NewRegistration>();
        List<AnnualInstructor> AnnInstRecords = new List<AnnualInstructor>();
        List<PerkinsI> PerkinsIRecords = new List<PerkinsI>();
        List<PerkinsII> PerkinsIIRecords = new List<PerkinsII>();
        List<Graduate> GraduateRecords = new List<Graduate>();
        struct TopGrades
            {
            public double ACTMath;
            public double ACTEnglish;
            public double ACTRead;
            public double CompassRead;
            public double CompassPALGP;
            public double CompassALGP;
            public double CompassALG;
            public double CompassPALG;
            public double CompassCALGP;
            public bool ACTGrades;
            public bool CompassGrades;
            }
 
        StreamReader srRegistration;
        StreamReader srGrades;
        StreamReader srGPAs;
        StreamWriter swEOT;
        StreamReader srStudents;
        StreamWriter swStudents;
        StreamReader srInstructors;
        StreamWriter swInstructors;
        StreamReader srCourses;
        StreamWriter swCourses;
        StreamWriter swRegistrations;
        StreamReader srAnnualInstructors;
        StreamWriter swAnnualInstructors;
        StreamReader srPerkinsI;
        StreamWriter swPerkinsI;
        StreamReader srPerkinsII;
        StreamWriter swPerkinsII;
        StreamWriter swErrorCodes;
        StreamReader srGraduates;
        StreamWriter swGraduates;
        StreamReader srTestGrades;

        Dictionary<string, string> HSLookup = new Dictionary<string, string>
        {
            //HS Codes Documented in Appendix D of ADHE manual
            {"Hot Springs High School", "041145" },
            {"Lake Hamilton High School", "041155" },
            {"Lakeside High School","041160" },
            {"Pine Bluff High School","042030" },
            {"Fountain Lake High School","041144" },
            {"Kirby High School","041315" },
            {"Oden High School","041880" },
            {"Malvern High School","041527" },
            {"Magnet Cove School","041520" },
            {"Mountain Pine High School","041745" },
            {"Centerpoint High School","040030" },
            {"Bismarck High School","040210" },
            {"Benton High School","040170" },
            {"Cutter-Morning Star High Sch","041143" },
            {"Jessieville High School","041235" }

        };

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        //Main Functions start here
        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;

            #region EOTREPORT
            if (rdbEOT.Checked)
            {
                StreamWriter swErrorCodes = new StreamWriter("c:\\adhe\\errorcodes.txt");
                int errCount = 0;
                //need original Registration file, data from EOT Grades query and data from EOT GPA query
                //create output file--EOT File (type 019)
                //read data from Reg file, find matching student/class records in Grades file--output grades
                //read data from Reg file, find matching student in GPA file append to student records in output file
                MessageBox.Show("Select the Beginning of Term Registration File");
                ofdRegistration.ShowDialog();
                MessageBox.Show("Select the End Of Term Grades File");
                ofdGrades.ShowDialog();
                MessageBox.Show("Select the End Of Term GPAs File");
                ofdGPAs.ShowDialog();

                srRegistration = new StreamReader(ofdRegistration.FileName);
                srGrades = new StreamReader(ofdGrades.FileName);
                srGPAs = new StreamReader(ofdGPAs.FileName);
                swEOT = new StreamWriter("c:\\adhe\\EOT_" + cmbxAcadYear.SelectedItem + ".dat");


                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srRegistration.ReadLine();
                discardRecord = srGrades.ReadLine();
                discardRecord = srGrades.ReadLine();
                discardRecord = srGPAs.ReadLine();
                discardRecord = srGPAs.ReadLine();

                string RegRecord = srRegistration.ReadLine();
                while (RegRecord != null)
                {
                    //creates a Registration object from the Registration record in the file
                    parsePreviousRegistration(RegRecord);  
                    RegRecord = srRegistration.ReadLine();
                }

                string GradeRecord = srGrades.ReadLine();
                while (GradeRecord != null)
                {
                    parseGrades(GradeRecord);
                    GradeRecord = srGrades.ReadLine();
                }

                string GPARecord = srGPAs.ReadLine();
                while(GPARecord != null)
                {
                    parseGPAs(GPARecord);
                    GPARecord = srGPAs.ReadLine();
                }

                srRegistration.Close();
                srGrades.Close();
                srGPAs.Close();


                //build and write EOT Header
                string eotHeader = "0190121052016" + "  ";
                swEOT.WriteLine(eotHeader);

                foreach (PreviousRegistration reg in PrevRegRecords)
                {
                    int gpaIndex = findGPARecord(reg.SSNID);

                    int gradeIndex = findGradeRecord(reg.SSNID);
                    if (gpaIndex > 10000 || gradeIndex > 10000)
                    {
                        errCount++;
                        string errRecordInfo = "Registration NID: " + reg.SSNID + "\r\n" +
                            "GPAIndex: " + gpaIndex + "\r\n" +
                            "GradeIndex: " + gradeIndex + "\r\n" +
                            "Class: " + reg.CourseNumber + "\r\n";
                        swErrorCodes.WriteLine(errRecordInfo);
                        //MessageBox.Show("GPA OR GRADE Record not found: " + reg.SSNID);
                    }
                    string EOTRecord = "029" + "3";
                    if (gradeIndex != 99999999)
                        EOTRecord += GradeRecords[gradeIndex].CollegeID;
                    else
                        EOTRecord += filler(10);

                    EOTRecord += reg.SSNID +
                    filler(5) +
                    reg.CourseSection +
                    reg.CourseNumber +
                    filler(3) +
                    reg.CourseSequenceNumber +
                    reg.FreeTuition;
                    if (gradeIndex != 99999999)
                        EOTRecord += GradeRecords[gradeIndex].CourseGrade;
                    else
                        EOTRecord += filler(2);

                    EOTRecord += filler(33);
                    if (gpaIndex != 99999999)
                    {
                        EOTRecord += GPARecords[gpaIndex].TermAttemptedHours +
                        GPARecords[gpaIndex].TermEarnedHours +
                        GPARecords[gpaIndex].TermGPA +
                        GPARecords[gpaIndex].CumuAttemptedHours +
                        GPARecords[gpaIndex].CumuEarnedHours +
                        GPARecords[gpaIndex].CumulativeGPA;
                    }
                    else
                    {
                        filler(10);

                    }

                    EOTRecord += filler(20);

                    swEOT.WriteLine(EOTRecord);


                }


                #region oldeot
                //foreach (Grade grade in GradeRecords)
                //{

                //    //find registration record that matches nationalid=ssnid and class = class
                //    int regIndex = findRegistrationRecord(grade.NationalID, grade.SubjectArea, grade.CatalogNumber);
                //    int gpaIndex = findGPARecord(grade.NationalID);
                //    if (regIndex != 99999999)
                //    {
                //        //string tmp1 = GPARecords[gpaIndex].FAUnitsTaken.Replace(".","").TrimEnd('0').PadRight(3,'0');
                //        //string tmp2 = GPARecords[gpaIndex].FAUnitsPassed.Replace(".","");
                //        string eotRecord = "0293" + 
                //            grade.EmplID.PadRight(10) + 
                //            RegRecords[regIndex].SSNID + 
                //            filler(5) + 
                //            RegRecords[regIndex].CourseSection + 
                //            RegRecords[regIndex].CourseNumber + 
                //            filler(3) + 
                //            RegRecords[regIndex].CourseSequenceNumber + 
                //            RegRecords[regIndex].FreeTuition +
                //            grade.CourseGrade.PadRight(2) + 
                //            filler(33) + 
                //            GPARecords[gpaIndex].FAUnitsTaken.Replace(".", "").TrimEnd('0').PadRight(3, '0') + 
                //            GPARecords[gpaIndex].FAUnitsPassed.Replace(".", "").TrimEnd('0').PadRight(3, '0') + 
                //            GPARecords[gpaIndex].CurrentGPA.Replace(".", "").TrimEnd('0').PadRight(4, '0') + 
                //            GPARecords[gpaIndex].TotalFAUnitsTaken.Replace(".", "").TrimEnd('0').PadRight(3, '0') + 
                //            GPARecords[gpaIndex].TotalFAUnitsPassed.Replace(".", "").TrimEnd('0').PadRight(3, '0') + 
                //            GPARecords[gpaIndex].CumulativeGPA.Replace(".", "").TrimEnd('0').PadRight(4, '0') + 
                //            filler(20);
                //        swEOT.WriteLine(eotRecord);
                //    }
                //    else
                //    {
                //        //swEOT.WriteLine(grade.ToString());
                //    }
                //}
                #endregion oldeot

                swEOT.WriteLine("999"); //ADHE trailer
                swEOT.Close();
                swErrorCodes.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Registration Records: " + PrevRegRecords.Count + "\r\n";
                tbxMessage.Text += "Grade Records: " + GradeRecords.Count + "\r\n";
                tbxMessage.Text += "GPA Records: " + GPARecords.Count + "\r\n";
                tbxMessage.Text += "Error Count: " + errCount + "\r\n";
                tbxMessage.Text += "EOT Report Complete";
                //rdbEOT.Checked = false;
                btnGo.Enabled = true;
            }
            #endregion EOTREPORT

            #region STUDENTREPORT
            if (rdbStudent.Checked)
            {
                //need original Students file (PeopleSoft Query: RFI_ABM_IR_STUDENT_ENROLL)
                //remove duplicates using NID field
                //creates output file--Student File (type 011)
                MessageBox.Show("Select the Student File");
                ofdStudents.ShowDialog();
                //Grades are now included in the same file as the other student information
                //MessageBox.Show("Select the Test Grades File");
                //ofdTestGrades.ShowDialog();

                srStudents = new StreamReader(ofdStudents.FileName);
                //srTestGrades = new StreamReader(ofdTestGrades.FileName);
                swStudents = new StreamWriter("c:\\adhe\\students.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                //discardRecord = srTestGrades.ReadLine();
                discardRecord = srStudents.ReadLine();

                //string TestGradeRecord = srTestGrades.ReadLine();
                //while (TestGradeRecord != null)
                //{
                //    parseTestGrades(TestGradeRecord);
                //    TestGradeRecord = srTestGrades.ReadLine();
                //}
                //srTestGrades.Close();


                string StudRecord = srStudents.ReadLine();
                while (StudRecord != null)
                {
                    //creates a Registration object from the Registration record in the file
                    parseStudents(StudRecord);
                    StudRecord = srStudents.ReadLine();
                }
                srStudents.Close();


                string studHeader = "011012105" + "2017" + "  "; //ADHE Header
                swStudents.WriteLine(studHeader);

                foreach (Student student in StudRecords)
                {
                    string studRecord = "021" + "2" + //term
                        student.CollegeID +
                        student.SSNID +
                        filler(6) +
                        student.StudentName +
                        student.CurrentLegalResidence +
                        student.CountyOfOrigin +
                        student.StateOfOrigin +
                        student.TuitionStatus +
                        student.BorderCountyWaiver +
                        student.Gender +
                        student.NonResidentAlien +
                        filler(2) +
                        student.DateOfBirth +
                        student.EnrollmentStatus +
                        student.TransferFICECode +
                        student.StudentLevel +
                        student.DegreeIntent +
                        student.AttendStatus +
                        student.TotalCreditHours +
                        filler(4) +
                        student.HighSchoolGPA +
                        filler(2) +
                        student.Ethnicity +
                        student.HighSchoolCode +
                        student.HighSchoolGraduationYear +
                        filler(1) +
                        student.HighSchoolCompletionStatus +
                    student.EntranceExamTestType +
                    student.EntranceExamScore +
                    student.MathTestType +
                    student.MathScore +
                    student.MathPlacementStatus +
                    student.EnglishTestType +
                    student.EnglishScore +
                    student.EnglishPlacementStatus +
                    student.ReadingTestType +
                    student.ReadingScore +
                    student.ReadingPlacementStatus +
                    student.ACTScienceReasoningScore +
                    student.CareerReadiness +
                    filler(7) +
                    student.FirstDegreeMajorCode +
                    student.SecondDegreeMajorCode +
                    student.UTeach +
                    student.GEDTestScore;

                    //studRecord = studRecord.PadRight(166, '0'); //pads to make record meet ADHE record length requirement
                    swStudents.WriteLine(studRecord);
                }

                swStudents.WriteLine("991"); //ADHE Trailer
                swStudents.WriteLine("");
                swStudents.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Student Records: " + StudRecords.Count + "\r\n";
                tbxMessage.Text += "Student Report Complete";
                btnGo.Enabled = true;
            }
            #endregion STUDENTREPORT

            #region REGISTRATIONREPORT
            //use query: RFI_TERM_REGISTRATION 11/14/16

            //This code has been modified to build the EOT report from a Excel file provided by Chris Coble
            //That file includes all the registration as well as the EOT information
            if (rdbRegistration.Checked)
            {
                //need Registration file (PeopleSoft Query: ABM_IR_REG1_GOOD)
                //should be no duplicates from this query
                //create output file--Registration File (type 016)
                MessageBox.Show("Select the Registration File");
                ofdRegistration.ShowDialog();

                srRegistration = new StreamReader(ofdRegistration.FileName);
                swRegistrations = new StreamWriter("c:\\adhe\\registrations.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srRegistration.ReadLine(); //discards header record
                //discardRecord = srRegistration.ReadLine(); //discards 2nd header record if needed

                string RegRecord = srRegistration.ReadLine();
                while (RegRecord != null)
                {
                    //creates a Registration object from the Registration record in the file
                    parseNewRegistration(RegRecord);
                    RegRecord = srRegistration.ReadLine();
                }

                srRegistration.Close();

                //string regHeader = "016012105" + "2017" + "  "; //ADHE Registration Header
                string regHeader = "016012105" + "2017" + "  "; //ADHE EOT Header

                swRegistrations.WriteLine(regHeader);


                foreach (NewRegistration reg in NewRegRecords)
                {
                    string regRecord = "026" + "2" + //ADHE Registration prefix
                    //string regRecord = "029" + "0" + //ADHE EOT prefix
                                                     //reg.Term +
                        reg.CollegeID +
                        reg.SSNID +
                        filler(5) +
                        reg.CourseSection +
                        reg.CourseNumber +
                        filler(3) +
                        reg.CourseSequenceNumber +
                        reg.FreeTuition +

                    //***this section is commented out for the Term report
                    //***it should be included for the EOT report
                    reg.Grade +
                    filler(12) + //filler for un-reported PostTestScores
                //reg.PostMathTestType +
                //reg.PostMathScore +
                //reg.PostEnglishTestType +
                //reg.PostEnglishScore +
                //reg.PostReadingTestType +
                //reg.PostReadingScore +
                reg.StateAid +
                filler(20) +
                reg.UndergraduateTermAttemptedCreditHours +
                reg.UndergraduateTermEarnedCreditHours +
                reg.UndergraduateTermGPA +
                reg.UndergraduateCumulativeAttemptedCreditHours +
                reg.UndergraduateCumulativeEarnedCreditHours +
                reg.UndergraduateCumulativeGPA;
                //reg.GraduateTermAttemptedCreditHours +
                //reg.GraduateTermEarnedCreditHours +
                //reg.GraduateTermGPA +
                //reg.GraduateCumulativeAttemptedCreditHours +
                //reg.GraduateCumulativeEarnedCreditHours +
                //reg.GraduateCumulativeGPA;


                //regRecord = regRecord.PadRight(52, ' '); //52 for Term, 124 for EOT
                swRegistrations.WriteLine(regRecord);

                }

                swRegistrations.WriteLine("996"); //ADHE Registration Trailer
                //swRegistrations.WriteLine("999"); //ADHE EOT Trailer
                //swRegistrations.WriteLine("");
                swRegistrations.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Registration Records: " + NewRegRecords.Count + "\r\n";
                tbxMessage.Text += "Registration Report Complete";
                btnGo.Enabled = true;

            }
            #endregion REGISTRATIONREPORT

            #region INSTRUCTORREPORT
            if(rdbInstructor.Checked)
            {
                //need Instructor file (PeopleSoft Query: SMC_ADHE_TERM_INSTRUCTOR)
                //remove duplicates using ID field
                //create output file--Instructor File (type 014)
                MessageBox.Show("Select the Instructor File");
                ofdInstructor.ShowDialog();

                srInstructors = new StreamReader(ofdInstructor.FileName);
                swInstructors = new StreamWriter("c:\\adhe\\instructors.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srInstructors.ReadLine();
                //discardRecord = srInstructors.ReadLine();

                string InstRecord = srInstructors.ReadLine();
                while (InstRecord != null)
                {
                    //creates a Instructor object from the Instructor record in the file
                    parseInstructor(InstRecord);
                    InstRecord = srInstructors.ReadLine();
                }

                srInstructors.Close();

                string instHeader = "014012105" + "2017" + " "; //ADHE Header
                swInstructors.WriteLine(instHeader);

                foreach (Instructor inst in InstRecords)
                {
                    if (inst.InstructorName.Contains("Staff"))
                    {
                        //do nothing, instructor record is STAFF
                    }
                    else
                    {
                        string instRecord = "024" + "2" +
                            inst.SSNID +
                            inst.InstructorName +
                            inst.ContractTerm +
                            inst.ContractSalary +
                        ///*These fields are only reported in Spring and Fall
                            inst.AcademicPositionSource +
                            inst.MaximumSalary +
                            inst.Gender +
                            inst.NonResidentAlien +
                            inst.HishestDegreeAttained +
                            inst.TerminalDegree +
                            inst.DateOfBirth +
                            filler(1) +
                            inst.AcademicRank +
                            inst.FacultyCategory +
                            inst.PrimaryCIPCode +
                            filler(4) +
                            inst.PercentOfTimeEmployed +
                            inst.CourseCreditHours +
                            inst.InstructionalAssignment +
                            filler(20) +
                            inst.PositionTitleCode +
                            inst.Asian +
                            inst.Black +
                            inst.Hispanic +
                            inst.Amind +
                            inst.White +
                            inst.Hawaiian +
                            inst.CollegeID;                          
                            //*/
                        //instRecord = instRecord.PadRight(129, ' ');
                        swInstructors.WriteLine(instRecord);
                    }
                }

                swInstructors.WriteLine("994"); //ADHE Trailer
                swInstructors.WriteLine("");
                swInstructors.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Instructor Records: " + InstRecords.Count + "\r\n";
                tbxMessage.Text += "Instructor Report Complete";
                btnGo.Enabled = true;

            }
            #endregion STUDENTREPORT

            #region COURSEREPORT
            if(rdbCourse.Checked)
            {
                //need COurse file (PeopleSoft Query: RFI_ABM_IR_CRSE1)
                //create output file--Course File (type 015)
                //remove duplicates: use ALL fields then use Class_Nbr field
                MessageBox.Show("Select the Course File");
                ofdCourse.ShowDialog();

                srCourses = new StreamReader(ofdCourse.FileName);
                swCourses = new StreamWriter("c:\\adhe\\courses.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srCourses.ReadLine();
                //discardRecord = srCourses.ReadLine();

                string CrseRecord = srCourses.ReadLine();
                while (CrseRecord != null)
                {
                    //creates a Course object from the Course record in the file
                    parseCourse(CrseRecord);
                    CrseRecord = srCourses.ReadLine();
                }

                srCourses.Close();

                string crseHeader = "015012105" + "2017" + " "; //ADHE Header
                swCourses.WriteLine(crseHeader);

                foreach (Course crse in CrseRecords)
                {

                    string crseRecord = "025" + "2" +
                        crse.UniqueCourseSequenceNumber +
                        crse.TechnicalInstituteFunding +
                        crse.CourseName +
                        crse.CourseNumber +
                        filler(3) +
                        crse.CourseProgramLevel +
                        crse.CourseDetailLevel +
                        crse.CourseType +
                        crse.CourseMethod +
                        crse.TechnologyType +
                        crse.CourseCreditHours +
                        crse.CourseLevel +
                        crse.RemedialCourseLevel +
                        crse.ACTCourse +
                        crse.SSNID +
                        crse.LinkedCourseIndicator +
                        crse.LinkedUniqueCourseSequenceNumber +
                        crse.Enrollment +
                        crse.AcademicType +
                        filler(1) +
                        crse.DepartmentCode +
                        crse.ReceivingCourseLocation +
                        crse.InOutOfDistrict +
                        crse.NonTraditionalSite +
                        crse.CountyCode +
                        filler(1) +
                        crse.ACTSCourseNumber +
                        crse.CollegeInstructorID +
                        crse.CourseSectionNumber;

                    // crseRecord = crseRecord.PadRight(156, ' ');
                    swCourses.WriteLine(crseRecord);
                    
                }

                swCourses.WriteLine("995"); //ADHE Trailer
                swCourses.WriteLine("");
                swCourses.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Course Records: " + CrseRecords.Count + "\r\n";
                tbxMessage.Text += "Course Report Complete";
                btnGo.Enabled = true;

            }
            #endregion COURSEREPORT

            #region ANNUALINSTRUCTORREPORT
            if (rdbAnnualInstructor.Checked)
            {
                //need AnnualInstructor file (PeopleSoft Query: ADHE_ANNUAL_INSTRUCTOR)
                //remove duplicates using ID field
                //create output file-- Annual Instructor File (type 017)
                MessageBox.Show("Select the Annual Instructor File");
                ofdAnnualInstructors.ShowDialog();

                srAnnualInstructors = new StreamReader(ofdAnnualInstructors.FileName);
                swAnnualInstructors = new StreamWriter("c:\\adhe\\annualinstructors.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srAnnualInstructors.ReadLine();
                //discardRecord = srAnnualInstructors.ReadLine();

                string AnnInstRecord = srAnnualInstructors.ReadLine();
                while (AnnInstRecord != null)
                {
                    //creates a Instructor object from the Instructor record in the file
                    parseAnnualInstructor(AnnInstRecord);
                    AnnInstRecord = srAnnualInstructors.ReadLine();
                }

                srAnnualInstructors.Close();

                string anninstHeader = "017012105" + "2017" + " "; //ADHE Header
                swAnnualInstructors.WriteLine(anninstHeader);

                foreach (AnnualInstructor inst in AnnInstRecords)
                {
                    string instRecord = "027" + 
                        inst.CollegeID + 
                        inst.SSNID + 
                        inst.PositionTitleCode + 
                        inst.SOCCode + 
                        inst.SOCDetail + 
                        filler(1) + 
                        inst.InstructorName + 
                        inst.ContractTerm +
                        inst.TotalAnnualSalary +
                        inst.SourceOfSalary +
                        inst.InstructionPercentOfSalary +
                        inst.DepartmentPercentOfSalary +
                        inst.InstitutionalAdministrationPercentOfSalary +
                        inst.ResearchScholarshipPercentOfSalary +
                        inst.PublicServicePercentOfSalary +
                        inst.OtherPercentOfSalary +
                        inst.FringeBenefits +
                        inst.InstructorPrimaryRole;

                    instRecord = instRecord.PadRight(95, ' ');
                    swAnnualInstructors.WriteLine(instRecord);
                }

                swAnnualInstructors.WriteLine("997"); //ADHE Trailer
                swAnnualInstructors.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Annual Instructor Records: " + AnnInstRecords.Count + "\r\n";
                tbxMessage.Text += "Annual Instructor Report Complete";
                btnGo.Enabled = true;

            }
            #endregion ANNUALSTUDENTREPORT

            #region PERKINSIREPORT
            if (rdbPerkinsI.Checked)
            {
                //need PerkinsII file (Supplied by Coble)
                //create output file--PerkinsI File (type 01V)
                MessageBox.Show("Select the Perkins I File");
                ofdPerkinsI.ShowDialog();

                srPerkinsI = new StreamReader(ofdPerkinsI.FileName);
                swPerkinsI = new StreamWriter("c:\\adhe\\perkinsI.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srPerkinsI.ReadLine();
                //discardRecord = srInstructors.ReadLine(); only one header line

                string PerkIRecord = srPerkinsI.ReadLine();
                while (PerkIRecord != null)
                {
                    //creates a Instructor object from the Instructor record in the file
                    parsePerkinsI(PerkIRecord);
                    PerkIRecord = srPerkinsI.ReadLine();
                }

                srPerkinsI.Close();

                string perkIHeader = "01V012105" + "2017" + " "; //ADHE Header
                swPerkinsI.WriteLine(perkIHeader);

                foreach (PerkinsI perk in PerkinsIRecords)
                {
                    string perkIRecord = "02V" +
                     perk.CollegeID +
                     perk.SSNID +
                     perk.Disabled +
                     perk.EconomicDisadvantage +
                     perk.SingleParent +
                     perk.DisplacedHomemaker +
                     perk.LimitedEnglish +
                     filler(2) +
                     perk.DegreeCode;

                    perkIRecord = perkIRecord.PadRight(33, ' ');
                    swPerkinsI.WriteLine(perkIRecord);
                    
                }

                swPerkinsI.WriteLine("99V"); //ADHE Trailer
                swPerkinsI.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Perkins I Records: " + PerkinsIRecords.Count + "\r\n";
                tbxMessage.Text += "Perkins I Report Complete";
                btnGo.Enabled = true;

            }
            #endregion PERKINSIREPORT

            #region PERKINSIIREPORT
            if (rdbPerkinsII.Checked)
            {
                //need PerkinsII file (Supplied by Coble)
                //create output file--PerkinsII File (type 01Q)
                MessageBox.Show("Select the Perkins II File");
                ofdPerkinsII.ShowDialog();

                srPerkinsII = new StreamReader(ofdPerkinsII.FileName);
                swPerkinsII = new StreamWriter("c:\\adhe\\perkinsII.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srPerkinsII.ReadLine();
                //discardRecord = srInstructors.ReadLine(); only one header line

                string PerkIIRecord = srPerkinsII.ReadLine();
                while (PerkIIRecord != null)
                {
                    //creates a PerkinsII object from the PerkinsII record in the file
                    parsePerkinsII(PerkIIRecord);
                    PerkIIRecord = srPerkinsII.ReadLine();
                }

                srPerkinsII.Close();

                string perkIIHeader = "01Q012105" + "2017" + " "; //ADHE Header
                swPerkinsII.WriteLine(perkIIHeader);

                foreach (PerkinsII perk in PerkinsIIRecords)
                {
                    string perkIIRecord = "02Q" +
                     perk.CollegeID +
                     perk.SSNID +
                     perk.CTETaken +
                     perk.CTEPassed +
                     perk.CTEName.Replace("\"","");
        
                    perkIIRecord = perkIIRecord.PadRight(74, ' ');
                    swPerkinsII.WriteLine(perkIIRecord);

                }

                swPerkinsII.WriteLine("99Q"); //ADHE Trailer
                swPerkinsII.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Perkins II Records: " + PerkinsIIRecords.Count + "\r\n";
                tbxMessage.Text += "Perkins II Report Complete";
                btnGo.Enabled = true;

            }
            #endregion PERKINSIIREPORT

            #region GRADUATEREPORT
            if (rdbGraduate.Checked)
            {
                //need Graduate file (Supplied by Chirs)
                //create output file--Graduate File (type ___)
                
                MessageBox.Show("Select the Graduate File");
                ofdGraduate.ShowDialog();

                srGraduates = new StreamReader(ofdGraduate.FileName);
                swGraduates = new StreamWriter("c:\\adhe\\graduates.dat");
                //load files into memory
                //initial readlines to discard header junk
                //may want to enhance this by doing some validation on header records
                string discardRecord;
                discardRecord = srGraduates.ReadLine();
                //discardRecord = srCourses.ReadLine();

                string GradRecord = srGraduates.ReadLine();
                while (GradRecord != null)
                {
                    //creates a Instructor object from the Instructor record in the file
                    parseGraduate(GradRecord);
                    GradRecord = srGraduates.ReadLine();
                }

                srGraduates.Close();

                string gradHeader = "012012105" + "2016" + " "; //ADHE Header
                swGraduates.WriteLine(gradHeader);

                foreach (Graduate grad in GraduateRecords)
                {

                    string gradRecord = "022" +
                        grad.CollegeID +
                        grad.SSNID +
                        grad.ReverseTransfer +
                        filler(6) +
                        grad.InitialEnrollmentStatus +
                        grad.InitialAttendanceStatus +
                        grad.InitialAdmissionDate +
                        grad.Gender +
                        grad.NonResidentAlien +
                        grad.CompletedHours +
                        grad.GraduationDate +
                        grad.DegreeLevel +
                        grad.CIPCode +
                        grad.CIPDetail +
                        grad.Degree1 +
                        grad.Degree2 +
                        grad.Degree3 +
                        grad.EECIPCode +
                        grad.EECIPDetail +
                        grad.Asian +
                        grad.Black +
                        grad.Hispanic +
                        grad.AmericanIndian +
                        grad.White +
                        grad.Hawaiian +
                        grad.Age;

                    gradRecord = gradRecord.PadRight(83, ' ');
                    swGraduates.WriteLine(gradRecord);

                }

                swGraduates.WriteLine("992"); //ADHE Trailer
                swGraduates.Close();

                tbxMessage.Text = "PROCESSED RECORDS\r\n";
                tbxMessage.Text += "Graduate Records: " + GraduateRecords.Count + "\r\n";
                tbxMessage.Text += "Graduate Report Complete";
                btnGo.Enabled = true;

            }
            #endregion GRADUATEREPORT


        }

        private int findRegistrationRecord(string nationalID, string subjectArea, string catalogNumber)
        {
            for (int i = 0; i<PrevRegRecords.Count; i++)
            {
                string subArea = PrevRegRecords[i].CourseNumber.Substring(0, 4).TrimEnd(' ').TrimStart(' ');
                string catNum = PrevRegRecords[i].CourseNumber.Substring(4, 6).TrimEnd(' ').TrimStart(' ');
                if (PrevRegRecords[i].SSNID == nationalID && subArea == subjectArea && catNum == catalogNumber)
                {
                    return i;
                }
            }
            //swEOT.WriteLine("Registration Record not found for: " + nationalID + "--" + subjectArea + "--" + catalogNumber);
            return 99999999;
        }

        private int findGPARecord(string nationalID)
        {
            for (int i=0; i<GPARecords.Count; i++)
            {
                if (GPARecords[i].SSNID == nationalID)
                {
                    return i;
                }
            }
            //swEOT.WriteLine("GPA Record not found for: " + nationalID);
            return 99999999;
        }

        private int findGradeRecord(string nationalID)
        {
            for (int i = 0; i < GradeRecords.Count; i++)
            {
                if (GradeRecords[i].SSNID == nationalID)
                {
                    return i;
                }
            }
            //swEOT.WriteLine("GPA Record not found for: " + nationalID);
            return 99999999;
        }

        //parse functions to decode data records from query files
        //these function read records from query output files, split them based on comma seperated values
        //and populate a new instance of the object and then add the object to the appropriate Global list
        private void parsePreviousRegistration(string record)
        {
        //used to parse information out of a PREVIOUSLY submitted REgistration File in ADHE Format, NOT directly from a PeopleSoft query
            if (record.Length > 50)
            {//assume valid record base on record length, probably should validate based on first two characters, RecordType
                PreviousRegistration reg = new PreviousRegistration();

                reg.RecordType = record.Substring(0, 2);
                reg.DataType = record.Substring(2, 1);
                reg.RegistrationTerm = record.Substring(3, 1);
                reg.CollegeID = record.Substring(4, 10);
                reg.SSNID = record.Substring(14, 9);
                reg.CourseSection = record.Substring(28, 4).Trim().PadLeft(4);
                reg.CourseNumber = record.Substring(32, 10);
                reg.CourseSequenceNumber = record.Substring(45, 6);
                reg.FreeTuition = record.Substring(51, 1);

                PrevRegRecords.Add(reg);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseGrades(string record)
        {
            if (record.Length > 40)
            {//assume valid record base on record length, probably need to validate using some other criteria
                Grade grade = new Grade();
                string[] tmpGrade = record.Split(',');

                grade.SSNID = tmpGrade[0];
                grade.Sequence = tmpGrade[1];
                grade.CourseGrade = tmpGrade[2].PadLeft(2);
                grade.SubjectArea = tmpGrade[3];
                grade.Number = tmpGrade[4];
                grade.Section = tmpGrade[5].Trim().PadLeft(4);
                grade.UnitsTaken = tmpGrade[6].Replace(".","").PadRight(4,'0');
                grade.LocationCode = tmpGrade[7];
                grade.AcademicGroup = tmpGrade[8];
                grade.CollegeID = tmpGrade[9].PadLeft(10);
                //grade.Term = standardizeTerm(tmpGrade[10]);

                GradeRecords.Add(grade);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseGPAs (string record)
        {
            if (record.Length > 60)
            {
                GPA gpa = new GPA();
                string[] tmpGPA = record.Split(',');
                gpa.SSNID = tmpGPA[0];
                gpa.Term = standardizeTerm(tmpGPA[1]);
                gpa.TermAttemptedHours = tmpGPA[2].Replace(".","").Substring(0,3);
                gpa.TermEarnedHours = tmpGPA[3].Replace(".", "").Substring(0,3);
                gpa.TermGPA = tmpGPA[4].Replace(".", "").PadRight(4, '0');
                gpa.CumuAttemptedHours = tmpGPA[5].Replace(".", "").Substring(0,3);
                gpa.CumuEarnedHours = tmpGPA[6].Replace(".", "").Substring(0,3);
                gpa.CumulativeGPA = tmpGPA[7].Replace(".", "").PadRight(4, '0');
                gpa.CollegeID = tmpGPA[8].PadLeft(10);
                gpa.Name = tmpGPA[9].PadRight(30);

                GPARecords.Add(gpa);
            }
            else
            {
                //do nothing...invlaid record
            }
        }

        private void parseStudents (string record)
        {
            //*********************WARNING******************************
            //*********************WARNING******************************
            //*********************WARNING******************************
            //*********************WARNING******************************
            //this code has been modified to work in a ONEOFF fashion with the one time
            //Excel file provided by Chris Coble
            if (record.Length > 45)
            {
                Student stud = new Student();
                string[] fields = record.Split(',');

                stud.CollegeID = filler(10);// fields[0].Trim().PadRight(10);
                stud.SSNID = fields[0].Trim();
                //filler
                //stud.StudentName = fields[3].Replace("\"","").PadRight(30); //replaces quotes in name field with nothing
                stud.StudentName = (fields[1] + "," + fields[2]).Replace("\"","").PadRight(30).Substring(0,30);
                stud.CurrentLegalResidence = "04";// fields[3].Trim().PadLeft(2,'0');
                stud.CountyOfOrigin = standardizeCountyOfOrgin(fields[4]);
                stud.StateOfOrigin = "04";// fields[5].Trim().PadLeft(2,'0');
                stud.TuitionStatus = fields[6];//.Trim().PadLeft(1);
                stud.BorderCountyWaiver = fields[7].Trim().PadLeft(1);
                stud.Gender = fields[8];
                stud.NonResidentAlien = fields[9].Trim().PadLeft(2,'0');
                //filler
                stud.DateOfBirth = fields[10].Trim().PadLeft(8,'0');
                stud.EnrollmentStatus = fields[11].Trim().PadLeft(2,'0');
                stud.TransferFICECode = fields[12].Trim().PadLeft(6,' '); 
                stud.StudentLevel = fields[13].Trim().PadLeft(2,'0');
                stud.DegreeIntent = fields[14].Trim().PadLeft(1);
                stud.AttendStatus = fields[15].Trim().PadLeft(1);
                stud.TotalCreditHours = fields[16].Trim().PadLeft(2, '0');
                //filler
                stud.HighSchoolGPA = standardizedHSGPA(fields[17].Replace(".","").PadRight(4,'0'));
                //filler

                //stud.Ethnicity = standardizedEthnicity_ONEFIELD(fields[18]); //NOT TESTED---USE ETHNICITY CODE FIELD Ethnic_GRP_TBL
                stud.Ethnicity =
                    fields[18].PadLeft(1, '2') +
                    fields[19].PadLeft(1, '2') +
                    fields[20].PadLeft(1, '2') +
                    fields[21].PadLeft(1, '2') +
                    fields[22].PadLeft(1, '2') +
                    fields[23].PadLeft(1, '2');
                stud.HighSchoolCode = fields[24].Trim().PadLeft(6, '0');//standardizedHSCode(fields[28]);
                stud.HighSchoolGraduationYear = standardizedHSGradYear(fields[25]);
                //filler
                stud.HighSchoolCompletionStatus = "9";// fields[30].Trim();
                  //composite ACT and/or SAT scores
                stud.EntranceExamTestType = fields[27].Trim().PadLeft(1,'9'); //See page P-19 in SIS manual
                if (stud.EntranceExamTestType == "9")
                    stud.EntranceExamScore = "0000";
                else
                    stud.EntranceExamScore = fields[28].Trim().PadLeft(4, '0');

                //Test types hardcoded to 9 becuase entrance exam type is hardcoded to 9
                //and test scores were not available at this time
                stud.MathTestType = fields[29].Trim().PadLeft(1,'9'); // fields[29].Trim().PadLeft(1,'0');
                if (stud.MathTestType == "9")
                    stud.MathScore = "999";
                else
                    stud.MathScore = fields[30].Trim().PadLeft(3,'0');
                stud.MathPlacementStatus = fields[31].Trim().PadLeft(1, '0');

                stud.EnglishTestType = fields[32].Trim().PadLeft(1, '9'); //fields[32].Trim().PadLeft(1, '0');
                if (stud.EntranceExamTestType == "9")
                    stud.EnglishScore = "999";
                else
                    stud.EnglishScore = fields[33].Trim().PadLeft(3, '0');
                stud.EnglishPlacementStatus = fields[34].Trim().PadLeft(1, '0');

                stud.ReadingTestType = fields[35].Trim().PadLeft(1, '9'); // fields[35].Trim().PadLeft(1, '0');
                if (stud.ReadingTestType == "9")
                    stud.ReadingScore = "999";
                else
                    stud.ReadingScore = fields[36].Trim().PadLeft(3, '0');
                stud.ReadingPlacementStatus = fields[37].Trim().PadLeft(1, '0');

                stud.ACTScienceReasoningScore =  fields[38].Trim().PadLeft(2, '0');
                stud.CareerReadiness = "3";// fields[43].Trim();
                stud.FirstDegreeMajorCode = fields[39].Replace("-","").PadRight(4).Substring(0,4);
                stud.SecondDegreeMajorCode = fields[40].Trim().PadLeft(4, '0').Substring(0,4);
                stud.UTeach = fields[41].Trim();
                stud.GEDTestScore = fields[42].Trim().PadLeft(4, '0');

                StudRecords.Add(stud);

                //***********************************
                //***********************************
                //The remainder of this method was used to identify student test scores and to identify TOP
                //scores in the case of multiple instances of the same exam

                //Get students ACT/COMPASS grades from the grades list that is read in at start
                //getGrades generates a TopGrades structure that contains the top grade in each ACT and Compass component

                //TopGrades topGrades = getGrades(stud.CollegeID);

                //If there are ONLY ACT grades or there are ACT AND Compass grades, report ACT grades
                /*
                if (topGrades.ACTGrades || (topGrades.ACTGrades && topGrades.CompassGrades))
                {
                    string testTypeACT = "0";
                    //place ACT grades in student record
                    //**************************************
                    stud.MathTestType = testTypeACT;
                    stud.MathScore = topGrades.ACTMath.ToString().Trim().PadLeft(3,'0');
                    stud.MathPlacementStatus = "1"; //see page P-20 in SIS Manual

                    stud.EnglishTestType = testTypeACT;
                    stud.EnglishScore = topGrades.ACTEnglish.ToString().Trim().PadLeft(3, '0');
                    stud.EnglishPlacementStatus = "1"; //see page P-20 in SIS Manual

                    stud.ReadingTestType = testTypeACT;
                    stud.ReadingScore = topGrades.ACTRead.ToString().Trim().PadLeft(3, '0');
                    stud.ReadingPlacementStatus = "1"; //see page P-20 in SIS Manual

                    stud.ACTScienceReasoningScore = "99";//see Page P-22 in SIS Manual
                }

                //If there are ONLY Compass grades
                if (topGrades.CompassGrades)
                {
                    string testTypeCompass = "3";
                    //place COMPASS grades in student record
                    //**************************************
                    stud.MathTestType = testTypeCompass;
                    stud.MathScore = topGrades.CompassALG.ToString().Trim().PadLeft(3,'0');
                    stud.MathPlacementStatus = "1"; //see page P-20 in SIS Manual

                    stud.EnglishTestType = testTypeCompass;
                    stud.EnglishScore = topGrades.CompassRead.ToString().Trim().PadLeft(3, '0');
                    stud.EnglishPlacementStatus = "1"; //see page P-20 in SIS Manual

                    stud.ReadingTestType = testTypeCompass;
                    stud.ReadingScore = topGrades.CompassRead.ToString().Trim().PadLeft(3, '0');
                    stud.ReadingPlacementStatus = "1"; //see page P-20 in SIS Manual

                    stud.ACTScienceReasoningScore = "99";//see Page P-22 in SIS Manual
                }

                //If there are neither ACT or Compass Grades
                if(!topGrades.ACTGrades && !topGrades.CompassGrades)
                {
                    string testTypeEmpty = "9"; //see page P-20 in SIS manual
                    //place EMPTY grades in student record, no test records found
                    //**************************************
                    stud.MathTestType = testTypeEmpty;
                    stud.MathScore = "000";
                    stud.MathPlacementStatus = "9"; //see page P-20 in SIS Manual

                    stud.EnglishTestType = testTypeEmpty;
                    stud.EnglishScore = "000";
                    stud.EnglishPlacementStatus = "9"; //see page P-20 in SIS Manual

                    stud.ReadingTestType = testTypeEmpty;
                    stud.ReadingScore = "000";
                    stud.ReadingPlacementStatus = "9"; //see page P-20 in SIS Manual

                    stud.ACTScienceReasoningScore = "99";//see Page P-22 in SIS Manual

                }

                stud.CareerReadiness = fields[31];
                ////filler
                stud.FirstDegreeMajorCode = fields[32].Trim().PadLeft(4);
                stud.SecondDegreeMajorCode = fields[33].Trim().PadLeft(4);
                stud.UTeach = fields[34].Trim().PadLeft(1);
                stud.GEDTestScore = fields[35].Trim().PadLeft(4,'0');
                //=================================================
                */
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseInstructor(string record)
        {
            //*********************WARNING******************************
            //*********************WARNING******************************
            //*********************WARNING******************************
            //*********************WARNING******************************
            //this code has been modified to work in a ONEOFF fashion with the one time
            //Excel file provided by Chris Coble

            if (record.Length > 80)
            {
                Instructor inst = new Instructor();
                string[] tmpInstructor = record.Split(',');

                inst.SSNID = tmpInstructor[1];
                inst.InstructorName = (tmpInstructor[2] + ", " + 
                    tmpInstructor[3]).Replace("\"","").PadRight(30).Substring(0,30);
                inst.ContractTerm = tmpInstructor[4];
                inst.ContractSalary = tmpInstructor[5].PadLeft(7,'0');
                double contractSalary = Convert.ToDouble(tmpInstructor[5]); //used below, see MaximumSalary

                ////****************************************
                ////The following fields are only submitted for the fall and spring terms
                ///*****************************************
                inst.AcademicPositionSource = tmpInstructor[6];

                //per SIS manual, only report Max Salary if it is exceeded by Contract Salary
                Double maxSalary = Convert.ToDouble(tmpInstructor[7]);
                if (contractSalary > maxSalary)
                    inst.MaximumSalary = tmpInstructor[7].PadLeft(7);
                else
                    inst.MaximumSalary = "0000000";

                inst.Gender = tmpInstructor[8];
                inst.NonResidentAlien = tmpInstructor[9].PadLeft(2,'0');
                inst.HishestDegreeAttained = tmpInstructor[10].PadLeft(2, '0') ;
                inst.TerminalDegree = tmpInstructor[11];
                inst.DateOfBirth = tmpInstructor[12].PadLeft(8,'0');
                inst.AcademicRank = tmpInstructor[13];
                inst.FacultyCategory = tmpInstructor[14];
                inst.PrimaryCIPCode = tmpInstructor[15].Substring(0,2);
                inst.PercentOfTimeEmployed = tmpInstructor[16].PadLeft(3,'0');
                inst.CourseCreditHours = tmpInstructor[17].PadLeft(2,'0');
                inst.InstructionalAssignment = tmpInstructor[18].Trim().PadLeft(3,'0');
                inst.PositionTitleCode = tmpInstructor[19];
                inst.Asian = tmpInstructor[21];
                inst.Black = tmpInstructor[22];
                inst.Hispanic = tmpInstructor[23];
                inst.Amind = tmpInstructor[24];
                inst.White = tmpInstructor[20];
                inst.Hawaiian = tmpInstructor[25];
                inst.CollegeID = tmpInstructor[26].PadLeft(10);                
                //*/
                InstRecords.Add(inst);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseCourse(string record)
        {
            {
                //*********************WARNING******************************
                //*********************WARNING******************************
                //*********************WARNING******************************
                //*********************WARNING******************************
                //this code has been modified to work in a ONEOFF fashion with the one time
                //Excel file provided by Chris Coble

                if (record.Length > 50)
                {
                    Course crse = new Course();
                    string[] tmpCourse = record.Split(',');

                    crse.UniqueCourseSequenceNumber = tmpCourse[3].PadLeft(6, '0');
                    crse.TechnicalInstituteFunding = tmpCourse[4].PadLeft(1, '0');
                    crse.CourseName = tmpCourse[5].PadRight(30).Substring(0,30);
                    crse.CourseNumber = tmpCourse[6].PadRight(10);
                    //filler

                    crse.CourseProgramLevel = tmpCourse[8].Substring(0, 2);
                    crse.CourseDetailLevel = tmpCourse[8].PadRight(7,'0').Substring(3, 4);
                    crse.CourseType = tmpCourse[9].PadRight(1,'0');
                    crse.CourseMethod = tmpCourse[10].PadLeft(2);
                    crse.TechnologyType = tmpCourse[11].PadLeft(2);
                    crse.CourseCreditHours = tmpCourse[12].Substring(0, 1).PadLeft(2,'0');
                    crse.CourseLevel = tmpCourse[13].PadRight(1,'0');
                    crse.RemedialCourseLevel = tmpCourse[14].Trim().PadLeft(1,'0');
                    crse.ACTCourse = tmpCourse[15].Trim().PadLeft(1);
                    crse.SSNID = tmpCourse[16];
                    crse.LinkedCourseIndicator = tmpCourse[17].Trim().PadLeft(1);
                    crse.LinkedUniqueCourseSequenceNumber = "000000";
                    crse.Enrollment = tmpCourse[19].PadLeft(4, '0');
                    crse.AcademicType = "1";
                    //filler
                    crse.DepartmentCode = tmpCourse[21].Trim().PadLeft(4);
                    crse.ReceivingCourseLocation = tmpCourse[22].PadLeft(2,'0');
                    crse.InOutOfDistrict = tmpCourse[23].Trim();
                    crse.NonTraditionalSite = tmpCourse[24].Trim().PadRight(30).Substring(0,30);
                    crse.CountyCode = tmpCourse[25].PadLeft(3,'0');
                    //filler
                    crse.ACTSCourseNumber = tmpCourse[27].Trim().PadLeft(9);
                    crse.CollegeInstructorID = filler(10);
                    crse.CourseSectionNumber = tmpCourse[7].Trim().PadLeft(4);

                    CrseRecords.Add(crse);
                }
                else
                {
                    //do nothing...invalid record
                }
            }
        }

        private void parsePerkinsI(string record)
        {
            if (record.Length > 25)
            {
                PerkinsI perk = new PerkinsI();
                string[] tmpPerkI = record.Split(',');

                perk.CollegeID = tmpPerkI[0].PadLeft(10, ' ');
                perk.SSNID = tmpPerkI[1];
                perk.Disabled = tmpPerkI[2];
                //following fields 1=yes 2=no
                perk.EconomicDisadvantage = tmpPerkI[3];
                perk.SingleParent = tmpPerkI[4];
                perk.DisplacedHomemaker = tmpPerkI[5];
                perk.LimitedEnglish = tmpPerkI[6];

                perk.DegreeCode = tmpPerkI[7].PadLeft(4);

                PerkinsIRecords.Add(perk);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parsePerkinsII(string record)
        {
            if (record.Length > 18) //there may be some really short line if/when fields are missing
            {
                PerkinsII perk = new PerkinsII();
                string[] tmpPerkII = record.Split(',');

                perk.CollegeID = tmpPerkII[0].PadLeft(10, ' ');
                perk.SSNID = tmpPerkII[1].PadLeft(9,'0');
                perk.CTETaken = tmpPerkII[2];
                perk.CTEPassed = tmpPerkII[3];
                perk.CTEName = tmpPerkII[4].PadRight(50);
                PerkinsIIRecords.Add(perk);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseNewRegistration(string record)
        {
            //use query: RFI_TERM_REGISTRATION 11/14/16
            if (record.Length > 20)
            {
                NewRegistration newReg = new NewRegistration();
                string[] tmpReg = record.Split(',');

                newReg.Term = tmpReg[2];
                //newReg.CollegeID = tmpReg[0].PadLeft(10,'0');
                newReg.CollegeID = tmpReg[3].PadLeft(10,'0');
                newReg.SSNID = tmpReg[4];
                //filler
                newReg.CourseSection = tmpReg[7].PadLeft(4,'0');
                newReg.CourseNumber = tmpReg[6].PadRight(10);
                //filler
                newReg.CourseSequenceNumber = tmpReg[9].PadLeft(6, '0');
                newReg.FreeTuition = "2";//tmpReg[5];//always TWO per CC on 11/11/16
/*Only needed for EOT
                //***Following fields are commented out for initial Registration
                //***report that is part of the term file. They must be un-commented
                //***for the EOT report
                newReg.Grade = tmpReg[11].PadRight(2);
                //newReg.PostMathTestType = filler(1); //UNKNOWN
                //newReg.PostMathScore = filler(3); //UNKNOWN
                //newReg.PostEnglishTestType = filler(1); //UNKNOWN
                //newReg.PostEnglishScore = filler(3); //UNKNOWN
                //newReg.PostReadingTestType = filler(1); //UNKNOWN
                //newReg.PostReadingScore = filler(3); //UNKNOWN
                newReg.StateAid = tmpReg[18];
                //filler
                newReg.UndergraduateTermAttemptedCreditHours = tmpReg[20].Substring(0, tmpReg[20].IndexOf('.')).PadLeft(3, '0');
                newReg.UndergraduateTermEarnedCreditHours = tmpReg[21].PadLeft(3, '0');
                newReg.UndergraduateTermGPA = tmpReg[22].Replace(".", "").TrimEnd('0').PadRight(4, '0');
                newReg.UndergraduateCumulativeAttemptedCreditHours = tmpReg[23].PadLeft(3, '0');
                newReg.UndergraduateCumulativeEarnedCreditHours = tmpReg[24].PadLeft(3, '0');
                newReg.UndergraduateCumulativeGPA = tmpReg[25].Replace(".", "").TrimEnd('0').PadRight(4, '0');
                //newReg.GraduateTermAttemptedCreditHours = filler(3); //UNKNOWN
                //newReg.GraduateTermEarnedCreditHours = filler(3); //UNKNOWN
                //newReg.GraduateTermGPA = filler(4); //UNKNOWN
                //newReg.GraduateCumulativeAttemptedCreditHours = filler(3); //UNKNOWN
                //newReg.GraduateCumulativeEarnedCreditHours = filler(3); //UNKNOWN
                //newReg.GraduateCumulativeGPA = filler(4); //UNKNOWN
*/
                NewRegRecords.Add(newReg);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseAnnualInstructor(string record)
        {
            if (record.Length > 45)
            {
                AnnualInstructor newAnnInst = new AnnualInstructor();

                string[] tmpAI = record.Split(',');
                newAnnInst.CollegeID = tmpAI[0].PadLeft(10, '0');
                newAnnInst.SSNID = tmpAI[1];
                newAnnInst.PositionTitleCode = tmpAI[2];
                newAnnInst.SOCCode = tmpAI[3];
                newAnnInst.SOCDetail = tmpAI[4];
                //filler
                newAnnInst.InstructorName = (tmpAI[5] + ", " + tmpAI[6]).PadRight(30);
                newAnnInst.ContractTerm = tmpAI[7];
                newAnnInst.TotalAnnualSalary = tmpAI[8].PadLeft(7,'0');
                newAnnInst.SourceOfSalary = tmpAI[9];
                newAnnInst.InstructionPercentOfSalary = tmpAI[10].PadLeft(3,'0');
                newAnnInst.DepartmentPercentOfSalary = tmpAI[11].PadLeft(3, '0');
                newAnnInst.InstitutionalAdministrationPercentOfSalary = tmpAI[12].PadLeft(3, '0');
                newAnnInst.ResearchScholarshipPercentOfSalary = tmpAI[13].PadLeft(3, '0');
                newAnnInst.PublicServicePercentOfSalary = tmpAI[14].PadLeft(3, '0');
                newAnnInst.OtherPercentOfSalary = tmpAI[15].PadLeft(3, '0');
                newAnnInst.FringeBenefits = tmpAI[16].TrimStart('0').PadLeft(6,'0');
                newAnnInst.InstructorPrimaryRole = tmpAI[17];

                AnnInstRecords.Add(newAnnInst);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseGraduate(string record)
        {
            if (record.Length > 60)
            {
                Graduate grad = new Graduate();
                string[] tmpGrad = record.Split(',');
                grad.CollegeID = tmpGrad[0].PadLeft(10);
                grad.SSNID = tmpGrad[1];
                grad.ReverseTransfer = tmpGrad[2].Trim();
                grad.InitialEnrollmentStatus = tmpGrad[3];
                grad.InitialAttendanceStatus = tmpGrad[4];
                grad.Gender = tmpGrad[6].Trim();
                grad.InitialAdmissionDate = tmpGrad[5].Trim().PadLeft(6,'0');
                //gender was duplicated in col 7 in initial file
                grad.NonResidentAlien = tmpGrad[7].Trim().PadLeft(2);
                grad.CompletedHours = tmpGrad[8].Trim().PadLeft(3);
                grad.GraduationDate = tmpGrad[9].Trim().PadLeft(6, '0');
                grad.DegreeLevel = tmpGrad[10].Trim().PadLeft(2,'0');
                grad.CIPCode = tmpGrad[11].Substring(0,2);
                grad.CIPDetail = tmpGrad[11].Substring(3, 4);
                grad.Degree1 = tmpGrad[12].Trim().PadLeft(4);
                grad.Degree2 = tmpGrad[13].Trim().PadLeft(4);
                grad.Degree3 = tmpGrad[14].Trim().PadLeft(4);
                grad.EECIPCode = tmpGrad[15].Trim().PadLeft(2);
                grad.EECIPDetail = tmpGrad[16].Trim().PadLeft(4);
                grad.Asian = tmpGrad[17];
                grad.Black = tmpGrad[18];
                grad.Hispanic = tmpGrad[19];
                grad.AmericanIndian = tmpGrad[20];
                grad.White = tmpGrad[21];
                grad.Hawaiian = tmpGrad[22];
                grad.Age = DateToAge(Convert.ToDateTime(tmpGrad[23])).ToString();

                GraduateRecords.Add(grad);
            }
            else
            {
                //do nothing...invalid record
            }
        }

        private void parseTestGrades(string record)
        {
            if (record.Length > 40)
            {
                TestGrade testGrade  = new TestGrade();
                string[] tmpTG = record.Split(',');

                testGrade.CollegeID = tmpTG[1];
                testGrade.TestID = tmpTG[2];
                testGrade.Component = tmpTG[3];
                testGrade.Score = tmpTG[4];
                testGrade.TestDate = tmpTG[5];
                //testGrade.DataSource = tmpTG[4];

                TestGradeRecords.Add(testGrade);
            }
            else
            {
                //do nothing...invalid record
            }
        }


        //miscellaneous helper functions

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rdbEOT_CheckedChanged(object sender, EventArgs e)
        {
            tbxMessage.Text = "You will be asked to select three file names: \r\n";
            tbxMessage.Text += "Beginning of Term Registration File \r\n";
            tbxMessage.Text += "End of Term Grades File (from PS query) \r\n";
            tbxMessage.Text += "End of Term GPAs File (from PS query) \r\n";
            tbxMessage.Text += "...and an Academic Year(above)\r\n";
            lblAcadYear.Visible = true;
            cmbxAcadYear.Visible = true;
            cmbxAcadYear.BackColor = Color.Yellow;
        }

        private void rdbStudent_CheckedChanged(object sender, EventArgs e)
        {
            tbxMessage.Text = "You will be asked to provide a CSV file that is the output of ";
            tbxMessage.Text += "the PeopleSoft query: ABM_IR_STUDENT_ENROLL \r\n";
            tbxMessage.Text += "...and an Academic Year(above)\r\n";
            lblAcadYear.Visible = true;
            cmbxAcadYear.Visible = true;
            cmbxAcadYear.BackColor = Color.Yellow;

        }

        private string standardizeDOB(string dob)
        {
            //accepts a string with any of the following formats and returns it in 
            //standard mmddyyyy format
            //  5/5/2016
            //  12/5/2016
            //  5/12/2016
            //  12/12/2016
            if (dob.Length > 6)
            {
                string month = "";
                string day = "";
                string year = dob.Substring(dob.Length - 4, 4);
                dob = dob.Substring(0, dob.Length - 5);
                int firstSlash = dob.IndexOf('/');
                month = dob.Substring(0, firstSlash).PadLeft(2, '0');
                dob = dob.Remove(0, firstSlash + 1);
                day = dob.PadLeft(2, '0');

                return (month + day + year);
            }
            else
            {
                //input dob string was invalid, return string of 8 blanks
                return "        ";
            }
        }

        private string standardizeTerm(string term)
        {
            if (term == "2153")
                return "0";
            if (term == "2163")
                return "0";
            if (term == "2173")
                return "0";
            if (term == "2151")
                return "1";
            if (term == "2161")
                return "1";
            if (term == "2171")
                return "1";
            if (term == "2181")
                return "1";
            if (term == "2152")
                return "2";
            if (term == "2162")
                return "2";
            if (term == "2172")
                return "2";
            if (term == "2182")
                return "2";

            return "-";

        }

        private string standardizeGender(string gender)
        {
            if (gender == "M" || gender == "1")
                return "1";
            if (gender == "F" || gender == "2")
                return "2";
            else
                return "0"; //bad value input to this function
        }

        private string standardizeSummerTerm(string term)
        {
            if (term == "SS1")
                return "3";
            if (term == "SS2")
                return "0";
            else
                return "9"; //invalid summer term received to this function, valid choices are 0-7
        }

        private string standardizeSOCCode(string title)
        {
            if (title == "INS")
                return "25";
            if (title == "MOC")
                return "13";
            else
                return "  "; //unknown code
        }

        private string filler(int count)
        {
            return " ".PadRight(count, ' ');
        }

        private string standardizeLocation(string loc)
        {
            if (loc == "NPCC")
                return "00";
            if (loc == "ONLINE")
                return "98";
            if (loc == "STUDNTHOME")
                return "77";
            if (loc == "BUSINESS")
                return "04";
            else
                return "  "; //invalid location code supplied to this function
        }

        private string standardizeCIPCode(string code)
        {
            return code.Substring(0, 2);
        }

        private string standardizedCIPDetail(string code)
        {
            if (code.Length < 7)
                code = code.PadRight(7, '0');
            string detail = code.Substring(3, 4);
            return detail;
        }

        private string standardizedEthnicity_ONEFIELD(string ethnicity)
        {
            if (ethnicity == "ASIAN")
                return "122222";
            if (ethnicity == "BLACK")
                return "212222";
            if (ethnicity == "HISPA")
                return "221222";
            if (ethnicity == "AMIND")
                return "222122";
            if (ethnicity == "WHITE")
                return "222212";
            if (ethnicity == "HAWI")
                return "222221";
            else
                return "000000";


        }

        private string standardizedEthnicity(string ethGroupCode)
        {
            char[] ethnicity = { '2', '2', '2', '2', '2', '2' };
            //Ethnicity Group codes are defined in the PeopleSoft Table Ethnic_GRP_TBL
            //This method converts those codes into a 6 character string as required by ADHE
            string ethnicityString = "";

            if (ethGroupCode == "4")
                ethnicity[0] = '1';
            if (ethGroupCode == "2")
                ethnicity[1] = '1';
            if (ethGroupCode == "3")
                ethnicity[2] = '1';
            if (ethGroupCode == "5")
                ethnicity[3] = '1';
            if (ethGroupCode == "1")
                ethnicity[4] = '1';
            ethnicity[5] = '2'; //no hawaiian field defined in peoplesoft
 

            //convert char[] to string
            foreach (char ch in ethnicity)
                ethnicityString += ch;

            return ethnicityString;
        }

        private string standardizedHSCode(string hsCode)
        {
            //if school name is in lookup table, return code
            //if it can be converted to an Int32, then it is likely a code already, return it
            //else, return 000000
            if (HSLookup.ContainsKey(hsCode))
              return HSLookup[hsCode];
            try
            {
                Int32 code = Convert.ToInt32(hsCode);
                return code.ToString().PadLeft(6,'0');
            }
            catch
            {
                return "000000";  //Code Not Found in HSLookup Dictionary...add failed code to dictionary near top of this listing
            }
        }

        private string standardizedHSGPA(string hsgpa)
        {
            if (hsgpa.Length > 0)
            {
                return hsgpa.Replace(".", "").PadRight(4,'0');
            }
            else
            {
                return "0000";
            }
        }

        private TopGrades getGrades(string studentID)
        {
            studentID = studentID.Trim(); //get rid of any trailing spaces
            //find all the grades in the master list that belong to the specified student
            List<TestGrade> StudentsGrades = new List<TestGrade>(); //all this students grades (from master test grade list)
            List<TestGrade> ACTGrades = new List<TestGrade>();
            List<TestGrade> ACTReadGrades = new List<TestGrade>();
            List<TestGrade> ACTEnglGrades = new List<TestGrade>();
            List<TestGrade> ACTMathGrades = new List<TestGrade>();
            //create sub lists for COMPASS -- PALGP, READ, ALGP, ALG, PALG, CALGP
            List<TestGrade> CompassPALGPGrades = new List<TestGrade>();
            List<TestGrade> CompassReadGrades = new List<TestGrade>();
            List<TestGrade> CompassALGPGrades = new List<TestGrade>();
            List<TestGrade> CompassALGGrades = new List<TestGrade>();
            List<TestGrade> CompassPALGGrades = new List<TestGrade>();
            List<TestGrade> CompassCALGPGrades = new List<TestGrade>();


            List<TestGrade> CompassGrades = new List<TestGrade>();
            TopGrades topGrades = new TopGrades();

            //this loop locates all grade records for the specified student and saves them in a list
            foreach (TestGrade tg in TestGradeRecords)
            {
                if (tg.CollegeID == studentID)
                    StudentsGrades.Add(tg);
            }

            //this loop locates all ACT grade records and saves them in a list
            foreach(TestGrade tg in StudentsGrades)
            {
                if (tg.TestID == "ACT")
                    ACTGrades.Add(tg);
            }

            //this loop locates all COMPASS grade records and saves them in a list
            foreach (TestGrade tg in StudentsGrades)
            {
                if (tg.TestID == "COMPASS")
                    CompassGrades.Add(tg);
            }

            //create sub lists for ACT -- Read, Engl and Math scores
            if (ACTGrades.Count > 0)
            {
                topGrades.ACTGrades = true;

                foreach (TestGrade tg in ACTGrades)
                {
                    if (tg.Component == "READ")
                        ACTReadGrades.Add(tg);
                    if (tg.Component == "ENGL")
                        ACTEnglGrades.Add(tg);
                    if (tg.Component == "MATH")
                        ACTMathGrades.Add(tg);
                }

                //step through each sublist, update the highest score
                foreach(TestGrade tg in ACTReadGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.ACTRead)
                        topGrades.ACTRead = Convert.ToDouble(tg.Score);                    
                }
                foreach (TestGrade tg in ACTEnglGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.ACTEnglish)
                        topGrades.ACTEnglish = Convert.ToDouble(tg.Score);
                }
                foreach (TestGrade tg in ACTMathGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.ACTMath)
                        topGrades.ACTMath = Convert.ToDouble(tg.Score);
                }


            }

            //create sub lists for COMPASS -- PALGP, READ, ALGP, ALG, PALG, CALGP
            if (CompassGrades.Count > 0)
            {
                topGrades.CompassGrades = true;

                foreach (TestGrade tg in CompassGrades)
                {
                    if (tg.Component == "PALGP")
                        CompassPALGPGrades.Add(tg);
                    if (tg.Component == "READ")
                        CompassReadGrades.Add(tg);
                    if (tg.Component == "ALGP")
                        CompassALGPGrades.Add(tg);
                    if (tg.Component == "ALG")
                        CompassALGGrades.Add(tg);
                    if (tg.Component == "PALG")
                        CompassPALGGrades.Add(tg);
                    if (tg.Component == "CALGP")
                        CompassCALGPGrades.Add(tg);
                }

                //step through each sublist, update the highest score in topGrades
                foreach (TestGrade tg in CompassPALGPGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.CompassPALGP)
                        topGrades.CompassPALGP = Convert.ToDouble(tg.Score);
                }
                foreach (TestGrade tg in CompassReadGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.CompassRead)
                        topGrades.CompassRead = Convert.ToDouble(tg.Score);
                }
                foreach (TestGrade tg in CompassALGPGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.CompassALGP)
                        topGrades.CompassALGP = Convert.ToDouble(tg.Score);
                }
                foreach (TestGrade tg in CompassALGGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.CompassALG)
                        topGrades.CompassALG = Convert.ToDouble(tg.Score);
                }
                foreach (TestGrade tg in CompassPALGGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.CompassPALG)
                        topGrades.CompassPALG = Convert.ToDouble(tg.Score);
                }
                foreach (TestGrade tg in CompassCALGPGrades)
                {
                    if (Convert.ToDouble(tg.Score) > topGrades.CompassCALGP)
                        topGrades.CompassCALGP = Convert.ToDouble(tg.Score);
                }

            }
            return topGrades;

        }

        private int DateToAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            return age;
        }

        private string standardizedHSGradYear(string text)
        {
            try
            {
                int year = Convert.ToInt16(text);
                return year.ToString().PadLeft(4,'0');
            }
            catch
            {
                return "0000";
            }

        }

        private string standardizeTuitionStatus(string status)
        {
            if (status == "INDS")
                return "2";
            if (status == "OUTDS")
                return "3";
            else
                return "X";
        }

        private string standardizeCountyOfOrgin(string county)
        {
            if (county == "Garland")
                return "026";
            if (county == "Pike")
                return "055";
            if (county == "Montgomery")
                return "049";
            if (county == "Hot Spring")
                return "030";
            if (county == "Saline")
                return "062";
            if (county == "CLARK" || county == "Clark")
                return "010";
            if (county == "Pulaski")
                return "060";
            if (county == "Crawford")
                return "017";
            if (county == "Dallas")
                return "020";
            if (county == "Drew")
                return "022";
            if (county == "Faulkner")
                return "023";
            if (county == "Hot Springs")
                return "030";
            if (county == "Howard")
                return "031";
            if (county == "Lawerence")
                return "038";
            if (county == "Lonoke")
                return "043";
            if (county == "Madison")
                return "044";
            if (county == "Nevada")
                return "050";
            if (county == "Perry")
                return "053";
            if (county == "Washington")
                return "072";
            if (county == "Yell")
                return "075";

            return "000";
        }

    }
}
