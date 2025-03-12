using Microsoft.Maui.Controls.StyleSheets;

namespace RandomStudentPicker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Resources.Add(StyleSheet.FromFile("Resources/Styles/styles.css"));
            //using (var reader = new StringReader("^contentpage { background-color: lightgray; }"))
            //{
            //    Resources.Add(StyleSheet.FromReader(reader));
            //}

            MainPage = new AppShell();
        }
    }
}
