using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CRUDSQL2022
{
    public partial class FormCrud : Form
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\PROJETO\CRUDSQL2022\CRUDSQL2022\DBPessoa.mdf;Integrated Security=True");


        public FormCrud()
        {
            InitializeComponent();
        }


        public void CarregaDGV()
        {

            try
            {
                string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\PROJETO\CRUDSQL2022\CRUDSQL2022\DBPessoa.mdf;Integrated Security=True";
                string query = "SELECT * FROM Pessoa";
                SqlConnection conexao = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, conexao);
                conexao.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable pessoa = new DataTable();
                da.Fill(pessoa);

                dgvPessoa.DataSource = pessoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex);
            }
            finally
            { 

                conexao.Close();
            }
            

        }

        private void FormCrud_Load(object sender, EventArgs e)
        {
            CarregaDGV();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Inserir", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCpf.Text.Trim();
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@endereco", SqlDbType.NChar).Value = txtEndereco.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.Parameters.AddWithValue("@email", SqlDbType.NChar).Value = txtEmail.Text.Trim();
                cmd.ExecuteNonQuery();
                CarregaDGV();
                MessageBox.Show("Pessoa Cadastrada com sucesso!", "Cadastro de Pessoas");
                txtCpf.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                txtEndereco.Text = "";
                txtNome.Text = "";
                txtCpf.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conexao.Close();
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Atualizar", conexao);
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCpf.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@endereco", SqlDbType.NChar).Value = txtEndereco.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.Parameters.AddWithValue("@email", SqlDbType.NChar).Value = txtEmail.Text.Trim();
                cmd.ExecuteNonQuery();
                CarregaDGV();
                MessageBox.Show("Pessoa atualizada com sucesso!", "Atualização de Pessoas");
                txtCpf.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                txtEndereco.Text = "";
                txtNome.Text = "";
                txtCpf.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Excluir", conexao);
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCpf.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
 
                cmd.ExecuteNonQuery();
                CarregaDGV();
                MessageBox.Show("Pessoa Excluida com sucesso!", "Exclusão de Pessoas");
                txtCpf.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                txtEndereco.Text = "";
                txtNome.Text = "";
                txtCpf.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Localizar", conexao);
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCpf.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtCpf.Text = dr["cpf"].ToString();
                    txtNome.Text = dr["nome"].ToString();
                    txtCelular.Text = dr["celular"].ToString();
                    txtEndereco.Text = dr["endereco"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    MessageBox.Show("Dados encontrados com sucesso!","Pesquisa localizada");
                    conexao.Close();
                }
                else
                {
                    MessageBox.Show("Não foi encontrado nenhum resultado!","Sem resultado de pesquisa");
                }
            }

            finally
            {
                conexao.Close();
            }
        }

        private void bntLimpar_Click(object sender, EventArgs e)
        {
            txtCpf.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
        }
    }
}
