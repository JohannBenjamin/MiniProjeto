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
        string stringConexao = frmLogin.stringConexao;
        /*string stringConexao = "" +
                            "Data Source=localhost;" + //local do banco
                            "Initial Catalog=N8_MiniProjeto;" + //nome do banco
                            "User ID=sa;" + //usuario
                            "Password=123456"; //senha
        */


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

        private bool VerificadorCodigo()
        {
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                mensagemErro = "Erro!! Informe um c�digo v�lido.";
                txtCodigo.Text = "";
                txtCodigo.Focus();
                return false;
            }
            return true;
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

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                mensagemErro = "Erro!! Informe um nome v�lido.";
                txtNome.Text = "";
                txtNome.Focus();
                return false;
            }

            if (!(txtLogin.Text.Contains("@") && txtLogin.Text.Contains(".com")))
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

            if (cboStatus.SelectedIndex == -1)
            {
                mensagemErro = "Erro!! Informe um status v�lido.";
                cboStatus.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtObs.Text))
            {
                //mensagemErro = "Erro!! Informe uma observa��o.";
                txtObs.Text = "Sem Obs";
                //txtObs.Focus();
                //return false;
            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (VerificadorCodigo())
            {
                string sql = "select * from Usuario where id_usuario = " + txtCodigo.Text;

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
                        txtCodigo.Text = leitura[0].ToString();
                        txtNome.Text = leitura[1].ToString();
                        txtLogin.Text = leitura[2].ToString();
                        txtSenha.Text = leitura[3].ToString();
                        txtCpf.Text = leitura[4].ToString();
                        cboStatus.Text = leitura[5].ToString();
                        txtObs.Text = leitura[6].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Erro! C�digo de usu�rio inexistente.");
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (VerificadorCodigo())
            {
                string sql = "delete from Usuario where id_usuario = " + txtCodigo.Text;

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Exclus�o realizada com sucesso!");
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (VerificadorCodigo())
            {
                string sql = "select * from Usuario where id_usuario = " + txtCodigo.Text;

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
                        if (string.IsNullOrEmpty(txtNome.Text))
                        {
                            txtNome.Text = leitura[1].ToString();
                        }
                        if (!(txtLogin.Text.Contains("@") && txtLogin.Text.Contains(".com")))
                        {
                            txtLogin.Text = leitura[2].ToString();
                        }

                        if (string.IsNullOrEmpty(txtSenha.Text))
                        {
                            txtSenha.Text = leitura[3].ToString();
                        }

                        if (!txtCpf.MaskFull)
                        {
                            txtCpf.Text = leitura[4].ToString();
                        }

                        if (cboStatus.SelectedIndex == -1)
                        {
                            cboStatus.Text = leitura[5].ToString();
                        }

                        if (string.IsNullOrEmpty(txtObs.Text))
                        {
                            txtObs.Text = leitura[6].ToString();
                        }
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

                sql = "update Usuario set " +
                    "nome_usuario = '" + txtNome.Text + "'," +
                    "login_usuario = '" + txtLogin.Text + "'," +
                    "senha_usuario = '" + txtSenha.Text + "'," +
                    "cpf_usuario = '" + txtCpf.Text + "'," +
                    "obs_usuario = '" + txtObs.Text + "'," +
                    "status_usuario = '" + cboStatus.Text + "' " +
                    "where id_usuario = " + txtCodigo.Text;

                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Altera��o realizada com sucesso!");
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

        private void btnCadastrarMelhorado_Click(object sender, EventArgs e)
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
                        ")select SCOPE_IDENTITY()";

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
                        MessageBox.Show("Dados cadastros com sucesso!");
                        btnLimpar.PerformClick();
                        MessageBox.Show("C�digo do registro � " + leitura[0].ToString());
                        txtCodigo.Text = leitura[0].ToString();
                        btnBuscar.PerformClick();
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