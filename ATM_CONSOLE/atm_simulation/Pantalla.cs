using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public class Pantalla
    {
        // Muestra un mensaje sin un retorno de carro al final
        public void MostrarMensaje (string mensaje)
        {
            Console.Write(mensaje);
        }
        // Muestra un mensaje con un retorno de carro al final
        public void MostrarLineaMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        // Muestra un monto en dolares
        public void MostrarMontoEnDolares(decimal monto)
        {
            Console.WriteLine("{0:C}", monto);
        }
    }
}
