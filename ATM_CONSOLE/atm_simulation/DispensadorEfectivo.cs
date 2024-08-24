using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class DispensadorEfectivo
    {
        // Numero inicial predetermindado de billetes en el dispensador de efectivo
        private const int CUENTA_INICIAL = 500;
        private int cuentaBilletes; // numero restante de billetes de $20

        // Constructor sin parametros que inicializa cuentaBilletes con CUENTA_INICIAL
        public DispensadorEfectivo()
        {
            cuentaBilletes = CUENTA_INICIAL;
        }
        // Simula dispensar el monto especificado de efectivo
        public void DispensarEfectivo(decimal monto)
        {
            // numero requerido de billetes de $20
            int billetesRequeridos = ((int)monto) / 20;
            cuentaBilletes -= billetesRequeridos;
        }

        // Indica si el dispensador de efectivo puede dispensar el monto deseado
        public bool HaySuficienteEfectivoDisponible(decimal monto)
        {
            // numero requerido de billetes de $20
            int billetesRequeridos = ((int)monto) / 20;

            // Devuelve si hay suficientes billetes disponibles
            return (cuentaBilletes >= billetesRequeridos);
        } // fin metodo
    } // fin clase
}
