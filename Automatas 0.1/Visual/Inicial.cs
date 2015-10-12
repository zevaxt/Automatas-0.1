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
<<<<<<< HEAD
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;




=======
using System.Runtime.InteropServices;
using System.Security;
>>>>>>> origin/master

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
<<<<<<< HEAD
            automata = new Clases.Automata();
            prueba = new Clases.Estado();
            timer1.Enabled = true;
            p = new Rectangle(50, 50, 50, 50);
            b1 = false;
=======
            panel_diagrama.Visible = false;
>>>>>>> origin/master


            crearAutomata();




        }
        public void crearAutomata() 
        {
              Clases.Automata automata;
              LinkedList <String> oelista= new LinkedList<String>();
              oelista.AddFirst("a");
              oelista.AddFirst("b");

              
        LinkedList<Clases.Estado> listaEstado = new LinkedList<Clases.Estado>();
        listaEstado.AddLast(new Clases.Estado("Q0", new LinkedList<Clases.Transicion>(), false));
        listaEstado.AddLast(new Clases.Estado("Q1", new LinkedList<Clases.Transicion>(), false));
        listaEstado.AddLast(new Clases.Estado("Q2", new LinkedList<Clases.Transicion>(), true));
        listaEstado.AddLast(new Clases.Estado("Q3", new LinkedList<Clases.Transicion>(), false));
        listaEstado.AddLast(new Clases.Estado("Q4", new LinkedList<Clases.Transicion>(), true));
        listaEstado.AddLast(new Clases.Estado("Q5", new LinkedList<Clases.Transicion>(), false));
        listaEstado.AddLast(new Clases.Estado("Q6", new LinkedList<Clases.Transicion>(), false));
        listaEstado.ElementAt(0).listTransiciones.AddLast(new Clases.Transicion("Q0", "a", "Q2"));
        listaEstado.ElementAt(0).listTransiciones.AddLast(new Clases.Transicion("Q0", "b", "Q1"));
        listaEstado.ElementAt(1).listTransiciones.AddLast(new Clases.Transicion("Q1", "a", "Q0"));
        listaEstado.ElementAt(1).listTransiciones.AddLast(new Clases.Transicion("Q1", "b", "Q2"));
        listaEstado.ElementAt(2).listTransiciones.AddLast(new Clases.Transicion("Q2", "a", "Q3"));
        listaEstado.ElementAt(2).listTransiciones.AddLast(new Clases.Transicion("Q2", "b", "Q5"));
        listaEstado.ElementAt(3).listTransiciones.AddLast(new Clases.Transicion("Q3", "a", "Q6"));
        listaEstado.ElementAt(3).listTransiciones.AddLast(new Clases.Transicion("Q3", "b", "Q1"));
        listaEstado.ElementAt(4).listTransiciones.AddLast(new Clases.Transicion("Q4", "a", "Q3"));
        listaEstado.ElementAt(4).listTransiciones.AddLast(new Clases.Transicion("Q4", "b", "Q5"));
        listaEstado.ElementAt(5).listTransiciones.AddLast(new Clases.Transicion("Q5", "a", "Q6"));
        listaEstado.ElementAt(5).listTransiciones.AddLast(new Clases.Transicion("Q5", "b", "Q4"));
        listaEstado.ElementAt(6).listTransiciones.AddLast(new Clases.Transicion("Q6", "a", "Q2"));
        listaEstado.ElementAt(6).listTransiciones.AddLast(new Clases.Transicion("Q6", "b", "Q5"));
        automata= new Clases.Automata("auto1", "Q0", listaEstado,oelista);
       

        //minimizar(automata);
       /* reconocer("ababbb", automata);
        if (!isCompleto(automata)) 
        {
            completar(automata);
        }
        Console.WriteLine(automata.listEstados.ElementAt(automata.listEstados.Count-1).nombre);*/
        reverso(automata);
        }
        public static Clases.Automata convertirVacias(Clases.Automata auto)
    {
        Clases.Automata nuevo = new Clases.Automata();
        nuevo.alfabeto = auto.alfabeto;
        nuevo.nombre = "dfa de: " + auto.nombre;
        String oe2 = "";

        LinkedList<Clases.Estado> lista = new LinkedList<Clases.Estado>();
        for (int i = 0; i < auto.listEstados.Count; i++)
        {
            if (auto.inicial.Equals(auto.listEstados.ElementAt(i).nombre))
            {

                String inicial = auto.listEstados.ElementAt(i).nombre;
                inicial = inicial + RecorrerVacias(inicial, auto, true);///a qie le mandamos un string 
                nuevo.listEstados.AddLast(new Clases.Estado(inicial, false));
                nuevo.inicial = inicial;
                lista.AddLast(new Clases.Estado(inicial, false));
            } else
            {

                while (lista.First!=null)

                {

                    String[] estados = lista.First().nombre.Split(',');
                    for (int q=0;q<auto.alfabeto.Count;q++)
                    {
                        int cont = 0;
                        Boolean es = true;
                        String oe = "";

                        for (int j = 0; j < estados.Length; j++)
                        {
                            for (int k = 0; k < auto.listEstados.Count(); k++)
                            {
                                if (auto.listEstados.ElementAt(k).nombre.Equals(estados[j]))
                                {

                                    for (int l = 0; l < auto.listEstados.ElementAt(k).getLista().Count(); l++)
                                    {

                                        if (auto.alfabeto.ElementAt(q).Equals(auto.listEstados.ElementAt(k).getLista().ElementAt(l).simbolo))
                                        {
                                            cont++;
                                            if (!oe.Equals(""))
                                            {
                                                if (oe.IndexOf(auto.listEstados.ElementAt(k).getLista().ElementAt(l).destino) == -1)
                                                {
                                                    oe = oe + "," + auto.listEstados.ElementAt(k).getLista().ElementAt(l).destino;
                                                }

                                            } else
                                            {
                                                if (oe.IndexOf(auto.listEstados.ElementAt(k).getLista().ElementAt(l).destino) == -1)
                                                {
                                                    oe = auto.listEstados.ElementAt(k).getLista().ElementAt(l).destino;
                                                    
                                                }
                                            }
                                        }

                                    }

                                }
                            }
                        }
                        if (cont == 0)
                        {
                            continue;
                        }
                        oe2="";

                        String[] trans = oe.Split(',');
                        for (int j = 0; j < trans.Length; j++)
                        {
                            oe2 =oe2+","+ trans[j] + RecorrerVacias(trans[j], auto, true);
                        }
                        trans=oe2.Split(',');
                        //eliminar repetidos
                        oe2="";
                        for (int j = 0; j < trans.Length; j++)
                        {
                          if(oe2.IndexOf(trans[j])==-1){
                          
                            if(oe2.Equals(""))
                           {
                               oe2=trans[j];
                           }
                           else
                           {
                               oe2=oe2+","+trans[j];
                           }
                          }
                        }
                      
                        String[] vector;
                        String oe3 = "";
                        for (int k = 0; k < nuevo.listEstados.Count(); k++)
                        {
                            vector = soniguales(nuevo.listEstados.ElementAt(k).nombre, oe2, lista.First().nombre);
                            if (nuevo.listEstados.ElementAt(k).nombre.Equals(vector[2]))
                            {
                                nuevo.listEstados.ElementAt(k).getLista().AddLast(new Clases.Transicion(nuevo.listEstados.ElementAt(k).nombre, auto.alfabeto.ElementAt(q), vector[0]));
                                oe3 = vector[0];
                            }

                            if (vector[0].Equals(vector[1]))
                            {
                                es = false;

                            }
                        }
                        if (es == true)
                        {
                            nuevo.listEstados.AddLast(new Clases.Estado(oe3, false));

                            lista.AddLast(nuevo.listEstados.Last());

                        }
                    }
                    lista.RemoveFirst();

                }

                for (int w = 0; w < nuevo.listEstados.Count;w++ )
                {
                    String[] nombre = nuevo.listEstados.ElementAt(w).nombre.Split(',');
                    for (int j = 0; j < nombre.Length; j++)
                    {
                        for (int k = 0; k < auto.listEstados.Count(); k++)
                        {
                            if (nombre[j].Equals(auto.listEstados.ElementAt(k).nombre))
                            {
                                if (auto.listEstados.ElementAt(k).aceptador)
                                {
                                    nuevo.listEstados.ElementAt(w).aceptador = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            }

        }
       return nuevo;
    }

        public static String RecorrerVacias(String cadena, Clases.Automata auto, Boolean ban)
        {
            String oe = "";
            if (ban)
            {
                for (int i = 0; i < auto.listEstados.Count(); i++)
                {

                    if (cadena.Equals(auto.listEstados.ElementAt(i).nombre))
                    {
                        int cont = 0;

                        for (int j = 0; j < auto.listEstados.ElementAt(i).getLista().Count(); j++)
                        {
                            if (auto.listEstados.ElementAt(i).getLista().ElementAt(j).simbolo.Equals("-"))
                            {
                                if (oe.IndexOf(auto.listEstados.ElementAt(i).getLista().ElementAt(j).destino) == -1)
                                {

                                    oe = oe + "," + auto.listEstados.ElementAt(i).getLista().ElementAt(j).destino;

                                    oe += RecorrerVacias(auto.listEstados.ElementAt(i).getLista().ElementAt(j).destino, auto, true);

                                }

                            }
                            else
                            {
                                cont++;
                            }

                        }
                        if (cont == auto.listEstados.ElementAt(i).getLista().Count())
                        {

                            oe += RecorrerVacias(cadena, auto, false);
                            return oe;
                        }

                    }
                }

            }
            return oe;
        }

        private static String[] soniguales(String nombre, String oe2, String lista)
    {
        String[] com1 = nombre.Split('.');
        String[] com2 = oe2.Split(',');
        String[] com3 = lista.Split(',');
        List<String> comp1 = new List<string>();
        List<String> comp2 = new List<String>();
        List<String> comp3 = new List<String>();
        for (int j = 0; j < com1.Length; j++)
        {
            comp1.Add(com1[j]);
        }
        for (int j = 0; j < com2.Length; j++)
        {
            comp2.Add(com2[j]);
        }
        for (int j = 0; j < com3.Length; j++)
        {
            comp3.Add(com3[j]);
        }
        comp1.Sort();
        comp2.Sort();
        comp3.Sort();
      
        
        nombre = "";
        oe2 = "";
        lista = "";
        for (int i = 0; i < comp1.Count(); i++)
        {
            if (nombre.Equals(""))
            {
                nombre = comp1.ElementAt(i);

            } else
            {
                nombre = nombre + "," + comp1.ElementAt(i);
            }

        }
        for (int i = 0; i < comp3.Count(); i++)
        {
            if (lista.Equals(""))
            {
                lista = comp3.ElementAt(i);

            } else
            {
                lista = lista + "," + comp3.ElementAt(i);
            }

        }
        for (int i = 0; i < comp2.Count(); i++)
        {
            if (oe2.Equals(""))
            {
                oe2 = comp2.ElementAt(i);
            } else
            {
                oe2 = oe2 + "," + comp2.ElementAt(i);
            }

        }
        String[] vector =
        {
            oe2, nombre, lista
        };
        return vector;

    }

        public static Clases.Automata union(Clases.Automata auto1, Clases.Automata auto2)
    {
        Clases.Automata nuevo = new Clases.Automata();
        String inicial = auto1.inicial + auto2.inicial;

        for (int i = 0; i < auto1.listEstados.Count; i++)
        {
            for (int j = 0; j < auto2.listEstados.Count; j++)
            {
                String nombre = auto1.listEstados.ElementAt(i).nombre + auto2.listEstados.ElementAt(j).nombre;
                LinkedList<Clases.Transicion> lista = new LinkedList<Clases.Transicion>();
                for (int k = 0; k < auto1.listEstados.ElementAt(i).listTransiciones.Count(); k++)
                {
                    String nombre2 = auto1.listEstados.ElementAt(i).listTransiciones.ElementAt(k).destino + auto2.listEstados.ElementAt(j).listTransiciones.ElementAt(k).destino;
                    lista.AddLast(new Clases.Transicion(nombre, auto1.listEstados.ElementAt(i).listTransiciones.ElementAt(k).simbolo, nombre2));
                }
                if (nombre.Equals(inicial))
                {

                    nuevo.inicial = nombre;
                }
                if (auto1.listEstados.ElementAt(i).aceptador || auto2.listEstados.ElementAt(j).aceptador)
                {

                    nuevo.listEstados.AddLast(new Clases.Estado(nombre, lista, true));
                } else if (!auto1.listEstados.ElementAt(i).aceptador || !auto2.listEstados.ElementAt(j).aceptador)
                {
                    nuevo.listEstados.AddFirst(new Clases.Estado(nombre, lista, false));
                }

            }
        }
        for (int i = 0; i < nuevo.listEstados.Count(); i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine(nuevo.listEstados.ElementAt(i).nombre + " por " + nuevo.listEstados.ElementAt(i).listTransiciones.ElementAt(j).simbolo + "para" + nuevo.listEstados.ElementAt(i).listTransiciones.ElementAt(j).destino + "Acetador:" + nuevo.listEstados.ElementAt(i).aceptador);
            }

        }
        return nuevo;
    }
        public static Clases.Automata intersepcion(Clases.Automata auto1, Clases.Automata auto2)
        {
            Clases.Automata nuevo = new Clases.Automata();
            String inicial = auto1.inicial + auto2.inicial;

            for (int i = 0; i < auto1.listEstados.Count; i++)
            {
                for (int j = 0; j < auto2.listEstados.Count; j++)
                {
                    String nombre = auto1.listEstados.ElementAt(i).nombre + auto2.listEstados.ElementAt(j).nombre;
                    LinkedList<Clases.Transicion> lista = new LinkedList<Clases.Transicion>();
                    for (int k = 0; k < auto1.listEstados.ElementAt(i).listTransiciones.Count(); k++)
                    {
                        String nombre2 = auto1.listEstados.ElementAt(i).listTransiciones.ElementAt(k).destino + auto2.listEstados.ElementAt(j).listTransiciones.ElementAt(k).destino;
                        lista.AddLast(new Clases.Transicion(nombre, auto1.listEstados.ElementAt(i).listTransiciones.ElementAt(k).simbolo, nombre2));
                    }
                    if (nombre.Equals(inicial))
                    {

                        nuevo.inicial = nombre;
                    }
                    if (auto1.listEstados.ElementAt(i).aceptador && auto2.listEstados.ElementAt(j).aceptador)
                    {

                        nuevo.listEstados.AddLast(new Clases.Estado(nombre, lista, true));
                    }
                    else if (!auto1.listEstados.ElementAt(i).aceptador || !auto2.listEstados.ElementAt(j).aceptador)
                    {
                        nuevo.listEstados.AddFirst(new Clases.Estado(nombre, lista, false));
                    }

                }
            }
            for (int i = 0; i < nuevo.listEstados.Count(); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine(nuevo.listEstados.ElementAt(i).nombre + " por " + nuevo.listEstados.ElementAt(i).listTransiciones.ElementAt(j).simbolo + "para" + nuevo.listEstados.ElementAt(i).listTransiciones.ElementAt(j).destino + "Acetador:" + nuevo.listEstados.ElementAt(i).aceptador);
                }

            }
            return nuevo;
        }

        public static Clases.Automata complemento (Clases.Automata auto)
        {
            Clases.Automata nuevo = auto; 
            for (int i = 0; i < nuevo.listEstados.Count; i++)
            {
                if (nuevo.listEstados.ElementAt(i).aceptador)
                {
                    nuevo.listEstados.ElementAt(i).aceptador = false;
                }
                else
                {
                    nuevo.listEstados.ElementAt(i).aceptador = false;
                }
            }
            return nuevo;
        }
        public static void completar(Clases.Automata automata) 
        {
            
            Clases.Estado trampa= new Clases.Estado("Trampa");
            for (int p = 0; p < automata.alfabeto.Count; p++) 
            {
                trampa.listTransiciones.AddFirst(new Clases.Transicion("trampa", automata.alfabeto.ElementAt(p), "trampa"));
            }
                automata.listEstados.AddLast(trampa);
            for (int i = 0; i < automata.listEstados.Count;i++) 
            {
                if(automata.listEstados.ElementAt(i).listTransiciones.Count!=automata.alfabeto.Count)
                {
                    Boolean estado = true;
                    for (int j = 0; j < automata.alfabeto.Count; j++)
                    {
                        for (int k = 0; k < automata.listEstados.ElementAt(i).listTransiciones.Count; k++)
                        {
                            
                            if(automata.alfabeto.ElementAt(j).Equals(automata.listEstados.ElementAt(i).listTransiciones.ElementAt(k).simbolo))
                            {
                                estado = false;
                                break;
                            }
                        }
                        if (estado == true) 
                        {
                            automata.listEstados.ElementAt(i).listTransiciones.AddLast(new Clases.Transicion(automata.listEstados.ElementAt(i).nombre, automata.alfabeto.ElementAt(j), trampa.nombre));
                        }
                    }
                }
            }
        }
        public static Boolean isCompleto(Clases.Automata automata)
        {
            Boolean var=true;
            for (int i = 0; i < automata.listEstados.Count; i++) 
            {
                if(automata.listEstados.ElementAt(i).listTransiciones.Count!=automata.alfabeto.Count)
                {
                    var = false;
                    break;
                }
            }
            return var;
        }

        public static void reconocer(String cadena, Clases.Automata automata)
    {
        Stack<Clases.Estado> estadoactual = new Stack<Clases.Estado>();
        
        for (int i = 0; i < automata.listEstados.Count; i++)
        {
            if (automata.listEstados.ElementAt(i).nombre.Equals(automata.inicial))
            {
                estadoactual.Push(automata.listEstados.ElementAt(i));
                for (int j = 0; j < cadena.Length; j++)
                {
                    for (int k = 0; k < estadoactual.Peek().listTransiciones.Count; k++)
                    {
                       // System.out.println(String.valueOf(cadena.charAt(j)));
                        if (cadena.Substring(j,1).Equals(estadoactual.Peek().listTransiciones.ElementAt(k).simbolo))
                        {
                            for (int l = 0; l < automata.listEstados.Count; l++)
                            {
                                if(automata.listEstados.ElementAt(l).nombre.Equals(estadoactual.Peek().listTransiciones.ElementAt(k).destino))
                                {
                                    estadoactual.Push(automata.listEstados.ElementAt(l));
                                    break;
                                }
                            }
                            
                        }
                    }
                }

            }
        }

        if (estadoactual.Peek().aceptador)
        {
            
            Console.WriteLine(cadena + "Es aceptada");
            
        }
        else 
        {
            Console.WriteLine(cadena + "NO Es aceptada");
        }
        for (int i = estadoactual.Count-1; i >= 0; i--) {

            Console.WriteLine(estadoactual.ElementAt(i).nombre);

        }
     
    }
        public static Clases.Automata reverso(Clases.Automata auto)
    {
        Clases.Automata nuevo= new Clases.Automata();
        int  cont=0;
        //vamos aver si tiene mas aceptadores
        for (int i = 0; i <auto.listEstados.Count; i++)
        {
            if(auto.listEstados.ElementAt(i).aceptador)
            {
                cont++;
            }
        }
        if(cont>1)//tiene mas aceptadores creamos un nuevo estado y todos loa ceptadores los mandamos por vacias a ese nuevo
        {
            Clases.Estado estadonuevo= new Clases.Estado("nuevo", true);
           for (int i = 0; i <auto.listEstados.Count; i++)
        {
            if(auto.listEstados.ElementAt(i).aceptador)
            {
                
                auto.listEstados.ElementAt(i).listTransiciones.AddLast(new Clases.Transicion(auto.listEstados.ElementAt(i).nombre,"-",estadonuevo.nombre));
                auto.listEstados.ElementAt(i).aceptador=false;
            }
        }
           auto.listEstados.AddLast(estadonuevo);
           nuevo=cambiar(auto);
          
        }
        else 
        {
            nuevo=cambiar(auto);
        }
        return nuevo;
    }
        public static Clases.Automata cambiar(Clases.Automata auto)
        {
            String inicial = auto.inicial;
            for (int i = 0; i < auto.listEstados.Count; i++)
            {
                if (auto.listEstados.ElementAt(i).aceptador)
                {
                    auto.listEstados.ElementAt(i).aceptador = false;
                    auto.inicial = auto.listEstados.ElementAt(i).nombre;

                }
                if (auto.listEstados.ElementAt(i).nombre == inicial)
                {
                    auto.listEstados.ElementAt(i).aceptador = true;


                }

                for (int j = 0; j < auto.listEstados.ElementAt(i).listTransiciones.Count(); j++)
                {

                    auto.listEstados.ElementAt(i).listTransiciones.ElementAt(j).origen = auto.listEstados.ElementAt(i).listTransiciones.ElementAt(j).destino;
                    auto.listEstados.ElementAt(i).listTransiciones.ElementAt(j).destino = auto.listEstados.ElementAt(i).nombre;

                }
            }
            for (int i = 0; i < auto.listEstados.Count; i++)
            {
                for (int j = 0; j < auto.listEstados.Count; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < auto.listEstados.ElementAt(j).listTransiciones.Count; k++)
                        {
                            if (auto.listEstados.ElementAt(i).nombre.Equals(auto.listEstados.ElementAt(j).listTransiciones.ElementAt(k).origen))
                            {
                                auto.listEstados.ElementAt(i).listTransiciones.AddLast(auto.listEstados.ElementAt(j).listTransiciones.ElementAt(k));
                                auto.listEstados.ElementAt(j).listTransiciones.Remove(auto.listEstados.ElementAt(j).listTransiciones.ElementAt(k));


                            }
                        }
                    }

                }
            }

            return auto;
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



<<<<<<< HEAD
=======

>>>>>>> origin/master
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

<<<<<<< HEAD

=======
        private void label16_Click(object sender, EventArgs e)
        {

        }
>>>>>>> origin/master
    }


}
