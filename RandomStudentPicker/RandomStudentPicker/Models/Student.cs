using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStudentPicker.Models
{
    public class Student : INotifyPropertyChanged
    {
        //public static int LastNumber { get; set; } = 0;
        public int Number { get; set; }

        private string _firstName;
        private string _lastName;
        private bool _isPresent;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public bool IsPresent
        {
            get => _isPresent;
            set
            {
                if (_isPresent != value)
                {
                    _isPresent = value;
                    OnPropertyChanged(nameof(IsPresent));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Student()
        {
            //LastNumber++;
            //Number = LastNumber;
        }

        public Student(string firstName, string lastName, bool isPresent)
        {
            FirstName = firstName;
            LastName = lastName;
            IsPresent = isPresent;
            //LastNumber++;
            //Number = LastNumber;
        }
    }
}