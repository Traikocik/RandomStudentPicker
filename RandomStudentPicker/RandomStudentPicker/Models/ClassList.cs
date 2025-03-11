using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStudentPicker.Models
{
    public class ClassList
    {
        public ObservableCollection<Student> Students { get; set; } = [];
        public int[] AskedStudents = [-1, -1, -1];
        public string Name { get; set; }

        public ClassList(string name)
        {
            this.Name = name;
        }
    }
}
