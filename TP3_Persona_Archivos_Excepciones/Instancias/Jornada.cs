using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Instancias
{
#pragma warning disable CS0661, CS0660
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de los alumnos de la jornada 
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de la clase de la jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad del profesor de la jornada 
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                if (value == this.clase)
                {
                    this.instructor = value;
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que recibe Clase e Instructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la jornada
        /// </summary>
        /// <param name="Guardar"></param>
        /// <returns>Retorna ture si se pudo realizar, caso contrario false</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto texto = new Texto();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\Jornada.txt";
            if (texto.Guardar(archivo, jornada.ToString()))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Retorna la informacion de la jornada guardada
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\Jornada.txt";
            texto.Leer(archivo, out string dato);
            return dato;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna toda la informacion de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nJornada:\n");
            sb.AppendFormat("Clase de {0} por: \n{1}", this.Clase, this.Instructor);
            sb.AppendFormat("Alumnos:\r\n");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<-------------------------------->\r\n");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si un alumno tienen la misma clase que la jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aAux in j.Alumnos)
            {
                if (a == aAux)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si un alumno no tienen la misma clase que la jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si se encuentra cursando la misma clase
        /// </summary>
        /// <param name="j">Jornada a la que se le insertara el anumno</param>
        /// <param name="a">Alumno que se desea insertar</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
