using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SisTDS06
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            FormSplash splash = new FormSplash();
            splash.Show();
            Thread.Sleep(4000);
            splash.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = ClassConecta.ObterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario Where login=@login AND senha=@senha";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@senha", SqlDbType.NChar).Value = txtSenha.Text.Trim();
                SqlDataReader usuario = cmd.ExecuteReader();
                if (usuario.HasRows)
                {
                    this.Hide();
                    FormPrincipal pri = new FormPrincipal();
                    pri.Show();
                    pri.lblUser.Text = txtNome.Text;
                    ClassConecta.FecharConexao();
                }
                else
                {
                    MessageBox.Show("Login ou senha inválido! Por favor, tente novamente!", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtSenha.Text = "";
                    txtNome.Focus();
                    ClassConecta.FecharConexao();
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            
        }
    }
}
