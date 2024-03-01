using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Gestore_di_Entrate.Modules
{
    class GestoreDati
    {
        private List<Entrata> entrate;
        private List<Uscita> uscite;

        public List<Entrata> Entrate { get { return entrate; } }

        public List<Uscita> Uscite { get { return uscite; } }

        private Chart grafico;

        public GestoreDati(Chart grafico)
        {
            entrate = new List<Entrata>();
            uscite = new List<Uscita>();
            this.grafico = grafico;
            InizializzaGrafico();
        }

        public void AggiungiEntrata(Entrata entrata)
        {
            entrate.Add(entrata);

            foreach (DataPoint corrente in grafico.Series["entrate"].Points)
            {
                Debug.WriteLine(corrente.AxisLabel + " " + corrente.YValues[0]);
                if (corrente.AxisLabel.Equals(entrata.Mese))
                {
                    corrente.YValues[0] = corrente.YValues[0] + entrata.Value;
                }
                //scrivi sul file AAA
            }
            AggiornaChart();
        }

        public void AggiungiUscita(Uscita uscita)
        {
            uscite.Add(uscita);

            foreach (DataPoint corrente in grafico.Series["uscite"].Points)
            {
                Debug.WriteLine(corrente.AxisLabel + " " + corrente.YValues[0]);
                if (corrente.AxisLabel.Equals(uscita.Mese))
                {
                    corrente.YValues[0] = corrente.YValues[0] + uscita.Value;
                }
            }
            AggiornaChart();
        }

        public void RimuoviEntrata(string name)
        {
            Entrata instance = null;
            foreach (var entrata in entrate)
            {
                if(entrata.Name.Contains(name))
                {
                    instance = entrata;
                    break;
                }
            }
            if(instance != null) entrate.Remove(instance);
        }
        public void RimuoviUscita(string name)
        {
            Uscita instance = null;
            foreach (var uscita in uscite)
            {
                if (uscita.Name.Contains(name))
                {
                    instance = uscita;
                    break;
                }
            }
            if (instance != null) uscite.Remove(instance);
        }

        private void CreaDatabase()
        {
            string[] righeFile = File.ReadAllLines(Consts.DIRECTORY);

            foreach (string line in righeFile)
            {
                string[] elementiRiga = line.Split(',');

                foreach (DataPoint corrente in grafico.Series["entrate"].Points)
                {
                    if (corrente.AxisLabel.Equals(elementiRiga[2]))
                    {
                        corrente.SetValueY(corrente.YValues[0] + double.Parse(elementiRiga[1]));
                    }
                }

                foreach (DataPoint corrente in grafico.Series["uscite"].Points)
                {
                    if (corrente.AxisLabel.Equals(elementiRiga[2]))
                    {
                        corrente.SetValueY(corrente.YValues[0] + double.Parse(elementiRiga[1]));
                    }
                }
            }
            AggiornaChart();
        }

        private void SalvaDati()
        {

        }

        private void InizializzaGrafico()
        {
            List<string> mesi = new List<string> { "Gen", "Feb", "Mar", "Apr", "Mag", "Giu", "Lug", "Ago", "Set", "Ott", "Nov", "Dic" };

            for (int i = 0; i < 12; i++)
            {
                grafico.Series["entrate"].Points.AddXY(mesi[i], 0);
                grafico.Series["uscite"].Points.AddXY(mesi[i], 0);
            }
            CreaDatabase();
        }

        private void AggiornaChart()
        {
            grafico.Update();
            grafico.Refresh();
        }
    }
}
