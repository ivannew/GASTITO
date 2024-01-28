using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using GASTITO.Modelos;
using GASTITO.Datos;
using Xamarin.Forms;

namespace GASTITO.VistaModelos
{
    public class VMregistrogasto:BaseViewModel
    {
        #region VARIABLES
        string _TxtNombre;
        DateTime _TxtFecha;
        double _TxtCantidad;
        #endregion


        #region CONSTRUCTOR
        public VMregistrogasto(INavigation navigation)
        {
            Navigation=navigation;
            TxtFecha = DateTime.Now;
        }
        #endregion

        #region OBJETOS
        public String TxtNombre
        {
            get { return _TxtNombre; }
            set { SetValue(ref _TxtNombre, value); }

        }

        public DateTime TxtFecha
        {
            get { return _TxtFecha; }
            set { SetValue(ref _TxtFecha, value); }

        }

        public double TxtCantidad
        {
           get { return _TxtCantidad; }
            set { SetValue(ref _TxtCantidad, value); }
        }
        #endregion
        #region
        public async Task Insertar()
        {
            var funcion = new Dgastos();
            var parametros = new Mgastos();
            parametros.Nombre=TxtNombre;
            parametros.Fecha=TxtFecha;
            parametros.Cantidad=TxtCantidad;
            await funcion.InsertarGasto(parametros);
            await volver();

        }
        public async Task volver()
        {
            await Navigation.PopAsync();

        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMADOS
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand volvercommand => new Command(async () => await volver());

        public ICommand ProcesoSimCommand => new Command(ProcesoSimple);
        #endregion
    }
}
