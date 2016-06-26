namespace HMA
{
    partial class HMA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bGetWeather = new System.Windows.Forms.Button();
            this.License = new System.Windows.Forms.TextBox();
            this.bImHome = new System.Windows.Forms.Button();
            this.bANN = new System.Windows.Forms.Button();
            this.tbAnnPredictedValue = new System.Windows.Forms.TextBox();
            this.tbANNHeatingStart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDemandingTemperature = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRlStartHeating = new System.Windows.Forms.TextBox();
            this.tBRlPredictedValue = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bImOut = new System.Windows.Forms.Button();
            this.bChangeHeaterState = new System.Windows.Forms.Button();
            this.bRL = new System.Windows.Forms.Button();
            this.bWma = new System.Windows.Forms.Button();
            this.tbWma = new System.Windows.Forms.TextBox();
            this.tbWmaHeatingStart = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // bGetWeather
            // 
            this.bGetWeather.Location = new System.Drawing.Point(15, 79);
            this.bGetWeather.Name = "bGetWeather";
            this.bGetWeather.Size = new System.Drawing.Size(100, 23);
            this.bGetWeather.TabIndex = 1;
            this.bGetWeather.Text = "Pobierz Pogode";
            this.bGetWeather.UseVisualStyleBackColor = true;
            this.bGetWeather.Click += new System.EventHandler(this.bGetWeather_Click);
            // 
            // License
            // 
            this.License.Location = new System.Drawing.Point(12, 229);
            this.License.Name = "License";
            this.License.ReadOnly = true;
            this.License.Size = new System.Drawing.Size(495, 20);
            this.License.TabIndex = 2;
            this.License.Text = "Temperatura pobrana z OpenWeatherMap";
            // 
            // bImHome
            // 
            this.bImHome.Location = new System.Drawing.Point(440, 12);
            this.bImHome.Name = "bImHome";
            this.bImHome.Size = new System.Drawing.Size(67, 53);
            this.bImHome.TabIndex = 3;
            this.bImHome.Text = "Wróciłem";
            this.bImHome.UseVisualStyleBackColor = true;
            this.bImHome.Click += new System.EventHandler(this.bImHome_Click);
            // 
            // bANN
            // 
            this.bANN.Location = new System.Drawing.Point(172, 187);
            this.bANN.Name = "bANN";
            this.bANN.Size = new System.Drawing.Size(100, 23);
            this.bANN.TabIndex = 5;
            this.bANN.Text = "Wykonaj ANN";
            this.bANN.UseVisualStyleBackColor = true;
            this.bANN.Click += new System.EventHandler(this.bExecuteAlgorthm_Click);
            // 
            // tbAnnPredictedValue
            // 
            this.tbAnnPredictedValue.Location = new System.Drawing.Point(172, 161);
            this.tbAnnPredictedValue.Name = "tbAnnPredictedValue";
            this.tbAnnPredictedValue.Size = new System.Drawing.Size(100, 20);
            this.tbAnnPredictedValue.TabIndex = 6;
            // 
            // tbANNHeatingStart
            // 
            this.tbANNHeatingStart.Location = new System.Drawing.Point(172, 135);
            this.tbANNHeatingStart.Name = "tbANNHeatingStart";
            this.tbANNHeatingStart.Size = new System.Drawing.Size(100, 20);
            this.tbANNHeatingStart.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Uruchomienie ogrzewania:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Przewidziany powrt do domu:";
            // 
            // tbDemandingTemperature
            // 
            this.tbDemandingTemperature.Enabled = false;
            this.tbDemandingTemperature.Location = new System.Drawing.Point(172, 107);
            this.tbDemandingTemperature.Name = "tbDemandingTemperature";
            this.tbDemandingTemperature.Size = new System.Drawing.Size(100, 20);
            this.tbDemandingTemperature.TabIndex = 11;
            this.tbDemandingTemperature.Text = "21 st C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Żądana Temperatura:";
            // 
            // tbRlStartHeating
            // 
            this.tbRlStartHeating.Location = new System.Drawing.Point(291, 135);
            this.tbRlStartHeating.Name = "tbRlStartHeating";
            this.tbRlStartHeating.Size = new System.Drawing.Size(100, 20);
            this.tbRlStartHeating.TabIndex = 16;
            // 
            // tBRlPredictedValue
            // 
            this.tBRlPredictedValue.Location = new System.Drawing.Point(291, 161);
            this.tBRlPredictedValue.Name = "tBRlPredictedValue";
            this.tBRlPredictedValue.Size = new System.Drawing.Size(100, 20);
            this.tBRlPredictedValue.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek",
            "Sobota",
            "Niedziela"});
            this.comboBox1.Location = new System.Drawing.Point(270, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // bImOut
            // 
            this.bImOut.Location = new System.Drawing.Point(12, 8);
            this.bImOut.Name = "bImOut";
            this.bImOut.Size = new System.Drawing.Size(103, 23);
            this.bImOut.TabIndex = 18;
            this.bImOut.Text = "Wychodzę";
            this.bImOut.UseVisualStyleBackColor = true;
            this.bImOut.Click += new System.EventHandler(this.bImOut_Click);
            // 
            // bChangeHeaterState
            // 
            this.bChangeHeaterState.Location = new System.Drawing.Point(12, 42);
            this.bChangeHeaterState.Name = "bChangeHeaterState";
            this.bChangeHeaterState.Size = new System.Drawing.Size(103, 23);
            this.bChangeHeaterState.TabIndex = 19;
            this.bChangeHeaterState.Text = "Zmien stan pieca";
            this.bChangeHeaterState.UseVisualStyleBackColor = true;
            this.bChangeHeaterState.Click += new System.EventHandler(this.bChangeHeaterState_Click);
            // 
            // bRL
            // 
            this.bRL.Location = new System.Drawing.Point(291, 187);
            this.bRL.Name = "bRL";
            this.bRL.Size = new System.Drawing.Size(100, 23);
            this.bRL.TabIndex = 14;
            this.bRL.Text = "Wykonaj RL";
            this.bRL.UseVisualStyleBackColor = true;
            this.bRL.Click += new System.EventHandler(this.bLienearRegression_Click);
            // 
            // bWma
            // 
            this.bWma.Location = new System.Drawing.Point(407, 187);
            this.bWma.Name = "bWma";
            this.bWma.Size = new System.Drawing.Size(100, 23);
            this.bWma.TabIndex = 20;
            this.bWma.Text = "Wykonaj WMA";
            this.bWma.UseVisualStyleBackColor = true;
            this.bWma.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbWma
            // 
            this.tbWma.Location = new System.Drawing.Point(407, 161);
            this.tbWma.Name = "tbWma";
            this.tbWma.Size = new System.Drawing.Size(100, 20);
            this.tbWma.TabIndex = 21;
            // 
            // tbWmaHeatingStart
            // 
            this.tbWmaHeatingStart.Location = new System.Drawing.Point(407, 135);
            this.tbWmaHeatingStart.Name = "tbWmaHeatingStart";
            this.tbWmaHeatingStart.Size = new System.Drawing.Size(100, 20);
            this.tbWmaHeatingStart.TabIndex = 22;
            // 
            // HMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 261);
            this.Controls.Add(this.tbWmaHeatingStart);
            this.Controls.Add(this.tbWma);
            this.Controls.Add(this.bWma);
            this.Controls.Add(this.bChangeHeaterState);
            this.Controls.Add(this.bImOut);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tbRlStartHeating);
            this.Controls.Add(this.tBRlPredictedValue);
            this.Controls.Add(this.bRL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDemandingTemperature);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbANNHeatingStart);
            this.Controls.Add(this.tbAnnPredictedValue);
            this.Controls.Add(this.bANN);
            this.Controls.Add(this.bImHome);
            this.Controls.Add(this.License);
            this.Controls.Add(this.bGetWeather);
            this.Controls.Add(this.textBox1);
            this.Name = "HMA";
            this.Text = "Heat Management Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bGetWeather;
        private System.Windows.Forms.TextBox License;
        private System.Windows.Forms.Button bImHome;
        private System.Windows.Forms.Button bANN;
        private System.Windows.Forms.TextBox tbAnnPredictedValue;
        private System.Windows.Forms.TextBox tbANNHeatingStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDemandingTemperature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRlStartHeating;
        private System.Windows.Forms.TextBox tBRlPredictedValue;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bImOut;
        private System.Windows.Forms.Button bChangeHeaterState;
        private System.Windows.Forms.Button bRL;
        private System.Windows.Forms.Button bWma;
        private System.Windows.Forms.TextBox tbWma;
        private System.Windows.Forms.TextBox tbWmaHeatingStart;
    }
}

