using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisTDS06;

namespace SisTDS06
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPrincipal ret = new FormPrincipal();
            ret.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario cad = new Usuario();
            cad.Inserir(txtNome.Text, txtLogin.Text, txtSenha.Text, txtCelular.Text, dateNasc.Value, dateAdm.Value, txtEndereco.Text, txtCidade.Text, txtBairro.Text, txtEmail.Text, Convert.ToInt32(txtCep.Text), txtFuncao.Text, txtFuncao.Text);

        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            string[] valores = new string[4];
            BuscaCEP busca = new BuscaCEP();
            valores = busca.CEP(txtCep.Text);

            if (valores is null)
            {
                MessageBox.Show("ERRO ao localizar CEP", "Erro de busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtEndereco.Text = valores[0];
                txtBairro.Text = valores[2];
                txtCidade.Text = valores[3];
                txtComplemento.Text = valores[1];
            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Usuario at = new Usuario();
            at.Atualizar(Convert.ToInt32(txtId.Text),txtNome.Text, txtLogin.Text, txtSenha.Text, txtCelular.Text, dateNasc.Value, dateAdm.Value, txtEndereco.Text, txtCidade.Text, txtBairro.Text, txtEmail.Text, Convert.ToInt32(txtCep.Text), txtFuncao.Text, txtFuncao.Text);

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Usuario ex= new Usuario();
            ex.Exclui(Convert.ToInt32(txtId.Text));
            MessageBox.Show("Usuario Excluido com sucesso!");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtBairro.Text = "";
            txtCelular.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtComplemento.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtFuncao.Text = "";
            txtId.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            dateAdm.Value = DateTime.Now;
            dateNasc.Value = DateTime.Now;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
           
            
            Usuario at = new Usuario();
            string[] inf = new string[12];
            inf = at.Localiza(Convert.ToInt32(txtId.Text));

            if (inf is null)
            {
                MessageBox.Show("Erro ao localizar contato, revise os dados", "Erro de busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtBairro.Text = "";
                txtCelular.Text = "";
                txtCep.Text = "";
                txtCidade.Text = "";
                txtComplemento.Text = "";
                txtEmail.Text = "";
                txtEndereco.Text = "";
                txtFuncao.Text = "";
                txtId.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                dateAdm.Value = DateTime.Now;
                dateNasc.Value = DateTime.Now;
                txtNome.Focus();
            }
            else
            {
                txtNome.Text = inf[0].Trim();
                txtLogin.Text = inf[1].Trim();
                txtSenha.Text = inf[2].Trim();
                txtCelular.Text = inf[3].Trim();
                dateNasc.Value = Convert.ToDateTime(inf[4]);
                dateAdm.Value = Convert.ToDateTime(inf[5]);
                txtEndereco.Text = inf[6].Trim();
                txtCidade.Text = inf[7].Trim();
                txtBairro.Text = inf[8].Trim();
                txtEmail.Text = inf[9].Trim();
                txtCep.Text = inf[10].Trim();
                txtFuncao.Text = inf[11].Trim();
                txtComplemento.Text = inf[12].Trim();
            }


        }
    }
}

