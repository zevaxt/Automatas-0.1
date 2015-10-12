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
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;





namespace Automatas_0._1.Visual
{
    public partial class Inicial : Form
    {
        LinkedList<Clases.Automata> listAutomatas;
        Clases.Automata automata;
        Graphics papel;
        Rectangle p;
        SolidBrush pincel;
        int mouseX;
        int mouseY;
        Boolean b1;


        Clases.Estado prueba;

        public Inicial()
        {
            InitializeComponent();
            //this.cARGARToolStripMenuItem.Click += new System.EventHandler(this.button6_Click);

            pincel = new SolidBrush(Color.Red);
            panel_quintupla.Visible = false;
            panel_tabla.Visible = false;
            automata = new Clases.Automata();
            prueba = new Clases.Estado();
            timer1.Enabled = true;
            p = new Rectangle(50, 50, 50, 50);
            b1 = false;







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

            reiniciarComboxEstados(transicion_origen_comboBox);
            reiniciarComboxEstados(transicion_destino_comboBox);
            reiniciarComboxEstados(aceptador_comboBox);
            reiniciarComboxEstados(inicial_comboBox);

            this.transicion_caracter_comboBox.Items.Clear();

            foreach (var item in automata.alfabeto)
            {
                this.transicion_caracter_comboBox.Items.Add(item);
            }
        }

        private void tABLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_quintupla.Visible = false;
            panel_tabla.Visible = true;


            cargartabla();

            reiniciarComboxEstados(destino_tabla_comboBox);
            reiniciarComboxEstados(origen_tabla_comboBox);
            reiniciarComboxEstados(tabla_aceptadores_comboBox);
            reiniciarComboxEstados(tabla_inicial_comboBox);

            this.caracter_tabla_comboBox.Items.Clear();

            foreach (var item in automata.alfabeto)
            {
                this.caracter_tabla_comboBox.Items.Add(item);
            }





        }



        private void dIAGRAMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_quintupla.Visible = false;
            panel_tabla.Visible = false;


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

        public void cargartabla()
        {
            tabla_dataGridView.Columns.Clear();


            List<String> caracteres = new List<String>();
            caracteres.Add("");

            DataGridViewTextBoxColumn dd = new DataGridViewTextBoxColumn();
            dd.HeaderText = "";
            dd.Width = 50;

            tabla_dataGridView.Columns.Add(dd);// la primera columna para los estados



            for (int i = 0; i < automata.alfabeto.Count; i++)
            {
                DataGridViewTextBoxColumn d = new DataGridViewTextBoxColumn();
                d.HeaderText = "";
                d.Width = 50;
                tabla_dataGridView.Columns.Add(d);
                //caracteres.Add(automata.alfabeto.ElementAt(i));

            }

            tabla_dataGridView.Rows.Clear();

            DataGridViewRow row = (DataGridViewRow)tabla_dataGridView.Rows[0].Clone();
            row.Cells[0].Value = "";


            for (int i = 0; i < automata.alfabeto.Count; i++)
            {
                row.Cells[i + 1].Value = automata.alfabeto.ElementAt(i);
            }

            tabla_dataGridView.Rows.Add(row);

            //mostrar estados en la tabla

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                DataGridViewRow fila = (DataGridViewRow)tabla_dataGridView.Rows[0].Clone();

                for (int j = 0; j < automata.alfabeto.Count + 1; j++)
                {
                    if (j == 0)
                    {
                        fila.Cells[j].Value = automata.listEstados.ElementAt(i).nombre;
                    }
                    else if (automata.listEstados.ElementAt(i).listTransiciones.Count > j - 1)
                    {
                        if (automata.listEstados.ElementAt(i).listTransiciones.ElementAt(j - 1) != null)
                        {

                            fila.Cells[j].Value = automata.listEstados.ElementAt(i).listTransiciones.ElementAt(j - 1).destino.nombre;
                            //  fila.Cells[j].Value=automata.listEstados.ElementAt(i).listTransiciones

                        }
                    }
                    else
                    {

                        fila.Cells[j].Value = "";
                    }

                }

                tabla_dataGridView.Rows.Add(fila);

            }

        }

        private void agregar_lenguaje_button_Click(object sender, EventArgs e)
        {
            String caracter = leguaje_textBox.Text;

            if (!caracter.Equals(""))
            {
                automata.alfabeto.AddLast(caracter);
            }
            else
            {
                Interaction.MsgBox("Agrege Un Caracter Primero");
            }



            leguaje_textBox.Text = "";

            this.transicion_caracter_comboBox.Items.Clear();

            foreach (var item in automata.alfabeto)
            {
                this.transicion_caracter_comboBox.Items.Add(item);
            }



        }


        private void agregar_estado_button_Click(object sender, EventArgs e)
        {
            String estado = "Q" + automata.listEstados.Count;

            estados_textBox.Enabled = false;

            Clases.Estado es = new Clases.Estado(estado);

            if (automata.listEstados.Count>0)
            {
                es.x = automata.listEstados.Last().x + 150;
            }


            automata.listEstados.AddLast(es);
            reiniciarComboxEstados(transicion_origen_comboBox);
            reiniciarComboxEstados(transicion_destino_comboBox);
            reiniciarComboxEstados(aceptador_comboBox);
            reiniciarComboxEstados(inicial_comboBox);

            estados_textBox.Text = automata.listEstados.Count + "";
       
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

            Clases.Estado d = new Clases.Estado();
            Clases.Estado o = new Clases.Estado(); 

            //buscar destino
            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                if (automata.listEstados.ElementAt(i).nombre.Equals(destino))
                {
                    d = automata.listEstados.ElementAt(i);

                }
            }

            //buscar origen

            for (int i = 0; i < automata.listEstados.Count; i++)
            {


                if (automata.listEstados.ElementAt(i).nombre.Equals(origen))
                {
                    o = automata.listEstados.ElementAt(i);
                  
                }

            }


            //todas las transiciones juntas


            LinkedList<Clases.Transicion> todasT = new LinkedList<Clases.Transicion>();

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                for (int j = 0; j < automata.listEstados.ElementAt(i).listTransiciones.Count; j++)
                {
                    todasT.AddLast(automata.listEstados.ElementAt(i).listTransiciones.ElementAt(j));
                }
            }

            Clases.Transicion t = new Clases.Transicion(o, caracter, d);

            for (int i = 0; i < todasT.Count; i++)
            {
                if (todasT.ElementAt(i).origen.nombre.Equals(d.nombre))
                {
                    t.doble = true;
                }
            }

            

            //agregar la transiccion

            o.listTransiciones.AddLast(t);

        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            automata.inicial = inicial_comboBox.Text;

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).inicial = false;

                if (automata.inicial.Equals(automata.listEstados.ElementAt(i).nombre))
                {
                    automata.listEstados.ElementAt(i).inicial = true;
                }

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            String caracter = alfabeto_tabla_textBox.Text;

            if (!caracter.Equals(""))
            {
                automata.alfabeto.AddLast(caracter);
            }
            else
            {
                Interaction.MsgBox("Agrege Un Caracter Primero");
            }

            alfabeto_tabla_textBox.Text = "";

            this.caracter_tabla_comboBox.Items.Clear();

            foreach (var item in automata.alfabeto)
            {
                this.caracter_tabla_comboBox.Items.Add(item);
            }


            cargartabla();






        }



        private void button3_Click(object sender, EventArgs e)
        {
            String estado = "Q" + automata.listEstados.Count;
            
            Clases.Estado es = new Clases.Estado(estado);

            if (automata.listEstados.Count > 0)
            {
                es.x = automata.listEstados.Last().x + 150;
            }


            automata.listEstados.AddLast(es);

            reiniciarComboxEstados(destino_tabla_comboBox);
            reiniciarComboxEstados(origen_tabla_comboBox);
            reiniciarComboxEstados(tabla_aceptadores_comboBox);
            reiniciarComboxEstados(tabla_inicial_comboBox);

            estados_textBox.Text = automata.listEstados.Count + "";

            cargartabla();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            String origen = origen_tabla_comboBox.Text;
            String caracter = caracter_tabla_comboBox.Text;
            String destino = destino_tabla_comboBox.Text;


            Clases.Estado d = new Clases.Estado(); ;
            Clases.Estado o = new Clases.Estado();

            //buscar destino
            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                if (automata.listEstados.ElementAt(i).nombre.Equals(destino))
                {
                    d = automata.listEstados.ElementAt(i);

                }
            }

            //buscar origen

            for (int i = 0; i < automata.listEstados.Count; i++)
            {


                if (automata.listEstados.ElementAt(i).nombre.Equals(origen))
                {
                    o = automata.listEstados.ElementAt(i);

                }

            }

            //todas las transiciones juntas


            LinkedList<Clases.Transicion> todasT = new LinkedList<Clases.Transicion>();

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                for (int j = 0; j < automata.listEstados.ElementAt(i).listTransiciones.Count; j++)
                {
                    todasT.AddLast(automata.listEstados.ElementAt(i).listTransiciones.ElementAt(j));
                }
            }




            Clases.Transicion t = new Clases.Transicion(o, caracter, d);

            for (int i = 0; i < todasT.Count; i++)
            {
                if (todasT.ElementAt(i).origen.nombre.Equals(d.nombre))
                {
                    t.doble = true;
                }
            }



            //agregar la transiccion

            o.listTransiciones.AddLast(t);



            cargartabla();

       
        }





        private void button6_Click(object sender, EventArgs e)
        {
            Interaction.MsgBox(prueba.x);
        }

        private void Inicial_Paint(object sender, PaintEventArgs e)
        {  
            papel = e.Graphics;
            papel.SmoothingMode = SmoothingMode.AntiAlias; // claridad al dibujar

          /*  int x =600;
            int y = 400;
            int x1 =100;
            int y1 = 550;
            int xm = 0;
            int ym = 0;

            int xx = (x1 - x) / 2;
            int xxx = Math.Abs(xx);

            if (xx >= 0)
            {
                xm = x + xxx;

            }
            else
            {
                xm = x - xxx;
            }

            
            int yy = (y1 - y) / 2;
            int yyy = Math.Abs(yy);

           
            if (yy >= 0)
            {
                ym = y + yyy ;

            }
            else
            {
               ym = y - yyy;
            }

            int hh = Math.Abs(yy);

            int aux = Convert.ToInt32((0.20 * Math.Abs(y1-y)));
            int auy = Convert.ToInt32((0.20 * Math.Abs(x1 - x)));
            
            Point[] points2 = {
            new Point(x,y),      
            new Point(xm+aux,ym+auy),   
            new Point(x1,y1)};


            Pen pen = new Pen(Color.Black);
            papel.DrawCurve(pen, points2);*/




            //pintar estados
            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).pintarEstados(papel);
      
            }

            //pintar transiciones

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
           
                for (int j = 0; j < automata.listEstados.ElementAt(i).listTransiciones.Count; j++)
                {
                    automata.listEstados.ElementAt(i).listTransiciones.ElementAt(j).Pintar_traciciones(papel);
                }


            }




            //pintar nombres de estados
            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).pintarNombre(papel);

            }




            //pintar etiquetas de transiciones

            for (int i = 0; i < automata.listEstados.Count; i++)
            {

                for (int j = 0; j < automata.listEstados.ElementAt(i).listTransiciones.Count; j++)
                {
                    //si ya existe

                    
                    automata.listEstados.ElementAt(i).listTransiciones.ElementAt(j).Pintar_etiqueta(papel, j);
                }


            }



            //papel.CopyFromScreen(new Point(10, 10), new Point(100, 100), new Size(70, 70));

        }
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            // p.X++;

           

            //prueba.moverder();


            // MessageBox.Show(prueba.x+"");
            this.Invalidate();


        }
        public void creaEstado(MouseEventArgs e)
        {
            this.mouseX = e.X;
            this.mouseY = e.Y;


            bool ban = false;
            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                if (mouseX >= automata.listEstados.ElementAt(i).x && mouseX <= automata.listEstados.ElementAt(i).x + automata.listEstados.ElementAt(i).ancho && mouseY >= automata.listEstados.ElementAt(i).y && mouseY <= automata.listEstados.ElementAt(i).y + automata.listEstados.ElementAt(i).alto)
                {
                    ban = true;

                    break;
                }
            }
            if (!ban)
            {
                String estado = "Q" + automata.listEstados.Count;

                estados_textBox.Enabled = false;

                Clases.Estado es = new Clases.Estado(estado);

                es.x = e.X;
                es.y = e.Y;


                automata.listEstados.AddLast(es);



               
            }
            

            

        }
        Boolean ban_1 = false;
        Boolean ban_2 = false;

        public void crearTransicion(MouseEventArgs e) 
        {

            this.mouseX = e.X;
            this.mouseY = e.Y;

            while (true)
            {  
                if (!ban_1)
                {
                    for (int i = 0; i < automata.listEstados.Count; i++)
                    {
                        if (mouseX >= automata.listEstados.ElementAt(i).x && mouseX <= automata.listEstados.ElementAt(i).x + automata.listEstados.ElementAt(i).ancho && mouseY >= automata.listEstados.ElementAt(i).y && mouseY <= automata.listEstados.ElementAt(i).y + automata.listEstados.ElementAt(i).alto)
                        {
                            ban_1 = true;

                            break;
                        }
                    }
                    break;
                }

                if (ban_1)
                {
                    for (int i = 0; i < automata.listEstados.Count; i++)
                    {
                        if (mouseX >= automata.listEstados.ElementAt(i).x && mouseX <= automata.listEstados.ElementAt(i).x + automata.listEstados.ElementAt(i).ancho && mouseY >= automata.listEstados.ElementAt(i).y && mouseY <= automata.listEstados.ElementAt(i).y + automata.listEstados.ElementAt(i).alto)
                        {
                            ban_2 = true;

                            break;
                        }
                    } 
                }
                else
                {
                    ban_2 = false;
                }
                if (ban_2 && ban_1)
                {
                    ban_1 = false;
                    ban_2 = false;
                    Interaction.InputBox("Ingrese Caracter");
                
                }

                break;

            }

            
        
        }
        private void Inicial_MouseDown(object sender, MouseEventArgs e)
        {
           // prueba.mover(e, 1);

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).mover(e, 1);

            }

            creaEstado(e);

           // crearTransicion(e); FALTAN DETALLES
            



            

        }

        private void Inicial_MouseUp(object sender, MouseEventArgs e)
        {

           // prueba.mover(e, 2);

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).mover(e, 2);
            }


          

        }



        private void Inicial_MouseMove(object sender, MouseEventArgs e)
        {
            //prueba.mover(e, 3);

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).mover(e, 3);
            }




        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            automata.inicial = tabla_inicial_comboBox.Text;

            for (int i = 0; i < automata.listEstados.Count; i++)
            {
                automata.listEstados.ElementAt(i).inicial = false;

                if (automata.inicial.Equals(automata.listEstados.ElementAt(i).nombre))
                {
                    automata.listEstados.ElementAt(i).inicial = true;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < automata.listEstados.Count; i++)
            {

                if (tabla_aceptadores_comboBox.Text.Equals(automata.listEstados.ElementAt(i).nombre))
                {
                    automata.listEstados.ElementAt(i).aceptador = true;
                }

            }
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void cARGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Automata|*.dat";
            openFileDialog1.Title = "Selecciones Un Automata";



            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String ruta = openFileDialog1.FileName;

                String p = ruta.Substring(ruta.LastIndexOf('\\') + 1, ruta.LastIndexOf('.') - ruta.LastIndexOf('\\') +3);

              //  MessageBox.Show(ruta);
               // MessageBox.Show(p);

                automata= (Clases.Automata)leer(p);


            }
      
        }




        public static object leer(String nombre)
        {
            FileStream archivo = new FileStream(nombre, FileMode.Open);
            BinaryFormatter binaryformater = new BinaryFormatter();
            object obj = (object)binaryformater.Deserialize(archivo);
            archivo.Close();
            return obj;
        }

        public static void guardar(String nombre, Object aguardar)
        {
            FileStream archivo = new FileStream(nombre, FileMode.Create);
            BinaryFormatter binaryformater = new BinaryFormatter();
            binaryformater.Serialize(archivo, aguardar);
            archivo.Close();
        }

        private void aRCHIVOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gUARDARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String tex = Interaction.InputBox("Ingrese el Nombre del Archivo");

            if (!tex.Equals(""))
            {
                guardar(tex+".dat", automata);
                //MessageBox.Show(tex);
            }

            

            
        }

        private void rEINICIARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automata = new Clases.Automata();
            reiniciarComboxEstados(transicion_origen_comboBox);
            reiniciarComboxEstados(transicion_destino_comboBox);
            reiniciarComboxEstados(aceptador_comboBox);
            reiniciarComboxEstados(inicial_comboBox);

            estados_textBox.Text = automata.listEstados.Count + "";
            
            transicion_origen_comboBox.Text="";
            transicion_destino_comboBox.Text="";
            aceptador_comboBox.Text="";
            inicial_comboBox.Text = "";
            transicion_caracter_comboBox.Text = "";
            

            //reiniciar tabla

            reiniciarComboxEstados(destino_tabla_comboBox);
            reiniciarComboxEstados(origen_tabla_comboBox);
            reiniciarComboxEstados(tabla_aceptadores_comboBox);
            reiniciarComboxEstados(tabla_inicial_comboBox);

            destino_tabla_comboBox.Text = "";
            origen_tabla_comboBox.Text = "";
            tabla_aceptadores_comboBox.Text="";
            tabla_inicial_comboBox.Text="";
            caracter_tabla_comboBox.Text = "";
            


            this.caracter_tabla_comboBox.Items.Clear();

            foreach (var item in automata.alfabeto)
            {
                this.caracter_tabla_comboBox.Items.Add(item);
            }

            
            cargartabla();

        }


    }


}
