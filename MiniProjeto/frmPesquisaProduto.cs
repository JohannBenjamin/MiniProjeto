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
    public partial class frmPesquisaProduto : Form
    {
        string stringConexao = frmLogin.stringConexao;
        public static string codigo;

        public frmPesquisaProduto()
        {
            InitializeComponent();
        }

        public void TestarConexao()
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

        public void CarregarGridProduto()
        {
            string sql = "select " +
                "P.id_produto as 'Código', " +
                "P.id_categoria_produto as 'Cód. da Categoria', " +
                "C.nome_categoria as 'Nome da Categoria', " +
                "P.nome_produto as 'Nome', " +
                "P.qtde_produto as 'Qtde', " +
                "P.peso_produto as 'Peso', " +
                "P.unidade_produto as 'Un. de Medida', " +
                "P.valorCusto_produto as 'Valor de Custo', " +
                "P.valorVenda_produto as 'Valor de Venda', " +
                "P.status_produto as 'Status' " +
                "from Produto as P " +
                "inner join Categoria as C on C.id_categoria = P.id_categoria_produto " +
                "where P.nome_produto like '%" + txtPesquisa.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet tabela = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(tabela);
                dataProduto.DataSource = tabela.Tables[0];
                dataProduto.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataProduto.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmPesquisaProduto_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarGridProduto();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridProduto();
        }

        private void dataProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = dataProduto.CurrentRow.Cells["Código"].Value.ToString();
            this.Close();
        }
    }
}
