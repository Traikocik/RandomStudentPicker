using RandomStudentPicker.Models;

namespace RandomStudentPicker.Views;

public partial class ModifyStudentPage : ContentPage
{
	public ModifyStudentPage()
	{
		InitializeComponent();
        //BindingContext = new Student();
	}

    public ModifyStudentPage(Student student)
    {
        InitializeComponent();
        BindingContext = student;
    }

    //private async void SubmitButton_Clicked(object sender, EventArgs e)
    //{
    //    string firstName = FirstNameEditor.Text;
    //    string lastName = LastNameEditor.Text;
    //    bool isPresent = IsPresentCheckBox.IsChecked;

    //    ((Student)BindingContext).FirstName = firstName;
    //    ((Student)BindingContext).LastName = lastName;
    //    ((Student)BindingContext).IsPresent = isPresent;
    //    await Navigation.PopAsync();
    //}

    private async void SubmitButton_Clicked(object sender, EventArgs e)
    {
        Student student = (Student)BindingContext;

        student.FirstName = FirstNameEditor.Text;
        student.LastName = LastNameEditor.Text;
        student.IsPresent = IsPresentCheckBox.IsChecked;

        await Navigation.PopAsync();
    }
}