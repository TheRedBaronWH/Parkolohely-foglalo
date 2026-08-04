namespace Parkolóhely_foglaló_UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Parkolóhely-foglaló_UI" };
        }
    }
}
