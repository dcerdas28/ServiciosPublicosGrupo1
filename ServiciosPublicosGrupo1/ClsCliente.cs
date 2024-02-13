using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiciosPublicosGrupo1
{
    internal class ClsCliente
    {
        #region ARREGLO DE CLIENTES
        //Arreglo para almacenar los clientes:
        public static ClsCliente[] ArrayClientes = new ClsCliente[10];
        #endregion

        #region ATRIBUTOS Y CONSTRUCTOR

        public string Apellido1;
        public string Apellido2;
        public string Nombre;
        public string Cedula;
        public string Direccion;

        public ClsCliente(string apellido1, string apellido2, string nombre, string cedula, string direccion)
        {
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Nombre = nombre;
            Cedula = cedula;
            Direccion = direccion;
        }//constructor

        #endregion

        #region MÉTODOS DE LA CLASE
        public static void incializarArrayClientes() {

            ArrayClientes[0] = new ClsCliente("Benjamin", "Curling", "Alexander", "654287413", "Liberia, GUA");
            ArrayClientes[1] = new ClsCliente("Cerdas", apellido2: "Romero", "David", "114720995", "Desamparados, SJ");
            ArrayClientes[2] = new ClsCliente("Castro", apellido2: "Madriz", "Jose Maria", "123456789", "La Giralda, ALA");
            ArrayClientes[3] = new ClsCliente("Calderon", apellido2: "Guardia", "Rafael Angel", "321654987", "Barranca, PUN");
            ArrayClientes[4] = new ClsCliente("Chaves", apellido2: "Robles", "Rodrigo", "111111111", "Casa Presidencial, SJ"); ;
            ArrayClientes[5] = new ClsCliente("Figueres", apellido2: "Ladrón", "Jose Maria", "222222222", ", Berna, Suiza");
            ArrayClientes[6] = new ClsCliente("Alvarado", apellido2: "Cochinilla", "Carlos", "333333333", "Flores, HER"); ;
            ArrayClientes[7] = new ClsCliente("Araya", apellido2: "Chorizo", "Johnny", "444444444", "Islas Caiman");
            ArrayClientes[8] = new ClsCliente("Solis", apellido2: "Pargo", "Luis Guillermo", "555555555", "Guapiles, LIM"); ;
            ArrayClientes[9] = new ClsCliente("Chinchilla", apellido2: "Trocha", "Laura", "666666666", "Tucurrique, CAR"); ;

        
        }//Método inicializar Clientes
        #endregion





    }//class
}//space
