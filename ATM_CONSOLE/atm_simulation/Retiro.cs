using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class Retiro : Transaccion
    {
        private decimal monto;
        private Teclado teclado;
        private DispensadorEfectivo dispensadorEfectivo;

        // constante que corresponde a la opcion de menu para cancelar
        private const int CANCELO = 6;
        // constructor de cinco parametros
        public Retiro (int numeroCuentaUsuario, Pantalla pantallaATM, BaseDatosBanco baseDatosBancoATM, Teclado tecladoATM, DispensadorEfectivo dispensadorEfectivoATM)
        : base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
        {
            teclado = tecladoATM;
            dispensadorEfectivo = dispensadorEfectivoATM;
        }

        public override void Ejecutar()
        {
            bool efectivoDispensado = false;
            bool transaccionCancelada = false;
            // itera hasta que se dispense efectivo o el usuario cancele
            do
            {
                // obtiene el monto de retiro elegido por el usuario
                int seleccion = MostrarMenuDeMontos();
                if (seleccion != CANCELO)
                {
                    monto = seleccion;
                    // obtiene el saldo disponible de cla cuenta involucrada
                    decimal saldoDisponible = BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);
                    // compruebe si el suuario tiene suficiente dinero en la cuenta
                    if (monto <= saldoDisponible)
                    {
                        // comprueba si el dispensador de efectivo tiene suficiente dinero
                        if (dispensadorEfectivo.HaySuficienteEfectivoDisponible(monto))
                        {
                            BaseDatos.Cargar(NumeroCuenta, monto);
                            dispensadorEfectivo.DispensarEfectivo(monto);
                            efectivoDispensado = true;

                            // instruye al usuario para que tome el efectivo
                            PantallaUsuario.MostrarLineaMensaje("\nPor favor tome su efectivo del dispensador");
                        }
                    }
                    else // el dispensador no tiene suficiente efectivo
                        PantallaUsuario.MostrarLineaMensaje("\nNo hay suficiente efectivo disponible en el ATM." +
                                                            "\nPor favor elija un monto más pequeño.");
                }
                else // No hay suficiente dinero disponible en la cuenta del usuario
                    PantallaUsuario.MostrarLineaMensaje("\nNo hay suficiente efectivo disponible en su cuenta" +
                        "\n \nPor favor elija un monto mas pequeno");

            } while ((!efectivoDispensado) && (!transaccionCancelada));
        }
    }
}
