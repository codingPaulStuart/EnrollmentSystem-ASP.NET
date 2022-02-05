using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spsModel.Model;
using spsModel.DAO;

namespace spsModel
{
    /// <summary>
    /// Author: Paul Stuart
    /// Date Created: 12/11/2021
    /// </summary>
 
    [Serializable]
    public class StudyPlan : IStudyPlan
    {
        // Variables ---------------------------------------------------------------
        public int StudyPlanCode;
        public Award studentAward;
        public Student student;
        public Lecturer studyPlanCounsellor;
        public List<Grade> completedSubjects;
        public List<Subject> awardSubjects;
        public List<CRN> cRNs;

        // Data Access Class for transfering
        DaoSps daoSps = new DaoSps();

        // The StudyPlan gets written to in different sections so there is no real instance where you will need a full All-args constructor
        public StudyPlan()
        {
        }


        // Methods ---------------------------------------------------------------
        public StudyPlan CreateStudyPlan(Student newStudent)
        {
            StudyPlan studyPlan = new StudyPlan();
            GenerateSPCode();
            student = newStudent;
   
            return studyPlan;
        }

        // TODO
        public void CommitStudyPlan(StudyPlan sp)
        {
            daoSps.CommitSPData(sp);
        }

        public void GenerateSPCode()
        {
            Random random = new Random(); 
            StudyPlanCode =  random.Next(100000, 199999);
        }

      
    }
}