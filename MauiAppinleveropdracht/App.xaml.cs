namespace MauiAppinleveropdracht
{
    public partial class App : Application
    {
        public static string CurrentUserName { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }

}