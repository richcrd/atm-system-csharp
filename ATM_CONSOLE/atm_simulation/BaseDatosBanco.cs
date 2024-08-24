using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class BaseDatosBanco
    {
        private Cuenta[] cuentas; // Arreglo de las cuentas bancarias

        // Constructor sin paramaetros inicializa las cuentas
        public BaseDatosBanco()
        {
            // crea dos objetos cuenta para prueba y los colca en el arreglo cuentas
            cuentas = new Cuenta[2];
            cuentas[0] = new Cuenta( 12345, 54321, 1000.00M, 1200.00M );
            cuentas[1] = new Cuenta( 98765, 56789, 200.00M, 200.00M );
        }

        // Obtiene un objeto Cuenta que contiene el numero de cuenta especificado
        private Cuenta ObtenerCuenta (int numeroCuenta)
        {
            // itera a traves de cuentas, buscando un numero de cuenta que coincida 
            foreach (Cuenta cuentaActual in cuentas)
            {
                if (cuentaActual.NumeroCuenta == numeroCuenta)
                    return cuentaActual;
            }

            // no se encontro la cuenta
            return null;
        }

        // Determina si el numero de cuenta y el PIN especificados por el usuario coinciden con los de una cuenta en la bd
        public bool AutenticarUsuario(int numeroCuentaUsuario, int PINUsuario)
        {
            // intenta obtener la cuenta con el numero de cuenta
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);

            // si la cuenta existe, devuelve el resultado de la funcion ValidarPIN de Cuenta
            if (cuentaUsuario != null)
                return cuentaUsuario.ValidarPIN(PINUsuario); // VERDADERO SI COINCIDE
            else
                return false; // no se encontro el numero de cuenta
        }

        // Devuelve el saldo disponible de la cuenta con el numero de cuenta especificado
        public decimal ObtenerSaldoDisponible(int numeroCuentaUsuario)
        {
            Cuenta cuentaUsario = ObtenerCuenta(numeroCuentaUsuario);
            return cuentaUsario.SaldoDisponible;
        }

        // Devuelve el saldo total de la cuenta con el numero de cuenta especificado
        public decimal ObtenerSaldoTotal(int numeroCuentaUsuario)
        {
            Cuenta cuentaUsario = ObtenerCuenta(numeroCuentaUsuario);
            return cuentaUsario.SaldoTotal;
        }

        // Abona a la cuenta con el numero de cuenta especificado
        public void Abonar (int numeroCuentaUsuario, decimal monto)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            cuentaUsuario.Abonar(monto);
        }

        // Carga a la cuenta con el numeor de cuenta especificado
        public void Cargar(int numeroCuentaUsuario, decimal monto)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            cuentaUsuario.Cargar(monto);
        }
    }
}
