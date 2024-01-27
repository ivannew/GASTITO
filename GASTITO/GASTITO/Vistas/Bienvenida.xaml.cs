using GASTITO.VistaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GASTITO.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Bienvenida : ContentPage
	{
		public Bienvenida ()
		{
			InitializeComponent ();
			BindingContext= new VMbienvenida(Navigation);
		}
	}
}