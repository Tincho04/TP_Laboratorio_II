using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Instancias
{
#pragma warning disable CS0661, CS0660
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor que recibe todos los parametros menos el estado de cuenta
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="claseQueToma">La clase que toma</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que recibe todos los parametros
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="claseQueToma">La clase que toma</param>
        /// <param name="estadoCuenta">El estado de de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que retorna toda la informacion del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que retorna que clase está tomando
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Toma clase de:  " + this.claseQueToma);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que retorna toda la información del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba que un alumno cursa una clase en especifico
        /// </summary>
        /// <param name="a">Alumno del que se desea saber que clase cursa</param>
        /// <param name="clase">Clase en la que se desea saber si cursa el alumno</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba qué un alumno no curse una clase en especifico
        /// </summary>
        /// <param name="a">Alumno del que se desea saber que clase cursa</param>
        /// <param name="clase">Clase en la que se desea saber si cursa el alumno</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma != clase)
            {
                retorno = true;
            }
            return retorno;
        }
        #endregion

        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
