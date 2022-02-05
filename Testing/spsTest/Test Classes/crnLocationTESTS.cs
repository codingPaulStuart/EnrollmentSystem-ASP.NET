using NUnit.Framework;
using spsModel.Model;
using spsModel;
using spsModel.Model;

namespace spsTest
{
    public class CrnLocationTESTS
    {
        private CRN crnTest;
        private CRN crnTest2;
        private CRN crnTest3;
        private CRN crnTest4;
        private Location locationTest;
        private Location locationTest2;
        private Location locationTest3;
        private Subject subjectT1;
        private Subject subjectT2;

        [SetUp]
        public void Setup()
        {
            subjectT1 = new Subject("Programming Basics", "3PRB");
            subjectT2 = new Subject("5WORK", "Develop IT project in team");

            locationTest = new Location("Adelaide", "B.001");
            locationTest2 = new Location("Adelaide", "B.001");
            locationTest3 = new Location("Mt Barker", "A.113");

            crnTest = new CRN(567, subjectT1, 2, 2022, "3-Feb-2022", locationTest, "Dale Van Heer");
            crnTest2 = new CRN(747, subjectT2, 2, 2022, "3-Feb-2022", locationTest2, "Dale Van Heer");
            crnTest3 = new CRN(459, subjectT1, 2, 2022, "3-Feb-2022", locationTest, "Dale Van Heer");
            crnTest4 = new CRN(459, subjectT1, 2, 2022, "3-Feb-2022", locationTest, "Roberto Cevallos");
        }

        [Test] // Paul Stuart 11.11.21
        public void getCRNCodeTest()
        {
            Assert.AreEqual(567, crnTest.getCrnCode());
        }

        [Test] // Paul Stuart 11.11.21
        public void compareEqualCRN()
        {
            Assert.AreNotEqual(crnTest2.getCrnCode(), crnTest4.getCrnCode());
        }

        [Test] // Paul Stuart 11.11.21
        public void compareEqualOveride()
        {
            Assert.AreEqual(false, crnTest3.Equals(crnTest4));
            Assert.AreNotEqual(crnTest3, crnTest4);
        }

        [Test] // Paul Stuart 11.11.21
        public void getLocationTest()
        {
            Assert.AreEqual(locationTest2, crnTest.getClassDetails());
        }

        [Test] // Paul Stuart 11.11.21
        public void getCampusTest()
        {
            Assert.AreEqual("Mt Barker", locationTest3.getCampus());
        }

        [Test] // Paul Stuart 11.11.21
        public void getRoomNumTest()
        {
            Assert.AreEqual("B.001", locationTest2.getRoomNumner());
        }

       
    }
}