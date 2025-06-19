using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using musica.Properties;

namespace musica
{
    public partial class Form1: Form // Tela inicial
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            notascadastradas notasForm = new notascadastradas(); // Instancia a nova tela
            notasForm.Show(); // Exibe a tela
            this.Hide(); // Opcional: Esconde a tela atual se não for mais necessária
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Fecha completamente a aplicação
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            importacao notasForm = new importacao(); // Instancia a nova tela
            notasForm.Show(); // Exibe a tela
            this.Hide(); // Opcional: Esconde a tela atual se não for mais necessária
        }
    }
}