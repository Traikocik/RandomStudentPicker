using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomStudentPicker.Models
{
    internal class AllClassLists
    {
        public static ObservableCollection<ClassList> ClassLists { get; set; } = new();
        public static int LuckyNumber { get; set; }
        private static string ClassListsFileName = Path.Combine(FileSystem.AppDataDirectory, "classLists.txt");

        public AllClassLists()
        {
            LoadClassLists();
        }

        public static void LoadClassLists()
        {
            if (File.Exists(ClassListsFileName))
            {
                ClassLists.Clear();

                var doc = XDocument.Load(ClassListsFileName);
                var rootElement = doc.Root;

                if (rootElement != null)
                {
                    var classListsElement = rootElement.Element("ClassLists");
                    if (classListsElement != null)
                    {
                        foreach (var classListElement in classListsElement.Elements("ClassList"))
                        {
                            string name = classListElement.Attribute("Name").Value;
                            ClassList classList = new ClassList(name);
                            classList.SetStudentsFromElement(classListElement.Element("Students"));
                            classList.SetAskedStudentsNumbersFromElement(classListElement.Element("AskedStudentsNumbers"));
                            ClassLists.Add(classList);
                        }
                    }
                }
            }
        }

        public static void SaveClassLists()
        {
            var rootElement = new XElement("ClassListsAppData");

            var classListsElements = new XElement("ClassLists");
            foreach (var classList in ClassLists)
            {
                XElement studentsElement = new XElement(classList.GetElementFromStudents());
                XElement askedStudentsNumbersElement = new XElement(classList.GetElementFromAskedStudentsNumbers());
                var classListsElement = new XElement("ClassList",
                    new XAttribute("Name", classList.Name),
                    studentsElement,
                    askedStudentsNumbersElement);
                classListsElements.Add(classListsElement);
            }
            rootElement.Add(classListsElements);

            var doc = new XDocument(rootElement);
            doc.Save(ClassListsFileName);
        }
    }
}
