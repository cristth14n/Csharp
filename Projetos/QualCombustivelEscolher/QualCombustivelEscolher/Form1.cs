using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualCombustivelEscolher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalculo_Click(object sender, EventArgs e)
        {





            if (txtprecoEtanol.Text == "")
            {
                DialogResult dialogResult = MessageBox.Show("Por favor, preencha todos os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    Calculodepreco comparando = new Calculodepreco();
                    comparando.precoEtanol = double.Parse(txtprecoEtanol.Text);
                    comparando.precoGasolina = double.Parse(txtprecoGasolina.Text);
                    double valorRetorno = comparando.comparacao();

                    if (valorRetorno < 0.7)
                    {
                        DialogResult dialogResult = MessageBox.Show("Vale mais a pena usar Etanol!" ,"", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Vale mais a pena usar Gasolina! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }

                }
                catch
                {
                    MessageBox.Show("Por favor, use apenas números!","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    txtprecoEtanol.Text = "";
                    txtprecoGasolina.Text = "";
                }
                


            }




        }

        private void txtprecoEtanol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprecoEtanol_Click(object sender, EventArgs e)
        {
           
            label1.Visible = true;

        }

        private void txtprecoEtanol_Leave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void txtprecoGasolina_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void txtprecoGasolina_Leave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }

}

