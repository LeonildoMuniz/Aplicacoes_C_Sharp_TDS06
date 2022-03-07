using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisTDS06
{
    internal class BuscaCEP
    {

   
        public string[] CEP(string cep)
        {

            try
            {
                string[] dados = new string[4];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + cep + "/json");
                request.AllowAutoRedirect = false;
                HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();
                if (ChecaServidor.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Servidor Indisponível!");
                    return null; //Sai da rotina e para e codificação
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
                                        return null;
                                    }
                                }

                                //Endereço
                                if (cont == 2)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    dados[0] = valor[1];
                                }

                                //Complemento
                                if (cont == 3)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    dados[1] = valor[1];
                                }

                                //Bairro
                                if (cont == 4)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    dados[2] = valor[1];
                                }

                                //Cidade
                                if (cont == 5)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    dados[3] = valor[1];
                                }
                                cont++;
                            }
                        }

                    }
                }
                return dados;
            }
            catch (Exception)
            {

                return null;
            }

        }
        
    }
}
