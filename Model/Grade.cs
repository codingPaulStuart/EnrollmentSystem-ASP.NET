using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using spsModel.Model;

/// <summary>
/// Author: Jaiwei Huang
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel
{
    public class Grade
    {
        public string StudentId;
        public string Crn;
        public Subject subject;
        public string TafeCompCode;
        public string TermCode;
        public string TermYear;
        public string AcademicResult;
        public DateTime GradeDate;



        //getters

        public string getStudentID()
        {
            return this.StudentId;
        }

        public string GetCrn()
        {
            return this.Crn;
        }

        public string GetTafecopCode()
        {
            return this.TafeCompCode;
        }

        public string GetTermCode()
        {
            return this.TermCode;
        }

        public string GetTermYear()
        {
            return this.TermYear;
        }

        public string GetAcademicResult()
        {
            return this.AcademicResult;
        }

        public DateTime GetGradeDate()

        {
            return this.GradeDate;
        }


        public Grade(string studentId, string crn, string tafeCompCode, string termCode, string termYear, string academicResult, DateTime gradeDate)

        {
            this.StudentId = studentId;
            this.Crn = crn;
            this.TafeCompCode = tafeCompCode;
            this.TermCode = termCode;
            this.TermYear = termYear;
            this.AcademicResult = academicResult;
            this.GradeDate = gradeDate;
        }






        public Grade() { }

        public DataTable getGradeDataTable(string studentId)
        {

            //Pass in a student ID and get a datatable from database **** Maybe it should under Student Class****
            DataTable dt = DAO_SPS.GetDataTableRecord(DAO_SPSQuery.GetStudentGrade(studentId)); // Put any of these Database structure classes under the DAO package (Paul)

            return dt;
        }

        public static bool operator ==(Grade x, Grade y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(Grade x, Grade y)
        {
            return !object.Equals(x, y);
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Grade targetGrade = obj as Grade;
            return this.TafeCompCode == targetGrade.TafeCompCode;
        }

        public override int GetHashCode()
        {
            int hashcode = this.StudentId.GetHashCode() ^ this.TafeCompCode.GetHashCode() ^ this.AcademicResult.GetHashCode();
            return hashcode;
        }

    }

}