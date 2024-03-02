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
    /// <summary>
    /// Classe parziale per il form principale dell'applicazione.
    /// </summary>
    public partial class Form1 : Form
    {
        private GestoreDati Dati;

        /// <summary>
        /// Costruttore del form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Inizializza l'istanza di GestoreDati con un riferimento al graficoDati.
            Dati = new GestoreDati(graficoDati);
        }

        /// <summary>
        /// Gestisce il click del pulsante per acquisire una spesa o un'entrata.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void acquisciSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeDellaSpesa = spesaUtente.Text;
                string mese = meseUtente.Text;
                double valoreDellaSpesa = Double.Parse(valoreSpesaUtente.Text);

                spesaUtente.Text = "";
                valoreSpesaUtente.Text = "";
                meseUtente.Text = "";

                // Controlla se sia stato selezionato sia 'Entrata' che 'Uscita'.
                if (isEntrata.Checked && isUscita.Checked)
                {
                    MessageBox.Show("Non puoi selezionare entrata ed uscita assieme", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Controlla se il nome o il valore della spesa sono vuoti o non validi.
                if (String.IsNullOrEmpty(nomeDellaSpesa) || valoreDellaSpesa <= 0)
                {
                    MessageBox.Show("Nome della spesa o valore della spesa non validi", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Se è selezionata l'opzione 'Entrata', aggiunge un'entrata.
                if (isEntrata.Checked)
                {
                    var entrata = new Entrata();
                    entrata.Name = nomeDellaSpesa;
                    entrata.Value = valoreDellaSpesa;
                    entrata.Mese = meseUtente.Text;
                    Dati.AggiungiEntrata(entrata);
                }

                // Se è selezionata l'opzione 'Uscita', aggiunge un'uscita.
                if (isUscita.Checked)
                {
                    var uscita = new Uscita();
                    uscita.Name = nomeDellaSpesa;
                    uscita.Value = valoreDellaSpesa;
                    uscita.Mese = meseUtente.Text;
                    Dati.AggiungiUscita(uscita);
                }

            }
            catch (Exception ex)
            {
                // Gestisce eventuali eccezioni mostrando un messaggio di errore.
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
