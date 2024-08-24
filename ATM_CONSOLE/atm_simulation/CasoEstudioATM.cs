using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class CasoEstudioATM
    {
        // El metodo Main es el punto de entrada de la aplicacion
        public static void Main(string[] args)
        {
            ATM elATM = new ATM();
            elATM.Ejecutar();
        }
    }
}
