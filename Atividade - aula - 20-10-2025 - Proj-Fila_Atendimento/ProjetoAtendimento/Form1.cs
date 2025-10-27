using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAtendimento
{
    public partial class Form1 : Form
    {
        Senhas senhas = new Senhas();
        Guiches guiches = new Guiches();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            senhas.Gerar();
            listSenhas.Items.Clear();
            foreach (Senha s in senhas.FilaSenhas)
                listSenhas.Items.Add(s.DadosParciais());
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Guiche g = new Guiche(guiches.ListaGuiches.Count + 1);
            guiches.Adicionar(g);
            lblQtdeGuiches.Text = guiches.ListaGuiches.Count.ToString();
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            if (guiches.ListaGuiches.Count == 0)
            {
                MessageBox.Show("Adicione ao menos um guichê!");
                return;
            }

            int id = (int)numGuiche.Value - 1;
            if (id < guiches.ListaGuiches.Count)
            {
                guiches.ListaGuiches[id].Chamar(senhas.FilaSenhas);
                listAtendimentos.Items.Clear();
                foreach (Senha s in guiches.ListaGuiches[id].Atendimentos)
                    listAtendimentos.Items.Add(s.DadosCompletos());
            }
            else
            {
                MessageBox.Show("Guichê inválido!");
            }
        }

        private void btnListarSenhas_Click(object sender, EventArgs e)
        {
            listSenhas.Items.Clear();
            foreach (Senha s in senhas.FilaSenhas)
                listSenhas.Items.Add(s.DadosParciais());
        }

        private void btnListarAtend_Click(object sender, EventArgs e)
        {
            listAtendimentos.Items.Clear();
            foreach (Guiche g in guiches.ListaGuiches)
            {
                foreach (Senha s in g.Atendimentos)
                    listAtendimentos.Items.Add($"Guichê {g.Id}: {s.DadosCompletos()}");
            }
        }
    }
}
