using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GASTITO.VistaModelos;
using GASTITO.Vistas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GASTITO.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagastos : ContentPage
    {

        VMlistarGasto vM;
        public Listagastos()
        {
            InitializeComponent();
            vM = new VMlistarGasto(Navigation);
            BindingContext=vM;
            this.Appearing += Listagastos_Appearing;
        }

       private async void Listagastos_Appearing(object sender, EventArgs e)
        {
            await vM.MostrarGasto();
        }
    }
}