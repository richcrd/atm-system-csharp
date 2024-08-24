using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_simulation
{
    public abstract class Transaccion
    {
        private int numeroCuenta; // cuenta involucrada en la transaccion
        private Pantalla pantallaUsuario;
        private BaseDatosBanco baseDatos;

        // Constructo de 3 parametros invocado por las clases derivadas
        public Transaccion(int cuentaUsuario, Pantalla laPantalla, BaseDatosBanco laBaseDatos)
        {
            numeroCuenta = cuentaUsuario;
            pantallaUsuario = laPantalla;
            baseDatos = laBaseDatos;
        }

        // Propiedad lectura solo
        public int NumeroCuenta
        {
            get { return numeroCuenta; }
        }
        public Pantalla PantallaUsuario
        {
            get { return pantallaUsuario; }
        }
        public BaseDatosBanco BaseDatos
        {
            get { return baseDatos; }
        }
    }
}
