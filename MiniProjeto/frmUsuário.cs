using System.Data;
using System.Data.SqlClient;

namespace MiniProjeto
{
    public partial class frmUsu�rio : Form
    {
        public frmUsu�rio()
        {
            InitializeComponent();
        }

        //vari�veis
        string mensagemErro = "";
        string stringConexao = "" +
                            "Data Source=localhost;" + //local do banco
                            "Initial Catalog=N8_MiniProjeto;" + //nome do banco
                            "User ID=sa;" + //usuario
                            "Password=123456"; //senha

        private void TestarConexao()
        {
            SqlConnection conn = new SqlConnection(stringConexao); //Inst�ncia da conex�o do banco de dados local

            try
            {
                conn.Open(); //abre a conex�o
                conn.Close(); //fecha a conex�o. Importante fechar no fim de cada processo!
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                Application.Exit();
            }
        }

        private bool VerificadorCadastrar()
        {
            /*if(!int.TryParse(txtCodigo.Text, out int codigo))
            {
                mensagemErro = "Erro!! Informe um n�mero.";
                txtCodigo.Text = "";
                txtCodigo.Focus();
                return false;
            }*/

            if(string.IsNullOrEmpty(txtNome.Text))
            {
                mensagemErro = "Erro!! Informe um nome v�lido.";
                txtNome.Text = "";
                txtNome.Focus();
                return false;
            }

            if(!(txtLogin.Text.Contains("@") && txtLogin.Text.Contains(".com")))
            {
                mensagemErro = "Erro!! Informe um login v�lido.";
                txtLogin.Text = "";
                txtLogin.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                mensagemErro = "Erro!! Informe uma senha v�lida.";
                txtSenha.Text = "";
                txtSenha.Focus();
                return false;
            }

            if (!txtCpf.MaskFull)
            {
                mensagemErro = "Erro!! Informe um CPF v�lido.";
                txtCpf.Text = "";
                txtCpf.Focus();
                return false;
            }

            if(cboStatus.SelectedIndex == -1)
            {
                mensagemErro = "Erro!! Informe um status v�lido.";
                cboStatus.Focus();
                return false;
            }

            /*if (string.IsNullOrEmpty(txtObs.Text))
            {
                mensagemErro = "Erro!! Informe uma observa��o v�lida.";
                txtObs.Text = "";
                txtObs.Focus();
                return false;
            }*/
            return true;
        }

        private void frmMiniProjeto_Load(object sender, EventArgs e)
        {
            TestarConexao(); //testa a conexao ao abrir o formul�rio
        }
        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (VerificadorCadastrar())
            {
                string sql = "insert into Usuario" +
                    "(" +
                        "nome_usuario," +
                        "login_usuario," +
                        "senha_usuario," +
                        "cpf_usuario," +
                        "status_usuario," +
                        "obs_usuario" +
                    ")values(" +
                        "'" + txtNome.Text + "'," +
                        "'" + txtLogin.Text + "'," +
                        "'" + txtSenha.Text + "'," +
                        "'" + txtCpf.Text + "'," +
                        "'" + cboStatus.Text + "'," +
                        "'" + txtObs.Text + "'" +
                    ")";

                SqlConnection conn = new SqlConnection(stringConexao); //instancia da conex�o
                SqlCommand cmd = new SqlCommand(sql, conn); //instancia de comando sql ("qual comando", "executa em qual banco")
                cmd.CommandType = CommandType.Text; //muda o tipo de texto do comando
                conn.Open(); //abre a conex�o

                try
                {
                    int i = cmd.ExecuteNonQuery(); //retorna o n�mero de linhas afetadas
                    if (i > 0)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }
                    btnLimpar.PerformClick(); //limpo as caixas de texto dps do insert
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    Application.Exit();
                }
                finally
                {
                    conn.Close(); //fechamento da conex�o
                }
            }
            else
            {
                MessageBox.Show(mensagemErro);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtCpf.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";
        }
    }
}