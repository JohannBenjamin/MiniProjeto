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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //Variáveis
        string mensagemErro = "";
        public static string stringConexao = "" +
            "Data Source=localhost;" +
            "Initial Catalog=N8_MiniProjeto;" +
            "User ID=sa;" +
            "Password=123456";

        private void TestarConexao()
        {
            SqlConnection conn = new SqlConnection(stringConexao);

            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                Application.Exit();
            }
        }

        private bool Verificador()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                mensagemErro = "Erro! Informe um email";
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return false;
            }

            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                mensagemErro = "Erro! Informe uma senha";
                txtSenha.Text = "";
                txtSenha.Focus();
                return false;
            }
            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Verificador())
            {
                string sql = "select nome_usuario, login_usuario, senha_usuario from Usuario where " +
                    "login_usuario = '" + txtUsuario.Text + "' and " +
                    "senha_usuario = '" + txtSenha.Text + "'";

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leitura;
                conn.Open();

                try
                {
                    leitura = cmd.ExecuteReader();
                    if (leitura.Read())
                    {
                        MessageBox.Show("Seja Bem vindo! " + leitura[0].ToString());
                        MDITelaInicial mdi = new MDITelaInicial();
                        mdi.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidas!");
                        txtUsuario.Text = "";
                        txtSenha.Text = "";
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
    }
}
