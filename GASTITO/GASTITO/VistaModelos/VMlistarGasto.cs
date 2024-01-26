using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GASTITO.Datos;
using GASTITO.Modelos;
using GASTITO.Vistas;
using Xamarin.Forms;

namespace GASTITO.VistaModelos
{
    public class VMlistarGasto: BaseViewModel
    {
        List<Mgastos> _ListaGastos;

        public VMlistarGasto(INavigation navigation)
        {
            Navigation = navigation;
            MostrarGasto();

        }

        public List<Mgastos> ListaGastos
        {
            get { return _ListaGastos; 
            }
            set
            {
                SetValue(ref _ListaGastos, value);
                OnpropertyChanged();
            }
        }

        public async Task MostrarGasto()
        {
            var funcion = new Dgastos();
            ListaGastos = await funcion.MostrarGasto2();

        }
        public async Task IrARegistro()
        {
            await Navigation.PushAsync(new Registrargasto());
        }
        public async Task IraEditar(Mgastos gastos)
        {
            await Navigation.PushAsync(new Editargasto(gastos));
        }

        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand IraEditarcommand => new Command<Mgastos>(async (p) => await IraEditar(p));
    }
}
