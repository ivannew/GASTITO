using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GASTITO.Datos;
using GASTITO.Modelos;
using GASTITO.Vistas;
using Xamarin.Forms;

namespace GASTITO.VistaModelos
{
    public class VMlistarGasto : BaseViewModel
    {
        List<Mgastos> _ListaGastos;
        private decimal _totalCantidad;

        public VMlistarGasto(INavigation navigation)
        {
            Navigation = navigation;
            MostrarGasto();
        }
        private bool _mostrarAdvertencia;

        public bool MostrarAdvertencia
        {
            get { return _mostrarAdvertencia; }
            set
            {
                SetValue(ref _mostrarAdvertencia, value);
                OnpropertyChanged();
            }
        }


        public List<Mgastos> ListaGastos
        {
            get { return _ListaGastos; }
            set
            {
                SetValue(ref _ListaGastos, value);
                ActualizarTotalCantidad();
                VerificarAdvertencia();
                OnpropertyChanged();
            }
        }
        public decimal TotalCantidad
        {
            get { return _totalCantidad; }
            set
            {
                SetValue(ref _totalCantidad, value);
                OnpropertyChanged();
            }
        }
        private void ActualizarTotalCantidad()
        {
            TotalCantidad = ListaGastos.Sum(g => Convert.ToDecimal(g.Cantidad));
            VerificarAdvertencia();
        }
        public async Task MostrarGasto()
        {
            var funcion = new Dgastos();
            ListaGastos = await funcion.MostrarGasto2();
        }
        private void VerificarAdvertencia()
        {
            MostrarAdvertencia = TotalCantidad > 5000;
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
