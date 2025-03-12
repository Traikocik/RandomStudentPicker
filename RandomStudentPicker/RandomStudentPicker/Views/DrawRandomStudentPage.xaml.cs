using RandomStudentPicker.Models;
using System.Collections.ObjectModel;

namespace RandomStudentPicker.Views;

public partial class DrawRandomStudentPage : ContentPage
{
	public DrawRandomStudentPage(ClassList classList)
	{
		BindingContext = classList;
		InitializeComponent();
	}

    private void DrawStudentButton_Clicked(object sender, EventArgs e)
    {
		ClassList classList = (ClassList)BindingContext;
        List<Student> drawableStudents = classList.Students
            .Where(s => s.IsPresent)
            .Where(s => !classList.AskedStudentsNumbers.Contains(s.Number))
            .Where(s => s.Number != AllClassLists.LuckyNumber)
            .ToList();
        if (drawableStudents.Count == 0)
        {
            DrawedStudentLabel.Text = "No students to draw from!";
            classList.AskedStudentsNumbers[2] = classList.AskedStudentsNumbers[1];
            classList.AskedStudentsNumbers[1] = classList.AskedStudentsNumbers[0];
            classList.AskedStudentsNumbers[0] = -1;
            AllClassLists.SaveClassLists();
            return;
        }

        Random random = new();
		Student drawedStudent = drawableStudents[random.Next(drawableStudents.Count)];

		DrawedStudentLabel.Text = $"Number in class list: {drawedStudent.Number}\nFirst name: {drawedStudent.FirstName}\nLast name: {drawedStudent.LastName}";

        classList.AskedStudentsNumbers[2] = classList.AskedStudentsNumbers[1];
        classList.AskedStudentsNumbers[1] = classList.AskedStudentsNumbers[0];
        classList.AskedStudentsNumbers[0] = drawedStudent.Number;

        AllClassLists.SaveClassLists();
    }
}