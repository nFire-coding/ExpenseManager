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

namespace Gestore_di_Entrate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initGrafico();


        }

        private void initGrafico()
        {
            List<string> mesi = new List<string> { "Gen", "Feb", "Mar", "Apr", "Mag", "Giu", "Lug", "Ago", "Set", "Ott", "Nov", "Dic" };
            //init mesi
            for(int i = 0; i < 12; i++)
            {
                graficoDati.Series["entrate"].Points.AddXY(mesi[i], 0);
                graficoDati.Series["uscite"].Points.AddXY(mesi[i],0);
            }

            //Lettura da file dei dati
            string[] righeFile = File.ReadAllLines("PERCORSO FILE");

            foreach (string line in righeFile) {
                string[] elementiRiga = line.Split(','); //TIPO, QUANTITA, MESE

                foreach (DataPoint corrente in graficoDati.Series["entrate"].Points)
                {
                    if (corrente.AxisLabel.Equals(elementiRiga[2]))
                    {   
                        corrente.SetValueY(corrente.YValues[0] + double.Parse(elementiRiga[1]));
                    }
                }

                foreach (DataPoint corrente in graficoDati.Series["uscite"].Points)
                {
                    if (corrente.AxisLabel.Equals(elementiRiga[2]))
                    {
                        corrente.SetValueY(corrente.YValues[0] + double.Parse(elementiRiga[1]));
                    }
                }
            }
            graficoDati.Update();
            graficoDati.Refresh();
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

                foreach (DataPoint corrente in graficoDati.Series["entrate"].Points)
                {
                    Debug.WriteLine(corrente.AxisLabel + " " + corrente.YValues[0]);
                    if (corrente.AxisLabel.Equals(meseUtente.Text)) {
                        corrente.YValues[0] = corrente.YValues[0] + valoreDellaSpesa;
                    }
                    //scrivi sul file AAA
                }
            }
            //Uscita
            if (isUscita.Checked)
            {

                foreach (DataPoint corrente in graficoDati.Series["uscite"].Points)
                {
                    Debug.WriteLine(corrente.AxisLabel + " " + corrente.YValues[0]);
                    if (corrente.AxisLabel.Equals(meseUtente.Text))
                    {
                        corrente.YValues[0] = corrente.YValues[0] + valoreDellaSpesa;
                    }
                }
            }
            
            meseUtente.Text = "";
            graficoDati.Update();
            graficoDati.Refresh();
        }
    }
}
