using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodMatch
{
    partial class GoodMatch
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
            this.textBoxC2 = new System.Windows.Forms.TextBox();
            this.textBoxC1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelManualResult = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonManual = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCSV = new System.Windows.Forms.TextBox();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.labelCSVResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxC2
            // 
            this.textBoxC2.Location = new System.Drawing.Point(84, 56);
            this.textBoxC2.Name = "textBoxC2";
            this.textBoxC2.Size = new System.Drawing.Size(100, 20);
            this.textBoxC2.TabIndex = 1;
            // 
            // textBoxC1
            // 
            this.textBoxC1.Location = new System.Drawing.Point(84, 33);
            this.textBoxC1.Name = "textBoxC1";
            this.textBoxC1.Size = new System.Drawing.Size(100, 20);
            this.textBoxC1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manual Pairing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Candidate 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Candidate2:";
            // 
            // labelManualResult
            // 
            this.labelManualResult.AutoSize = true;
            this.labelManualResult.Location = new System.Drawing.Point(15, 126);
            this.labelManualResult.Name = "labelManualResult";
            this.labelManualResult.Size = new System.Drawing.Size(256, 13);
            this.labelManualResult.TabIndex = 5;
            this.labelManualResult.Text = "Please input candidates then click the button above.";
            // 
            // buttonManual
            // 
            this.buttonManual.Location = new System.Drawing.Point(15, 87);
            this.buttonManual.Name = "buttonManual";
            this.buttonManual.Size = new System.Drawing.Size(100, 23);
            this.buttonManual.TabIndex = 2;
            this.buttonManual.Text = "Calculate Match";
            this.buttonManual.UseVisualStyleBackColor = true;
            this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "CSV Pairing";
            // 
            // textBoxCSV
            // 
            this.textBoxCSV.Location = new System.Drawing.Point(84, 187);
            this.textBoxCSV.Name = "textBoxCSV";
            this.textBoxCSV.Size = new System.Drawing.Size(100, 20);
            this.textBoxCSV.TabIndex = 3;
            this.textBoxCSV.Text = "data.csv";
            // 
            // buttonCSV
            // 
            this.buttonCSV.Location = new System.Drawing.Point(15, 247);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(100, 23);
            this.buttonCSV.TabIndex = 4;
            this.buttonCSV.Text = "Compile Results";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Click += new System.EventHandler(this.buttonCSV_Click);
            // 
            // labelCSVResult
            // 
            this.labelCSVResult.AutoSize = true;
            this.labelCSVResult.Location = new System.Drawing.Point(15, 284);
            this.labelCSVResult.Name = "labelCSVResult";
            this.labelCSVResult.Size = new System.Drawing.Size(78, 13);
            this.labelCSVResult.TabIndex = 10;
            this.labelCSVResult.Text = "Process Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "CSV Path:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ouput Path:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(84, 210);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(100, 20);
            this.textBoxOutput.TabIndex = 14;
            this.textBoxOutput.Text = "output.txt";
            // 
            // GoodMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 310);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCSVResult);
            this.Controls.Add(this.buttonCSV);
            this.Controls.Add(this.textBoxCSV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonManual);
            this.Controls.Add(this.labelManualResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxC1);
            this.Controls.Add(this.textBoxC2);
            this.Name = "GoodMatch";
            this.Text = "GoodMatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxC2;
        private System.Windows.Forms.TextBox textBoxC1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelManualResult;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonManual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCSV;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.Label labelCSVResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}