namespace TransportationCostSimulator
{
    partial class Form1
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
            this.SetCurrentLocation = new System.Windows.Forms.Button();
            this.LblCurrentLocation = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCurrenLocation = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.BtnSetDestination = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstAdvisor = new System.Windows.Forms.ListBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetCurrentLocation
            // 
            this.SetCurrentLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetCurrentLocation.Location = new System.Drawing.Point(18, 17);
            this.SetCurrentLocation.Name = "SetCurrentLocation";
            this.SetCurrentLocation.Size = new System.Drawing.Size(98, 64);
            this.SetCurrentLocation.TabIndex = 0;
            this.SetCurrentLocation.Text = "Set Current Location";
            this.SetCurrentLocation.UseVisualStyleBackColor = true;
            this.SetCurrentLocation.Click += new System.EventHandler(this.SetCurrentLocation_Click);
            // 
            // LblCurrentLocation
            // 
            this.LblCurrentLocation.AutoSize = true;
            this.LblCurrentLocation.CausesValidation = false;
            this.LblCurrentLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentLocation.Location = new System.Drawing.Point(122, 36);
            this.LblCurrentLocation.Name = "LblCurrentLocation";
            this.LblCurrentLocation.Size = new System.Drawing.Size(113, 17);
            this.LblCurrentLocation.TabIndex = 2;
            this.LblCurrentLocation.Text = "Current Location";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.txtCurrenLocation);
            this.panel3.Controls.Add(this.SetCurrentLocation);
            this.panel3.Controls.Add(this.LblCurrentLocation);
            this.panel3.Location = new System.Drawing.Point(12, 609);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 133);
            this.panel3.TabIndex = 5;
            // 
            // txtCurrenLocation
            // 
            this.txtCurrenLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrenLocation.Location = new System.Drawing.Point(124, 56);
            this.txtCurrenLocation.Name = "txtCurrenLocation";
            this.txtCurrenLocation.Size = new System.Drawing.Size(170, 23);
            this.txtCurrenLocation.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel4.Controls.Add(this.txtDestination);
            this.panel4.Controls.Add(this.BtnSetDestination);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(328, 609);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 133);
            this.panel4.TabIndex = 6;
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(124, 56);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(166, 23);
            this.txtDestination.TabIndex = 3;
            // 
            // BtnSetDestination
            // 
            this.BtnSetDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSetDestination.Location = new System.Drawing.Point(18, 17);
            this.BtnSetDestination.Name = "BtnSetDestination";
            this.BtnSetDestination.Size = new System.Drawing.Size(98, 64);
            this.BtnSetDestination.TabIndex = 0;
            this.BtnSetDestination.Text = "Set Destination";
            this.BtnSetDestination.UseVisualStyleBackColor = true;
            this.BtnSetDestination.Click += new System.EventHandler(this.BtnSetDestination_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selection";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.lstAdvisor);
            this.panel2.Location = new System.Drawing.Point(644, 609);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 133);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = global::TransportationCostSimulator.Properties.Resources.Daegu;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(60, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 591);
            this.panel1.TabIndex = 3;
            // 
            // lstAdvisor
            // 
            this.lstAdvisor.FormattingEnabled = true;
            this.lstAdvisor.Location = new System.Drawing.Point(3, 6);
            this.lstAdvisor.Name = "lstAdvisor";
            this.lstAdvisor.Size = new System.Drawing.Size(301, 121);
            this.lstAdvisor.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(966, 754);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SetCurrentLocation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblCurrentLocation;
        private System.Windows.Forms.TextBox txtCurrenLocation;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button BtnSetDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstAdvisor;
    }
}

