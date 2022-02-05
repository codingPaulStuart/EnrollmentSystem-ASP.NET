using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spsModel.Model;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel.DAO
{
  
    interface IDaoSPS
    {
        Student GetStudentProfile(string studentID);
        DataTable GetTableRecord(string query);
        DataSet GetDataSet(string query);
        void ExecuteQuery(string query);
        string GetDataSingleValue(string query);
        List<Grade> GetStudentGrades(string studentID);
        Award GetStudentAward(string studentID);
        List<string> GetJSONStudyPlan(string studentID);
        List<string> GetJSONSubjectList();
        void CommitSPData(StudyPlan completedSP);

    }
}
