using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class SolicitudSaldo : Transaccion
    {
        // Constructor de 5 parametros inicializa las variables de la clase base 
        public SolicitudSaldo(int numeroCuentaUsuario, Pantalla pantallaATM, BaseDatosBanco baseDatosBancoATM)
            : base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM){ }

        // realiza una transaccion; redefine el metodo abstracto de transaccion 
        public override void Ejecutar()
        {
            // obtiene el saldo disponible para la Cuenta del usuario actual
            decimal saldoDisponible = BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);

            // obtiene el saldo total para la cuenta del usuario actual
            decimal saldoTotal = BaseDatos.ObtenerSaldoTotal(NumeroCuenta);

            // muestra la informacion del saldo en la pantalla
            PantallaUsuario.MostrarLineaMensaje("\nInformacion del saldo:");
            PantallaUsuario.MostrarMensaje(" - Saldo disponible: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoDisponible);
            PantallaUsuario.MostrarMensaje("\n - Saldo total: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoTotal);
            PantallaUsuario.MostrarLineaMensaje("");
        }
        
    }
}
