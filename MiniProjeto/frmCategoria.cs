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
        string stringConexao = frmLogin.stringConexao;
        /*string stringConexao = "" +
                            "Data Source=localhost;" +
                            "Initial Catalog=N8_MiniProjeto;" +
                            "User ID=sa;" +
                            "Password=123456";*/

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

        private void CarregarGridCategoria()
        {
            string sql = "select " +
                "id_categoria as 'Código', " +
                "nome_categoria as 'Nome', " +
                "descricao_categoria as 'Descrição'," +
                "status_categoria as 'Status' " +
                "from Categoria " +
                "where nome_categoria like '%" + txtPesquisa.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet tabela = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(tabela);
                dataCategoria.DataSource = tabela.Tables[0];
                dataCategoria.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataCategoria.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
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

        private bool VerificadorCodigo()
        {
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                mensagemErro = "Erro!! Informe um código válido.";
                txtCodigo.Text = "";
                txtCodigo.Focus();
                return false;
            }
            return true;
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

            if (string.IsNullOrEmpty(txtObs.Text))
            {
                //mensagemErro = "Erro!! Informe uma observação.";
                txtObs.Text = "Sem Obs";
                //txtObs.Focus();
                //return false;
            }
            return true;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            TesteConexao();
            CarregarGridCategoria();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (VerificadorCodigo())
            {
                string sql = "select * from Categoria where id_categoria = " + txtCodigo.Text;

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader leitura;
                conn.Open();

                try
                {
                    leitura = cmd.ExecuteReader();
                    if (leitura.Read())
                    {
                        txtCodigo.Text = leitura[0].ToString();
                        txtNome.Text = leitura[1].ToString();
                        txtDescricao.Text = leitura[2].ToString();
                        cboStatus.Text = leitura[3].ToString();
                        txtObs.Text = leitura[4].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Erro! Código de Categoria inexistente.");
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
            if(VerificadorCodigo())
            {
                string sql = "delete from Categoria where id_categoria = " + txtCodigo.Text;

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Exclusão realizada com sucesso!");
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
            if(VerificadorCodigo())
            {
                string sql = "select * from Categoria where id_categoria = " + txtCodigo.Text;

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
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

                        if (string.IsNullOrEmpty(txtDescricao.Text))
                        {
                            txtDescricao.Text = leitura[2].ToString();
                        }
                        
                        if (cboStatus.SelectedIndex == -1)
                        {
                            cboStatus.Text = leitura[3].ToString();
                        }

                        if (string.IsNullOrEmpty(txtObs.Text))
                        {
                            txtObs.Text = leitura[4].ToString();
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

                sql = "update Categoria set " +
                    "nome_categoria = '" + txtNome.Text + "'," +
                    "descricao_categoria = '" + txtDescricao.Text + "'," +
                    "status_categoria = '" + cboStatus.Text + "'," +
                    "obs_categoria = '" + txtObs.Text + "' " +
                    "where id_categoria = " + txtCodigo.Text;

                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Alteração realizada com sucesso!");
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
                        MessageBox.Show("Dados cadastrados com sucesso!");
                        btnLimpar.PerformClick();
                        MessageBox.Show("Código do registro é " + leitura[0].ToString());
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

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridCategoria();
        }

        private void dataCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataCategoria.CurrentRow.Cells["Código"].Value.ToString();
            btnBuscar.PerformClick();
        }
    }
}
