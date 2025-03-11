using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStudentPicker.Models
{
    internal class AllClassLists
    {
        public static ObservableCollection<ClassList> ClassLists { get; set; } = new();
        public static int LuckyNumber { get; set; }

        public AllClassLists()
        {
            //Bez ustawienia w pliku strony że bindingcontext to nowy obiekt tej klasy ten konstruktor się nie wykona
            //ClassLists.Add(new ClassList("1A")); 
            //ClassLists.Add(new ClassList("2A"));
            //ClassLists.Add(new ClassList("3A"));
        }
    }
}
