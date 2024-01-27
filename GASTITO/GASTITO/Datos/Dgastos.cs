using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Firebase.Database;
using GASTITO.Modelos;
using GASTITO.Conexion;
using System.Linq;

namespace GASTITO.Datos
{
    public class Dgastos
    {
        public async Task InsertarGasto(Mgastos parametros)
        {
            await Cconexion.firebase.Child("Gasto").PostAsync(new Mgastos
            {
                Cantidad= parametros.Cantidad,
                Fecha= parametros.Fecha,
                Nombre= parametros.Nombre,

            }) ;
        }

        public async Task EliminarGasto(Mgastos mGasto)
        {
            string Id = mGasto.Id;
            await Cconexion.firebase.Child("Gasto").Child(Id).DeleteAsync();
        }



        public async Task<List<Mgastos>> MostrarGasto2()
        {
            return (await Cconexion.firebase.Child("Gasto") // Cambiado de "Pokemon" a "Gasto"
                    .OnceAsync<Mgastos>())
                    .Select(item => new Mgastos
                    {
                        Id = item.Key,
                        Nombre = item.Object.Nombre,
                        Fecha = item.Object.Fecha,
                        Cantidad = item.Object.Cantidad,
                    }).ToList();
        }

        public async Task Actualizar(Mgastos parametros)
        {
            await Cconexion.firebase.Child("Gasto").Child(parametros.Id).PutAsync(new Mgastos
            {
                Nombre = parametros.Nombre,
                Fecha = parametros.Fecha,
               Cantidad = parametros.Cantidad
              

            });

        }
    }
}
