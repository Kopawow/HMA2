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
            this.bExecuteAlgorthm = new System.Windows.Forms.Button();
            this.tbPredictedValue = new System.Windows.Forms.TextBox();
            this.tbHeatingStart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentTempInHome = new System.Windows.Forms.TextBox();
            this.tbDemandingTemperature = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAnimaStartHeating = new System.Windows.Forms.TextBox();
            this.tBAnimaPredictedValue = new System.Windows.Forms.TextBox();
            this.bAnima = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // bGetWeather
            // 
            this.bGetWeather.Location = new System.Drawing.Point(12, 38);
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
            this.License.Size = new System.Drawing.Size(404, 20);
            this.License.TabIndex = 2;
            this.License.Text = "Temperatura pobrana z OpenWeatherMap";
            // 
            // bImHome
            // 
            this.bImHome.Location = new System.Drawing.Point(349, 8);
            this.bImHome.Name = "bImHome";
            this.bImHome.Size = new System.Drawing.Size(67, 53);
            this.bImHome.TabIndex = 3;
            this.bImHome.Text = "Wróciłem";
            this.bImHome.UseVisualStyleBackColor = true;
            this.bImHome.Click += new System.EventHandler(this.bImHome_Click);
            // 
            // bExecuteAlgorthm
            // 
            this.bExecuteAlgorthm.Location = new System.Drawing.Point(172, 187);
            this.bExecuteAlgorthm.Name = "bExecuteAlgorthm";
            this.bExecuteAlgorthm.Size = new System.Drawing.Size(100, 23);
            this.bExecuteAlgorthm.TabIndex = 5;
            this.bExecuteAlgorthm.Text = "Wykonaj ANN";
            this.bExecuteAlgorthm.UseVisualStyleBackColor = true;
            this.bExecuteAlgorthm.Click += new System.EventHandler(this.bExecuteAlgorthm_Click);
            // 
            // tbPredictedValue
            // 
            this.tbPredictedValue.Location = new System.Drawing.Point(172, 161);
            this.tbPredictedValue.Name = "tbPredictedValue";
            this.tbPredictedValue.Size = new System.Drawing.Size(100, 20);
            this.tbPredictedValue.TabIndex = 6;
            // 
            // tbHeatingStart
            // 
            this.tbHeatingStart.Location = new System.Drawing.Point(172, 135);
            this.tbHeatingStart.Name = "tbHeatingStart";
            this.tbHeatingStart.Size = new System.Drawing.Size(100, 20);
            this.tbHeatingStart.TabIndex = 7;
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
            // tbCurrentTempInHome
            // 
            this.tbCurrentTempInHome.Location = new System.Drawing.Point(172, 81);
            this.tbCurrentTempInHome.Name = "tbCurrentTempInHome";
            this.tbCurrentTempInHome.Size = new System.Drawing.Size(100, 20);
            this.tbCurrentTempInHome.TabIndex = 10;
            // 
            // tbDemandingTemperature
            // 
            this.tbDemandingTemperature.Location = new System.Drawing.Point(172, 107);
            this.tbDemandingTemperature.Name = "tbDemandingTemperature";
            this.tbDemandingTemperature.Size = new System.Drawing.Size(100, 20);
            this.tbDemandingTemperature.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Aktualna Temperatura:";
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
            // tbAnimaStartHeating
            // 
            this.tbAnimaStartHeating.Location = new System.Drawing.Point(291, 135);
            this.tbAnimaStartHeating.Name = "tbAnimaStartHeating";
            this.tbAnimaStartHeating.Size = new System.Drawing.Size(100, 20);
            this.tbAnimaStartHeating.TabIndex = 16;
            // 
            // tBAnimaPredictedValue
            // 
            this.tBAnimaPredictedValue.Location = new System.Drawing.Point(291, 161);
            this.tBAnimaPredictedValue.Name = "tBAnimaPredictedValue";
            this.tBAnimaPredictedValue.Size = new System.Drawing.Size(100, 20);
            this.tBAnimaPredictedValue.TabIndex = 15;
            // 
            // bAnima
            // 
            this.bAnima.Location = new System.Drawing.Point(291, 187);
            this.bAnima.Name = "bAnima";
            this.bAnima.Size = new System.Drawing.Size(100, 23);
            this.bAnima.TabIndex = 14;
            this.bAnima.Text = "Wykonaj ANIMA";
            this.bAnima.UseVisualStyleBackColor = true;
            this.bAnima.Click += new System.EventHandler(this.bAnima_Click);
            // 
            // HMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 261);
            this.Controls.Add(this.tbAnimaStartHeating);
            this.Controls.Add(this.tBAnimaPredictedValue);
            this.Controls.Add(this.bAnima);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDemandingTemperature);
            this.Controls.Add(this.tbCurrentTempInHome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHeatingStart);
            this.Controls.Add(this.tbPredictedValue);
            this.Controls.Add(this.bExecuteAlgorthm);
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
        private System.Windows.Forms.Button bExecuteAlgorthm;
        private System.Windows.Forms.TextBox tbPredictedValue;
        private System.Windows.Forms.TextBox tbHeatingStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentTempInHome;
        private System.Windows.Forms.TextBox tbDemandingTemperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAnimaStartHeating;
        private System.Windows.Forms.TextBox tBAnimaPredictedValue;
        private System.Windows.Forms.Button bAnima;
    }
}

