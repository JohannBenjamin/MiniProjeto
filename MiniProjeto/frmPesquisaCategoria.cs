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
    public partial class frmPesquisaCategoria : Form
    {
        string stringConexao = frmLogin.stringConexao;
        public static string codigo;

        public frmPesquisaCategoria()
        {
            InitializeComponent();
        }

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

        private void frmPesquisaCategoria_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarGridCategoria();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridCategoria();
        }

        private void dataCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = dataCategoria.CurrentRow.Cells["Código"].Value.ToString();
            this.Close();
        }
    }
}
