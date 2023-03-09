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
    public partial class frmPesquisaUsuario : Form
    {
        string stringConexao = frmLogin.stringConexao;
        public static string codigo;

        public frmPesquisaUsuario()
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

        private void CarregarGridUsuario()
        {
            string sql = "select " +
                "id_usuario as 'Código', " +
                "nome_usuario as 'Nome', " +
                "login_usuario as 'Email', " +
                "cpf_usuario as 'CPF', " +
                "status_usuario as 'Status'" +
                "from Usuario " +
                "where nome_usuario like '%" + txtPesquisa.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet tabela = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(tabela);
                dataUsuario.DataSource = tabela.Tables[0];
                dataUsuario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataUsuario.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
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

        private void frmPesquisaUsuario_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarGridUsuario();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridUsuario();
        }

        private void dataUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = dataUsuario.CurrentRow.Cells["Código"].Value.ToString();
            this.Close();
        }
    }
}
