using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class Teclado
    {
        // Devuelve un valor entero introducido por el usuario
        public int ObtenerEntrada()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
