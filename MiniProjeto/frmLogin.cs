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
            "Data Source=localhost;" + //local do banco
            "Initial Catalog=N8_MiniProjeto;" + //nome do banco
            "User ID=sa;" + //usuario
            "Password=123456"; //senha

        private void TestarConexao()
        {
            SqlConnection conn = new SqlConnection(stringConexao); //instância uma conexao do banco com o parâmetro da stringconexao

            try
            {
                conn.Open(); //abre a conexao
                conn.Close(); //fecha a conexao
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                Application.Exit(); //fecha a aplicação
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
            TestarConexao(); //chama o método de testarConexao ao carregar o frm
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

                SqlConnection conn = new SqlConnection(stringConexao); //instância de conexão
                SqlCommand cmd = new SqlCommand(sql, conn); //instância de um comando com parâmetro da string de comando e da conexão
                cmd.CommandType = CommandType.Text; //mudança do tipo de comando para texto
                SqlDataReader leitura; //instância de uma leitura de busca no banco (somente usado quando for "SELECT")
                conn.Open(); //abertura de conexão

                try
                {
                    leitura = cmd.ExecuteReader(); //executa a leitura (SELECT)
                    if (leitura.Read())
                    {
                        MessageBox.Show("Seja Bem vindo! " + leitura[0].ToString());
                        MDITelaInicial mdi = new MDITelaInicial(); //instancia a MDI
                        mdi.Show(); //mostra a mdi
                        this.Hide(); //esconde o frmLogin (pois se fechar, fecha toda a aplicação)
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
                    conn.Close(); //fechamento da conexão (Importante fechar depois de utilizá-la)
                }
            }
            else
            {
                MessageBox.Show(mensagemErro);
            }
        }
    }
}
