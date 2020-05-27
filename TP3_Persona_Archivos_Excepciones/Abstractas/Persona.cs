using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del apellido de la Persona
        /// </summary>
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        /// <summary>
        /// Propiedad del DNI de la Persona
        /// </summary>
        public int DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        /// <summary>
        /// Propiedad de la nacionalidad de la Persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad del nombre de la Persona
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Propiedad del parseo del DNI de la Persona
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = this.ValidarDNI(this.Nacionalidad, value); }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor que asigna los datos de la Persona
        /// </summary>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que asigna todos los datos del universitario
        /// </summary>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario en formato Int</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que asigna todos los datos del universitario
        /// </summary>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario en String</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo qué retorna toda la informacion de la persona 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nombre: {0}\r\n", this.nombre);
            sb.AppendFormat("Apellido: {0}\r\n", this.apellido);
            sb.AppendFormat("Nacionalidad: {0}\r\n", this.nacionalidad);
            sb.AppendFormat("DNI: {0}\r\n", this.dni);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Metodo qué validará el DNI en base a la nacionalidad
        /// </summary>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato > 0 && dato <= 89999999) ||
                (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 999999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI.");
            }
        }

        /// <summary>
        /// Metodo qué validará el DNI como un formato válido
        /// </summary>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (int.TryParse(dato, out dni) &&
                dato.Length < 9)
            {
                return ValidarDNI(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("DNI INVALIDO");
            }
        }


        /// <summary>
        /// Metodo qué validará el nombre y apellido de la persona
        /// </summary>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            bool letras = true;
            foreach (char letra in dato)
            {
                if (!Char.IsLetter(letra))
                { letras = false; }
            }

            if (letras == true)
            { return dato; }
            else { return string.Empty; }
        }
        #endregion
    }
}
