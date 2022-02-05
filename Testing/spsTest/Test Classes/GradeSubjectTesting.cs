using NUnit.Framework;
using spsModel;
using spsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using spsModel.Model;

namespace spsTest
{

    [TestFixture]
    public class SubjectTesting
    {
        
        private Subject subject1;
        private Subject subject2;
        private Subject subject3;
        private Subject subject4;


        [SetUp]
        public void Setup()
        {
            subject1 = new Subject("C#Base", "123");
            subject2 = new Subject("C#web", "321");
            subject3 = new Subject("C#Mobile", "231");
            subject4 = new Subject("C#Base", "123");
        }

        [Test]
        public void SubjectGetterTest()
        {
            Assert.AreEqual("C#Base", subject1.subjectDescription);
            Assert.AreEqual("321", subject2.subjectCode);
        }

        [Test]
        public void SubjectSetterTest()
        {
            subject2.subjectDescription = "C#Base";
            subject3.subjectCode = "321";
            Assert.AreEqual("C#Base", subject2.subjectDescription);
            Assert.AreEqual("321", subject3.subjectCode);
        }

        [Test]
        public void SubjectEqualTest()
        {
            Assert.True(subject4.Equals(subject1));
            Assert.False(subject2.Equals(subject3));
            Assert.True(subject1 != subject3);
            Assert.False(subject4 == subject2);

        }
    }

    [TestFixture]
    public class GradeTesting
    {

        private Grade grade1;
        private Grade grade2;
        private Grade grade3;
        private Grade grade4;



        [SetUp]
        public void Setup()
        {

            grade1 = new Grade("001122322", "5238", "3a23", "S2", "2021", "PA", DateTime.Parse("Jan 1, 2020"));
            grade2 = new Grade("001122312", "5238", "3a20", "S1", "2021", "P", DateTime.Parse("July 1, 2020"));
            grade3 = new Grade("001155531", "1238", "3a26", "S1", "2021", "P", DateTime.Parse("August 1, 2020"));
            grade4 = new Grade("001155531", "1238", "3a26", "S1", "2021", "P", DateTime.Parse("August 1, 2020"));

        }

        [Test]

        public void GradeGetterTest()
        {
            Assert.AreEqual("001122322", grade1.getStudentID());
            Assert.AreEqual("5238", grade2.GetCrn());
            Assert.AreEqual("3a26", grade3.GetTafecopCode());
            Assert.AreEqual("P", grade4.GetAcademicResult());


        }

        [Test]
        public void GradeEqualTest()
        {
            Assert.False(grade1.Equals(grade2));
            Assert.True(grade3.Equals(grade4));
            Assert.True(grade3 != grade2);
            Assert.False(grade2 == grade1);
        }

    }


}