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
    public partial class frmProduto : Form
    {
        public frmProduto()
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
                MessageBox.Show("Erro: " + ex.Message);
                Application.Exit();
            }
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            TesteConexao();
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
            if (!int.TryParse(txtCodigoCategoria.Text, out int codigoCategoria))
            {
                mensagemErro = "Erro!! Informe um código de categoria.";
                txtCodigoCategoria.Text = "";
                txtCodigoCategoria.Focus();
                return false;
            }

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

            if (numQtde.Value == 0)
            {
                mensagemErro = "Erro!! Informe uma quantidade válida.";
                numQtde.Text = "1";
                numQtde.Focus();
                return false;
            }

            if (!float.TryParse(txtPeso.Text, out float peso))
            {
                mensagemErro = "Erro!! Informe um peso válido.";
                txtPeso.Text = "";
                txtPeso.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUnidade.Text))
            {
                mensagemErro = "Erro!! Informe uma unidade válida.";
                txtUnidade.Text = "";
                txtUnidade.Focus();
                return false;
            }

            /*if (!txtCadastro.MaskFull)
            {
                //mensagemErro = "Erro!! Informe uma data de cadastro.";
                txtCadastro.Text = ;
                //txtCadastro.Focus();
                //return false;
            }*/

            if (!float.TryParse(txtCusto.Text, out float custo))
            {
                mensagemErro = "Erro!! Informe um valor de custo válido.";
                txtCusto.Text = "";
                txtCusto.Focus();
                return false;
            }

            if (!float.TryParse(txtVenda.Text, out float venda))
            {
                mensagemErro = "Erro!! Informe um valor de venda válida.";
                txtVenda.Text = "";
                txtVenda.Focus();
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (VerificadorCadastrar())
            {
                string sql = "insert into Produto" +
                    "(" +
                        "id_categoria_produto," +
                        "nome_produto," +
                        "qtde_produto," +
                        "peso_produto," +
                        "unidade_produto," +
                        "valorCusto_produto," +
                        "valorVenda_produto," +
                        "status_produto," +
                        "obs_produto" +
                    ")values(" +
                        "" + txtCodigoCategoria.Text + "," +
                        "'" + txtNome.Text + "'," +
                        "" + numQtde.Text + "," +
                        "" + txtPeso.Text.Replace(",", ".") + "," +
                        "'" + txtUnidade.Text + "'," +
                        "" + txtCusto.Text.Replace(",", ".") + "," +
                        "" + txtVenda.Text.Replace(",", ".") + "," +
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
                    if(i > 0)
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
            txtCodigoCategoria.Text = "";
            txtNome.Text = "";
            cboStatus.SelectedIndex = -1;
            numQtde.Value = 1;
            txtPeso.Text = "";
            txtUnidade.Text = "";
            txtCadastro.Text = "";
            txtCusto.Text = "";
            txtVenda.Text = "";
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
                string sql = "select * from Produto where id_produto = " + txtCodigo.Text;
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
                        txtCodigoCategoria.Text = leitura[1].ToString();
                        txtNome.Text = leitura[2].ToString();
                        numQtde.Value = decimal.Parse(leitura[3].ToString());
                        txtPeso.Text = leitura[4].ToString();
                        txtUnidade.Text = leitura[5].ToString();
                        txtCadastro.Text = leitura[6].ToString();
                        txtCusto.Text = leitura[7].ToString();
                        txtVenda.Text = leitura[8].ToString();
                        cboStatus.Text = leitura[9].ToString();
                        txtObs.Text = leitura[10].ToString();
                        MessageBox.Show("Busca realizada!");
                    }
                    else
                    {
                        MessageBox.Show("Erro! Código de produto inexistente.");
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
                string sql = "delete from Produto where id_produto = " + txtCodigo.Text;

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
            if (VerificadorCodigo())
            {
                string sql = "select * from Produto where id_produto = " + txtCodigo.Text;

                SqlConnection conn = new SqlConnection(stringConexao);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader leitura;
                conn.Open();

                try
                {
                    leitura = cmd.ExecuteReader();
                    if (leitura.Read())
                    {
                        if (!int.TryParse(txtCodigoCategoria.Text, out int codigoCategoria))
                        {
                            txtCodigoCategoria.Text = leitura[1].ToString();
                        }

                        if (string.IsNullOrEmpty(txtNome.Text))
                        {
                            txtNome.Text = leitura[2].ToString();
                        }

                        if (numQtde.Value == 0)
                        {
                            numQtde.Value = decimal.Parse(leitura[3].ToString());
                        }

                        if (!float.TryParse(txtPeso.Text, out float peso))
                        {
                            txtPeso.Text = leitura[4].ToString();
                        }

                        if (string.IsNullOrEmpty(txtUnidade.Text))
                        {
                            txtUnidade.Text = leitura[5].ToString();
                        }

                        if (!txtCadastro.MaskFull)
                        {
                            txtCadastro.Text = leitura[6].ToString();
                        }

                        if (!float.TryParse(txtCusto.Text, out float custo))
                        {
                            txtCusto.Text = leitura[7].ToString();
                        }

                        if (!float.TryParse(txtVenda.Text, out float venda))
                        {
                            txtVenda.Text = leitura[8].ToString();
                        }

                        if (cboStatus.SelectedIndex == -1)
                        {
                            cboStatus.Text = leitura[9].ToString();
                        }

                        if (string.IsNullOrEmpty(txtObs.Text))
                        {
                            txtObs.Text = leitura[10].ToString();
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

                sql = "update Produto set " +
                    "id_categoria_produto = " + txtCodigoCategoria.Text + "," +
                    "nome_produto = '" + txtNome.Text + "'," +
                    "qtde_produto = " + numQtde.Value + ", " +
                    "peso_produto = " + txtPeso.Text.Replace(",", ".") + "," +
                    "unidade_produto = '" + txtUnidade.Text + "'," +
                    "cadastro_produto = '" + txtCadastro.Text + "'," +
                    "valorCusto_produto = " + txtCusto.Text.Replace(",", ".") + "," +
                    "valorVenda_produto = " + txtVenda.Text.Replace(",", ".") + "," +
                    "status_produto = '" + cboStatus.Text + "'," +
                    "obs_produto = '" + txtObs.Text + "' " +
                    "where id_produto = " + txtCodigo.Text;

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
    }
}