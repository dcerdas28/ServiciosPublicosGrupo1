using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicosGrupo1
{
    internal class ClsServicio
    {
        #region ARREGLO DE SERVICIOS
        public static ClsServicio[] ArrayServicios = new ClsServicio[10];
        #endregion

        #region ATRIBUTOS Y CONSTRUCTOR

        public string NombreServicio;
        public float MontoServicio;
        public float Comision;

        public ClsServicio( string nombreServicio, 
                            float montoServicio, 
                            float comision)
        {
            NombreServicio = nombreServicio;
            MontoServicio = montoServicio;
            Comision = comision;
        }

        #endregion

        #region MÉTODOS DE LA CLASE
        public static void inicializarArrayServicios() {

            ArrayServicios[0] = new ClsServicio("Agua", 7948f, 52f);//comisión Agua 6.5%
            ArrayServicios[1] = new ClsServicio("Electricidad", 14940f, 60f);//comisióm Electricidad 4%
            ArrayServicios[2] = new ClsServicio("Teléfono Móvil", 24862.5f, 137.5f);//comisión Teléfono Móvil 5.5%
            ArrayServicios[3] = new ClsServicio("Internet", 19880f, 120f);//comisión Internet 6%
            ArrayServicios[4] = new ClsServicio("TV por cable", 12911.2f, 38.8f);//comisión TV por cable 3%
            ArrayServicios[5] = new ClsServicio("Impuestos Municipales", 24800f, 200f);//comisión Impuestos Municipales 8%
            ArrayServicios[6] = new ClsServicio("Impuestos de salida del país", 4985f, 15f);//comisión Impuestos salida del país 3%
            ArrayServicios[7] = new ClsServicio("Tarjeta transporte público", 4985f, 15f);//comisión Tarjeta transporte público 3%
            ArrayServicios[8] = new ClsServicio("Subscripción Revista Forbes", 10945f, 55f); //comisión Subscripción Revista Forbes 5%)
            ArrayServicios[9] = new ClsServicio ("Subscripción Diario El Financiero", 11940f, 60f); //comisión Subscripción Diario El Financiero 5%
            
            /*Documentación: Información de los servicios
              
            Nombre de cada servicio
            "Agua";
            "Electricidad";
            "Teléfono Móvil";
            "Internet";
            "TV por cable";
            "Impuestos Municipales";
            "Impuestos de salida del país";
            "Tarjeta transporte público";
            "Subscripción Revista Forbes";
            "Subscripción Diario El Financiero";
            
            //Monto p/ Servicio
            8000f;//agua
            15000f;//elec
            25000f;//telef
            20000f;//internet
            12950f;//TV
            25000f;//Imp Muni
            5000f;//Imp Salida
            5000f;//Tarjeta Transp.
            11000f;//Subsc. Forbes
            12000f;//Subsc. Financiero*/


        }//método inializar Servicios

        public static string seleccionServicio() {

            string servicioSeleccionado = "";
            string opcion = "";
            bool validacion = false; //para validar opción válida (true) no válida (false)

            

            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nSeleccione el servicio a pagar:");
                Console.ResetColor();

                Console.WriteLine("");

                Console.WriteLine("1  -  Agua");
                Console.WriteLine("2  -  Electricidad");
                Console.WriteLine("3  -  Teléfono Móvil");
                Console.WriteLine("4  -  Internet");
                Console.WriteLine("5  -  TV por cable");
                Console.WriteLine("6  -  Impuestos Municipales");
                Console.WriteLine("7  -  Impuestos de salida del país");
                Console.WriteLine("8  -  Tarjeta transporte público");
                Console.WriteLine("9  -  Subscripción Revista Forbes");
                Console.WriteLine("10 -  Subscripción Diario El Financiero");
                Console.WriteLine("11 -  Salir (Menú Principal) ");

                Console.WriteLine("\nDigite una opción: ");
                opcion = Console.ReadLine(); //almaceno opción


                switch (opcion)//Selección del servicio
                {

                    case "1":

                        Console.Clear(); //limpia la pantalla.

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n*** Servicio de Agua Potable ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Agua";
                        return servicioSeleccionado;

                        validacion = true;

                        break;
                    case "2":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** Servicio de Electricidad ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Electricidad";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "3":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n*** Servicio de Telefonía Móvil ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Telefonía Móvil";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "4":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n*** Pago servicio de Internet ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Internet";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "5":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n*** Servicio de Televisión por Cable ***");
                        Console.ResetColor();

                        servicioSeleccionado = "TV por Cable";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "6":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n*** Pago de Impuestos Municipales ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Impuestos Municipales";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "7":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n*** Pago de Impuestos de Salida del País ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Impuestos de Salida del País";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "8":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n*** Pago Tarjeta de Transporte Público ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Tarjeta de Transporte Público";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "9":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n*** Pago Subscripción Revista Forbes ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Subscripción Revista Forbes";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    case "10":

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n*** Pago Subscripción Diario El Financiero ***");
                        Console.ResetColor();

                        servicioSeleccionado = "Subscripción Diario El Financiero";
                        return servicioSeleccionado;

                        validacion = true;


                        break;
                    default:

                        Console.Clear();//limpio pantalla


                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** x_x opción no válida ***\n");
                        Console.ResetColor();

                        servicioSeleccionado = "ERROR DE SELECCIÓN";
                        return servicioSeleccionado;

                        validacion = false;


                       break;


                }//swith

            }//do
            while (validacion==false);


        }//método seleccionar servicio

        #endregion

    }//class
}//space
