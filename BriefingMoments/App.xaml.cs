namespace BriefingMoments
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
                /*{ BarBackgroundColor = Color.FromHex("#5c0303"), /*BarTextColor = Color.w}*/ 
        }
    }
}
