using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Player
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador();
            List<Jogador> jogadores = jogador.listaJogador();

            dgvPlayer.DataSource = jogadores;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador();
            jogador.Inserir(txtNome.Text,txtCidade.Text,txtEmail.Text,txtCelular.Text);
            MessageBox.Show("Cadastro realizado com sucesso!");
            List<Jogador> jogadores = jogador.listaJogador();
            dgvPlayer.DataSource = jogadores;

            txtCelular.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Atualizar(Id,txtNome.Text, txtCidade.Text, txtEmail.Text, txtCelular.Text);
            MessageBox.Show("Atualizado com sucesso!");
            List<Jogador> jogadores = jogador.listaJogador();
            dgvPlayer.DataSource = jogadores;

            txtCelular.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtId.Text = "";
            txtNome.Text = "";

        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Localiza(Id);
            txtNome.Text = jogador.nome;
            txtCidade.Text = jogador.cidade;
            txtEmail.Text = jogador.email;
            txtCelular.Text = jogador.cidade;
        
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Excluir (Id);
            MessageBox.Show("Cadastro excluido com sucesso!");
            List<Jogador> jogadores = jogador.listaJogador();
            dgvPlayer.DataSource = jogadores;
            txtNome.Text = jogador.nome;
            txtCidade.Text = jogador.cidade;
            txtEmail.Text = jogador.email;
            txtCelular.Text = jogador.cidade;

        }
    }


    
}
