using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GASTITO.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GASTITO.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrargasto : ContentPage
    {
        public Registrargasto()
        {
            InitializeComponent();
            BindingContext= new VMregistrogasto(Navigation);
        }
    }
}