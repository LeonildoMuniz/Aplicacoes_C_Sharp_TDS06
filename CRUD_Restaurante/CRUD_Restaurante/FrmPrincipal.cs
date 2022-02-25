using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Restaurante
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ServBanco carregar = new ServBanco();
            dgvClientes.DataSource = carregar.listaCliente();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {


        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
          
            ServBanco localizar = new ServBanco();
            localizar.Inserir(txtNome.Text, dataNasc.Value.Date, txtEmail.Text, txtCelular.Text, txtCidade.Text); 
            MessageBox.Show("Cadastro efetuado com sucesso");
            txtCelular.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtId.Text = "";
            this.dataNasc.Value = DateTime.Now.Date;
        }
    }
}
