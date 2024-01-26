using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GASTITO.Modelos;
using GASTITO.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GASTITO.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editargasto : ContentPage
    {
        public Editargasto(Mgastos gastos)
        {
            InitializeComponent();
            BindingContext = new VMeditarGastos(Navigation, gastos);
        }
    }
}