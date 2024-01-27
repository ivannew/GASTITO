using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GASTITO.Modelos;
using GASTITO.Vistas;
namespace GASTITO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Bienvenida());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
