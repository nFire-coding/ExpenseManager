using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

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
                if (corrente.AxisLabel.Equals(entrata.Mese))
                {
                    corrente.YValues[0] = corrente.YValues[0] + entrata.Value;
                }
            }
            SalvaDati();
            AggiornaChart();
        }

        public void AggiungiUscita(Uscita uscita)
        {
            uscite.Add(uscita);

            foreach (DataPoint corrente in grafico.Series["uscite"].Points)
            {
                if (corrente.AxisLabel.Equals(uscita.Mese))
                {
                    corrente.YValues[0] = corrente.YValues[0] + uscita.Value;
                }
            }
            SalvaDati();
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

            foreach (DataPoint corrente in grafico.Series["entrate"].Points)
            {
                if (corrente.AxisLabel.Equals(instance.Mese))
                {
                    corrente.YValues[0] = 0;
                    break;
                }
            }
            SalvaDati(true, instance.Value);
            AggiornaChart();
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

            foreach (DataPoint corrente in grafico.Series["uscite"].Points)
            {
                if (corrente.AxisLabel.Equals(instance.Mese))
                {
                    corrente.YValues[0] = 0;
                    break;
                }
            }
            SalvaDati(true, instance.Value);
            AggiornaChart();
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

        private void SalvaDati(bool remove = false, double value = -1)
        {
            string[] righeFile = File.ReadAllLines(Consts.DIRECTORY);
            List<string> filteredLines = new List<string>();


            foreach (string line in righeFile)
            {
                filteredLines.Add(line);
            }

            if (!remove)
            {
                foreach (var item in uscite)
                {
                    filteredLines.Add($"uscita,{item.Value},{item.Mese}");
                }

                foreach (var item in entrate)
                {
                    filteredLines.Add($"entrata,{item.Value},{item.Mese}");
                }

                using (StreamWriter writer = new StreamWriter(Consts.DIRECTORY))
                {
                    foreach (string line in filteredLines)
                    {
                        writer.WriteLine(line);
                    }
                }
                return;
            }

            if (value == -1) throw new Exception("Nessun valore inserito");

            foreach (var item in filteredLines)
            {
                string[] elementiRiga = item.Split(',');

                if (double.Parse(elementiRiga[1]) == value)
                {
                    filteredLines.Remove(item);
                    break;
                }
            }

            using (StreamWriter writer = new StreamWriter(Consts.DIRECTORY))
            {
                foreach (string line in filteredLines)
                {
                    writer.WriteLine(line);
                }
            }
        }
        

        private void InizializzaGrafico()
        {
            List<string> mesi = new List<string> { "Gen", "Feb", "Mar", "Apr", "Mag", "Giu", "Lug", "Ago", "Set", "Ott", "Nov", "Dic" };

            for (int i = 0; i < 12; i++)
            {
                grafico.Series["entrate"].Points.AddXY(mesi[i], 0);
                grafico.Series["uscite"].Points.AddXY(mesi[i], 0);
            }

            grafico.ChartAreas[0].AxisX.Minimum = double.NaN;
            grafico.ChartAreas[0].AxisX.Maximum = double.NaN;


            CreaDatabase();
        }

        private void AggiornaChart()
        {
            grafico.ChartAreas[0].AxisX.Minimum = double.NaN;
            grafico.ChartAreas[0].AxisX.Maximum = double.NaN;

            grafico.Invalidate();
            grafico.Update();
            grafico.Refresh(); 
        }
    }
}
