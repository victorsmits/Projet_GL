﻿namespace interface_Magasinier
{
    partial class SupplierWizard
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.supplierGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StreetTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.RefTextBox = new System.Windows.Forms.TextBox();
            this.supplierReference = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.StreetLabel = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.NumbertextBox = new System.Windows.Forms.TextBox();
            this.finishButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.CityBox = new System.Windows.Forms.TextBox();
            this.addzip = new System.Windows.Forms.Button();
            this.ZipLabel = new System.Windows.Forms.Label();
            this.ZipBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CityList = new System.Windows.Forms.ListBox();
            this.ZipList = new System.Windows.Forms.ListBox();
            this.IdZipList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ZipTextBox = new System.Windows.Forms.TextBox();
            this.supplierGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierGroupBox
            // 
            this.supplierGroupBox.Controls.Add(this.panel2);
            this.supplierGroupBox.Controls.Add(this.label7);
            this.supplierGroupBox.Controls.Add(this.panel1);
            this.supplierGroupBox.Controls.Add(this.label5);
            this.supplierGroupBox.Controls.Add(this.label4);
            this.supplierGroupBox.Controls.Add(this.label3);
            this.supplierGroupBox.Controls.Add(this.IdLabel);
            this.supplierGroupBox.Controls.Add(this.label1);
            this.supplierGroupBox.Controls.Add(this.CityList);
            this.supplierGroupBox.Controls.Add(this.ZipList);
            this.supplierGroupBox.Controls.Add(this.IdZipList);
            this.supplierGroupBox.Location = new System.Drawing.Point(3, 3);
            this.supplierGroupBox.Name = "supplierGroupBox";
            this.supplierGroupBox.Size = new System.Drawing.Size(523, 598);
            this.supplierGroupBox.TabIndex = 33;
            this.supplierGroupBox.TabStop = false;
            this.supplierGroupBox.Text = "Supplier";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.ZipTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.StreetTextBox);
            this.panel2.Controls.Add(this.NameLabel);
            this.panel2.Controls.Add(this.RefTextBox);
            this.panel2.Controls.Add(this.supplierReference);
            this.panel2.Controls.Add(this.NameTextBox);
            this.panel2.Controls.Add(this.StreetLabel);
            this.panel2.Controls.Add(this.NumberLabel);
            this.panel2.Controls.Add(this.NumbertextBox);
            this.panel2.Controls.Add(this.finishButton);
            this.panel2.Location = new System.Drawing.Point(25, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 188);
            this.panel2.TabIndex = 47;
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.Location = new System.Drawing.Point(120, 69);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(100, 20);
            this.StreetTextBox.TabIndex = 35;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(13, 43);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 13);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Name :";
            // 
            // RefTextBox
            // 
            this.RefTextBox.Location = new System.Drawing.Point(120, 12);
            this.RefTextBox.Name = "RefTextBox";
            this.RefTextBox.Size = new System.Drawing.Size(100, 20);
            this.RefTextBox.TabIndex = 29;
            // 
            // supplierReference
            // 
            this.supplierReference.AutoSize = true;
            this.supplierReference.Location = new System.Drawing.Point(13, 15);
            this.supplierReference.Name = "supplierReference";
            this.supplierReference.Size = new System.Drawing.Size(63, 13);
            this.supplierReference.TabIndex = 3;
            this.supplierReference.Text = "Reference :";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(120, 40);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 32;
            // 
            // StreetLabel
            // 
            this.StreetLabel.AutoSize = true;
            this.StreetLabel.Location = new System.Drawing.Point(13, 72);
            this.StreetLabel.Name = "StreetLabel";
            this.StreetLabel.Size = new System.Drawing.Size(41, 13);
            this.StreetLabel.TabIndex = 33;
            this.StreetLabel.Text = "Street :";
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(13, 105);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(50, 13);
            this.NumberLabel.TabIndex = 34;
            this.NumberLabel.Text = "Number :";
            // 
            // NumbertextBox
            // 
            this.NumbertextBox.Location = new System.Drawing.Point(120, 98);
            this.NumbertextBox.Name = "NumbertextBox";
            this.NumbertextBox.Size = new System.Drawing.Size(100, 20);
            this.NumbertextBox.TabIndex = 36;
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(11, 162);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(143, 23);
            this.finishButton.TabIndex = 31;
            this.finishButton.Text = "Add the new Supplier";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Fill the text box and select the zip code in the list to add a new supplier";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CityBox);
            this.panel1.Controls.Add(this.addzip);
            this.panel1.Controls.Add(this.ZipLabel);
            this.panel1.Controls.Add(this.ZipBox);
            this.panel1.Location = new System.Drawing.Point(25, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 121);
            this.panel1.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "City :";
            // 
            // CityBox
            // 
            this.CityBox.Location = new System.Drawing.Point(92, 41);
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(100, 20);
            this.CityBox.TabIndex = 38;
            // 
            // addzip
            // 
            this.addzip.Location = new System.Drawing.Point(11, 80);
            this.addzip.Name = "addzip";
            this.addzip.Size = new System.Drawing.Size(109, 23);
            this.addzip.TabIndex = 0;
            this.addzip.Text = "add the zip code";
            this.addzip.UseVisualStyleBackColor = true;
            this.addzip.Click += new System.EventHandler(this.addzip_Click);
            // 
            // ZipLabel
            // 
            this.ZipLabel.AutoSize = true;
            this.ZipLabel.Location = new System.Drawing.Point(16, 18);
            this.ZipLabel.Name = "ZipLabel";
            this.ZipLabel.Size = new System.Drawing.Size(56, 13);
            this.ZipLabel.TabIndex = 1;
            this.ZipLabel.Text = "Zip Code :";
            // 
            // ZipBox
            // 
            this.ZipBox.Location = new System.Drawing.Point(92, 15);
            this.ZipBox.Name = "ZipBox";
            this.ZipBox.Size = new System.Drawing.Size(100, 20);
            this.ZipBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Otherwise add it to the llist by filling this textBox";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "City :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Zip code :";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(48, 61);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(19, 13);
            this.IdLabel.TabIndex = 42;
            this.IdLabel.Text = "Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "If the zip code is in the list select it to fill the textBox in the wizard";
            // 
            // CityList
            // 
            this.CityList.FormattingEnabled = true;
            this.CityList.Location = new System.Drawing.Point(341, 77);
            this.CityList.Name = "CityList";
            this.CityList.Size = new System.Drawing.Size(120, 95);
            this.CityList.TabIndex = 40;
            this.CityList.Click += new System.EventHandler(this.listBox_Click);
            // 
            // ZipList
            // 
            this.ZipList.FormattingEnabled = true;
            this.ZipList.Location = new System.Drawing.Point(192, 77);
            this.ZipList.Name = "ZipList";
            this.ZipList.Size = new System.Drawing.Size(120, 95);
            this.ZipList.TabIndex = 39;
            this.ZipList.Click += new System.EventHandler(this.listBox_Click);
            // 
            // IdZipList
            // 
            this.IdZipList.FormattingEnabled = true;
            this.IdZipList.Location = new System.Drawing.Point(36, 77);
            this.IdZipList.Name = "IdZipList";
            this.IdZipList.Size = new System.Drawing.Size(120, 95);
            this.IdZipList.TabIndex = 38;
            this.IdZipList.Click += new System.EventHandler(this.listBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Zip Code :";
            // 
            // ZipTextBox
            // 
            this.ZipTextBox.Location = new System.Drawing.Point(120, 124);
            this.ZipTextBox.Name = "ZipTextBox";
            this.ZipTextBox.Size = new System.Drawing.Size(100, 20);
            this.ZipTextBox.TabIndex = 40;
            // 
            // SupplierWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.supplierGroupBox);
            this.Name = "SupplierWizard";
            this.Size = new System.Drawing.Size(601, 657);
            this.Load += new System.EventHandler(this.LoadList);
            this.supplierGroupBox.ResumeLayout(false);
            this.supplierGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox supplierGroupBox;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label supplierReference;
        private System.Windows.Forms.Label ZipLabel;
        private System.Windows.Forms.TextBox RefTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.Label StreetLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox NumbertextBox;
        private System.Windows.Forms.TextBox StreetTextBox;
        private System.Windows.Forms.TextBox ZipBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CityList;
        private System.Windows.Forms.ListBox ZipList;
        private System.Windows.Forms.ListBox IdZipList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CityBox;
        private System.Windows.Forms.Button addzip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox ZipTextBox;
        private System.Windows.Forms.Label label2;
    }
}
