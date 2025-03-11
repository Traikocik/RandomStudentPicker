using RandomStudentPicker.Models;

namespace RandomStudentPicker.Views;

public partial class AllClassListsPage : ContentPage
{
	public AllClassListsPage()
	{
		InitializeComponent();
        int seed = DateTime.UtcNow.Date.GetHashCode();
        Random random = new(seed);
        AllClassLists.LuckyNumber = random.Next(1, 35);
        //BindingContext = new AllClassLists();
        LuckyNumberLabel.Text = AllClassLists.LuckyNumber.ToString();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AllClassLists.LoadClassLists();
        ClassListCollection.ItemsSource = AllClassLists.ClassLists;
    }

    private async void AddClassList_Clicked(object sender, EventArgs e)
    {
        string classListName = await DisplayPromptAsync("Add new class list", "Enter the name of the new class list:");
        if (!string.IsNullOrEmpty(classListName))
        {
            AllClassLists.ClassLists.Add(new ClassList(classListName));
            AllClassLists.SaveClassLists();
        }
        else
        {
            await DisplayAlert("WARNING!", "No class list name has been entered. Can not create new class list.", "OK");
        }
    }

    private async void ClassListCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var classList = (ClassList)e.CurrentSelection[0];
            await Navigation.PushAsync(new ClassListPage(classList));
            ClassListCollection.SelectedItem = null;
        }
    }
}