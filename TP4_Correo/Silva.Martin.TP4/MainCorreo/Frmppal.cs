using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmCorreo : Form
    {
        private Correo correo;
        public FrmCorreo()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado.
        /// Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
        /// Llamará al método ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Text != string.Empty && mtxtTrackingID.Text != "   -   -")
            {
                Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                try
                {
                    correo += p;
                    p.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                }
                catch (TrackingIdRepetidoException exc)
                {
                    MessageBox.Show(exc.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en base de datos: " + ex.Message);
                }
            }
            else
            {
                if (txtDireccion.Text == string.Empty)
                {
                    txtDireccion.BackColor = Color.Red;
                    MessageBox.Show("Por favor defina la dirección de destino");
                }
                if (mtxtTrackingID.Text == "   -   -")
                {
                    mtxtTrackingID.BackColor = Color.Red;
                    MessageBox.Show("Se requiere asignar un Tracking ID");
                }
            }
        }

        /// <summary>
        /// llamará al método ActualizarEstados luego de haber sido invocado en el hilo principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// actualiza los listbox mostrando los paquetes q contiene cada uno
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// muestra la informacion de todos los paquetes y los guarda en un archivo
        /// muestra un mensaje si no puede guardarse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    rtbMostrar.Text.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al guardar en archivo");
                }
            }
        }

        /// <summary>
        /// Mostrará todos los paquetes generados en el RichTextBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Se llama al método FinEntregas a fin de cerrar todos los hilos abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCorreo_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.finEntregas();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.BackColor = Color.White;
        }

        private void mtxtTrackingID_TextChanged(object sender, EventArgs e)
        {
            mtxtTrackingID.BackColor = Color.White;
        }
    }
}
