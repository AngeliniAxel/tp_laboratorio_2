using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaDeClases;



namespace WindowsFormsCalculadora
{
    public partial class Form1 : Form
    {

        Numero numUno = new Numero();
        Numero numDos = new Numero();
        Numero resultado = new Numero();
        string operador;

        public Form1()
        {
            InitializeComponent();

        }

        #region Eventos

        /// <summary>
        /// Carga el texto escrito por el usuario en la variable numUno
        /// </summary>
        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            numUno = new Numero(this.txtNumero1.Text);
        }

        /// <summary>
        /// Carga el texto escrito por el usuario en la variable numDos
        /// </summary>
        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            numDos = new Numero(this.txtNumero2.Text);
        }

        /// <summary>
        /// Carga el signo seleccionado por el usuario en la variable del mismo tipo llamada operador
        /// </summary>
        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = this.cmbOperacion.Text;
        }

        /// <summary>
        /// Carga el resultado de operacion entre txtNumero1 y txtNumero2 en la variable del mismo nombre
        /// En caso de divisor=0 muestra mensaje de error
        /// </summary>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            resultado = new Numero(Calculadora.operar(numUno, numDos, operador));
            lblResultado.Text = Convert.ToString(resultado.getNumero());

            if (numDos.equalsNumeric(0) && operador == "/")
                MessageBox.Show("No se pude dividir por 0!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Carga todas las variables en 0 y borra todos los textos ingresados por el usuario
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            numUno = new Numero();
            numDos = new Numero();
            resultado = new Numero();

            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperacion.Text = "+";
        }

        #endregion
    }
}
