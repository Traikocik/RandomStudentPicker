using RandomStudentPicker.Models;

namespace RandomStudentPicker.Views;

public partial class ClassListPage : ContentPage
{
	public ClassListPage()
	{
		InitializeComponent();
        //BindingContext = new ClassList();
    }

    public ClassListPage(ClassList classList)
    {
        InitializeComponent();
        BindingContext = classList;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        StudentCollection.ItemsSource = ((ClassList)BindingContext).Students;
    }

    private async void AddStudent_Clicked(object sender, EventArgs e)
    {
        Student student = new Student();
        student.Number = ((ClassList)BindingContext).Students.Count + 1;
        ((ClassList)BindingContext).Students.Add(student);
        await Navigation.PushAsync(new ModifyStudentPage(student));
    }

    //private async void AddStudent_Clicked(object sender, EventArgs e)
    //{
    //    var student = new Student();
    //    var modifyPage = new ModifyStudentPage(student);

    //    await Navigation.PushAsync(modifyPage);

    //    // Wait for ModifyStudentPage to finish, then add student to the list
    //    modifyPage.Disappearing += (s, args) =>
    //    {
    //        if (!string.IsNullOrWhiteSpace(student.FirstName) || !string.IsNullOrWhiteSpace(student.LastName))
    //        {
    //            ((ClassList)BindingContext).Students.Add(student);
    //        }
    //    };
    //}

    private async void DrawStudent_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DrawRandomStudentPage((ClassList)BindingContext));
    }

    private async void StudentCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var student = (Student)e.CurrentSelection[0];
            await Navigation.PushAsync(new ModifyStudentPage(student));
            StudentCollection.SelectedItem = null;
        }
    }

    private void RemoveButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton imageButton && imageButton.BindingContext is Student studentToBeDeleted)
        {
            ((ClassList)BindingContext).Students.Remove(studentToBeDeleted);
            
        }
    }

    //private async void StudentCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.CurrentSelection.Count != 0)
    //    {
    //        var student = (Student)e.CurrentSelection[0];
    //        var modifyPage = new ModifyStudentPage(student);

    //        await Navigation.PushAsync(modifyPage);

    //        // Wait for ModifyStudentPage to finish, then add student to the list
    //        modifyPage.Disappearing += (s, args) =>
    //        {
    //            if (!string.IsNullOrWhiteSpace(student.FirstName) || !string.IsNullOrWhiteSpace(student.LastName))
    //            {
    //                StudentCollection.ItemsSource = ((ClassList)BindingContext).Students;
    //            }
    //        };
    //        StudentCollection.SelectedItem = null;
    //    }
    //}
}