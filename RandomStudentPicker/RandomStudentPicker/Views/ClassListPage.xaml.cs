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
        await Navigation.PushAsync(new ModifyStudentPage((ClassList)BindingContext));
    }

    private async void DrawStudent_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DrawRandomStudentPage((ClassList)BindingContext));
    }

    private async void StudentCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var student = (Student)e.CurrentSelection[0];
            await Navigation.PushAsync(new ModifyStudentPage((ClassList)BindingContext, student));
            StudentCollection.SelectedItem = null;
        }
    }

    private void RemoveButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton imageButton && imageButton.BindingContext is Student studentToBeDeleted)
        {
            ClassList classList = ((ClassList)BindingContext);
            classList.Students.Remove(studentToBeDeleted);
            classList.Students.Where(s => s.Number > studentToBeDeleted.Number).ToList().ForEach(s => { s.Number--; });
            for (int i = 0; i < classList.AskedStudentsNumbers.Length; i++)
            {
                if (classList.AskedStudentsNumbers[i] > studentToBeDeleted.Number)
                {
                    classList.AskedStudentsNumbers[i]--;
                }
                else if (classList.AskedStudentsNumbers[i] == studentToBeDeleted.Number)
                {
                    classList.AskedStudentsNumbers[i] = -1;
                }
            }
            AllClassLists.SaveClassLists();
        }
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        AllClassLists.SaveClassLists();
    }
}