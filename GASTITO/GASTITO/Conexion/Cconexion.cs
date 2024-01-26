using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace GASTITO.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://gastito-f30df-default-rtdb.firebaseio.com/");
    }
}
