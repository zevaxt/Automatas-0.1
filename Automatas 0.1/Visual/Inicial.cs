using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatas_0._1.Visual
{
    public partial class Inicial : Form
    {

        Clases.Automata automata;

        public Inicial()
        {
            InitializeComponent();

        
        }


        public void Inicial_Load(object sender, EventArgs e)
        {
            panel_quintupla.Visible = false;
            panel_tabla.Visible = false;
            panel_diagrama.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void qUINTUPLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_quintupla.Visible = true;
            panel_tabla.Visible = false;
            panel_diagrama.Visible = false;
        }

        private void tABLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_quintupla.Visible = false;
            panel_tabla.Visible = true;
            panel_diagrama.Visible = false;
        }

        private void dIAGRAMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_quintupla.Visible = false;
            panel_tabla.Visible = false;
            panel_diagrama.Visible = true;
        }



    }
}
