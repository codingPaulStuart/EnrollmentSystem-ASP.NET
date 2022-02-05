using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel
{
    // Set up all Queries here as static methods that get called from the static class SPSQueries,
    // No need to instantiate, simply call the class and which ever method you need
    public static class DAO_SPSQuery
    {

        // Insert into the Competency Table
        public static string InsertCompetency(string tafeCompCode, string nationalComp, string compName, string hours)
        {
            string query = "INSERT INTO [db_tafebuddy].[competency]([TafeCompCode],[NationalCompCode],[CompetencyName],[Hours])VALUES('" + tafeCompCode + "', '" + nationalComp + "', '" + compName + "', " + hours + ")";
            return query;
        }

        // Update record in the Competency Table, needs the old CompCode and the new data
        public static string UpdateCompetency(string newTafeCompCode, string nationalComp, string compName, string hours, string oldTafeCompCode)
        {
            string query = "UPDATE[db_tafebuddy].[competency] SET[TafeCompCode] = '" + newTafeCompCode + "', [NationalCompCode] = '" + nationalComp + "', [CompetencyName] = '" + compName + "', [Hours] ='" + Convert.ToInt32(hours) + "' WHERE TafeCompCode = '" + oldTafeCompCode + "' ";
            return query;
        }

        // Delete record in the Competency Table, needs the CompCode
        public static string DeleteCompetency(string tafeCompCode)
        {
            string query = "DELETE FROM [db_tafebuddy].[competency] WHERE TafeCompCode = '" + tafeCompCode + "' "; 
            return query;
        }

        // Select all from the Competency Table
        public static string SelectAllCompetency()
        {
            string query = "SELECT  [TafeCompCode],[NationalCompCode],[CompetencyName] ,[Hours] FROM[db_tafebuddy].[db_tafebuddy].[competency]";
            return query;
        }

        // Search for Student Study Plan based on StudentID - Basic Search using just the Student Grade Table
        public static string FindStudyPlan(string studentNumber)
        {
            string query = "SELECT [StudentID],[CRN],[TafeCompCode],[TermCode],[TermYear],[Grade],[GradeDate], FROM[db_tafebuddy].[db_tafebuddy].[student_grade] WHERE StudentID = '" + studentNumber + "' ";
            return query;
        }




        // Pre-generated Views Functions ** THESE ARE UNDER TEST AND ARE VIEWS, NOT DIRECT QUERIES ** -------------------------------------------------------------------   

        // StudyPlan View
        public static string StudyPlanView()
        {
            string query = "SELECT  * FROM [db_tafebuddy].[dbo].[SPMainView]";
            return query;
        }
        // StudyPlan View Filtered
        public static string StudyPlanView(string studentID)
        {
            string query = "SELECT  * FROM [db_tafebuddy].[dbo].[SPMainView] WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Completed Subjects
        public static string CompletedUnitsView(string studentID)
        {
            string query = "SELECT * FROM CompletedUnitView WHERE StudentID = '" + studentID+"' ";
            return query;
        }
        // Get Student Name
        public static string StudentFullNameView(string studentID)
        {
            string query = "SELECT CONCAT(GivenName, ' ', LastName) as Name FROM StudentNameView WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get Student ID Number
        public static string StudentIDView(string studentID)
        {
            string query = "SELECT StudentID FROM StudentNameView WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get Full Student Profile View
        public static string StudentProfileView(string studentID)
        {
            string query = "SELECT * FROM StudentNameView WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get Student Award from StudyPlan
        public static string StudentAwardView(string studentID)
        {
            string query = "SELECT * FROM studentAwardView WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get Student Award Code from StudyPlan
        public static string StudentAwardCodeView(string studentID)
        {
            string query = "SELECT NationalQualCode FROM studentAwardView WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get TAFE Code from StudyPlan
        public static string TafeCodeView(string studentID)
        {
            string query = "SELECT[TafeQualCode] FROM[db_tafebuddy].[dbo].[SPMainView] WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get Qualification Code from StudyPlan
        public static string QualCodeView(string studentID)
        {
            string query = "SELECT[QualCode] FROM[db_tafebuddy].[dbo].[SPMainView] WHERE StudentID = '" + studentID + "' ";
            return query;
        }
        // Get Subject Catalog info to present in table
        public static string SubjectCatalogView()
        {
            string query = "SELECT * FROM [db_tafebuddy].[dbo].[SubjectCatalogView]";
            return query;
        }
        // Get Detailed Subject Catalog info to present in table
        public static string SubjectCatalogDetailedView()
        {
            string query = "SELECT TOP (100) * FROM [db_tafebuddy].[dbo].[SubjectCatalogDetailedView]";
            return query;
        }
        // Get Detailed Subject Catalog info to present in table - Can use WHERE Clause on this statement to filter out single award, tafeCode or Qual Name
        public static string SubjectCatalogDetailedViewFilter(string NatQualCode)
        {
            string query = "SELECT TOP (50) * FROM [db_tafebuddy].[dbo].[SubjectCatalogDetailedView] WHERE NationalQualCode = '" + NatQualCode + "' ";
            return query;
        }

        // JSON and Stored Procedure Queries
        public static string GetStudentsCompletedSubjects(string studentID)
        {
            string query = "EXEC GetStudentsCompletedSubjects @StudentID = '" + studentID + "' ";
            return query;
        }

        // Query of Getting subject name by subject ID  ** Jiawei 01/11/2021

        public static string GetStudentSubjectBySubjectCode(string subjectCode)
        {
            string query = "SELECT [SubjectDescription] FROM [db_tafebuddy].[subject] WHERE [SubjectCode] = '" + subjectCode + "'";
            return query;

        }


        public static string GetStudentGrade(string studentID)
        {
            string query = "SELECT * FROM [db_tafebuddy].[student_grade] WHERE StudentID = '" + studentID + "'";
            return query;
        }




































    }
}
