using System.Data;
using System.Data.SqlClient;

namespace MiniProjeto
{
    public partial class frmMiniProjeto : Form
    {
        public frmMiniProjeto()
        {
            InitializeComponent();
        }

        //vari�veis
        string mensagemErro = "";
        string stringConexao = "" +
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
                mensagemErro = "Erro!! Informe um Status v�lido.";
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
            TestarConexao();
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
                    }
                    btnLimpar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    Application.Exit();
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