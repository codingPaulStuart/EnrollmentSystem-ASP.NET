using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spsModel.DAO;
using Newtonsoft.Json;
using spsModel.Model;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel.DAO
{
    class DaoSps : IDaoSPS
    {
        // Author - Paul Stuart 2021
        public void ExecuteQuery(string query)
        {
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet GetDataSet(string query)
        {
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                return ds;
            }
        }

        public DataTable GetTableRecord(string query)
        {
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        // Retrieve DataTable based on a query to get completed Grade Objects, return as a List
        public List<Grade> GetStudentGrades(string studentID)
        {
            string query = DAO_SPSQuery.CompletedUnitsView(studentID);
            List<Grade> subjectList = new List<Grade>();
            DataTable dt = GetTableRecord(query);

            // Iterate through the DT and add to the List of Subjects
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Grade grade = new Grade();
                Subject subject = new Subject();
                grade.StudentId = dt.Rows[i]["StudentID"].ToString();
                grade.Crn = dt.Rows[i]["CRN"].ToString();
                grade.AcademicResult = dt.Rows[i]["Grade"].ToString();
                grade.GradeDate = Convert.ToDateTime(dt.Rows[i]["GradeDate"]);
                grade.TermCode = dt.Rows[i]["TermCode"].ToString();
                grade.TermYear = dt.Rows[i]["TermYear"].ToString();
                grade.TafeCompCode = dt.Rows[i]["TafeCompCode"].ToString();

                subject.subjectCode = dt.Rows[i]["SubjectCode"].ToString();
                subject.subjectDescription = dt.Rows[i]["CompetencyName"].ToString();
                grade.subject = subject;

                subjectList.Add(grade);
            }
            return subjectList;
        }

        // Get the Name of the Students Award they are studying
        public Award GetStudentAward(string studentID)
        {
            Award tempAward = new Award();
            string query = DAO_SPSQuery.StudentAwardView(studentID);
            DataTable dt = GetTableRecord(query);

            // Set the Award object attributes from the DT record retrieved
            tempAward.AwardID = dt.Rows[0]["NationalQualCode"].ToString();
            tempAward.AwardName = dt.Rows[0]["Expr1"].ToString();
           
           return tempAward;
        }

        // Get the Student Profile, return as an Object
        public Student GetStudentProfile(string studentID)
        {
            Student student = new Student();
            string query = DAO_SPSQuery.StudentProfileView(studentID);
            DataTable dt = GetTableRecord(query);

            // Set the Student Object Attributes from the DB result set
            student.FirstName = dt.Rows[0]["GivenName"].ToString();
            student.LastName = dt.Rows[0]["LastName"].ToString();
            student.StudentID = dt.Rows[0]["StudentID"].ToString();

            return student;
        }

        public string GetDataSingleValue(string query)
        {
            string returnString;
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                returnString = cmd.ExecuteScalar().ToString();
                con.Close();
                return returnString;
            }
        }

        // Always call this first to get a JSON file from the stored procedure in the DB, put into a List and return
        public List<string> GetJSONStudyPlan(string studentID)
        {
            List<string> StudyPlanJSON = new List<string>();
            string query = DAO_SPSQuery.GetStudentsCompletedSubjects(studentID);
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                StudyPlan sp = new StudyPlan();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // JsonConverter();
                string JSONresult = JsonConvert.SerializeObject(sp);
                string path = @"C:\Users\Public\Documents\json\employee.json";

                return StudyPlanJSON;
            }
        }

        // Get Full JSON Data Set with the subject listings Catalog
        public List<string> GetJSONSubjectList()
        {
            List<string> subjectList = new List<string>();

            return subjectList;
        }

        //Get Subject Description by Subject Code  ** Jiawei 01/11/2021
        public string GetSubjectDescritpionBySubjectCode(string subjectCode)
        {
            string subjectDescription = GetDataSingleValue(DAO_SPSQuery.GetStudentSubjectBySubjectCode(subjectCode));
            return subjectDescription;

        }

        //Get GetStudentGrade  **Jiawei 05/11/2021
        public static string GetStudentGrade(string studentID)
        {
            string query = "SELECT [StudentID],[CRN],[TafeCompCode],[TermCode],[TermYear],[Grade],[GradeDate] FROM [db_tafebuddy].[student_grade] WHERE StudentID = '" + studentID + "'";
            return query;
        }

        // Send SP to the Database
        public void CommitSPData(StudyPlan completedSP)
        {
            throw new NotImplementedException();
        }

    }
}