using GASTITO.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GASTITO.Datos;
using System.Collections.ObjectModel;

namespace GASTITO.VistaModelos
{
    public class VMeditarGastos:BaseViewModel
    {

        #region VARIABLES
        string _TxtNombre;
        DateTime _TxtFecha;
        double _TxtCantidad;
       
        public Mgastos _gastos { get; set; }
        #endregion
        #region Contructor
        public VMeditarGastos(INavigation navigation, Mgastos gastos)
        {
            Navigation = navigation;
            _gastos = gastos;

        }
        #endregion
        #region Objetivo;
        public string TxtNombre
        {
            get { return _gastos.Nombre; }
            set
            {
                _gastos.Nombre = value;
                OnPropertyChanged(nameof(TxtNombre));
            }
        }

        public DateTime TxtFecha
        {
            get { return _gastos.Fecha; }
            set
            {
                _gastos.Fecha = value;
                OnPropertyChanged(nameof(TxtFecha));
            }
        }

        public double TxtCantidad
        {
            get { return _gastos.Cantidad; }
            set
            {
                _gastos.Cantidad = value;
                OnPropertyChanged(nameof(TxtCantidad));
            }
        }

        #endregion
        #region PROCESOS
        public async Task Editar()
        {
            var funcion = new Dgastos();
            var parametros = new Mgastos();
            parametros.Id = _gastos.Id;
            parametros.Nombre = TxtNombre;
            parametros.Fecha = TxtFecha;
            parametros.Cantidad=TxtCantidad;

            await funcion.Actualizar(parametros);
            await Volver();
        }

        public async Task Eliminar()
        {

            var funcion = new Dgastos();
            await funcion.EliminarGasto(_gastos);
            await Volver(); ;
        }

        public async Task Volver()
        {
            await Navigation.PopAsync();
        }



        #endregion.
        #region CONTRUCTOR

        #endregion.
        #region COMANDOS
        public ICommand Editarcommand => new Command(async () => await Editar());
        public ICommand Eliminarcommand => new Command(async () => await Eliminar());

        public ICommand Volvercommand => new Command(async () => await Volver());

        #endregion
    }
}
