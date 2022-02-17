using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace CrudEx01
{

    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        #region Botão Cancelar
            private void btnCancelar_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        #endregion

        #region Check Mostrar/Esconder senha
            private void checkMostrarSenha_CheckedChanged(object sender, EventArgs e)
            {
                if (checkMostrarSenha.Checked == true)
                {
                    this.txtSenha.PasswordChar = '\u0000';
                }
                else
                {
                    this.txtSenha.PasswordChar = '*';
                }
            }
        #endregion

        #region Botão Novo Usuario
            private void btnNovo_Click(object sender, EventArgs e)
            {

                try
                {
                    SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ws-visualstudeo\CrudEx01\CrudEx01\DBCadastro.mdf;Integrated Security=True");
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("Localizar", conexao);
                    cmd.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtLogin.Text.Trim();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("Login já existente, não é possivel cadastar novamente", "Erro ao cadastrar");
                    }
                    else
                    {
                        dr.Close();
                        SqlCommand cmd2 = new SqlCommand("Inserir", conexao);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtLogin.Text.Trim();
                        cmd2.Parameters.AddWithValue("@senha", SqlDbType.NChar).Value = txtSenha.Text.Trim();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Usuario cadastrado com sucesso!", "Cadastro");
                        txtLogin.Text = "";
                        txtSenha.Text = "";
                        conexao.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        #endregion

        #region Botão Entrar
            private void btnEntrar_Click(object sender, EventArgs e)
            {
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ws-visualstudeo\CrudEx01\CrudEx01\DBCadastro.mdf;Integrated Security=True");
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Localizar", conexao);
                cmd.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtLogin.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();



                if (dr.Read())
                {
                    
                    MessageBox.Show("Login efetuado com sucesso", "Logado");
                    frmCadastro log = new frmCadastro();
                    this.Hide();
                    log.ShowDialog();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
          
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


    }
}
