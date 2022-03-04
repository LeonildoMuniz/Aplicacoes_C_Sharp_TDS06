using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Teste_CRUD
{
    class Usuario

    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public DateTime data_nascimento { get; set; }
        public DateTime data_admissao { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string email { get; set; }
        public int cep { get; set; }
        public string funcao { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SisTDS06\SisTDS06\DbSis.mdf;Integrated Security=True");

        public void Inserir(string nome, string login, string senha, string celular, DateTime data_nascimento, DateTime data_admissao, string endereco, string cidade, string bairro, string email, int cep, string funcao)
        {
            string dta_ad = data_admissao.ToString("yyyy/MM/dd");
            string dta_na = data_nascimento.ToString("yyyy/MM/dd");
            string sql = "INSERT INTO Jogador(nome,cidade,email,celular) VALUES ('" + nome + "','" + login + "','" + senha + "','" + celular + ",'" + dta_ad + ",'" + dta_na + ",'" + endereco + "" +
                ",'" + cidade + ",'" + bairro + ",'" + email + ",'" + cep + ",'" + funcao + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Usuario> listaUsuario()
        {
            List<Usuario> li = new List<Usuario>();
            string sql = "SELECT * FROM Usuario";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario u = new Usuario();
                u.Id = (int)dr["Id"];
                u.nome = dr["nome"].ToString();
                u.login = dr["login"].ToString();
                u.senha = dr["senha"].ToString();
                u.celular = dr["celular"].ToString();
                u.data_nascimento = Convert.ToDateTime(dr["data_nascimento"]);
                u.data_admissao = Convert.ToDateTime(dr["data_admissao"]);
                u.endereco = dr["endereco"].ToString();
                u.cidade = dr["cidade"].ToString();
                u.bairro = dr["bairro"].ToString();
                u.email = dr["email"].ToString();
                u.cep = Convert.ToInt32(dr["cep"]);
                u.funcao = dr["funcao"].ToString();
                li.Add(u);
            }
            return li;
        }

        public void Localiza(int id)
        {
            string sql = "SELECT * FROM Usuario WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                login = dr["login"].ToString();
                senha = dr["senha"].ToString();
                celular = dr["celular"].ToString();
                data_nascimento = Convert.ToDateTime(dr["data_nascimento"]);
                data_admissao = Convert.ToDateTime(dr["data_admissao"]);
                endereco = dr["endereco"].ToString();
                cidade = dr["cidade"].ToString();
                bairro = dr["bairro"].ToString();
                email = dr["email"].ToString();
                cep = Convert.ToInt32(dr["cep"]);
                funcao = dr["funcao"].ToString();
            }
        }

        public void Atualizar(int Id, string nome, string login, string senha, string celular, DateTime data_nascimento, DateTime data_admissao, string endereco, string cidade, string bairro, string email, int cep, string funcao)
        {
            string dta_ad = data_admissao.ToString("yyyy/MM/dd");
            string dta_na = data_nascimento.ToString("yyyy/MM/dd");
            string sql = "UPDATE Jogador SET '" + nome + "','" + login + "','" + senha + "','" + celular + ",'" + dta_ad + ",'" + dta_na + ",'" + endereco + "" +
                ",'" + cidade + ",'" + bairro + ",'" + email + ",'" + cep + ",'" + funcao + "'  WHERE Id = '" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Exclui(int id)
        {
            string sql = "DELETE FROM Cliente WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

