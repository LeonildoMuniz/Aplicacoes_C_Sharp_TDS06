using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CadastroFriend
{
    public partial class frmCadastro : Form
    {

        #region String Conexão
            SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CadastroFriend\CadastroFriend\DBAmigos.mdf;Integrated Security=True");
        #endregion

        public frmCadastro()
        {
            InitializeComponent();
        }

        #region Fechar
            private void btnFechar_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion

        #region Carrega DGV
            public void CarregaDGV()
            {

                try
                {
                    string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CadastroFriend\CadastroFriend\DBAmigos.mdf;Integrated Security=True";
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


            private void frmCadastro_Load(object sender, EventArgs e)
            {
                CarregaDGV();
            }


        #endregion

        #region Localizar
            private void btnLocaliza_Click(object sender, EventArgs e)
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("Localizar", conexao);
                    cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtNascimento.Text = dr["nascimento"].ToString();
                        txtNome.Text = dr["nome"].ToString();
                        txtCelular.Text = dr["celular"].ToString();
                        txtCidade.Text = dr["cidade"].ToString();
                        MessageBox.Show("Dados encontrados com sucesso!", "Pesquisa localizada");
                        conexao.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado nenhum resultado!", "Sem resultado de pesquisa");
                    }
                }

                finally
                {
                    conexao.Close();
                }


            }
        #endregion

        #region Cadastrar

            private void btnCadastrar_Click(object sender, EventArgs e)
            {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Inserir", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@nascimento", SqlDbType.NChar).Value = txtNascimento.Text.Trim();
                cmd.Parameters.AddWithValue("@cidade", SqlDbType.NChar).Value = txtCidade.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.ExecuteNonQuery();
                CarregaDGV();
                MessageBox.Show("Pessoa Cadastrada com sucesso!", "Cadastro de Pessoas");
                txtNome.Text = "";
                txtNascimento.Text = "";
                txtCelular.Text = "";
                txtCidade.Text = "";
                txtNome.Focus();

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



        #endregion

        #region Editar
            private void btnEditar_Click(object sender, EventArgs e)
            {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("Atualizar", conexao);
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nascimento", SqlDbType.NChar).Value = txtNascimento.Text.Trim();
                cmd.Parameters.AddWithValue("@cidade", SqlDbType.NChar).Value = txtCidade.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.ExecuteNonQuery();
                CarregaDGV();
                MessageBox.Show("Pessoa atualizada com sucesso!", "Atualização de Pessoas");
                txtNome.Text = "";
                txtNascimento.Text = "";
                txtCidade.Text = "";
                txtCelular.Text = "";
                txtNome.Focus();
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

        #endregion

        #region Excluir
            private void btnExcluir_Click(object sender, EventArgs e)
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("Excluir", conexao);
                    cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    CarregaDGV();
                    MessageBox.Show("Pessoa Excluida com sucesso!", "Exclusão de Pessoas");
                    txtNome.Text = "";
                    txtNascimento.Text = "";
                    txtCidade.Text = "";
                    txtCelular.Text = "";
                    txtNome.Focus();
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



        #endregion

        #region Limpar

            private void btnLimpar_Click(object sender, EventArgs e)
            {
                txtNome.Text = "";
                txtNascimento.Text = "";
                txtCidade.Text = "";
                txtCelular.Text = "";
                txtNome.Focus();
            }




        #endregion

        #region Seleciona DGV
            private void dgvPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex];

                    txtNome.Text = row.Cells[0].Value.ToString();
                    txtNascimento.Text = row.Cells[1].Value.ToString();
                    txtCidade.Text = row.Cells[2].Value.ToString();
                    txtCelular.Text = row.Cells[3].Value.ToString();

                }
            }

        #endregion

    }
}
