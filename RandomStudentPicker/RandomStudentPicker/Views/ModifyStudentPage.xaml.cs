using RandomStudentPicker.Models;

namespace RandomStudentPicker.Views;

public partial class ModifyStudentPage : ContentPage
{
    ClassList ParentClassList;

	public ModifyStudentPage()
	{
		InitializeComponent();
        //BindingContext = new Student();
	}

    public ModifyStudentPage(ClassList parentClassList, Student studentToBeEdited)
    {
        InitializeComponent();
        ParentClassList = parentClassList;
        Student student = new Student
        {
            Number = studentToBeEdited.Number,
            FirstName = studentToBeEdited.FirstName,
            LastName = studentToBeEdited.LastName,
            IsPresent = studentToBeEdited.IsPresent
        };
        BindingContext = student;
    }

    public ModifyStudentPage(ClassList parentClassList)
    {
        InitializeComponent();
        ParentClassList = parentClassList;
        Student newStudent = new()
        {
            Number = ParentClassList.Students.Count + 1
        };
        BindingContext = newStudent;
    }

    private async void SubmitButton_Clicked(object sender, EventArgs e)
    {
        Student student = (Student)BindingContext;
        string firstName = FirstNameEditor.Text;
        string lastName = LastNameEditor.Text;
        bool isPresent = IsPresentCheckBox.IsChecked;

        if (ParentClassList.Students.Where(s => s.Number == student.Number).Count() == 0)
        {
            ParentClassList.Students.Add(student);
        }
        else
        {
            student = ParentClassList.Students.First(s => s.Number == student.Number);
        }

        if (string.IsNullOrEmpty(firstName))
        {
            await DisplayAlert("WARNING!", "First name's entry is empty! Can't add new student.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(lastName))
        {
            await DisplayAlert("WARNING!", "Last name's entry is empty! Can't add new student.", "OK");
            return;
        }

        student.FirstName = firstName;
        student.LastName = lastName;
        student.IsPresent = isPresent;

        AllClassLists.SaveClassLists();

        await Navigation.PopAsync();
    }
}