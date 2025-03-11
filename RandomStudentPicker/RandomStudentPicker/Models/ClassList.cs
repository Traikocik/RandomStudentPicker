using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomStudentPicker.Models
{
    public class ClassList
    {
        public ObservableCollection<Student> Students { get; set; } = [];
        public int[] AskedStudentsNumbers = [-1, -1, -1];
        public string Name { get; set; }

        public ClassList(string name)
        {
            Name = name;
        }

        public void SetStudentsFromElement(XElement studentsElement)
        {
            ObservableCollection<Student> students = new();

            foreach (XElement studentElement in studentsElement.Elements("Student"))
            {
                int number = int.Parse(studentElement.Attribute("Number").Value);
                string firstName = studentElement.Attribute("FirstName").Value;
                string lastName = studentElement.Attribute("LastName").Value;
                bool isPresent = bool.Parse(studentElement.Attribute("IsPresent").Value);

                Student student = new Student(firstName, lastName, isPresent) { Number = number };
                students.Add(student);
            }

            Students = students;
        }

        public void SetAskedStudentsNumbersFromElement(XElement askedStudentsNumbersElement)
        {
            int[] askedStudentsNumbers = [-1, -1, -1];

            for (int i = 0; i < askedStudentsNumbers.Length; i++)
            {
                askedStudentsNumbers[i] = int.Parse(askedStudentsNumbersElement.Elements("AskedStudentsNumber").ElementAt(i).Value);
            }

            AskedStudentsNumbers = askedStudentsNumbers;
        }

        public XElement GetElementFromStudents()
        {
            XElement studentsElement = new XElement("Students");

            foreach (var student in Students)
            {
                XElement studentElement = new XElement("Student",
                    new XAttribute("Number", student.Number),
                    new XAttribute("FirstName", student.FirstName),
                    new XAttribute("LastName", student.LastName),
                    new XAttribute("IsPresent", student.IsPresent));

                studentsElement.Add(studentElement);
            }

            return studentsElement;
        }

        public XElement GetElementFromAskedStudentsNumbers()
        {
            XElement askedStudentsNumbersElement = new XElement("AskedStudentsNumbers");

            XElement askedStudentsNumberElement0 = new XElement("AskedStudentsNumber", AskedStudentsNumbers[0]);
            XElement askedStudentsNumberElement1 = new XElement("AskedStudentsNumber", AskedStudentsNumbers[1]);
            XElement askedStudentsNumberElement2 = new XElement("AskedStudentsNumber", AskedStudentsNumbers[2]);

            askedStudentsNumbersElement.Add(askedStudentsNumberElement0);
            askedStudentsNumbersElement.Add(askedStudentsNumberElement1);
            askedStudentsNumbersElement.Add(askedStudentsNumberElement2);

            return askedStudentsNumbersElement;
        }
    }
}
