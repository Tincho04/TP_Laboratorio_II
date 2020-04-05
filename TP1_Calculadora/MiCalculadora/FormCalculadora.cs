using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = FormCalculadora.Operar(txtNro1.Text, txtNro2.Text, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNro1.Text = "";
            txtNro2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }


        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculadora = new Calculadora();
            double resultado = calculadora.Operar(num1, num2, operador);
            return resultado;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            double aux;
            Numero numeroBinario = new Numero();
            if (double.TryParse(lblResultado.Text, out aux))
            { 
            lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
            }
            else
            {
            btnConvertirADecimal.Enabled = false;
            }
    }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
    }
}
