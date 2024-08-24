using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class Cuenta
    {
        private int numeroCuenta;
        private int pin;
        private decimal saldoDispoible; // monto dispobile para retiro
        private decimal saldoTotal; // fondos disponibles + deposito pendiente

        // Constructor de cuatro parametros inicializa los atributos
        public Cuenta(int elNumeroCuenta, int elPIN, decimal elSaldoDisponible, decimal elSaldoTotal)
        {
            numeroCuenta = elNumeroCuenta;
            pin = elPIN;
            saldoDispoible = elSaldoDisponible;
            saldoTotal = elSaldoTotal;
        }

        // Propiedad de solo lectura que obtiene el numero de cuenta
        public int NumeroCuenta
        {
            get { return numeroCuenta; }
        }

        // Propiedad de solo lectura que obtiene el saldo disponible
        public decimal SaldoDisponible
        {
            get { return saldoDispoible; }
        }

        // Propiedad de solo lectura que obtiene el saldo total
        public decimal SaldoTotal
        {
            get { return saldoTotal; }
        }

        // Determina si un PIN especificado por el usuario coincide con un PIN en cuenta 
        public bool ValidarPIN(int PINUsario)
        {
            return (PINUsario == pin);
        }

        // Abona a la cuenta (los fondos no se han verificado todavia)
        public void Abonar(decimal monto)
        {
            saldoTotal += monto;
        }

        // Carga la cuenta
        public void Cargar(decimal monto)
        {
            saldoDispoible -= monto;
            saldoTotal -= monto;
        }
    }
}
