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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + txtCep.Text + "/json");
            request.AllowAutoRedirect = false;
            HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();
            if (ChecaServidor.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Servidor Indisponível!");
                return; //Sai da rotina e para e codificação
            }
            using (Stream webStream = ChecaServidor.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        response = Regex.Replace(response, "[{},]", string.Empty);
                        response = response.Replace("\"", "");

                        String[] substrings = response.Split('\n');

                        int cont = 0;
                        foreach (var substring in substrings)
                        {
                            if (cont == 1)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                if (valor[0] == "  erro")
                                {
                                    MessageBox.Show("CEP não encontrado!");
                                    txtCep.Focus();
                                    return;
                                }
                            }

                            //Endereço
                            if (cont == 2)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtEndereco.Text = valor[1];
                            }

                            //Complemento
                            if (cont == 3)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtComplemento.Text = valor[1];
                            }

                            //Bairro
                            if (cont == 4)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtBairro.Text = valor[1];
                            }

                            //Cidade
                            if (cont == 5)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtCidade.Text = valor[1];
                            }
                            cont++;
                        }
                    }

                }
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
    }
}

