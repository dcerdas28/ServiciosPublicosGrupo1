using System;
using System.Threading;

namespace ServiciosPublicosGrupo1
{
    internal class ClsPago
    {
        #region ARREGLO DE PAGOS
        public static ClsPago[] ArrayPagos = new ClsPago[10]; //Array para almacenar los pagos realizados (hasta 10).
        #endregion

        #region VARIABLES PARA USO DE LA CLASE
        public static float precioFinal; //para almacenar precio final, se usa en varios métodos.
        public static ClsCliente ClienteEncontrado;//Objeto para almacenar el cliente.
        public static ClsServicio ServicioPagar; //Objeto para almacenar el servicio.
        public static ClsSucursal SucursalPagar; //Objeto para almacenar la sucursal.
        public static bool errorPago = false; //para controlar do while en caso de errores en pago.
        public static bool arrayLLeno = false; //para controlar si un array se llenó a través de un for.
        public static int contador = 0; //para ayudar a generar el # de consecutivo de cada pago.
        #endregion

        #region ATRITUBOS Y CONSTRUCTOR

        public int ConsecutivoPago;
        public DateTime FechayHora;
        public ClsCliente Cliente;
        public ClsServicio Servicio;
        public ClsSucursal Sucursal;
        public static float MontoPagar;//El atributo servicio ya trae MontoServicio y Comisión 
        public static float PagaCon;
        public static float Vuelto;

        public ClsPago(int consecutivoPago,
                        DateTime fechayHora,
                        ClsCliente cliente,
                        ClsServicio servicio,
                        ClsSucursal sucursal,
                        float montoPagar,
                        float pagaCon,
                        float vuelto)
        {
            ConsecutivoPago = consecutivoPago;
            FechayHora = fechayHora;
            Cliente = cliente;
            Servicio = servicio;
            Sucursal = sucursal;
            MontoPagar = montoPagar;
            PagaCon = pagaCon;
            Vuelto = vuelto;
        }//constructor.

        #endregion

        #region MÉTODOS DE LA CLASE
        public static void inicializarArrayPagos()
        {

            //El Array de Pagos se inicializa con todos los elementos en null.

            ArrayPagos[0] = null;
            ArrayPagos[1] = null;
            ArrayPagos[2] = null;
            ArrayPagos[3] = null;
            ArrayPagos[4] = null;
            ArrayPagos[5] = null;
            ArrayPagos[6] = null;
            ArrayPagos[7] = null;
            ArrayPagos[8] = null;
            ArrayPagos[9] = null;


        }//Método inicializarArrayPagos

        public static void relizarPagos()
        {

            Console.Clear(); //limpio consola
            Console.WriteLine("***Módulo de Pagos***");

            /*PASOS:
            1-BUSCAR CLIENTE POR APELLIDO
            2-SELECCIONAR EL SERVICIO (CONSULTAR PENDIENTE-SALIR)
            3-REALIZAR PAGO
            4-IMPRIMIR FACTURA*/


            #region BUSCANDO EL CLIENTE
            string apellidoBuscado = "";
            bool errorCliente = false;
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


                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.WriteLine(".");

                    if (ClienteEncontrado != null)
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\nBienvenido: {ClienteEncontrado.Apellido1} {ClienteEncontrado.Apellido2} {ClienteEncontrado.Nombre}");
                        Console.ResetColor();

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

                    Console.WriteLine(  "\nFavor contactar a T.I.");

                }//catch

            }//do

            while (errorCliente == true);


            Console.WriteLine("\nDigite una tecla para continuar...");
            Console.ReadLine();

            #endregion

            #region SELECCIONANDO SERVICIO

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Estimado(a): {ClienteEncontrado.Apellido1} {ClienteEncontrado.Apellido2} {ClienteEncontrado.Nombre}");
            Console.ResetColor();

            //*****************

            string seleccionServicio = "";
            bool validacion = false; //para validar opción válida (true) no válida (false)



            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nSeleccione el servicio a pagar:\n");
                Console.ResetColor();

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

                    case "11":
                        ClsMenu.MenuPrincipal();
                        break;
                    default:


                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** x_x opción no válida ***\n");
                        Console.ResetColor();

                        validacion = false;
                        break;

                }//swith


                /*Busco el servicio seleccionado en el ArrayServicios con una función LAMBDA,
                 el servicio del Array que tenga el atributo NombreServicio == a seleccion servicio,
                se almacenará en ServicioPagar*/


                ServicioPagar = Array.Find(ClsServicio.ArrayServicios, servicio => servicio.NombreServicio == seleccionServicio);

                Console.Clear();

                Console.Write("El servicio seleccionado es: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{ServicioPagar.NombreServicio}");
                Console.ResetColor();
                Console.Write(".");

                #endregion

            #region SELECCIONANDO SUCRUSAL

                //Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n\nCliente: {ClienteEncontrado.Apellido1} {ClienteEncontrado.Apellido2} {ClienteEncontrado.Nombre}");
                Console.ResetColor();

                //*****************

                string sleccionSucursal = "";
                bool validacion2 = false; //para validar opción válida (true) no válida (false)





                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nSeleccione la Sucursal donde dese registrar su pago:\n");
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
                sleccionSucursal = Console.ReadLine(); //almaceno seleccion Sucursal


                switch (sleccionSucursal)
                {

                    case "1":
                        sleccionSucursal = "Desamparados";
                        validacion = true;
                        break;

                    case "2":
                        sleccionSucursal = "Mall San Pedro";
                        validacion = true;
                        break;

                    case "3":
                        sleccionSucursal = "Super Compro Tres Ríos";
                        validacion = true;
                        break;

                    case "4":
                        sleccionSucursal = "Colima Tibás";
                        validacion = true;
                        break;

                    case "5":
                        sleccionSucursal = "Cartago Ruinas";
                        validacion = true;
                        break;

                    case "6":
                        sleccionSucursal = "Cartago Taras";
                        validacion = true;
                        break;

                    case "7":
                        sleccionSucursal = "Heredia";
                        validacion = true;
                        break;

                    case "8":
                        sleccionSucursal = "San José Av. 2";
                        validacion = true;
                        break;

                    case "9":
                        sleccionSucursal = "San José Calle 10";
                        validacion = true;
                        break;

                    case "10":
                        sleccionSucursal = "Guadalupe El Alto";
                        validacion = true;
                        break;

                    default:


                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** x_x opción no válida ***\n");
                        Console.ResetColor();

                        validacion = false;
                        break;

                }//swith


                /*Busco la sucursal seleccionada en el ArraySucursales con una función LAMBDA,
                 la sucursal del Array que tenga el atributo NombreSucursal == a seleccionSucursal,
                se almacenará en SucursalPagar*/


                SucursalPagar = Array.Find(ClsSucursal.ArraySucursales, sucursal => sucursal.NombreSucursal == sleccionSucursal);

                Console.Clear();

                Console.Write("La sucursal seleccionada es: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(sleccionSucursal);
                Console.ResetColor();
                Console.Write(".");

                #endregion

            #region PAGANDO SERVICIO

                precioFinal = ServicioPagar.MontoServicio + ServicioPagar.Comision;

                Console.Write($"\n\nEl monto a pagar por el servicio: {ServicioPagar.NombreServicio}, es de ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"¢{precioFinal}");
                Console.ResetColor();
                Console.Write(".");

                do
                {//errorPago

                    //Aquí controlo que el pago no sea menor al monto a pagar:



                    Console.Write("\n\n¿Con cuánto desea cancelar?: ");

                    float.TryParse(Console.ReadLine(), out PagaCon);





                    if (PagaCon < precioFinal)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nx_X El monto ingresado es menor al precio del servicio");
                        Console.ResetColor();
                        errorPago = true;

                    }//if

                    else
                    {

                        Thread.Sleep(500);
                        Console.WriteLine("\nProcesando pago");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        Thread.Sleep(500);
                        Console.WriteLine(".");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n$$$ PAGO REALIZADO $$$");
                        Console.ResetColor();

                        errorPago = false;

                        contador++; //esto generará el consecutivo para el # de factura.
                    }//else

                }//do error pago
                while (errorPago == true); ;



            }//do
            while (validacion == false);

            #endregion

            Console.WriteLine("\nDigite una tecla para continuar...");
            Console.ReadLine();

            imprimirFactura();

        }//método realizar pagos

        public static void imprimirFactura()
        {

            Console.Clear();//limpio consola


            #region MONTAJE DE FACTURA
            //Se genera objeto tipo ClsPago que se almacenará en el ArrayFacturas


            //Genero el Monto a Pagar Sumando el Monto del Servicio+Comision
            MontoPagar = ServicioPagar.MontoServicio + ServicioPagar.Comision;

            //Genero el vuelto
            Vuelto = PagaCon - MontoPagar;


            //Genero el objeto ClsPago
            ClsPago pago = new ClsPago((contador), DateTime.Now, ClienteEncontrado, ServicioPagar, SucursalPagar, MontoPagar, PagaCon, Vuelto);


            //Antes de agregar al Array verifico si aún tiene espacio disponible

            for (int i = 0; i < ArrayPagos.Length; i++)
            {

                if (ArrayPagos[i] == null)
                {//si encuentra alguna posición en null, aún no está lleno...

                    arrayLLeno = false;
                    break; //con solo encontrar una posisión en null, sale del ciclo.
                }//if

            }//for

            
             if(arrayLLeno == true){
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("°o° El Array de Pagos ya se encuentra lleno, \nno se pueden procesar más transacciónes por hoy.");
                    Console.ResetColor();

                    Console.WriteLine("\nPresione una tecla para volver al menú principal...");
                    //Si el array se llena se va al menu principal

                    Console.ReadLine();
                    ClsMenu.MenuPrincipal();

                }//if
             
             


            //Agrego el pago al ArrayPagos
            for (int i = 0; i < ArrayPagos.Length; i++)
            {
                if (ArrayPagos[i] == null)//si el array en la posición i está null...
                {
                    ArrayPagos[i] = pago;//almacene el objeto "pago" ahí.

                    break;//y sale del ciclo.

                }//if

              
                else //si en la posición i no está null
                {
                    continue;//si el actual índice i no está null, continúa con la siguiente iteración.

                } //else

            }//for

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** Pago de Servicios Públicos S.A.*** ");
            Console.ResetColor();
            Console.WriteLine("");

            Console.WriteLine($"Factura: #202402-0{contador}.");
            Console.WriteLine("Fecha: " + DateTime.Now.ToString() + ".");
            Console.WriteLine("Sucursal: " + SucursalPagar.NombreSucursal);
            Console.WriteLine($"Cliente: {ClienteEncontrado.Apellido1} {ClienteEncontrado.Apellido2} {ClienteEncontrado.Nombre}.");
            Console.WriteLine("Servicio: " + ServicioPagar.NombreServicio + ".");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************************");
            Console.ResetColor();

            Console.WriteLine("Monto del servicio: ¢" + ServicioPagar.MontoServicio + ".");
            Console.WriteLine("Comisión: ¢" + ServicioPagar.Comision);
            Console.WriteLine("Total a pagar: ¢" + MontoPagar+".");
            Console.WriteLine("");
            Console.WriteLine("Paga Con: ¢" + PagaCon + ".");
            Console.WriteLine("Su vuelto es: ¢" + Vuelto + ".");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************************");
            Console.ResetColor();

            Console.WriteLine(  "☺ Gracias por confiar en nuestro trabajo ☺");

            Console.WriteLine("\n\nPresione una tecla para continuar...");
            Console.ReadLine();

            Console.Clear();




            #endregion

  
        }//método imprimir factura

        #endregion

    }//class
}//space
