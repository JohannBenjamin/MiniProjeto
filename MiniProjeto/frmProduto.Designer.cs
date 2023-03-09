namespace MiniProjeto
{
    partial class frmProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCodigoCategoria = new System.Windows.Forms.ComboBox();
            this.cboNomeCategoria = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCadastro = new System.Windows.Forms.MaskedTextBox();
            this.numQtde = new System.Windows.Forms.NumericUpDown();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtVenda = new System.Windows.Forms.TextBox();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCadastrarMelhorado = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataProduto = new System.Windows.Forms.DataGridView();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtde)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCodigoCategoria);
            this.groupBox1.Controls.Add(this.cboNomeCategoria);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboCodigoCategoria
            // 
            this.cboCodigoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodigoCategoria.Enabled = false;
            this.cboCodigoCategoria.FormattingEnabled = true;
            this.cboCodigoCategoria.Location = new System.Drawing.Point(438, 57);
            this.cboCodigoCategoria.Name = "cboCodigoCategoria";
            this.cboCodigoCategoria.Size = new System.Drawing.Size(121, 33);
            this.cboCodigoCategoria.TabIndex = 3;
            // 
            // cboNomeCategoria
            // 
            this.cboNomeCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNomeCategoria.FormattingEnabled = true;
            this.cboNomeCategoria.Location = new System.Drawing.Point(193, 57);
            this.cboNomeCategoria.Name = "cboNomeCategoria";
            this.cboNomeCategoria.Size = new System.Drawing.Size(239, 33);
            this.cboNomeCategoria.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 25);
            this.label11.TabIndex = 3;
            this.label11.Text = "Nome da Categoria";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(154, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 33);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(6, 57);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(142, 33);
            this.txtCodigo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código da Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCadastro);
            this.groupBox2.Controls.Add(this.numQtde);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.txtUnidade);
            this.groupBox2.Controls.Add(this.txtPeso);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(838, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtCadastro
            // 
            this.txtCadastro.Location = new System.Drawing.Point(604, 120);
            this.txtCadastro.Mask = "00/00/0000";
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.Size = new System.Drawing.Size(228, 33);
            this.txtCadastro.TabIndex = 5;
            this.txtCadastro.ValidatingType = typeof(System.DateTime);
            // 
            // numQtde
            // 
            this.numQtde.Location = new System.Drawing.Point(6, 121);
            this.numQtde.Margin = new System.Windows.Forms.Padding(5);
            this.numQtde.Name = "numQtde";
            this.numQtde.Size = new System.Drawing.Size(157, 33);
            this.numQtde.TabIndex = 2;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cboStatus.Location = new System.Drawing.Point(604, 57);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(228, 33);
            this.cboStatus.TabIndex = 1;
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(412, 120);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(186, 33);
            this.txtUnidade.TabIndex = 4;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(171, 121);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(235, 33);
            this.txtPeso.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(6, 57);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(592, 33);
            this.txtNome.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Unidade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(604, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Data de Cadastro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Peso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quantidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtVenda);
            this.groupBox3.Controls.Add(this.txtCusto);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(838, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtVenda
            // 
            this.txtVenda.Location = new System.Drawing.Point(272, 57);
            this.txtVenda.Name = "txtVenda";
            this.txtVenda.Size = new System.Drawing.Size(254, 33);
            this.txtVenda.TabIndex = 1;
            // 
            // txtCusto
            // 
            this.txtCusto.Location = new System.Drawing.Point(6, 57);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(260, 33);
            this.txtCusto.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Valor de Venda";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Valor de Custo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtObs);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(12, 395);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(838, 195);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(6, 57);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(826, 128);
            this.txtObs.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Obs";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCadastrarMelhorado);
            this.groupBox5.Controls.Add(this.btnCadastrar);
            this.groupBox5.Controls.Add(this.btnAlterar);
            this.groupBox5.Controls.Add(this.btnLimpar);
            this.groupBox5.Controls.Add(this.btnExcluir);
            this.groupBox5.Controls.Add(this.btnSair);
            this.groupBox5.Location = new System.Drawing.Point(12, 596);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(838, 75);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // btnCadastrarMelhorado
            // 
            this.btnCadastrarMelhorado.Location = new System.Drawing.Point(117, 32);
            this.btnCadastrarMelhorado.Name = "btnCadastrarMelhorado";
            this.btnCadastrarMelhorado.Size = new System.Drawing.Size(219, 32);
            this.btnCadastrarMelhorado.TabIndex = 0;
            this.btnCadastrarMelhorado.Text = "Cadastrar (Melhorado)";
            this.btnCadastrarMelhorado.UseVisualStyleBackColor = true;
            this.btnCadastrarMelhorado.Click += new System.EventHandler(this.btnCadastrarMelhorado_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(342, 32);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(102, 32);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(450, 32);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(91, 32);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(547, 32);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(91, 32);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(644, 32);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(91, 32);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(741, 32);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(91, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataProduto);
            this.groupBox6.Controls.Add(this.txtPesquisa);
            this.groupBox6.Location = new System.Drawing.Point(856, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(347, 377);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            // 
            // dataProduto
            // 
            this.dataProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProduto.Location = new System.Drawing.Point(6, 71);
            this.dataProduto.Name = "dataProduto";
            this.dataProduto.ReadOnly = true;
            this.dataProduto.RowTemplate.Height = 25;
            this.dataProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataProduto.Size = new System.Drawing.Size(335, 300);
            this.dataProduto.TabIndex = 1;
            this.dataProduto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduto_CellClick);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(6, 32);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(335, 33);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // frmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(1215, 697);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProduto";
            this.Load += new System.EventHandler(this.frmProduto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtde)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtCodigo;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private MaskedTextBox txtCadastro;
        private NumericUpDown numQtde;
        private ComboBox cboStatus;
        private TextBox txtUnidade;
        private TextBox txtPeso;
        private TextBox txtNome;
        private Label label7;
        private Label label10;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private GroupBox groupBox3;
        private TextBox txtVenda;
        private TextBox txtCusto;
        private Label label8;
        private Label label9;
        private GroupBox groupBox4;
        private TextBox txtObs;
        private Label label12;
        private GroupBox groupBox5;
        private Button btnCadastrar;
        private Button btnAlterar;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnSair;
        private Button btnBuscar;
        private Button btnCadastrarMelhorado;
        private ComboBox cboNomeCategoria;
        private Label label11;
        private ComboBox cboCodigoCategoria;
        private GroupBox groupBox6;
        private DataGridView dataProduto;
        private TextBox txtPesquisa;
    }
}