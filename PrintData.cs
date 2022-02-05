using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spsModel.Model;

namespace spsModel
{
    public static class PrintData
    {
        // DataTable Output Method for testing
        public static void dataPrint(DataTable data)
        {
            Console.WriteLine();
            Dictionary<string, int> colWidths = new Dictionary<string, int>();

            foreach (DataColumn col in data.Columns)
            {
                Console.Write(col.ColumnName);
                var maxLabelSize = data.Rows.OfType<DataRow>()
                        .Select(m => (m.Field<object>(col.ColumnName)?.ToString() ?? "").Length)
                        .OrderByDescending(m => m).FirstOrDefault();

                colWidths.Add(col.ColumnName, maxLabelSize);
                for (int i = 0; i < maxLabelSize - col.ColumnName.Length + 10; i++) Console.Write(" ");
            }
            Console.WriteLine();

            foreach (DataRow dataRow in data.Rows)
            {
                for (int j = 0; j < dataRow.ItemArray.Length; j++)
                {
                    Console.Write("-" + dataRow.ItemArray[j]);
                    for (int i = 0; i < colWidths[data.Columns[j].ColumnName] - dataRow.ItemArray[j].ToString().Length + 10; i++) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static void printSubjectList(List<Subject> list)
        {
            foreach (Subject subject in list) // Loop through List with foreach
            {
                Console.WriteLine("\n- Subject Code: " + subject.subjectCode + ", Description:  " + subject.subjectDescription);
                foreach (UnitsOfComptency unit in subject.units)
                {
                    Console.WriteLine("----- Unit Name: " + unit.SubjectName + ", National Code: " + unit.NationalCode);
                }             
            }
        }

        public static void printGradesList(List<Grade> gradeList)
        {
            Console.WriteLine("\n");
            foreach (Grade grade in gradeList)
            {
                Console.WriteLine(" -" + grade.subject.subjectCode + ", " + " Grade = " + grade.AcademicResult + ", " +  grade.GradeDate );
            }
        }

        public static void printUnitComp(List<UnitsOfComptency> unitsList)
        {
            Console.WriteLine("\n");
            foreach (UnitsOfComptency uoc in unitsList)
            {
                Console.WriteLine(uoc.NationalCode + ", Name = " + uoc.SubjectName + ", Description = " + uoc.SubjectDescription);
            }
        }




    }
}
