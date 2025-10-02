using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listaAgenda
{
    public partial class Form1 : Form
    {
        private Contatos agenda = new Contatos();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                string[] partes = txtNascimento.Text.Split('/');
                Data data = new Data(int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]));

                Contato novo = new Contato(nome, email, data);

                string tipo = txtTipo.Text;
                string numero = txtNumero.Text;
                bool principal = chkPrincipal.Checked;

                Telefone tel = new Telefone(tipo, numero, principal);
                novo.adicionarTelefone(tel);

                if (agenda.adicionar(novo))
                    MessageBox.Show("Contato adicionado com sucesso!");
                else
                    MessageBox.Show("Contato já existe!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstContatos.Items.Clear();
            foreach (var contato in agenda.Listar())
            {
                lstContatos.Items.Add(contato.ToString());
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Contato pesquisa = new Contato("", email, new Data());

            Contato encontrado = agenda.pesquisar(pesquisa);
            if (encontrado != null)
                MessageBox.Show(encontrado.ToString());
            else
                MessageBox.Show("Contato não encontrado!");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Contato remover = new Contato("", email, new Data());

            if (agenda.remover(remover))
                MessageBox.Show("Contato removido!");
            else
                MessageBox.Show("Contato não encontrado!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
