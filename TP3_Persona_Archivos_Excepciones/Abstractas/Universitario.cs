using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
#pragma warning disable CS0659, CS0661
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Constructor que asigna todos los datos del universitario
        /// </summary>
        /// <param name="legajo">Legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo qué retorna toda la informacion del universitario 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Número de Legajo: " + this.legajo);
            return sb.ToString();
        }
        #endregion

        #region Abstractos
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si dos universitarios son iguales cuando coinciden ser del mismo tipo y tener el mismo DNI o Legajo
        /// </summary>
        /// <param name="uni1">Primer universitario a comparar</param>
        /// <param name="uni2">Segundo universitario a comparar</param>
        /// <returns>true si son iguales</returns>
        public static bool operator ==(Universitario uni1, Universitario uni2)
        {
            bool retorno = false;
            if (uni1.GetType() == uni2.GetType() && (uni1.DNI == uni2.DNI || uni1.legajo == uni2.legajo))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si dos universitarios no son iguales cuando no coinciden ser del mismo tipo y no tienen el mismo DNI o Legajo
        /// </summary>
        /// <param name="uni1">Primer universitario a comparar</param>
        /// <param name="uni2">Segundo universitario a comparar</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universitario uni1, Universitario uni2)
        {
            return !(uni1 == uni2);
        }

        /// <summary>
        /// sobrecarga el equals reutilizando el == 
        /// </summary>
        /// <param name="obj">objeto a comparar </param>
        /// <returns>true si son iguales</returns>
        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }
        #endregion
    }
}
