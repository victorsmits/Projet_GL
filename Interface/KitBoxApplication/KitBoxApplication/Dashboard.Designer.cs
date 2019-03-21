﻿namespace KitBoxApplication
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.SidePanel = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonCart = new System.Windows.Forms.Button();
            this.buttonCreation = new System.Windows.Forms.Button();
            this.buttonDash = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonHome = new System.Windows.Forms.Button();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.KitBoxHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxSubscribe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cartPage1 = new KitBoxApplication.CartPage();
            this.homePage3 = new KitBoxApplication.HomePage();
            this.creation2 = new KitBoxApplication.Creation();
            this.SidePanel.SuspendLayout();
            this.LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SidePanel.Controls.Add(this.buttonAbout);
            this.SidePanel.Controls.Add(this.buttonCart);
            this.SidePanel.Controls.Add(this.buttonCreation);
            this.SidePanel.Controls.Add(this.buttonDash);
            this.SidePanel.Controls.Add(this.panel2);
            this.SidePanel.Controls.Add(this.ButtonHome);
            this.SidePanel.Controls.Add(this.LogoPanel);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 0);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(1);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(157, 478);
            this.SidePanel.TabIndex = 0;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.ForeColor = System.Drawing.Color.White;
            this.buttonAbout.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbout.Image")));
            this.buttonAbout.Location = new System.Drawing.Point(0, 244);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(1);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(157, 63);
            this.buttonAbout.TabIndex = 8;
            this.buttonAbout.Text = "About Us";
            this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAbout.UseVisualStyleBackColor = true;
            // 
            // buttonCart
            // 
            this.buttonCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCart.FlatAppearance.BorderSize = 0;
            this.buttonCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCart.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCart.ForeColor = System.Drawing.Color.White;
            this.buttonCart.Image = ((System.Drawing.Image)(resources.GetObject("buttonCart.Image")));
            this.buttonCart.Location = new System.Drawing.Point(0, 181);
            this.buttonCart.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCart.Name = "buttonCart";
            this.buttonCart.Size = new System.Drawing.Size(157, 63);
            this.buttonCart.TabIndex = 7;
            this.buttonCart.Text = "Cart";
            this.buttonCart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCart.UseVisualStyleBackColor = true;
            this.buttonCart.Click += new System.EventHandler(this.buttonCart_Click);
            // 
            // buttonCreation
            // 
            this.buttonCreation.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreation.FlatAppearance.BorderSize = 0;
            this.buttonCreation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreation.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreation.ForeColor = System.Drawing.Color.White;
            this.buttonCreation.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreation.Image")));
            this.buttonCreation.Location = new System.Drawing.Point(0, 118);
            this.buttonCreation.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCreation.Name = "buttonCreation";
            this.buttonCreation.Size = new System.Drawing.Size(157, 63);
            this.buttonCreation.TabIndex = 6;
            this.buttonCreation.Text = "Creation";
            this.buttonCreation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCreation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreation.UseVisualStyleBackColor = true;
            this.buttonCreation.Click += new System.EventHandler(this.ButtonCreation_Click);
            // 
            // buttonDash
            // 
            this.buttonDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDash.FlatAppearance.BorderSize = 0;
            this.buttonDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDash.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDash.ForeColor = System.Drawing.Color.White;
            this.buttonDash.Image = ((System.Drawing.Image)(resources.GetObject("buttonDash.Image")));
            this.buttonDash.Location = new System.Drawing.Point(0, 55);
            this.buttonDash.Margin = new System.Windows.Forms.Padding(1);
            this.buttonDash.Name = "buttonDash";
            this.buttonDash.Size = new System.Drawing.Size(157, 63);
            this.buttonDash.TabIndex = 1;
            this.buttonDash.Text = "Dashboard";
            this.buttonDash.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDash.UseVisualStyleBackColor = true;
            this.buttonDash.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(157, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 427);
            this.panel2.TabIndex = 5;
            // 
            // ButtonHome
            // 
            this.ButtonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ButtonHome.FlatAppearance.BorderSize = 0;
            this.ButtonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonHome.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonHome.Location = new System.Drawing.Point(0, 55);
            this.ButtonHome.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonHome.Name = "ButtonHome";
            this.ButtonHome.Size = new System.Drawing.Size(157, 46);
            this.ButtonHome.TabIndex = 1;
            this.ButtonHome.Text = "Home";
            this.ButtonHome.UseVisualStyleBackColor = false;
            this.ButtonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LogoPanel.Controls.Add(this.pictureBox1);
            this.LogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoPanel.Location = new System.Drawing.Point(0, 0);
            this.LogoPanel.Margin = new System.Windows.Forms.Padding(1);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(157, 55);
            this.LogoPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 55);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.HeaderPanel.Controls.Add(this.KitBoxHeader);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(157, 0);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(1);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1366, 55);
            this.HeaderPanel.TabIndex = 1;
            // 
            // KitBoxHeader
            // 
            this.KitBoxHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.KitBoxHeader.AutoSize = true;
            this.KitBoxHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.KitBoxHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KitBoxHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(97)))), ((int)(((byte)(24)))));
            this.KitBoxHeader.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.KitBoxHeader.Location = new System.Drawing.Point(615, 14);
            this.KitBoxHeader.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.KitBoxHeader.Name = "KitBoxHeader";
            this.KitBoxHeader.Size = new System.Drawing.Size(88, 29);
            this.KitBoxHeader.TabIndex = 0;
            this.KitBoxHeader.Text = "KitBox";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(97)))), ((int)(((byte)(24)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBoxSubscribe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(157, 435);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 43);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(97)))), ((int)(((byte)(24)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(97)))), ((int)(((byte)(24)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(75)))), ((int)(((byte)(19)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(852, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBoxSubscribe
            // 
            this.textBoxSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxSubscribe.Location = new System.Drawing.Point(694, 15);
            this.textBoxSubscribe.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxSubscribe.Name = "textBoxSubscribe";
            this.textBoxSubscribe.Size = new System.Drawing.Size(151, 20);
            this.textBoxSubscribe.TabIndex = 1;
            this.textBoxSubscribe.Text = "example@mail.com";
            this.textBoxSubscribe.Click += new System.EventHandler(this.PlaceHolderText);
            this.textBoxSubscribe.MouseLeave += new System.EventHandler(this.PlaceHolderTextleaving);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(520, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subscribe NewsLetter";
            // 
            // cartPage1
            // 
            this.cartPage1.AutoSize = true;
            this.cartPage1.Location = new System.Drawing.Point(372, 57);
            this.cartPage1.Margin = new System.Windows.Forms.Padding(1);
            this.cartPage1.MaximumSize = new System.Drawing.Size(1000, 500);
            this.cartPage1.MinimumSize = new System.Drawing.Size(839, 392);
            this.cartPage1.Name = "cartPage1";
            this.cartPage1.Size = new System.Drawing.Size(839, 442);
            this.cartPage1.TabIndex = 7;
            this.cartPage1.Visible = false;
            // 
            // homePage3
            // 
            this.homePage3.Dock = System.Windows.Forms.DockStyle.Top;
            this.homePage3.Location = new System.Drawing.Point(157, 744);
            this.homePage3.Margin = new System.Windows.Forms.Padding(0);
            this.homePage3.Name = "homePage3";
            this.homePage3.Size = new System.Drawing.Size(1366, 689);
            this.homePage3.TabIndex = 6;
            // 
            // creation2
            // 
            this.creation2.Dock = System.Windows.Forms.DockStyle.Top;
            this.creation2.Location = new System.Drawing.Point(157, 55);
            this.creation2.Margin = new System.Windows.Forms.Padding(0);
            this.creation2.Name = "creation2";
            this.creation2.Size = new System.Drawing.Size(1366, 689);
            this.creation2.TabIndex = 5;
            this.creation2.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1523, 478);
            this.Controls.Add(this.cartPage1);
            this.Controls.Add(this.homePage3);
            this.Controls.Add(this.creation2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.SidePanel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(1546, 847);
            this.MinimumSize = new System.Drawing.Size(777, 439);
            this.Name = "Dashboard";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SidePanel.ResumeLayout(false);
            this.LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button ButtonHome;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label KitBoxHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSubscribe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;       
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonCart;
        private System.Windows.Forms.Button buttonCreation;
        private System.Windows.Forms.Button buttonDash;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;        
        private Creation creation2;
        private HomePage homePage3;
        private CartPage cartPage1;
    }
}

