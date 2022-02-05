using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spsModel.Model;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel
{
    public interface IStudyPlan
    {
       
        StudyPlan CreateStudyPlan(Student newStudent);
        void CommitStudyPlan(StudyPlan sp);
    }
}