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

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            numUno = new Numero(this.txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            numDos = new Numero(this.txtNumero2.Text);
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = this.cmbOperacion.Text;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            resultado = new Numero(Calculadora.operar(numUno, numDos, operador));
            lblResultado.Text = Convert.ToString(resultado.getNumero());

            if (numDos.equalsNumeric(0) && operador == "/")
                MessageBox.Show("No se pude dividir por 0!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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
