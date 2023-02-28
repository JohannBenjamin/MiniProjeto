using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjeto
{
    public partial class MDITelaInicial : Form
    {
        private int childFormNumber = 0;

        public MDITelaInicial()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuário frmUsuário = new frmUsuário();
            frmUsuário.MdiParent = this;
            frmUsuário.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto frmProduto = new frmProduto();
            frmProduto.MdiParent = this;
            frmProduto.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.MdiParent = this;
            frmCategoria.Show();
        }
    }
}
