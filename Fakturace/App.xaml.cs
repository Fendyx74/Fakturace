
namespace Fakturace
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


        }

        //Honza

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 1500;
            const int newHeight = 800;

            window.X = 700;
            window.Y = 300;

            window.Width = newWidth;
            window.Height = newHeight;

            window.MinimumHeight = newHeight;
            window.MinimumWidth = newWidth;

            window.MaximumHeight = newHeight;
            window.MaximumWidth = newWidth;

            return window;
        }
    }

    
}
