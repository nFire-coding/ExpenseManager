namespace Gestore_di_Entrate
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.spesaUtente = new System.Windows.Forms.TextBox();
            this.valoreSpesaUtente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acquisciSpesa = new System.Windows.Forms.Button();
            this.graficoDati = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.meseUtente = new System.Windows.Forms.TextBox();
            this.isEntrata = new System.Windows.Forms.CheckBox();
            this.isUscita = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.graficoDati)).BeginInit();
            this.SuspendLayout();
            // 
            // spesaUtente
            // 
            this.spesaUtente.Location = new System.Drawing.Point(89, 49);
            this.spesaUtente.Name = "spesaUtente";
            this.spesaUtente.Size = new System.Drawing.Size(335, 20);
            this.spesaUtente.TabIndex = 0;
            // 
            // valoreSpesaUtente
            // 
            this.valoreSpesaUtente.Location = new System.Drawing.Point(89, 77);
            this.valoreSpesaUtente.Name = "valoreSpesaUtente";
            this.valoreSpesaUtente.Size = new System.Drawing.Size(335, 20);
            this.valoreSpesaUtente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valore Spesa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Spesa";
            // 
            // acquisciSpesa
            // 
            this.acquisciSpesa.Location = new System.Drawing.Point(443, 47);
            this.acquisciSpesa.Name = "acquisciSpesa";
            this.acquisciSpesa.Size = new System.Drawing.Size(247, 102);
            this.acquisciSpesa.TabIndex = 4;
            this.acquisciSpesa.Text = "Acquisisci Spesa";
            this.acquisciSpesa.UseVisualStyleBackColor = true;
            this.acquisciSpesa.Click += new System.EventHandler(this.acquisciSpesa_Click);
            // 
            // graficoDati
            // 
            chartArea2.Name = "ChartArea1";
            this.graficoDati.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.graficoDati.Legends.Add(legend2);
            this.graficoDati.Location = new System.Drawing.Point(12, 164);
            this.graficoDati.Name = "graficoDati";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "entrate";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "uscite";
            this.graficoDati.Series.Add(series3);
            this.graficoDati.Series.Add(series4);
            this.graficoDati.Size = new System.Drawing.Size(678, 318);
            this.graficoDati.TabIndex = 5;
            this.graficoDati.Text = "grafico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipologia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mese";
            // 
            // meseUtente
            // 
            this.meseUtente.Location = new System.Drawing.Point(89, 103);
            this.meseUtente.Name = "meseUtente";
            this.meseUtente.Size = new System.Drawing.Size(335, 20);
            this.meseUtente.TabIndex = 8;
            // 
            // isEntrata
            // 
            this.isEntrata.AutoSize = true;
            this.isEntrata.Location = new System.Drawing.Point(89, 141);
            this.isEntrata.Name = "isEntrata";
            this.isEntrata.Size = new System.Drawing.Size(59, 17);
            this.isEntrata.TabIndex = 10;
            this.isEntrata.Text = "entrata";
            this.isEntrata.UseVisualStyleBackColor = true;
            // 
            // isUscita
            // 
            this.isUscita.AutoSize = true;
            this.isUscita.Location = new System.Drawing.Point(154, 142);
            this.isUscita.Name = "isUscita";
            this.isUscita.Size = new System.Drawing.Size(54, 17);
            this.isUscita.TabIndex = 11;
            this.isUscita.Text = "uscita";
            this.isUscita.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 507);
            this.Controls.Add(this.isUscita);
            this.Controls.Add(this.isEntrata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.meseUtente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.graficoDati);
            this.Controls.Add(this.acquisciSpesa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valoreSpesaUtente);
            this.Controls.Add(this.spesaUtente);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graficoDati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox spesaUtente;
        private System.Windows.Forms.TextBox valoreSpesaUtente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button acquisciSpesa;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoDati;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox meseUtente;
        private System.Windows.Forms.CheckBox isEntrata;
        private System.Windows.Forms.CheckBox isUscita;
    }
}

