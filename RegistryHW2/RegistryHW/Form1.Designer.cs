﻿namespace RegistryHW
{
    partial class RegTestForm
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
            this.lbHelloWord = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbFont = new System.Windows.Forms.Label();
            this.lbBackgroundColor = new System.Windows.Forms.Label();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.cdBackgroundColor = new System.Windows.Forms.ColorDialog();
            this.btColor = new System.Windows.Forms.Button();
            this.btBackgroundColor = new System.Windows.Forms.Button();
            this.tbFont = new System.Windows.Forms.TextBox();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.rbSaveToXML = new System.Windows.Forms.RadioButton();
            this.rbSaveToRegistry = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHelloWord
            // 
            this.lbHelloWord.AutoSize = true;
            this.lbHelloWord.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbHelloWord.Location = new System.Drawing.Point(13, 13);
            this.lbHelloWord.Name = "lbHelloWord";
            this.lbHelloWord.Size = new System.Drawing.Size(65, 13);
            this.lbHelloWord.TabIndex = 0;
            this.lbHelloWord.Text = "Hello World!";
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(13, 201);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(34, 13);
            this.lbColor.TabIndex = 1;
            this.lbColor.Text = "Color:";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(16, 236);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(54, 13);
            this.lbSize.TabIndex = 2;
            this.lbSize.Text = "Text Size:";
            // 
            // lbFont
            // 
            this.lbFont.AutoSize = true;
            this.lbFont.Location = new System.Drawing.Point(221, 200);
            this.lbFont.Name = "lbFont";
            this.lbFont.Size = new System.Drawing.Size(63, 13);
            this.lbFont.TabIndex = 3;
            this.lbFont.Text = "Font Family:";
            // 
            // lbBackgroundColor
            // 
            this.lbBackgroundColor.AutoSize = true;
            this.lbBackgroundColor.Location = new System.Drawing.Point(224, 235);
            this.lbBackgroundColor.Name = "lbBackgroundColor";
            this.lbBackgroundColor.Size = new System.Drawing.Size(95, 13);
            this.lbBackgroundColor.TabIndex = 4;
            this.lbBackgroundColor.Text = "Background Color:";
            // 
            // btColor
            // 
            this.btColor.Location = new System.Drawing.Point(113, 197);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(75, 23);
            this.btColor.TabIndex = 5;
            this.btColor.Text = "Select";
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // btBackgroundColor
            // 
            this.btBackgroundColor.Location = new System.Drawing.Point(350, 231);
            this.btBackgroundColor.Name = "btBackgroundColor";
            this.btBackgroundColor.Size = new System.Drawing.Size(75, 23);
            this.btBackgroundColor.TabIndex = 5;
            this.btBackgroundColor.Text = "Select";
            this.btBackgroundColor.UseVisualStyleBackColor = true;
            this.btBackgroundColor.Click += new System.EventHandler(this.btBackgroundColor_Click);
            // 
            // tbFont
            // 
            this.tbFont.Location = new System.Drawing.Point(325, 197);
            this.tbFont.Name = "tbFont";
            this.tbFont.Size = new System.Drawing.Size(100, 20);
            this.tbFont.TabIndex = 6;
            // 
            // numUpDown
            // 
            this.numUpDown.Location = new System.Drawing.Point(96, 235);
            this.numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(120, 20);
            this.numUpDown.TabIndex = 7;
            this.numUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // rbSaveToXML
            // 
            this.rbSaveToXML.AutoSize = true;
            this.rbSaveToXML.Location = new System.Drawing.Point(6, 19);
            this.rbSaveToXML.Name = "rbSaveToXML";
            this.rbSaveToXML.Size = new System.Drawing.Size(47, 17);
            this.rbSaveToXML.TabIndex = 8;
            this.rbSaveToXML.TabStop = true;
            this.rbSaveToXML.Text = "XML";
            this.rbSaveToXML.UseVisualStyleBackColor = true;
            // 
            // rbSaveToRegistry
            // 
            this.rbSaveToRegistry.AutoSize = true;
            this.rbSaveToRegistry.Checked = true;
            this.rbSaveToRegistry.Location = new System.Drawing.Point(6, 42);
            this.rbSaveToRegistry.Name = "rbSaveToRegistry";
            this.rbSaveToRegistry.Size = new System.Drawing.Size(63, 17);
            this.rbSaveToRegistry.TabIndex = 8;
            this.rbSaveToRegistry.TabStop = true;
            this.rbSaveToRegistry.Text = "Registry";
            this.rbSaveToRegistry.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSaveToXML);
            this.groupBox1.Controls.Add(this.rbSaveToRegistry);
            this.groupBox1.Location = new System.Drawing.Point(438, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 64);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save to/Load from";
            // 
            // RegTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.tbFont);
            this.Controls.Add(this.btBackgroundColor);
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.lbBackgroundColor);
            this.Controls.Add(this.lbFont);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.lbHelloWord);
            this.Name = "RegTestForm";
            this.Text = "Registry Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegTestForm_FormClosed);
            this.Load += new System.EventHandler(this.RegTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHelloWord;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbFont;
        private System.Windows.Forms.Label lbBackgroundColor;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.ColorDialog cdBackgroundColor;
        private System.Windows.Forms.Button btColor;
        private System.Windows.Forms.Button btBackgroundColor;
        private System.Windows.Forms.TextBox tbFont;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.RadioButton rbSaveToXML;
        private System.Windows.Forms.RadioButton rbSaveToRegistry;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

