using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjeto
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        //Variáveis
        string mensagemErro = "";
        string stringConexao = "" +
                            "Data Source=localhost;" +
                            "Initial Catalog=N8_MiniProjeto;" +
                            "User ID=sa;" +
                            "Password=123456";

        private void TesteConexao()
        {
            SqlConnection conn = new SqlConnection(stringConexao);

            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex.Message);
                Application.Exit();
            }
        }

        private bool VerificadorCadastrar()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                mensagemErro = "Erro!! Informe um nome.";
                txtNome.Text = "";
                txtNome.Focus();
                return false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                mensagemErro = "Erro!! Informe um status válido.";
                cboStatus.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                mensagemErro = "Erro!! Informe uma descrição.";
                txtDescricao.Text = "";
                txtDescricao.Focus();
                return false;
            }
            return true;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            TesteConexao();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(VerificadorCadastrar())
            {
                string sql = "insert into Categoria" +
                    "(" +
                        "nome_categoria," +
                        "descricao_categoria," +
                        "status_categoria," +
                        "obs_categoria" +
                    ")values(" +
                        "'" + txtNome.Text + "'," +
                        "'" + txtDescricao.Text + "'," +
                        "'" + cboStatus.Text + "'," +
                        "'" + txtObs.Text + "'" +
                    ")";

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        btnLimpar.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    Application.Exit();
                }
                finally
                {
                    conn.Close();
                }
                
            }
            else
            {
                MessageBox.Show(mensagemErro);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
