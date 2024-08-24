using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class ATM
    {
        private bool usuarioAutenticado; // Verdadero si el usuario es autenticado
        private int numeroCuentaActual; // Numero de cuenta del usuario
        private Pantalla pantalla; // Referencia a la pantalla del ATM
        private Teclado teclado; // Referencia al teclado ATM
        private DispensadorEfectivo dispensadorEfectivo; // Referencia al dispensador de efectivo
        private RanuraDeposito ranuraDeposito; // Referencia a la ranura del deposito
        private BaseDatosBanco baseDatosBanco; // Referencia a la informacion de la base de datos de cuentas
        
        // Enumeracion que representa las opciones del menu principal
        private enum OpcionMenu
        {
            SOLICITUD_SALDO = 1,
            RETIRO = 2,
            DEPOSITO = 3,
            SALIR_ATM = 4,
        }

        // Constructor sin parametro inicializa las variables de instancia
        public ATM()
        {
            usuarioAutenticado = false; // Al principio el usuario no esta autenticado
            numeroCuentaActual = 0; // Al principio no hay numero de cuenta actual
            pantalla = new Pantalla(); // Crea la pantalla
            teclado = new Teclado(); // Crea el teclado
            dispensadorEfectivo = new DispensadorEfectivo(); // Crea el dispensador de efectivo
            ranuraDeposito = new RanuraDeposito(); // Crea la ranura de deposito
            baseDatosBanco = new BaseDatosBanco(); // Crea la base de datos de informacion de las cuentas
        }

        // Inicia ATM
        public void Ejecutar()
        {
            // Bienvenida y autenticacion de usuario; realiza transacciones
            while (true) // ciclo infinto
            {
                // itera mientras el usuario no sea autenticado
                while (!usuarioAutenticado)
                {
                    pantalla.MostrarLineaMensaje("\n!Bienvenido!");
                    AutenticarUsuario(); // Autentica al usuario
                }
                RealizarTransacciones(); // para el usuario autenticado
                usuarioAutenticado = false; // Se restablece antes de la siguiente sesion con el atm
                numeroCuentaActual = 0; // Se restablece antes de la siguiente sesion con el atm
                pantalla.MostrarLineaMensaje("\nGracias! Adios!");
            } 
        }

        // Trata de autenticar al usuario con la base de datos
        private void AutenticarUsuario()
        {
            // Pide el numero de cuenta y lo recibe como entrada del usuario
            pantalla.MostrarMensaje("\nIntroduzca su PIN: ");
            int pin teclado.ObtenerEntrada();

            // Establece usuarioAutenticado al valor boolenado devuelto por la base de datos
            usuarioAutenticado =
                baseDatosBanco.AutenticarUsuario(numeroCuentaActual, pin);

            // Verifica si se realizo la autenticacion con exito
            if (usuarioAutenticado)
            {
                numeroCuentaActual = numeroCuenta; // Guarda el # de cuenta del usuario
            } 
            else
            {
                pantalla.MostrarLineaMensaje("Numero de cuenta o PIN invalido. Intente de nuevo.");
            }
        }

        // Muestra el menu principal y realiza las transacciones
        private void RealizarTransacciones()
        {
            Transaccion transaccionActual; // la transaccion que se esta procesando
            bool usuarioSalio = false; // El usuario no ha elegido salir

            // itera mienteras el usuario no elija la opcion salir
            while (!usuarioSalio)
            {
                // Muestra el menu principal y obtiene la seleccion del usuario
                int seleccionMenuPrincipal = MostrarMenuPrincipal();

                // Decide como proceder, con base en la seleccion del menu del usuario
                switch ((OpcionMenu)seleccionMenuPrincipal) 
                {
                    // El usuario elije realizar uno de tres tipos de transacciones
                    case OpcionMenu.SOLICITUD_SALDO:
                    case OpcionMenu.RETIRO:
                    case OpcionMenu.DEPOSITO:
                        // se inicializa como nuevo objeto del tipo elegido 
                        transaccionActual =
                            CrearTransaccion(seleccionMenuPrincipal);
                        transaccionActual.Ejecutar(); // ejecuta la transaccion
                            break;
                    case OpcionMenu.SALIR_ATM: // el usuario eligio terminar la sesion
                        pantalla.MostrarLineaMensaje("\n...Saliendo del sistema...");
                        usuarioSalio = true;
                        break;
                    default: // El usuario no introdujo un entero del 1 al 4
                        pantalla.MostrarLineaMensaje("\nNo introdujo una seleccion valida. Intente de nuevo.");
                        break;
                } // fin switch
            } // fin while
        } // fin metodo 

        // Muestra el menu principal y devuelve una seleccion de entrada
        private int MostrarMenuPrincipal()
        {
            pantalla.MostrarLineaMensaje("-----\nMenu Principal-----");
            pantalla.MostrarLineaMensaje("1 - Consultar Saldo");
            pantalla.MostrarLineaMensaje("2 - Retirar Efectivo");
            pantalla.MostrarLineaMensaje("3 - Depositar Fondos");
            pantalla.MostrarLineaMensaje("4 - Salir\n");
            pantalla.MostrarLineaMensaje("Introduzca una opcion: ");
            return teclado.ObtenerEntrada();
        }

        // Devuelve un objeto de la clase especificada, derivada de transaccion
        private Transaccion CrearTransaccion( int tipo)
        {
            Transaccion temp = null; // Referencia Transaccion nula

            // Determina el tipo de Transaccion que va a crear
            switch((OpcionMenu) tipo)
            {
                // crea nueva transaccion SolicitudSaldo
                case OpcionMenu.SOLICITUD_SALDO:
                    temp = new SolicitudSaldo(numeroCuentaActual,
                        pantalla, baseDatosBanco);
                    break;
                case OpcionMenu.RETIRO:
                    temp = new Retiro(numeroCuentaActual, pantalla, baseDatosBanco, teclado, dispensadorEfectivo);
                    break;
                case OpcionMenu.DEPOSITO:
                    temp = new Deposito(numeroCuentaActual, pantalla, baseDatosBanco, teclado, ranuraDeposito);
                    break;
            }
            return temp;
        } // fin metodo
    } // fin clase
}
