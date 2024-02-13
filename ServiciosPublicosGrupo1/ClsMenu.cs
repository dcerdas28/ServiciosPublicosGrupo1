using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001; //para utilizar Threading.Sleep (esperar segundos una instrucción)

namespace ServiciosPublicosGrupo1
{
    internal class ClsMenu
    {

        #region VARIABLES PARA TODOS LOS MÉTODOS
        static string opcion; //para guardar la opción seleccionada del menú principal
        static string opcion2; //para guardar la opción seleccionada del submenú reportes
        static string opcion3; //para guardar la opción seleccionada en opción, modificar pagos.
        static string seleccionPago; //para guardar la opción seleccionada en el módulo modificar, opción 4
        static int contadorPagos = 0; //para contar la cantidad de pagos en el ArrayPagos para módulo modificar, opción 4
        static string seleccionSucursal; //para guargar la sucursal seleccionada en submenú reportes
        static bool error = false; //para validar errores en los do while+
        static bool arreglosListos = false; //para controlar que primero se deben incializar los arreglos antes de cualq. trámite.
        static bool validacion = false; //para validar ciclos do while.
        static string seleccionServicio;//para guargar el servicio seleccionado en submenú reportes
        static float acumuladoComision = 0f; // para guardar el monto acumulado de Comisiones por Servicio
        static string apellidoBuscado = ""; //para buscar cliente por apellido, menú principal opcion 3.
        public static ClsCliente ClienteEncontrado;//Objeto para almacenar el objeto ClsCliente buscado, menú principal opción 3.
        static bool errorCliente = false; //para controlar errores al buscar algún cluente, menú principal opción 3.
        public static DateTime nuevaFecha; //para almacenar nuevaFecha, modificar pago, opción 4
        public static string nuevoNombre; //para almacenar nuevoNombre, modificar pago, opción 4
        public static string nuevoApellido1; //para almacenar nuevoApellido1, modificar pago, opción 4
        public static string nuevoApellido2; //para almacenar nuenuevoApellido2, modificar pago, opción 4
        public static string nuevaCedula; //para almacenar nuevaCedula, modificar pago, opción 4
        public static string nuevoServicio; //para almacenar nuevoServicio, modificar pago, opción 4
        public static string nuevaSucursal; //para almacenar nuevaSucursal, modificar pago, opción 4
        #endregion

        #region MÉTODOS DE LA CLASE
        public static void MenuPrincipal()
        {
            Console.Clear();//limpio pantalla

            do
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n****Sistema de Pago de Servicios Publicos****\n");
                Console.ResetColor();

                Console.WriteLine(  "Menú Principal\n");

                Console.WriteLine("1 - Inicializar Arreglos");
                Console.WriteLine("2 - Realizar Pagos");
                Console.WriteLine("3 - Consultar Pagos");
                Console.WriteLine("4 - Modificar Pagos");
                Console.WriteLine("5 - Eliminar Pagos");
                Console.WriteLine("6 - Submenú: Reportes");
                Console.WriteLine("7 - Salir");
                Console.Write("\n\nDigite una opción: ");
                opcion = Console.ReadLine();

                switch (opcion) //Switch menú principal
                {

                    case "1":

                        inicializarArreglos(); //inicia los arreglos de todas las clases, método local.

                        arreglosListos |= true;

                        break;//Inicializar Arreglos

                    case "2":

                        //Primero reviso si ya los arreglos fueron inicializados con este if / else:

                        if (arreglosListos == false)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n***Por favor, inicialice los arreglos en la opción #1***");
                            Console.ResetColor();

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadLine();

                            MenuPrincipal();

                        }//if

                        else
                        {

                            ClsPago.relizarPagos();
                        
                        
                        }//else

                        break;//Realizar Pagos

                    case "3":

                        //El cliente se identifica y el sistema le indica sus pagos realizados, la consulta es por cliente.

                        if (arreglosListos == false)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n***Por favor, inicialice los arreglos en la opción #1***");
                            Console.ResetColor();

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadLine();

                            MenuPrincipal();

                        }//if

                        else
                        {
                            Console.Clear();//limpio consola

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n***Módulo de Consulta de Pagos***");
                            Console.ResetColor();

                            #region BUSCANDO CLIENTE

                            do
                            {

                                try
                                {

                                    Console.Write("\n\nPor favor digite su primer apellido: ");
                                    apellidoBuscado = Console.ReadLine();


                                    /* Creo un objeto tipo ClsCliente e intento buscar el cliente con una Expresión LAMBA,
                                     * el resultado se almacenará en ClienteEncontrado*/

                                    ClienteEncontrado = Array.Find(ClsCliente.ArrayClientes, cliente => cliente.Apellido1 == apellidoBuscado);


                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\nBuscando, espere por favor");
                                    Console.ResetColor();


                                    Thread.Sleep(300);
                                    Console.WriteLine(".");
                                    Thread.Sleep(300);
                                    Console.WriteLine(".");
                                    Thread.Sleep(300);
                                    Console.WriteLine(".");

                                    if (ClienteEncontrado != null)
                                    {

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine($"\nBienvenido: {ClienteEncontrado.Apellido1} {ClienteEncontrado.Apellido2} {ClienteEncontrado.Nombre}");
                                        Console.ResetColor();

                                        Console.WriteLine("\nPresione una tecla para continuar...");
                                        Console.ReadLine();

                                        Console.Clear();//Limpio Consola

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine($"Sr.(a): {ClienteEncontrado.Apellido1} {ClienteEncontrado.Apellido2} {ClienteEncontrado.Nombre}.");
                                        Console.ResetColor();

                                        Console.WriteLine("\nA continuación verá un reporte de sus pagos realizados: \n");


                                        for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                                        {

                                            if (ClsPago.ArrayPagos[i] == null)
                                            { //si el elemento del array[i] es null, salga del for.

                                                //no haga nada ☺

                                            }//if


                                            else if (ClsPago.ArrayPagos[i].Cliente.Apellido1 == apellidoBuscado)
                                            {

                                                //si el Apellido1 de Cliente de ArrayPagos[i] == apellidoBuscado


                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"***************************************");
                                                Console.ResetColor();

                                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                                                Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                                                Console.ResetColor();
                                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[i].Servicio.NombreServicio}.");
                                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");

                                                float pagó = ClsPago.ArrayPagos[i].Servicio.MontoServicio + ClsPago.ArrayPagos[i].Servicio.Comision;

                                                Console.WriteLine($"Monto: ¢{pagó}.");
                                                Console.WriteLine("");


                                            }//else if

                                            else
                                            {

                                                //que no haga nada... que termine el for y salga..

                                            }//else



                                        }//for


                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nNo hay más pagos registrados a su nombre");
                                        Console.ResetColor();

                                        Console.WriteLine("\nPresione una tecla para continuar...");
                                        Console.ReadLine();

                                        errorCliente = false;

                                    }//if

                                    else
                                    {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\nNo se encontró ningún cliente con primer apellido: {apellidoBuscado}\n");
                                        Console.ResetColor();

                                        errorCliente = true;


                                    }//else


                                }//try
                                catch (NullReferenceException)
                                {

                                    Console.WriteLine("\nFavor contactar a T.I.");

                                }//catch

                            }//do

                            while (errorCliente == true);

                            Console.Clear();

#endregion


                        }//else

                        break;//Consultar Pagos                                    

                    case "4":

                        //Esta opción, muestra todos los pagos registrados y el usuario debe seleccionar cuál pago modificar.

                        if (arreglosListos == false)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n***Por favor, inicialice los arreglos en la opción #1***");
                            Console.ResetColor();

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadLine();

                            MenuPrincipal();

                        }//if (si no se han inicializado los arrays...)

                        else
                        {
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n***Módulo de Modificación de Pagos***");
                            Console.ResetColor();

                            Console.WriteLine("\nA continuación verá la lista de pagos registrados en sistema:\n");

                            for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                            {

                                if (ClsPago.ArrayPagos[i] == null)//si en el campo [i] está nulo.
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("No hay más pagos registrados actualmente en sistema.");
                                    Console.ResetColor();

                                    break;//sale del ciclo.

                                }//if
                                
                                contadorPagos++; //si hay un pago en ArrayPagos[i], contadorPagos se suma en 1 en cada vuelta del for (seguimos en el for).

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"*********** Pago #{i + 1} ***********");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                                Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                                Console.WriteLine($"Cédula: {ClsPago.ArrayPagos[i].Cliente.Cedula}.");
                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[i].Servicio.NombreServicio}.");
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");

                                float pagó = ClsPago.ArrayPagos[i].Servicio.MontoServicio + ClsPago.ArrayPagos[i].Servicio.Comision;

                                Console.WriteLine($"Monto: ¢{pagó}.");
                                Console.WriteLine("");

                            }//for

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nDigite el número del pago que desea modificar: ");
                            Console.ResetColor();
                            seleccionPago = Console.ReadLine();

                            if (int.Parse(seleccionPago) > contadorPagos) //Si el usuario ingresa un # de pago mayor a la cantidad de pagos en el Array...
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("X_X El valor ingresado no es válido");
                                Console.ResetColor();

                            }//if

                            else {

                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Pago Seleccionado:");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[int.Parse(seleccionPago)-1].ConsecutivoPago}."); //aplico parseporque selección pago es string, se puso string para evitar excepciones por format.
                                Console.WriteLine($"Fecha y hora: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido1} {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido2} {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Nombre}.");
                                Console.WriteLine($"Cédula: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Cedula}.");
                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Servicio.NombreServicio}.");
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Sucursal.NombreSucursal}.");

                                Console.WriteLine("\nSeleccione el parámetro que desea modificar:");
                                Console.WriteLine("");
                                Console.WriteLine("1 - Fecha");
                                Console.WriteLine("2 - Cliente");
                                Console.WriteLine("3 - Cédula");
                                Console.WriteLine("4 - Servicio");
                                Console.WriteLine("5 - Sucursal");

                                Console.Write("\nDigite una opción: ");
                                opcion3 = Console.ReadLine();

                            }//else


                           
                            switch (opcion3)
                            {

                                case "1":

                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("*****Modificar Fecha*****");
                                    Console.ResetColor();

                                    Console.Write("\n\nPor favor ingrese el nuevo valor (formato: dd/MM/yyyy HH:mm:ss");
                                    DateTime.TryParse(Console.ReadLine(), out nuevaFecha);//Uso try parse para tratar de convertir lo ingresado (string) a formato DateTime    


                                    DateTime fechaVieja = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].FechayHora; //Almaceno para mostrarla al final del trámite

                                    //Asigno el dato nuevo
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].FechayHora = nuevaFecha;

                                    Console.Clear();

                                    Console.WriteLine("\nSe modificó la fecha del pago:\n");

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"- Fecha anterior: {fechaVieja}.");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\n- Fecha nueva: {nuevaFecha} ");

                                    Console.ResetColor();

                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadLine();

                                    Console.Clear();

                                    break;//Modificar Fecha
                                case "2":

                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("*****Modificar Cliente*****");
                                    Console.ResetColor();

                                    //Almaceno el nombre COMPELTO anterior para mostrarlo al final del trámite
                                    String apellido1Viejo = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido1;
                                    String apellido2Viejo = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido2;
                                    String nombreViejo = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Nombre;

                                    Console.WriteLine("\n\nPor favor ingrese la nueva información a continuación:");

                                    //Almaceno variables nuevas

                                    Console.Write("\n\nPrimer Apellido: ");
                                    nuevoApellido1 = Console.ReadLine();

                                    Console.Write("\nSegundo Apellido: ");
                                    nuevoApellido2 = Console.ReadLine();

                                    Console.Write("\nNombre: ");
                                    nuevoNombre = Console.ReadLine();

                                    

                                    //Modifico el nombre por pasos, Ape1 registrado en el ArrayPagos:,luego  Ape 2, Nombre...
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido1 = nuevoApellido1;
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido2 = nuevoApellido2;
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Nombre = nuevoNombre;


                                    Console.Clear();


                                    //Muestro datos nuevos:
                                    Console.WriteLine("\nSe modificó el nombre del cliente:\n");

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"- Nombre anterior: {apellido1Viejo} {apellido2Viejo} {nombreViejo}.");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\n- Nombre nuevo: {nuevoApellido1} {nuevoApellido2} {nuevoNombre}.");

                                    Console.ResetColor();

                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadLine();

                                    Console.Clear();

                                    break;//Modificar Cliente
                                case "3":

                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("*****Modificar Cédula*****");
                                    Console.ResetColor();

                                    Console.Write("\n\nPor favor ingrese el nuevo valor: ");
                                    nuevaCedula = Console.ReadLine(); //guardo el nuevo valor en una variable.


                                    string cedulaVieja = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Cedula; //guardo el valor anterior para mostrarlo al final


                                    //Asigno el dato nuevo
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Cedula = nuevaCedula; //Asigno el nuevo valor en el Array

                                    Console.Clear();

                                    Console.WriteLine("\nSe modificó la fecha cédula:\n");

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"- Cédula anterior: {cedulaVieja}.");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\n- Cédula nueva: {nuevaCedula} ");

                                    Console.ResetColor();

                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadLine();

                                    Console.Clear();



                                    break;//Modificar Cédula
                                case "4":

                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("*****Modificar Servicio*****");
                                    Console.ResetColor();

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n¡Aviso!: Al hacer este cambio, simplemente cambiará el nombre del servicio");
                                    Console.WriteLine("sin embargo, no se cambiarán temas de montos ya que es dinero que ya fue cobrado.");
                                    Console.ResetColor();

                                    do
                                    {

                                        Console.Write("\n\nPor favor seleccione el nuevo servicio: \n\n");


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

                                        Console.Write("\n\nDigite una opción: ");
                                        seleccionServicio = Console.ReadLine(); //almaceno seleccion Servicio


                                        switch (seleccionServicio)
                                        {

                                            case "1":
                                                nuevoServicio = "Agua";
                                                validacion = true;
                                                break;

                                            case "2":
                                                nuevoServicio = "Electricidad";
                                                validacion = true;
                                                break;

                                            case "3":
                                                nuevoServicio = "Teléfono Móvil";
                                                validacion = true;
                                                break;

                                            case "4":
                                                nuevoServicio = "Internet";
                                                validacion = true;
                                                break;

                                            case "5":
                                                nuevoServicio = "TV por cable";
                                                validacion = true;
                                                break;

                                            case "6":
                                                nuevoServicio = "Impuestos Municipales";
                                                validacion = true;
                                                break;

                                            case "7":
                                                seleccionServicio = "Impuestos de salida del país";
                                                validacion = true;
                                                break;

                                            case "8":
                                                nuevoServicio = "Tarjeta transporte público";
                                                validacion = true;
                                                break;

                                            case "9":
                                                nuevoServicio = "Subscripción Revista Forbes";
                                                validacion = true;
                                                break;

                                            case "10":
                                                nuevoServicio = "Subscripción Diario El Financiero";
                                                validacion = true;
                                                break;

                                            default:


                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\n*** x_x opción no válida ***\n");
                                                Console.ResetColor();

                                                validacion = false;
                                                break;

                                        }//swith

                                    }//do
                                    while (validacion == false);

                                    string servicioViejo = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Servicio.NombreServicio; //guardo el valor anterior para mostrarlo al final


                                    //Asigno el dato nuevo
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Servicio.NombreServicio = nuevoServicio; //Asigno el nuevo valor en el Array

                                    Console.Clear();

                                    Console.WriteLine("\nSe modificó el nombre del servicio:\n");

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"- Servicio anterior: {servicioViejo}.");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\n- Servicio nuevo: {nuevoServicio} ");

                                    Console.ResetColor();

                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadLine();

                                    Console.Clear();



                                    break;//Modificar Servicio
                                case "5":

                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("*****Modificar Sucursal*****");
                                    Console.ResetColor();

                                    do
                                    {

                                        Console.WriteLine("\nSeleccione la nueva Sucursal:\n");

                                        Console.WriteLine("1  -  Desamparados");
                                        Console.WriteLine("2  -  Mall San Pedro");
                                        Console.WriteLine("3  -  Super Compro Tres Ríos");
                                        Console.WriteLine("4  -  Colima Tibás");
                                        Console.WriteLine("5  -  Cartago Ruinas");
                                        Console.WriteLine("6  -  Cartago Taras");
                                        Console.WriteLine("7  -  Heredia");
                                        Console.WriteLine("8  -  San José Av. 2");
                                        Console.WriteLine("9  -  San José Calle 10");
                                        Console.WriteLine("10 -  Guadalupe El Alto");

                                        Console.Write("\n\nDigite una opción: ");
                                        opcion3 = Console.ReadLine(); //almaceno seleccion Sucursal


                                        switch (opcion3)
                                        {

                                            case "1":
                                                nuevaSucursal = "Desamparados";
                                                validacion = true;
                                                break;

                                            case "2":
                                                nuevaSucursal = "Mall San Pedro";
                                                validacion = true;
                                                break;

                                            case "3":
                                                nuevaSucursal = "Super Compro Tres Ríos";
                                                validacion = true;
                                                break;

                                            case "4":
                                                nuevaSucursal = "Colima Tibás";
                                                validacion = true;
                                                break;

                                            case "5":
                                                nuevaSucursal = "Cartago Ruinas";
                                                validacion = true;
                                                break;

                                            case "6":
                                                nuevaSucursal = "Cartago Taras";
                                                validacion = true;
                                                break;

                                            case "7":
                                                nuevaSucursal = "Heredia";
                                                validacion = true;
                                                break;

                                            case "8":
                                                nuevaSucursal = "San José Av. 2";
                                                validacion = true;
                                                break;

                                            case "9":
                                                nuevaSucursal = "San José Calle 10";
                                                validacion = true;
                                                break;

                                            case "10":
                                                nuevaSucursal = "Guadalupe El Alto";
                                                validacion = true;
                                                break;

                                            default:


                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\n*** x_x opción no válida ***\n");
                                                Console.ResetColor();

                                                validacion = false;
                                                break;

                                        }//swith selección sucursal


                                    }//do
                                    while (validacion == false);


                                    string sucursalVieja = ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Sucursal.NombreSucursal; //guardo el valor anterior para mostrarlo al final


                                    //Asigno el dato nuevo
                                    ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Sucursal.NombreSucursal = nuevaSucursal; //Asigno el nuevo valor en el Array

                                    Console.Clear();

                                    Console.WriteLine("\nSe modificó la Sucursal:\n");

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"- Sucursal anterior: {sucursalVieja}.");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\n- Sucursal nueva: {nuevaSucursal} ");

                                    Console.ResetColor();

                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadLine();

                                    Console.Clear();


                                    break;//Modificar sucursal

                            }//switch

                           

                        }//else principal opción 4

                        break;//Modificar Pagos

                    case "5":


                        if (arreglosListos == false)//si los array no están inicializados
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n***Por favor, inicialice los arreglos en la opción #1***");
                            Console.ResetColor();

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadLine();

                            MenuPrincipal();

                        }//if

                        else
                        {

                            #region ELIMINAR PAGOS

                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n***Módulo de Eliminación de Pagos***");
                            Console.ResetColor();

                            Console.WriteLine("\nA continuación verá la lista de pagos registrados en sistema:\n");

                            for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                            {

                                if (ClsPago.ArrayPagos[i] == null)//si en el campo [i] está nulo.
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("No hay más pagos registrados actualmente en sistema.");
                                    Console.ResetColor();

                                    break;//sale del ciclo.

                                }//if

                                contadorPagos++; //si hay un pago en ArrayPagos[i], contadorPagos se suma en 1 en cada vuelta del for (seguimos en el for).

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"*********** Pago #{i + 1} ***********");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                                Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                                Console.WriteLine($"Cédula: {ClsPago.ArrayPagos[i].Cliente.Cedula}.");
                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[i].Servicio.NombreServicio}.");
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");

                                float pagó = ClsPago.ArrayPagos[i].Servicio.MontoServicio + ClsPago.ArrayPagos[i].Servicio.Comision;

                                Console.WriteLine($"Monto: ¢{pagó}.");
                                Console.WriteLine("");

                            }//for

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nDigite el número del pago que desea eliminar: ");
                            Console.ResetColor();
                            seleccionPago = Console.ReadLine();

                            if (int.Parse(seleccionPago) > contadorPagos) //Si el usuario ingresa un # de pago mayor a la cantidad de pagos en el Array...
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("X_X El valor ingresado no es válido");
                                Console.ResetColor();

                            }//if

                            else
                            {

                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Pago Seleccionado:");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].ConsecutivoPago}."); //aplico parseporque selección pago es string, se puso string para evitar excepciones por format.
                                Console.WriteLine($"Fecha y hora: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido1} {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Apellido2} {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Nombre}.");
                                Console.WriteLine($"Cédula: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Cliente.Cedula}.");
                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Servicio.NombreServicio}.");
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1].Sucursal.NombreSucursal}.");

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n¿Desea eliminar el pago?");
                                Console.ResetColor();

                                Console.WriteLine("\n1 - Sí (Eliminar)");
                                Console.WriteLine("2 - No (Menú Principal");
                                Console.WriteLine("");
                                Console.Write("\nDigite una opción: ");

                                string opcionEliminar = Console.ReadLine();

                                switch (opcionEliminar)
                                {

                                    case "1": 

                                        ClsPago.ArrayPagos[int.Parse(seleccionPago) - 1] = null; //Eliminar el pago del array.
                                        
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n ****El pago fue eliminado**** ");
                                        Console.ResetColor();

                                        Console.WriteLine("\nPresione una tecla para continuar...");

                                        Console.ReadLine();
                                        break;

                                    case "2":

                                        ClsMenu.MenuPrincipal();

                                        break;        

                                }//switch


                            }//else

                                #endregion


                            }//else principal

                        break;//Eliminar Pagos

                    case "6":


                        if (arreglosListos == false)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n***Por favor, inicialice los arreglos en la opción #1***");
                            Console.ResetColor();

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadLine();

                            MenuPrincipal();

                        }//if

                        else
                        {

                            subMenuReportes();


                        }
                            break;//Submenú: Reportes

                    case "7":

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nSaliendo, presione una tecla para continuar...\n");
                        Console.ResetColor();
                        Console.ReadKey();//para dar chance al usuario de leer que está saliendo.

                        Environment.Exit(0); //cierra el programa.


                        break;//Salir

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** x_x digitó una opción incorrecta ***\n");
                        Console.ResetColor();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadLine();

                        Console.Clear();

                        break;

                }//switch menú principal

            }//do
            while ( opcion != "1" ||
                    opcion != "2" ||
                    opcion != "3" || 
                    opcion != "4" || 
                    opcion != "5" || 
                    opcion != "6" || 
                    opcion != "7"); //while
            
                        Console.ReadLine();//permite leer la consola antes de limpiar y realizar la siguiente gestión.

            Console.Clear();//limpia pantalla despues de recorrer todo y antes de volver a mostrar de nuevo el menu.

        }//método MenuPrincipal

        public static void inicializarArreglos() {

            Console.Clear();//limpio la pantalla
                 

            do {

                try
                {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Inicializando");
                Console.ResetColor();

                //Cargando Servicios:

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nCargando Servicios...");
                    Console.ResetColor();                
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    ClsServicio.inicializarArrayServicios();//método inicializarArrayServicios



                    //Cargando Clientes:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nCargando Clientes...");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    ClsCliente.incializarArrayClientes();//método incializarArrayClientes

                    //Cargando Pagos:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nCargando Pagos...");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    ClsPago.inicializarArrayPagos();//método inicializarArrayPagos

                    //Cargando Sucursales:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nCargando Sucursales...");
                    Console.ResetColor();
                    ClsPago.inicializarArrayPagos();
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    ClsSucursal.inicializarSucursales();//métodoinicializarSucursales

                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡Inicialización Exitosa!");
                Console.ResetColor();

                error = false;

            }//try
            catch (Exception e)
                {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("x_x Hubo un Error al Inicializar");
                Console.ResetColor();
                Console.WriteLine($"Detalle: {e}");

                error= true;

                }//catch
        
        }//do

        while(error==true);//mientras error sea true se repite el ciclo. si error es false sigue adelante...


            Console.WriteLine("\nDigite una tecla para continuar...");
            Console.ReadLine();
            Console.Clear();//limpio pantalla


        }//método para inicializar todos los arreglos de todas las clases;

        public static void subMenuReportes() {

            do {
                
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n****Submenú de Reportes****\n");
            Console.ResetColor();

            Console.WriteLine("");

            Console.WriteLine("1 - Ver todos los pagos realizados");
            Console.WriteLine("2 - Ver pagos por servicio");
            Console.WriteLine("3 - Ver pagos por sucursal");
            Console.WriteLine("4 - Ver dinero comisionado por servicios");
            Console.WriteLine("5 - Regresar a menú principal");
            
             Console.Write("\n\nDigite una opción: ");
             opcion2 = Console.ReadLine();


                switch (opcion2)
                {
                    case "1":

                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n****Reportes de Pagos Realizados****\n");
                        Console.ResetColor();

                        Console.WriteLine("");

                        for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                        {

                            if (ClsPago.ArrayPagos[i]==null)//si en el campo está nulo.
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("No hay más pagos registrados actualmente en sistema.");
                                Console.ResetColor();

                                Console.WriteLine("\nPresione una tecla para continuar...");
                                Console.ReadLine();

                                break;//sale del ciclo.

                            }//if
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"*********** Pago #{i+1} ***********");
                            Console.ResetColor();

                            Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                            Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                            Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                            Console.WriteLine($"Cédula: {ClsPago.ArrayPagos[i].Cliente.Cedula}.");
                            Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[i].Servicio.NombreServicio}.");
                            Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");

                            float pagó = ClsPago.ArrayPagos[i].Servicio.MontoServicio + ClsPago.ArrayPagos[i].Servicio.Comision;

                            Console.WriteLine($"Monto: ¢{pagó}.");
                            Console.WriteLine("");
                            
                        }//for

                        break;//Reporte de todos los pagos

                    case "2":
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n****Reportes de Pagos por Servicio****\n");
                        Console.ResetColor();

                            #region SELECCIÓN DEL SERVICIO

                        do
                        {

                            Console.WriteLine("\nSeleccione el servicio a consultar:\n");

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

                            Console.Write("\n\nDigite una opción: ");
                            seleccionServicio = Console.ReadLine(); //almaceno seleccion Servicio

                            Console.WriteLine("");


                            switch (seleccionServicio)
                            {

                                case "1":
                                    seleccionServicio = "Agua";
                                    validacion = true;
                                    break;

                                case "2":
                                    seleccionServicio = "Electricidad";
                                    validacion = true;
                                    break;

                                case "3":
                                    seleccionServicio = "Teléfono Móvil";
                                    validacion = true;
                                    break;

                                case "4":
                                    seleccionServicio = "Internet";
                                    validacion = true;
                                    break;

                                case "5":
                                    seleccionServicio = "TV por cable";
                                    validacion = true;
                                    break;

                                case "6":
                                    seleccionServicio = "Impuestos Municipales";
                                    validacion = true;
                                    break;

                                case "7":
                                    seleccionServicio = "Impuestos de salida del país";
                                    validacion = true;
                                    break;

                                case "8":
                                    seleccionServicio = "Tarjeta transporte público";
                                    validacion = true;
                                    break;

                                case "9":
                                    seleccionServicio = "Subscripción Revista Forbes";
                                    validacion = true;
                                    break;

                                case "10":
                                    seleccionServicio = "Subscripción Diario El Financiero";
                                    validacion = true;
                                    break;

                                default:


                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n*** x_x opción no válida ***\n");
                                    Console.ResetColor();

                                    validacion = false;
                                    break;

                            }//swith

                            Console.Clear();//limpio consola


                        }//do
                        while (validacion == false);

                        #endregion

                        #region MOSTRAR PAGOS POR SERVICIO
                        for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                        {

                            if (ClsPago.ArrayPagos[i] == null) { //si el elemento del array[i] es null, salga del for.
                            
                                //no haga nada ☺

                            }//if


                            else if (ClsPago.ArrayPagos[i].Servicio.NombreServicio == seleccionServicio)
                            {

                                //si el NombreServicio de  Servicio de ArrayPagos[i] == seleccionServicio


                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"***************************************");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                                Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[i].Servicio.NombreServicio}.");
                                Console.ResetColor();
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");

                                float pagó = ClsPago.ArrayPagos[i].Servicio.MontoServicio + ClsPago.ArrayPagos[i].Servicio.Comision;

                                Console.WriteLine($"Monto: ¢{pagó}.");
                                Console.WriteLine("");


                            }//else if

                            else {

                              //que no haga nada... que termine el for y salga..

                            }//else

                            

                        }//for

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nNo hay más pagos registrados para el servicio: " + seleccionServicio);
                        Console.ResetColor();

                        Console.ReadLine();
                        #endregion
                        
                        break;//Reporte de pago por Servicio

                    case "3":
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n****Reportes de Pagos por Sucursal****\n");
                        Console.ResetColor();

                        #region SELECCIÓN DE SUCURSAL

                        do
                        {

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\nSeleccione la sucursal que desea consultar:\n");
                            Console.ResetColor();


                            Console.WriteLine("1  -  Desamparados");
                            Console.WriteLine("2  -  Mall San Pedro");
                            Console.WriteLine("3  -  Super Compro Tres Ríos");
                            Console.WriteLine("4  -  Colima Tibás");
                            Console.WriteLine("5  -  Cartago Ruinas");
                            Console.WriteLine("6  -  Cartago Taras");
                            Console.WriteLine("7  -  Heredia");
                            Console.WriteLine("8  -  San José Av. 2");
                            Console.WriteLine("9  -  San José Calle 10");
                            Console.WriteLine("10 -  Guadalupe El Alto");

                            Console.Write("\n\nDigite una opción: ");
                            seleccionSucursal = Console.ReadLine(); //almaceno seleccion Sucursal


                            switch (seleccionSucursal)
                            {

                                case "1":
                                    seleccionSucursal = "Desamparados";
                                    validacion = true;
                                    break;

                                case "2":
                                    seleccionSucursal = "Mall San Pedro";
                                    validacion = true;
                                    break;

                                case "3":
                                    seleccionSucursal = "Super Compro Tres Ríos";
                                    validacion = true;
                                    break;

                                case "4":
                                    seleccionSucursal = "Colima Tibás";
                                    validacion = true;
                                    break;

                                case "5":
                                    seleccionSucursal = "Cartago Ruinas";
                                    validacion = true;
                                    break;

                                case "6":
                                    seleccionSucursal = "Cartago Taras";
                                    validacion = true;
                                    break;

                                case "7":
                                    seleccionSucursal = "Heredia";
                                    validacion = true;
                                    break;

                                case "8":
                                    seleccionSucursal = "San José Av. 2";
                                    validacion = true;
                                    break;

                                case "9":
                                    seleccionSucursal = "San José Calle 10";
                                    validacion = true;
                                    break;

                                case "10":
                                    seleccionSucursal = "Guadalupe El Alto";
                                    validacion = true;
                                    break;

                                default:


                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n*** x_x opción no válida ***\n");
                                    Console.ResetColor();

                                    validacion = false;
                                    break;

                            }//swith

                            Console.Clear();//limpio consola

                        }//do
                        while (validacion == false);

                        #endregion


                        #region MOSTRAR PAGOS POR SUCURSAL
                        for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                        {

                            if (ClsPago.ArrayPagos[i] == null)
                            { //si el elemento del array[i] es null, salga del for.

                                //no haga nada ☺

                            }//if

                            else if (ClsPago.ArrayPagos[i].Sucursal.NombreSucursal == seleccionSucursal)
                            {

                                //si el NombreSucursal de Sucursal de ArrayPagos[i] == seleccionSucursal


                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"***************************************");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                                Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                                Console.WriteLine($"Servicio: {ClsPago.ArrayPagos[i].Servicio.NombreServicio}.");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");
                                Console.ResetColor();

                                float pagó = ClsPago.ArrayPagos[i].Servicio.MontoServicio + ClsPago.ArrayPagos[i].Servicio.Comision;

                                Console.WriteLine($"Monto: ¢{pagó}.");
                                Console.WriteLine("");


                            }//else if

                            else
                            {

                                //que no haga nada... que termine el for y salga..

                            }//else

                        }//for

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nNo hay más pagos registrados para la sucursal: " + seleccionSucursal);
                        Console.ResetColor();

                        Console.ReadLine();
                        #endregion

                        break;//Reporte de pago por Sucursal

                    case "4":                       
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n****Reportes de Dinero Comisionado por Servicio****\n");
                        Console.ResetColor();

                        #region SELECCIÓN DEL SERVICIO

                        do
                        {

                            Console.WriteLine("\nSeleccione el servicio a consultar:\n");

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
                            Console.WriteLine("11 -  Salir (Menú Principal)");

                            Console.Write("\n\nDigite una opción: ");
                            seleccionServicio = Console.ReadLine(); //almaceno seleccion Servicio

                            Console.WriteLine("");


                            switch (seleccionServicio)
                            {

                                case "1":
                                    seleccionServicio = "Agua";
                                    validacion = true;
                                    break;

                                case "2":
                                    seleccionServicio = "Electricidad";
                                    validacion = true;
                                    break;

                                case "3":
                                    seleccionServicio = "Teléfono Móvil";
                                    validacion = true;
                                    break;

                                case "4":
                                    seleccionServicio = "Internet";
                                    validacion = true;
                                    break;

                                case "5":
                                    seleccionServicio = "TV por cable";
                                    validacion = true;
                                    break;

                                case "6":
                                    seleccionServicio = "Impuestos Municipales";
                                    validacion = true;
                                    break;

                                case "7":
                                    seleccionServicio = "Impuestos de salida del país";
                                    validacion = true;
                                    break;

                                case "8":
                                    seleccionServicio = "Tarjeta transporte público";
                                    validacion = true;
                                    break;

                                case "9":
                                    seleccionServicio = "Subscripción Revista Forbes";
                                    validacion = true;
                                    break;

                                case "10":
                                    seleccionServicio = "Subscripción Diario El Financiero";
                                    validacion = true;
                                    break;

                                default:


                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n*** x_x opción no válida ***\n");
                                    Console.ResetColor();

                                    validacion = false;
                                    break;

                            }//swith

                            Console.Clear();//limpio consola


                        }//do
                        while (validacion == false);

                        #endregion

                        #region MOSTRAR REPORTE DE COMISIONES POR SERVICIO:

                        for (int i = 0; i < ClsPago.ArrayPagos.Length; i++)
                        {
                            

                            if (ClsPago.ArrayPagos[i] == null)
                            { //si el elemento del array[i] es null, salga del for.

                                //no haga nada ☺

                            }//if

                            else if (ClsPago.ArrayPagos[i].Servicio.NombreServicio == seleccionServicio)
                            {

                                //si el NombreServicio de Servicio de ArrayPagos[i] == seleccionServicio


                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"***************************************");
                                Console.ResetColor();

                                Console.WriteLine($"\nFactura: #202402-0{ClsPago.ArrayPagos[i].ConsecutivoPago}.");
                                Console.WriteLine($"Fecha: {ClsPago.ArrayPagos[i].FechayHora}.");
                                Console.WriteLine($"Cliente: {ClsPago.ArrayPagos[i].Cliente.Apellido1} {ClsPago.ArrayPagos[i].Cliente.Apellido2} {ClsPago.ArrayPagos[i].Cliente.Nombre}.");
                                Console.WriteLine($"Sucursal: {ClsPago.ArrayPagos[i].Sucursal.NombreSucursal}.");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Comisión: ¢{ClsPago.ArrayPagos[i].Servicio.Comision}");
                                Console.ResetColor();


                                //Sumo al acumulado de comisión el monto de cada comisión.
                                acumuladoComision = acumuladoComision + ClsPago.ArrayPagos[i].Servicio.Comision;


                            }//else if

                            else
                            {

                                //que no haga nada... que termine el for y salga..

                            }//else

                        }//for

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"***************************************");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl monto total de recaudación por comisión del servicio: {seleccionServicio}, es de: ¢{acumuladoComision}.");
                        Console.ResetColor();

                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadLine();

                        acumuladoComision = 0f; //reseteo el acumulado a 0, por aquello.

                        #endregion



                        break;//Reporte dinero comisionado por Servicio

                    case "5":
                        MenuPrincipal();

                        break;//Volver al menú principal

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** x_x digitó una opción incorrecta ***\n");
                        Console.ResetColor();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadLine();

                        Console.Clear();

                        break;
                }//switch


            }//do
            while ( opcion2 != "1" ||
                    opcion2 != "2" ||
                    opcion2 != "3" ||
                    opcion2 != "4" ||
                    opcion2 != "5"); //while




        }//método subMenuReportes

        #endregion

    }//class
}//space
