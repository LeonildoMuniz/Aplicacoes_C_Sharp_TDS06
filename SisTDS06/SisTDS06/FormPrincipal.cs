using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisTDS06
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormUsuario usuario = new FormUsuario();
            usuario.Show();


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}
