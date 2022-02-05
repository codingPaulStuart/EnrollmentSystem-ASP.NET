using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spsModel.Model;
using spsModel.DAO;

namespace spsModel
{
    class Program
    {

        static void Main(string[] args)
        {
            /// StudyPlan Class Testing
            /// Author Paul Stuart
            /// 

            // Data Testing for Classes can be done here
            DaoSps daoSpsTest = new DaoSps();

            // Create units of competency to go into the Award Units List Variable ----------------------------------------------------
            UnitsOfComptency unit1 = new UnitsOfComptency();
            unit1.NationalCode = "ICADMT403A";
            unit1.SubjectName = "Produce and edit digital images";
            unit1.SubjectDescription = "used in the digital media courses and uses photoshop etc";

            UnitsOfComptency unit2 = new UnitsOfComptency();
            unit2.NationalCode = "ICAGAM301A";
            unit2.SubjectName = "Apply simple modelling techniques";
            unit2.SubjectDescription = "used in the digital media courses for multimedia modelling methods";

            UnitsOfComptency unit3 = new UnitsOfComptency();
            unit3.NationalCode = "ICADMT401A";
            unit3.SubjectName = "Create visual design components for digital media";
            unit3.SubjectDescription = "used in the digital media courses for VS design techniques";

            UnitsOfComptency unit4 = new UnitsOfComptency();
            unit4.NationalCode = "ICADMT501A";
            unit4.SubjectName = "Incorporate and edit digital video";
            unit4.SubjectDescription = "used in the digital media courses for editing videos";

            List<UnitsOfComptency> digitalMediaUnits = new List<UnitsOfComptency>();
            digitalMediaUnits.Add(unit1);
            digitalMediaUnits.Add(unit2);
            digitalMediaUnits.Add(unit3);
            digitalMediaUnits.Add(unit4);

            Award AdvDipComputerSystems = new Award();

            AdvDipComputerSystems.AwardID = "ICA60511";
            AdvDipComputerSystems.AwardName = "Advanced Diploma of Computer Systems Technology";
            AdvDipComputerSystems.UnitsList = digitalMediaUnits;

            // Create Subjects then put into a list and add to the study plan subject List Variable ----------------------------------------------------
            Subject subjectTest1 = new Subject();
            subjectTest1.subjectCode = "2IOS";
            subjectTest1.subjectDescription = "Install and Optimise Software";
            
            Subject subjectTest2 = new Subject();
            subjectTest2.subjectCode = "4CYWEB";
            subjectTest2.subjectDescription = "Website security";

            List<UnitsOfComptency> tempSubjectList = new List<UnitsOfComptency>();
            tempSubjectList.Add(unit1);
            tempSubjectList.Add(unit2);

            subjectTest1.units = tempSubjectList;

            List<UnitsOfComptency> tempSubjectList2 = new List<UnitsOfComptency>();
            tempSubjectList2.Add(unit3);
            tempSubjectList2.Add(unit4);

            subjectTest2.units = tempSubjectList2;

            List<Subject> subjectList = new List<Subject>();
            subjectList.Add(subjectTest1);
            subjectList.Add(subjectTest2);

            Person personPaul = new Person("Paul", "Stuart", "paulstuart1980@gmail.com");

            Student Paul = new Student("000389223", personPaul);

            StudyPlan studyPlanTest = new StudyPlan();

            studyPlanTest.CreateStudyPlan(Paul);
            studyPlanTest.studentAward = AdvDipComputerSystems;
            studyPlanTest.awardSubjects = subjectList;

            // Output for a created StudyPlan Object ----------------------------------------------------
            Console.WriteLine("\nOutput created StudyPlan Object ----------------------------------------------------------------------------------\n");

            Console.WriteLine("StudyPlan Code = " + studyPlanTest.StudyPlanCode);
            Console.WriteLine("Student Name = " + studyPlanTest.student.FirstName + studyPlanTest.student.LastName);
            Console.WriteLine("Student Email = " + studyPlanTest.student.Email);
            Console.WriteLine("Award Code = " + studyPlanTest.studentAward.AwardID);
            Console.WriteLine("Award Name = " + studyPlanTest.studentAward.AwardName);
            Console.WriteLine("\n --- Subject Listing for: " + studyPlanTest.studentAward.AwardName);
            PrintData.printSubjectList(studyPlanTest.awardSubjects);
            Console.WriteLine("\n --- Units of Competency in the Award: " + studyPlanTest.studentAward.AwardName);
            PrintData.printUnitComp(studyPlanTest.studentAward.UnitsList);

            // Output for a retrieved StudyPlan created from DB ----------------------------------------------------
            Console.WriteLine("\n\n\nOutput retrieved StudyPlan from DB mapped to StudyPlan List<Grade> Objects ----------------------------------------------------------------------------------\n");

            StudyPlan retrievedSP = new StudyPlan();
            retrievedSP.completedSubjects = daoSpsTest.GetStudentGrades("000896534");
            retrievedSP.student = daoSpsTest.GetStudentProfile("000896534");
            retrievedSP.studentAward = daoSpsTest.GetStudentAward("000896534");
            Console.WriteLine("\n--" + retrievedSP.student.FirstName + " " + retrievedSP.student.LastName + " Student Number: " + retrievedSP.student.StudentID);
            Console.WriteLine("--Course Award: " + retrievedSP.studentAward.AwardName);
            Console.WriteLine("--Course Award Code: " + retrievedSP.studentAward.AwardID);


            PrintData.printGradesList(retrievedSP.completedSubjects);
            

            // --------------------------------------------------------------------------------------------------------------------------
            /// DataBase Testing
            /// Author Paul Stuart        

            // Student IDs for testing Queries
            string Martin = "000724247";
            string Sally = "000896534";

            // Qual Codes for Testing the Subject Catalog
            string NatQual1 = "ICT40515";
            string NatQual2 = "ICA10111";

            // Output for the StudyPlan Main View
            Console.WriteLine("\nOutput for the StudyPlan Main View -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.StudyPlanView()));

            // Output for the Students Unit View using StudentID
            Console.WriteLine("\nOutput Students Unit View using StudentID -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.CompletedUnitsView(Sally)));
            Console.WriteLine("\nOutput Students Unit View using StudentID 2 -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.CompletedUnitsView(Martin)));

            // Output for Students Award based on Student ID
            Console.WriteLine("\nStudents Award Details based on Student ID -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.StudentAwardView(Sally)));
            Console.WriteLine("\nStudents Award Details based on Student ID -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.StudentAwardView(Martin)));

            // Output for Students Completed Units based on Student ID
            Console.WriteLine("\nStudents Completed Units based on Student ID -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.GetStudentGrade(Sally)));
            Console.WriteLine("\nStudents Completed Units based on Student ID -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.GetStudentGrade(Martin)));

            // Output for Subject Catalog with Detailed view with a national code paramater
            Console.WriteLine("\nOutput (top 50) Subject Catalog with Detailed view with a national code paramater -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.SubjectCatalogDetailedViewFilter(NatQual1)));
            Console.WriteLine("\nOutput (top 50) Subject Catalog with Detailed view with a national code paramater -----------------------------------------\n");
            PrintData.dataPrint(daoSpsTest.GetTableRecord(DAO_SPSQuery.SubjectCatalogDetailedViewFilter(NatQual2)));

            Console.ReadLine();
        }
    }
}
