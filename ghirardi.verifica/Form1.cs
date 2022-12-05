using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ghirardi.verifica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        verifica[] disponibili = new verifica[1000];
        private elenco ele;
        int cont1 = 0;
        int indice;
        private void Form1_Load(object sender, EventArgs e)
        {
           
            ele = new elenco("1");
            string[] intestazione = new string[] { "ID", "MATERIA", "VOTO", "DATA" };

            for (int i = 0; i < intestazione.Length; i++)
            {
               listView1.Columns.Add(intestazione[i]);
            }


            verifica[] prodotti = ele.Registro;

            for (int i = 0; i < prodotti.Length; i++)
            {
                //se ToString presenta esattamente i campi necessari..
                ListViewItem riga = new ListViewItem(prodotti[i].ToString().Split(';'));
                listView1.Items.Add(riga);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disponibili[cont1] = new verifica(Convert.ToString(ele.Checkid), textBox1.Text, (float)numericUpDown1.Value, dateTimePicker1.Value);
            ele.aggiungiVoto(textBox1.Text, (float)numericUpDown1.Value, dateTimePicker1.Value);
            
          
            listView1.Clear();
            string[] intestazione = new string[] { "ID", "NOME", "VOTO", "DATA" };

            for (int i = 0; i < intestazione.Length; i++)
            {
                listView1.Columns.Add(intestazione[i]);
            }

            verifica[] prodotti = ele.Registro;

            for (int i = 0; i < prodotti.Length; i++)
            {
               
                ListViewItem riga = new ListViewItem(prodotti[i].ToString().Split(';'));
                listView1.Items.Add(riga);
            }
            cont1++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indici = listView1.SelectedIndices[0];
            string materia = disponibili[indici].Materia;
            float media = ele.calcoloMedia(materia);
            MessageBox.Show("la tua media in " + materia + " equivale a "+Convert.ToString(media));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indici = listView1.SelectedIndices[0];
            ele.rimuovi(disponibili[indici]);
            int index = indici;

            for (int i = index; i < disponibili.Length - 1; i++)
            {
                disponibili[i] = disponibili[i + 1];
            }
            Array.Resize(ref disponibili, disponibili.Length - 1);
            listView1.Items.RemoveAt(indici);
            cont1--;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listView1.FocusedItem != null) { 
            label7.Show();
            label6.Show();
            label5.Show();
            button5.Show();
            textBox2.Show();
            numericUpDown2.Show();
            dateTimePicker2.Show();
            indice = listView1.SelectedIndices[0];
            textBox2.Text = disponibili[indice].Materia;
            numericUpDown2.Value =(Decimal)disponibili[indice].Voto;
            dateTimePicker2.Value = disponibili[indice].Data;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("sei sicuro di voler modificare la verifica?", "verifica", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                disponibili[indice].modificaMateria(textBox2.Text);
                disponibili[indice].modificaVoto((float)numericUpDown2.Value);
                disponibili[indice].modificaData(dateTimePicker2.Value);
                ele.modificaVoto(disponibili[indice], disponibili[indice].Voto);
                ele.modificaMateria(disponibili[indice], disponibili[indice].Materia);
                ele.modificaData(disponibili[indice], disponibili[indice].Data);
                listView1.Clear();
                string[] intestazione = new string[] { "ID", "NOME", "VOTO", "DATA" };

                for (int i = 0; i < intestazione.Length; i++)
                {
                    listView1.Columns.Add(intestazione[i]);
                }

                verifica[] prodotti = ele.Registro;

                for (int i = 0; i < prodotti.Length; i++)
                {

                    ListViewItem riga = new ListViewItem(prodotti[i].ToString().Split(';'));
                    listView1.Items.Add(riga);
                }

            label7.Hide();
            label6.Hide();
            label5.Hide();
            button5.Hide();
            textBox2.Hide();
            numericUpDown2.Hide();
            dateTimePicker2.Hide();
            }
          
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
