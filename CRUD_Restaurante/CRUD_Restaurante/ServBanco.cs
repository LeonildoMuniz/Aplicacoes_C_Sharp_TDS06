using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_Restaurante
{
    class ServBanco
    {
        public string Con { get; set; }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CRUD_Restaurante\CRUD_Restaurante\BDClientes.mdf;Integrated Security=True");
        public List<Clientes> listaCliente()
        {
            List<Clientes> li = new List<Clientes>();
            string sql = "SELECT * FROM Clientes";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            foreach (var clientes in dr)
            {
                Clientes dados = new Clientes();
                dados.Id = Convert.ToInt32(dr["Id"]);
                dados.Nome = dr["nome"].ToString();
                dados.Data = Convert.ToDateTime(dr["data"]);
                dados.Email = dr["email"].ToString();
                dados.Celular = dr["celular"].ToString();
                dados.Cidade = dr["cidade"].ToString();
                li.Add(dados);
            }

            return li;
        }


        public void Inserir(string nome, DateTime data, string email, string celular, string cidade)
        {
            try
            {
                Convert.ToDateTime(data);
                string sql = "INSERT INTO Clientes(nome, data, email, celular, cidade) VALUES  ('" + nome + "','" + data + "','" + email + "','" + celular + "','" + cidade + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
           catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                
            }

        }


        public void Localiza(int Id)
        {

            try
            {
                string sql = "SELECT * FROM Clientes WHERE Id = '" + Id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var clientes in dr)
                {
                    Clientes dados = new Clientes();
                    dados.Id = Convert.ToInt32(dr["Id"]);
                    dados.Nome = dr["nome"].ToString();
                    dados.Data = Convert.ToDateTime(dr["data"]);
                    dados.Email = dr["email"].ToString();
                    dados.Celular = dr["celular"].ToString();
                    dados.Cidade = dr["cidade"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);

            }


        }

        public void Atualizar(int Id, string nome, DateTime data, string email, string celular, string cidade)
        {

            try
            {
                string sql = "UPDATE Clientes SET nome='" + nome + "', data='" + data + "', email='" + email + "',celular='" + celular + "',cidade='" + cidade + "' WHERE id='" + Id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex);

            }
            


        }

        public void Excluir(int Id)
        {

            try
            {
                string sql = "DELETE FROM Clientes WHERE id='" + Id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex);

            }
            

        }


    }
}
