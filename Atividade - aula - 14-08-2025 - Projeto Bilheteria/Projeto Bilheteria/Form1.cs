using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projeto_Bilheteria
{
    public partial class Form1 : Form
    {
        const int LINHAS = 15;
        const int COLUNAS = 40;
        double[] VALOR = { 50.0, 30.0, 15.0 };

        CheckBox[,] poltronas = new CheckBox[LINHAS, COLUNAS];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriarMapaPoltronas();
            CriarBotoes();
        }

        private void CriarMapaPoltronas()
        {
            int startX = 20, startY = 20;
            int size = 20;

            for (int i = 0; i < LINHAS; i++)
            {
                for (int j = 0; j < COLUNAS; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Appearance = Appearance.Button;
                    cb.Size = new Size(size, size);
                    cb.Location = new Point(startX + j * (size + 2), startY + i * (size + 2));
                    cb.Text = "";
                    cb.BackColor = Color.LightGreen; // vago
                    cb.Tag = new Tuple<int, int>(i, j);

                    cb.CheckedChanged += (s, e) =>
                    {
                        if (cb.Checked)
                            cb.BackColor = Color.Red; // ocupado
                        else
                            cb.BackColor = Color.LightGreen; // vago
                    };

                    this.Controls.Add(cb);
                    poltronas[i, j] = cb;
                }
            }
        }

        private void CriarBotoes()
        {
            Button btnMapa = new Button();
            btnMapa.Text = "Ocupação";
            btnMapa.Location = new Point(20, 400);
            btnMapa.Click += BtnMapa_Click;
            this.Controls.Add(btnMapa);

            Button btnFaturamento = new Button();
            btnFaturamento.Text = "Faturamento";
            btnFaturamento.Location = new Point(150, 400);
            btnFaturamento.Click += BtnFaturamento_Click;
            this.Controls.Add(btnFaturamento);
        }

        private void BtnMapa_Click(object sender, EventArgs e)
        {
            string mapa = "Mapa de Ocupação:\n";
            for (int i = 0; i < LINHAS; i++)
            {
                mapa += (i + 1).ToString("D2") + " ";
                for (int j = 0; j < COLUNAS; j++)
                {
                    mapa += poltronas[i, j].Checked ? "# " : ". ";
                }
                mapa += "\n";
            }

            MessageBox.Show(mapa, "Mapa");
        }

        private void BtnFaturamento_Click(object sender, EventArgs e)
        {
            int ocupados = 0;
            double faturamento = 0;

            for (int i = 0; i < LINHAS; i++)
            {
                for (int j = 0; j < COLUNAS; j++)
                {
                    if (poltronas[i, j].Checked)
                    {
                        ocupados++;
                        if (i < 5)
                            faturamento += VALOR[0];
                        else if (i < 10)
                            faturamento += VALOR[1];
                        else
                            faturamento += VALOR[2];
                    }
                }
            }

            MessageBox.Show($"Qtde de lugares ocupados: {ocupados}\n" +
                            $"Valor da bilheteira: R$ {faturamento:F2}");
        }
    }
}

