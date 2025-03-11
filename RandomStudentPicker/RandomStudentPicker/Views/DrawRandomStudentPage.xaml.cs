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
            .Where(s => s.Number != classList.AskedStudents[0] && s.Number != classList.AskedStudents[1] && s.Number != classList.AskedStudents[2])
            .Where(s => s.Number != AllClassLists.LuckyNumber)
            .ToList();
        if (drawableStudents.Count == 0)
        {
            DrawedStudentLabel.Text = "No students to draw from!";
            if (classList.AskedStudents[0] == -1 || classList.AskedStudents[1] == -1 || classList.AskedStudents[2] == -1)
            {
                classList.AskedStudents[2] = classList.AskedStudents[1];
                classList.AskedStudents[1] = classList.AskedStudents[0];
                classList.AskedStudents[0] = -1;
            }
            return;
        }
        Random random = new();
		Student drawedStudent = drawableStudents.ElementAt(random.Next(drawableStudents.Count));
		DrawedStudentLabel.Text = $"Number in w class list: {drawedStudent.Number}\nFirst name: {drawedStudent.FirstName}\nLast name: {drawedStudent.LastName}";
        if (classList.AskedStudents.Length == 3)
        {
            classList.AskedStudents[2] = classList.AskedStudents[1];
            classList.AskedStudents[1] = classList.AskedStudents[0];
            classList.AskedStudents[0] = drawedStudent.Number;
        }
        else
        {
            classList.AskedStudents[classList.AskedStudents.Length + 1] = drawedStudent.Number; 
        }
    }
}