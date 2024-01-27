using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.macOSSpecific;
using GASTITO.Datos;
using GASTITO.Modelos;
using GASTITO.Vistas;
using Xamarin.Forms;
using System.Windows.Input;

namespace GASTITO.VistaModelos
{
    public class VMbienvenida:BaseViewModel
    {
        public VMbienvenida(INavigation navigation)
        {
            Navigation = navigation;
        }
        public async Task irLista()
        {
            await Navigation.PushAsync(new Listagastos());

        }


        public ICommand IrAlistacommand => new Command(async () => await irLista());
       
    }
}
