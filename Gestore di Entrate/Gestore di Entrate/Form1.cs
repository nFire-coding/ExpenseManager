using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Gestore_di_Entrate.Modules;

namespace Gestore_di_Entrate
{
    public partial class Form1 : Form
    {
        private GestoreDati Dati;
        public Form1()
        {
            InitializeComponent();
            Dati = new GestoreDati(graficoDati);
        }

        private void acquisciSpesa_Click(object sender, EventArgs e)
        {
            string nomeDellaSpesa = spesaUtente.Text;
            double valoreDellaSpesa = double.Parse(valoreSpesaUtente.Text);
            Debug.WriteLine(nomeDellaSpesa + " " + valoreDellaSpesa); //Salviamo la spesa
            spesaUtente.Text = "";
            valoreSpesaUtente.Text = "";
            

            //Entrata
            if (isEntrata.Checked) {
                var entrata = new Entrata();
                entrata.Name = nomeDellaSpesa;
                entrata.Value = valoreDellaSpesa;
                entrata.Mese = meseUtente.Text;
                Dati.AggiungiEntrata(entrata);
            }
            //Uscita
            if (isUscita.Checked)
            {
                var uscita = new Uscita();
                uscita.Name = nomeDellaSpesa;
                uscita.Value = valoreDellaSpesa;
                uscita.Mese = meseUtente.Text;
                Dati.AggiungiUscita(uscita);
            }
            
            meseUtente.Text = "";
        }
    }
}
