﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KitBoxSourceCode;
using Newtonsoft.Json.Linq;
using System.IO;

namespace KitBoxApplication
{
    public partial class CartPage : UserControl
    {

        private static Cart cart;
        private JObject jsonCart;

        public static Cart Cart { get => cart; set => cart = value; }

        public CartPage()
        {
            InitializeComponent();

            // enables design of tabheader
            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabPageBox1_DrawItem);

            tabControl.ItemSize = new Size(70, 30);
        }

        public void Load_Json()
        {
            try
            {
                jsonCart = cart.ShowCart();
                if (cart != null)
                {
                    comfirmCartButton.Visible = true;
                    totalLabel.Visible = true;
                    costLabel.Visible = true;
                }
                Create_Layout();
            }
            catch(Newtonsoft.Json.JsonReaderException e)
            {
                tabControl.TabPages.Clear();
                TabPage emptyCart = new TabPage(Name = "Empty");
                emptyCart.BackColor = Color.FromArgb(41, 44, 51);
                tabControl.TabPages.Add(emptyCart);
                comfirmCartButton.Visible = false;
                costLabel.Visible = false;
                totalLabel.Visible = false;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            //Get the index of the cabinet from parent of the button
            Control button = (Control)sender;
            Control tabPage = button.Parent;
            string tabName = tabPage.Text;
            string[] list = tabName.Split(' ');
            int index = (int.Parse(list[1])-1);
            cart.DelCabinet(index);
            MessageBox.Show("L'armoire a été supprimé");
            Load_Json();
        }

        // function to get relative path to a file
        private string GetRelativePath(string directory)
        {
            char[] test1 = "\\".ToCharArray();
            string[] test = directory.Split(test1);
            string root = test[0];
            string user = test[1];
            string namePC = test[2];
            string dir = root + "\\" + user + "\\" + namePC + "\\";
            return dir;
        }

        private void Create_Layout()
        {

            if (jsonCart.ToString() == "{}")
            {
                tabControl.TabPages.Clear();
                TabPage emptyCart = new TabPage(Name = "Empty");
                emptyCart.BackColor = Color.FromArgb(41, 44, 51);
                tabControl.TabPages.Add(emptyCart);
                comfirmCartButton.Visible = false;
                costLabel.Visible = false;
                totalLabel.Visible = false;
            }
            else
            {
                tabControl.TabPages.Clear(); //Clear the tabs

                //For every cabinet of the json
                for (int cabinetCount = 0; cabinetCount < jsonCart.Count - 1; cabinetCount++)
                {
                    bool availability = false;

                    Font font = new Font("Century Gothic", 9, FontStyle.Bold);
                    //Get the elements of the cabinet
                    JObject cabinetContains = jsonCart["Cabinet " + cabinetCount.ToString()].Value<JObject>();
                    //Add a tab for the cabinet
                    TabPage addedCabinePage = new TabPage(Name = "Cabine " + (cabinetCount + 1).ToString());
                    addedCabinePage.BackColor = Color.FromArgb(41, 44, 51);
                    tabControl.TabPages.Add(addedCabinePage);
                    int floorCount = 0;

                    //Add a delete button
                    Button deleteButton = new Button();
                    Image Beating_Cabinet = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\images\Beating_Cabinet.png");
                    deleteButton.ImageAlign = ContentAlignment.MiddleCenter;
                    deleteButton.BackgroundImageLayout = ImageLayout.Center;
                    deleteButton.BackgroundImage = Beating_Cabinet;
                    //Color DarkRed = Color.FromName("DarkRed");
                    //deleteButton.BackColor = DarkRed;
                    //Color Black = Color.FromName("Black");
                    //deleteButton.ForeColor = Black;
                    //deleteButton.Text = "Delete cabinet";
                    deleteButton.Click += DeleteButton_Clicked;
                    deleteButton.Location = new Point(981, 15);
                    deleteButton.Size = new Size(75, 61);
                    addedCabinePage.Controls.Add(deleteButton);


                    //Generates label for angles
                    JObject angle = cabinetContains["Angle"].Value<JObject>();
                    int angleLength = angle["Length"].Value<int>();
                    string angleColor = angle["Color"].Value<string>();
                    int angleQty = angle["Quantity"].Value<int>();

                    Label angleLabel = new Label();
                    angleLabel.AutoSize = true;
                    angleLabel.Text = "\nAngle : ";
                    angleLabel.Location = new Point(30, 5);

                    Label angleFeatLabel = new Label();
                    angleFeatLabel.AutoSize = true;
                    angleFeatLabel.Text = String.Format("\nLength: {0}cm\nColor : {1}\nQuantity: {2}\n", angleLength.ToString(), angleColor, angleQty.ToString());
                    angleFeatLabel.Location = new Point(110, 5);

                    angleLabel.Font = font;
                    angleFeatLabel.Font = font;
                    int angleLabelLength = angleLabel.Width;

                    addedCabinePage.Controls.Add(angleLabel);
                    addedCabinePage.Controls.Add(angleFeatLabel);

                    int labelLength = 15;

                    string floorColor1 = "blanc";
                    string floorColor2 = "blanc";
                    string floorColor3 = "blanc";
                    string floorColor4 = "blanc";
                    string floorColor5 = "blanc";
                    string floorColor6 = "blanc";
                    string floorColor7 = "blanc";
                    string doorMaterial1 = "NoDoor";
                    string doorMaterial2 = "NoDoor";
                    string doorMaterial3 = "NoDoor";
                    string doorMaterial4 = "NoDoor";
                    string doorMaterial5 = "NoDoor";
                    string doorMaterial6 = "NoDoor";
                    string doorMaterial7 = "NoDoor";

                    for (floorCount = 0; floorCount < cabinetContains.Count - 2; floorCount++)
                    {
                        labelLength = 15;
                        JObject floor = cabinetContains["Floor " + floorCount.ToString()].Value<JObject>();
                        //Check if parts are available
                        JObject panel1 = floor["Panel 1"].Value<JObject>();
                        JObject panel2 = floor["Panel 2"].Value<JObject>();
                        JObject panel3 = floor["Panel 3"].Value<JObject>();
                        JObject cleat = floor["Cleat"].Value<JObject>();
                        JObject beam1 = floor["Beam 1"].Value<JObject>();
                        JObject beam2 = floor["Beam 2"].Value<JObject>();
                        JObject doorBeam = floor["DoorBeam"].Value<JObject>();

                        int panel1Qty = panel1["Qty"].Value<int>();
                        int panel2Qty = panel2["Qty"].Value<int>();
                        int panel3Qty = panel3["Qty"].Value<int>();
                        int cleatQty = cleat["Qty"].Value<int>();
                        int beam1Qty = beam1["Qty"].Value<int>();
                        int beam2Qty = beam2["Qty"].Value<int>();
                        int doorBeamQty = doorBeam["Qty"].Value<int>();

                        int panel1Stk = panel1["Remaining Stock"].Value<int>();
                        int panel2Stk = panel2["Remaining Stock"].Value<int>();
                        int panel3Stk = panel3["Remaining Stock"].Value<int>();
                        int cleatStk = cleat["Remaining Stock"].Value<int>();
                        int beam1Stk = beam1["Remaining Stock"].Value<int>();
                        int beam2Stk = beam2["Remaining Stock"].Value<int>();
                        int doorBeamStk = doorBeam["Remaining Stock"].Value<int>();

                        bool panel1Avail = panel1Stk >= panel1Qty;
                        bool panel2Avail = panel2Stk >= panel2Qty;
                        bool panel3Avail = panel3Stk >= panel3Qty;
                        bool cleatAvail = cleatStk >= cleatQty;
                        bool beam1Avail = beam1Stk >= beam1Qty;
                        bool beam2Avail = beam2Stk >= beam2Qty;
                        bool doorBeamAvail = doorBeamStk >= doorBeamQty;


                        if (panel1Avail && panel2Avail && panel3Avail && cleatAvail && beam1Avail && beam2Avail && doorBeamAvail)
                        {
                            availability = true;
                        }

                        //Creating a GroupBox for a box
                        GroupBox floorGroup = new GroupBox();
                        floorGroup.Text = "Box " + (floorCount + 1).ToString();
                        floorGroup.AutoSize = true;
                        floorGroup.Font = font;
                        Color color = Color.White;
                        floorGroup.ForeColor = color;
                        floorGroup.Location = new Point(30, 80 + floorCount * 130);
                        addedCabinePage.Controls.Add(floorGroup);

                        //Generates label for dimension
                        string floorColor = "";
                        int HEIGHT = 4;
                        int LENGTH = 0;
                        int DEPTH = 0;
                        Label boxDimension = new Label();
                        Label boxColor = new Label();
                        boxDimension.AutoSize = true;
                        boxColor.AutoSize = true;

                        for (int numberOfLabel = 0; numberOfLabel < 3; numberOfLabel++)
                        {
                            JObject floorPanel = floor["Panel " + (numberOfLabel + 1).ToString()].Value<JObject>();
                            floorColor = floorPanel["Coleur"].Value<string>();
                            int height = floorPanel["Height"].Value<int>();
                            int length = floorPanel["Length"].Value<int>();
                            int panelQty = floorPanel["Qty"].Value<int>();

                            if (numberOfLabel == 0)
                            {
                                HEIGHT += height;
                                LENGTH += length;
                            }
                            if (numberOfLabel == 1)
                            {
                                DEPTH += length;
                            }
                            if (numberOfLabel == 2)
                            {
                                boxColor.Text = String.Format("Color\n\n{0}", floorColor);
                            }
                        }

                        boxDimension.Text = String.Format("Dimensions\n\nHeight : {0}cm\nWidth : {1}cm\nDepth : {2}cm", HEIGHT.ToString(), LENGTH.ToString(), DEPTH.ToString());
                        boxDimension.Location = new Point(labelLength, 28);
                        int panelLabelLength = boxDimension.Width;
                        labelLength += (panelLabelLength);
                        floorGroup.Controls.Add(boxDimension);

                        //Generates label for color
                        boxColor.Location = new Point(labelLength, 28);
                        labelLength += (panelLabelLength - 30);
                        floorGroup.Controls.Add(boxColor);

                        costLabel.Text = jsonCart["CartPrice"] + "€";

                        //Generates label for Double doors
                        try
                        {
                            JObject door = floor["DoubleDoors"].Value<JObject>();
                            int doorHeight = door["Height"].Value<int>();
                            int doorLength = door["Length"].Value<int>();
                            string doorMaterial = door["Material"].Value<string>();
                            int doorQty = door["Qty"].Value<int>();
                            int doorStk = door["Remaining Stock"].Value<int>() * 2;
                            bool doorAvail = doorStk >= doorQty;

                            JObject knop = door["Knop"].Value<JObject>();
                            int knopQty = knop["Quantity"].Value<int>();
                            int knopStk = knop["Remaining Stock"].Value<int>();
                            bool knopAvail = knopStk >= knopQty;

                            Label doorLabel = new Label();
                            doorLabel.AutoSize = true;
                            doorLabel.Text = String.Format("Double Doors\n\nColor (or Material) : {0}\nGot {1} knops\n", doorMaterial, knopQty.ToString());
                            doorLabel.Location = new Point(labelLength, 28);
                            int doorLabelLenght = doorLabel.Width;
                            labelLength += (doorLabelLenght);

                            floorGroup.Controls.Add(doorLabel);

                            if (doorAvail && knopAvail)
                            {
                                availability = true;
                            }
                        }
                        catch
                        {

                        }

                        //Generate label if material available
                        Label availableMaterial = new Label();
                        availableMaterial.AutoSize = true;
                        availableMaterial.Location = new Point(floorGroup.Width + 35, 120 + floorCount * 110);

                        if (availability)
                        {
                            Color Green = Color.FromName("Green");
                            availableMaterial.ForeColor = Green;
                            availableMaterial.Text = "All the parts are available";
                        }
                        else
                        {
                            Color Red = Color.FromName("Red");
                            availableMaterial.ForeColor = Red;
                            availableMaterial.Text = "Not all the parts are available";
                        }
                        addedCabinePage.Controls.Add(availableMaterial);

                    }
                    if (floorCount >= 4)
                    {
                        addedCabinePage.AutoScroll = true;
                        addedCabinePage.AutoScrollMargin = new Size(20, 5);
                    }

                    System.Windows.Forms.Panel panelShelf1 = new System.Windows.Forms.Panel();
                    System.Windows.Forms.Panel panelShelf2 = new System.Windows.Forms.Panel();
                    System.Windows.Forms.Panel panelShelf3 = new System.Windows.Forms.Panel();
                    System.Windows.Forms.Panel panelShelf4 = new System.Windows.Forms.Panel();
                    System.Windows.Forms.Panel panelShelf5 = new System.Windows.Forms.Panel();
                    System.Windows.Forms.Panel panelShelf6 = new System.Windows.Forms.Panel();
                    System.Windows.Forms.Panel panelShelf7 = new System.Windows.Forms.Panel();

                    if (cabinetContains.Count - 2 > 0)
                    {
                        Image myImage1 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor1 + doorMaterial1 + ".png");
                        panelShelf1.BackgroundImage = myImage1;
                        panelShelf1.BackColor = Color.Transparent;
                        panelShelf1.BackgroundImageLayout = ImageLayout.Stretch;
                        panelShelf1.Size = new System.Drawing.Size(300, 600);
                        panelShelf1.Location = new Point(500, (-200 + floorCount * 76/5*2));

                        if (cabinetContains.Count - 2 > 1)
                        {
                            Image myImage2 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor2 + doorMaterial2 + ".png");
                            panelShelf2.BackgroundImage = myImage2;
                            panelShelf2.BackColor = Color.Transparent;
                            panelShelf2.BackgroundImageLayout = ImageLayout.Stretch;
                            panelShelf2.Size = new System.Drawing.Size(300, 600);
                            panelShelf2.Location = new Point(0, -76);
                            panelShelf1.Controls.Add(panelShelf2);
                            if (cabinetContains.Count - 2 > 2)
                            {
                                Image myImage3 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor3 + doorMaterial3 + ".png");
                                panelShelf3.BackgroundImage = myImage3;
                                panelShelf3.BackColor = Color.Transparent;
                                panelShelf3.BackgroundImageLayout = ImageLayout.Stretch;
                                panelShelf3.Size = new System.Drawing.Size(300, 600);
                                panelShelf3.Location = new Point(0, -76);
                                panelShelf2.Controls.Add(panelShelf3);

                                if (cabinetContains.Count - 2 > 3)
                                {
                                    Image myImage4 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor4 + doorMaterial4 + ".png");
                                    panelShelf4.BackgroundImage = myImage4;
                                    panelShelf4.BackColor = Color.Transparent;
                                    panelShelf4.BackgroundImageLayout = ImageLayout.Stretch;
                                    panelShelf4.Size = new System.Drawing.Size(300, 600);
                                    panelShelf4.Location = new Point(0, -76);
                                    panelShelf3.Controls.Add(panelShelf4);

                                    if (cabinetContains.Count - 2 > 4)
                                    {
                                        Image myImage5 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor5 + doorMaterial5 + ".png");
                                        panelShelf5.BackgroundImage = myImage5;
                                        panelShelf5.BackColor = Color.Transparent;
                                        panelShelf5.BackgroundImageLayout = ImageLayout.Stretch;
                                        panelShelf5.Size = new System.Drawing.Size(300, 600);
                                        panelShelf5.Location = new Point(0, -76);
                                        panelShelf4.Controls.Add(panelShelf5);

                                        if (cabinetContains.Count - 2 > 5)
                                        {
                                            Image myImage6 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor6 + doorMaterial6 + ".png");
                                            panelShelf6.BackgroundImage = myImage6;
                                            panelShelf6.BackColor = Color.Transparent;
                                            panelShelf6.BackgroundImageLayout = ImageLayout.Stretch;
                                            panelShelf6.Size = new System.Drawing.Size(300, 600);
                                            panelShelf6.Location = new Point(0, -76);
                                            panelShelf5.Controls.Add(panelShelf6);

                                            if (cabinetContains.Count - 2 > 6)
                                            {
                                                Image myImage7 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + floorColor7 + doorMaterial7 + ".png");
                                                panelShelf7.BackgroundImage = myImage7;
                                                panelShelf7.BackColor = Color.Transparent;
                                                panelShelf7.BackgroundImageLayout = ImageLayout.Stretch;
                                                panelShelf7.Size = new System.Drawing.Size(300, 600);
                                                panelShelf7.Location = new Point(0, -76);
                                                panelShelf6.Controls.Add(panelShelf7);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    addedCabinePage.Controls.Add(panelShelf1);

                }
            }
        }

        private void ConfirmCartButton_Click(object sender, EventArgs e)
        {
            tabControl.Visible = false;
            totalLabel.Visible = false;
            comfirmCartButton.Visible = false;
            costLabel.Visible = false;
            clientIdentifier1.Visible = true;
        }

        // -- Method to design tabheader
        private void TabPageBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];
            Color col = Color.FromArgb(27, 29, 33);

            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

            Font font = new Font("Century Gothic", 8, FontStyle.Bold);

            Color myColor = Color.FromArgb(60, 120, 138);
            SolidBrush myBrush = new SolidBrush(myColor);

            SizeF sz = e.Graphics.MeasureString(tabControl.TabPages[e.Index].Text, font);

            // changes color of text when tab is selected
            if (tabControl.SelectedIndex == e.Index)
            {
                myColor = Color.FromArgb(230, 232, 237);
                myBrush = new SolidBrush(myColor);
                e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, font, myBrush, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 4 + 1);
            }
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, font, myBrush, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 4 + 1);

            Rectangle rect = e.Bounds;
            rect.Offset(0, -2);
            rect.Inflate(0, -2);
            e.Graphics.DrawRectangle(Pens.Transparent, rect);
            e.DrawFocusRectangle();
        }
    }
}
