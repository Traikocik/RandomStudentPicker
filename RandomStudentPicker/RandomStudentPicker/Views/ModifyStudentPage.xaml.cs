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

        if (ParentClassList.Students.Where(s => s.Number == student.Number).Count() == 0)
        {
            ParentClassList.Students.Add(student);
        }
        else
        {
            student = ParentClassList.Students.First(s => s.Number == student.Number);
        }

        student.FirstName = FirstNameEditor.Text;
        student.LastName = LastNameEditor.Text;
        student.IsPresent = IsPresentCheckBox.IsChecked;

        AllClassLists.SaveClassLists();

        await Navigation.PopAsync();
    }
}