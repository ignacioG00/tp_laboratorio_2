using System;
using System.Linq;
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

        bool binFlag= false;
            
        ///<summary>
        ///
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmb_Operador.SelectedIndex = 0;
            lblResultado.Text = default;
            btn_DecimalABin.Enabled = false;
            btn_BinarioADec.Enabled = false;
            binFlag = false;
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Operar_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.All(char.IsDigit) && !string.IsNullOrWhiteSpace(txtNumero1.Text) &&
                txtNumero2.Text.All(char.IsDigit) && !string.IsNullOrWhiteSpace(txtNumero2.Text))
            {
                double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmb_Operador.Text);
                if (resultado == double.MinValue)
                {
                    MessageBox.Show("No se puede dividir por cero", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    Limpiar();
                }
                else
                {
                    lstOperaciones.Items.Add(txtNumero1.Text + " " + cmb_Operador.Text + " " + txtNumero2.Text
                                             + "=" + resultado.ToString());
                    lblResultado.Text = resultado.ToString();
                    btn_DecimalABin.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Ingrese caracteres numericos unicamente", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Limpiar();
            }
        }

        private static double Operar(string numero1,string numero2,string operador) 
        {
            Operando operador1 = new Operando(numero1);
            Operando operador2 = new Operando(numero2);
            char.TryParse(operador, out char auxOperador);
            return Calculadora.Operar(operador1, operador2, auxOperador);
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro desea salir?", "Salir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_ConvertirADecimal(object sender, EventArgs e)
        {
            if (binFlag)
            {
                Operando numero = new Operando();
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
                binFlag = false;
            }
        }

        private void btn_ConvertirABinario(object sender, EventArgs e)
        {
            if (binFlag==false)
            {
                Operando numero = new Operando();
                lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
                btn_BinarioADec.Enabled = true;
                binFlag = true;
            }
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
