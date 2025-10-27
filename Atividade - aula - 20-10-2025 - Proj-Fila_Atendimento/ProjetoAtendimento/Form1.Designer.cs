namespace ProjetoAtendimento
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer — não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listSenhas = new System.Windows.Forms.ListBox();
            this.listAtendimentos = new System.Windows.Forms.ListBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnListarSenhas = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnChamar = new System.Windows.Forms.Button();
            this.btnListarAtend = new System.Windows.Forms.Button();
            this.lblQtdeGuiches = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numGuiche = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numGuiche)).BeginInit();
            this.SuspendLayout();
            // 
            // listSenhas
            // 
            this.listSenhas.FormattingEnabled = true;
            this.listSenhas.ItemHeight = 16;
            this.listSenhas.Location = new System.Drawing.Point(25, 60);
            this.listSenhas.Name = "listSenhas";
            this.listSenhas.Size = new System.Drawing.Size(240, 180);
            this.listSenhas.TabIndex = 0;
            // 
            // listAtendimentos
            // 
            this.listAtendimentos.FormattingEnabled = true;
            this.listAtendimentos.ItemHeight = 16;
            this.listAtendimentos.Location = new System.Drawing.Point(370, 60);
            this.listAtendimentos.Name = "listAtendimentos";
            this.listAtendimentos.Size = new System.Drawing.Size(300, 180);
            this.listAtendimentos.TabIndex = 1;
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(25, 20);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(100, 30);
            this.btnGerar.TabIndex = 2;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnListarSenhas
            // 
            this.btnListarSenhas.Location = new System.Drawing.Point(25, 250);
            this.btnListarSenhas.Name = "btnListarSenhas";
            this.btnListarSenhas.Size = new System.Drawing.Size(120, 30);
            this.btnListarSenhas.TabIndex = 3;
            this.btnListarSenhas.Text = "Listar Senhas";
            this.btnListarSenhas.UseVisualStyleBackColor = true;
            this.btnListarSenhas.Click += new System.EventHandler(this.btnListarSenhas_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(280, 160);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(80, 30);
            this.btnAdicionar.TabIndex = 4;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnChamar
            // 
            this.btnChamar.Location = new System.Drawing.Point(590, 20);
            this.btnChamar.Name = "btnChamar";
            this.btnChamar.Size = new System.Drawing.Size(80, 30);
            this.btnChamar.TabIndex = 5;
            this.btnChamar.Text = "Chamar";
            this.btnChamar.UseVisualStyleBackColor = true;
            this.btnChamar.Click += new System.EventHandler(this.btnChamar_Click);
            // 
            // btnListarAtend
            // 
            this.btnListarAtend.Location = new System.Drawing.Point(370, 250);
            this.btnListarAtend.Name = "btnListarAtend";
            this.btnListarAtend.Size = new System.Drawing.Size(160, 30);
            this.btnListarAtend.TabIndex = 6;
            this.btnListarAtend.Text = "Listar Atendimentos";
            this.btnListarAtend.UseVisualStyleBackColor = true;
            this.btnListarAtend.Click += new System.EventHandler(this.btnListarAtend_Click);
            // 
            // lblQtdeGuiches
            // 
            this.lblQtdeGuiches.AutoSize = true;
            this.lblQtdeGuiches.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblQtdeGuiches.Location = new System.Drawing.Point(300, 120);
            this.lblQtdeGuiches.Name = "lblQtdeGuiches";
            this.lblQtdeGuiches.Size = new System.Drawing.Size(30, 31);
            this.lblQtdeGuiches.TabIndex = 7;
            this.lblQtdeGuiches.Text = "0";
            // 
            // label1 (Qtde guichês)
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Qtde guichês";
            // 
            // label2 (Guichê:)
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Guichê:";
            // 
            // numGuiche
            // 
            this.numGuiche.Location = new System.Drawing.Point(430, 25);
            this.numGuiche.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numGuiche.Name = "numGuiche";
            this.numGuiche.Size = new System.Drawing.Size(60, 22);
            this.numGuiche.TabIndex = 10;
            this.numGuiche.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 300);
            this.Controls.Add(this.numGuiche);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblQtdeGuiches);
            this.Controls.Add(this.btnListarAtend);
            this.Controls.Add(this.btnChamar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnListarSenhas);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.listAtendimentos);
            this.Controls.Add(this.listSenhas);
            this.Name = "Form1";
            this.Text = "Atendimento";
            ((System.ComponentModel.ISupportInitialize)(this.numGuiche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listSenhas;
        private System.Windows.Forms.ListBox listAtendimentos;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnListarSenhas;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnChamar;
        private System.Windows.Forms.Button btnListarAtend;
        private System.Windows.Forms.Label lblQtdeGuiches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numGuiche;
    }
}
