using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace musica
{
    public partial class notascadastradas : Form // Tela de pesquisa de notas
    {
        private bool fecharAplicacao = true; // Controla se a aplicação será encerrada

        public notascadastradas()
        {
            InitializeComponent();
            this.FormClosing += notascadastradas_FormClosing; // Garante que o programa feche ao fechar essa tela
        }

        private void notascadastradas_Load(object sender, EventArgs e)
        {
            // Pode ser usado para carregar dados quando a tela abrir
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            fecharAplicacao = false; // Evita que o programa feche ao voltar para a tela inicial
            Form1 formPrincipal = new Form1(); // Instancia a tela inicial
            formPrincipal.Show(); // Exibe a tela inicial
            this.Close(); // Fecha a tela atual
        }

        private void notascadastradas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fecharAplicacao) // Se o usuário fechou manualmente, encerra tudo
            {
                Application.Exit();
            }
        }
    }
}