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
        Numero num = new Numero();
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Limpia los textbox, combobox y label. Además, deshabilita los botones de conversión.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = String.Empty;
            lblResultado.Text = String.Empty;
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }
        /// <summary>
        /// Se encarga de realizar la operacion
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operacion como double</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            char.TryParse(operador, out char op);
            return Calculadora.Operar(num1, num2, op);
        }
        /// <summary>
        /// Finaliza el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Invoca al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Realiza la operacion matematica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (!(txtNumero1.Text == String.Empty || txtNumero2.Text == String.Empty))
            {
                if (!(cmbOperador.Text == String.Empty))
                {
                    lblResultado.Text = (FormCalculadora.Operar
                    (txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
                    lstOperaciones.AppendText($"{txtNumero1.Text} + {txtNumero2.Text} = {lblResultado.Text}\n");
                    btnConvertirABinario.Enabled = true;
                    btnConvertirADecimal.Enabled = false;
                }
                else
                {
                    lblResultado.Text = "Ingrese el operador.";
                }
            }
            else
            {
                lblResultado.Text = "Ingrese ambos numeros.";
            }
        }
        /// <summary>
        /// Realiza la conversion de numero decimal a numero binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = num.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }
        /// <summary>
        /// Realiza la conversion de numero binario a numero decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }
        /// <summary>
        /// Carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Solicita confirmación para cerrar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicacion?", "Mensaje de salida", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
