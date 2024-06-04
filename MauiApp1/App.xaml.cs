namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var NavPage = new NavigationPage(new MainPage());
            NavPage.BarBackgroundColor = Colors.Red;
            NavPage.BarTextColor = Colors.Blue;
            MainPage = NavPage;
        }
    }
}
