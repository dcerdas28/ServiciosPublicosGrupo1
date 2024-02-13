using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicosGrupo1
{
    internal class ClsSucursal
    {
        #region ATRIBUTOS Y CONSTRUCTOR

        public string NombreSucursal;

        public ClsSucursal(string nombreSucursal)
        {
            NombreSucursal = nombreSucursal;
        }//constructor

        #endregion

        #region ARRAY SUCURSALES

        public static ClsSucursal[] ArraySucursales = new ClsSucursal[10];

        #endregion

        #region MÉTODOS DE LA CLASE
        public static void inicializarSucursales() {

            ArraySucursales[0] = new ClsSucursal("Desamparados");
            ArraySucursales[1] = new ClsSucursal("Mall San Pedro");
            ArraySucursales[2] = new ClsSucursal("Super Compro Tres Ríos");
            ArraySucursales[3] = new ClsSucursal("Colima Tibás");
            ArraySucursales[4] = new ClsSucursal("Cartago Ruinas");
            ArraySucursales[5] = new ClsSucursal("Cartago Taras");
            ArraySucursales[6] = new ClsSucursal("Heredia");
            ArraySucursales[7] = new ClsSucursal("San José Av. 2");
            ArraySucursales[8] = new ClsSucursal("San José Calle 10");
            ArraySucursales[9] = new ClsSucursal("Guadalupe El Alto");


        }//método inicializarSucursales
        #endregion



    }//Class
}//Space
