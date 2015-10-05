using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Automatas_0._1.Visual
{
    public partial class Inicial : Form
    {
        LinkedList<Clases.Automata> listAutomatas;
        Clases.Automata automata;

        public Inicial()
        {
            InitializeComponent();
            panel_quintupla.Visible = false;
            panel_tabla.Visible = false;
            panel_diagrama.Visible = false;

            automata = new Clases.Automata();






        }


        public void Inicial_Load(object sender, EventArgs e)
        {



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

            tabla_dataGridView.Columns.Clear();
            for (int i = 0; i < automata.alfabeto.Count; i++)
            {
                DataGridViewTextBoxColumn d = new DataGridViewTextBoxColumn();
                d.HeaderText = automata.alfabeto.ElementAt(i);
                d.Width = 50;
                tabla_dataGridView.Columns.Add(d);
            }



            tabla_dataGridView.Rows.Clear();

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                tabla_dataGridView.Rows.Add(automata.listEstados.ElementAt(i).nombre);

            }


            


        }

        private void dIAGRAMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_quintupla.Visible = false;
            panel_tabla.Visible = false;
            panel_diagrama.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < automata.listEstados.Count; i++)
            {

                if (aceptador_comboBox.Text.Equals(automata.listEstados.ElementAt(i).nombre))
                {
                    automata.listEstados.ElementAt(i).aceptador = true;
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void agregar_lenguaje_button_Click(object sender, EventArgs e)
        {
            String caracter = leguaje_textBox.Text;
            leguaje_textBox.Text = "";
            automata.alfabeto.AddLast(caracter);

            this.transicion_caracter_comboBox.Items.Clear();

            foreach (var item in automata.alfabeto)
            {
                this.transicion_caracter_comboBox.Items.Add(item);
            }



        }

        private void transicion_caracter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void agregar_estado_button_Click(object sender, EventArgs e)
        {
            String estado = "Q" + automata.listEstados.Count;
            estados_textBox.Text = automata.listEstados.Count + "";
            estados_textBox.Enabled = false;

            automata.listEstados.AddLast(new Clases.Estado(estado));
            reiniciarComboxEstados(transicion_origen_comboBox);
            reiniciarComboxEstados(transicion_destino_comboBox);
            reiniciarComboxEstados(aceptador_comboBox);
            reiniciarComboxEstados(inicial_comboBox);





        }

        public void reiniciarComboxEstados(ComboBox c)
        {
            c.Items.Clear();

            foreach (var item in automata.listEstados)
            {
                c.Items.Add(item.nombre);
            }
        }

        private void agregar_transicion_button_Click(object sender, EventArgs e)
        {
            String origen = transicion_origen_comboBox.Text;
            String caracter = transicion_caracter_comboBox.Text;
            String destino = transicion_destino_comboBox.Text;

            for (int i = 0; i < automata.listEstados.Count; i++)
            {


                if (automata.listEstados.ElementAt(i).nombre.Equals(origen))
                {
                    automata.listEstados.ElementAt(i).listTransiciones.AddLast(new Clases.Transicion(origen, caracter, destino));

                }



            }

        }

        private void estados_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_quintupla_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            automata.inicial = inicial_comboBox.Text;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataGridViewTextBoxColumn d = new DataGridViewTextBoxColumn();
            d.HeaderText = "A";
            d.Width = 50;
            tabla_dataGridView.Columns.Add(d);


            tabla_dataGridView.Rows.Add("dd");


            




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel_tabla_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            String a="";

            foreach (DataGridViewRow fil in tabla_dataGridView.Rows)
	        {
		        foreach (DataGridViewColumn col in tabla_dataGridView.Columns)
	            {
		            
	            }
	        }

      






    }
}
