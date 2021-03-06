﻿using System;
using System.Data.OleDb;
using System.Windows.Forms;
using KitBoxSourceCode;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace KitBoxApplication
{
    public partial class BoxStandard : UserControl
    {
        // initialisation of variable to be able to safe selected values when switching to one or more boxes
        private string colorS1 = null;
        private string colorSA = null;
        private string colorSIf1 = null;

        private string doorM1 = null;
        private string doorMIf1 = null;

        private int increment = 1;


        public BoxStandard()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = false;

            // Add a "CheckedChanged" event handler for each radio button.
            // Ensure that all radio buttons are in the same groupbox control.

            // radio buttons in same group added to same function - group : --panelYesNoIf1--
            radioButtonYesIf1.CheckedChanged += new EventHandler(RadioButtonsYesNoIf1_CheckedChanged);
            radioButtonNoIf1.CheckedChanged += new EventHandler(RadioButtonsYesNoIf1_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesIf2.CheckedChanged += new EventHandler(RadioButtonsYesNoIf2_CheckedChanged);
            radioButtonNoIf2.CheckedChanged += new EventHandler(RadioButtonsYesNoIf2_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox1.CheckedChanged += new EventHandler(RadioButtonBox1_CheckedChanged);
            radioButtonNoBox1.CheckedChanged += new EventHandler(RadioButtonBox1_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox2.CheckedChanged += new EventHandler(RadioButtonBox2_CheckedChanged);
            radioButtonNoBox2.CheckedChanged += new EventHandler(RadioButtonBox2_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox3.CheckedChanged += new EventHandler(RadioButtonBox3_CheckedChanged);
            radioButtonNoBox3.CheckedChanged += new EventHandler(RadioButtonBox3_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox4.CheckedChanged += new EventHandler(RadioButtonBox4_CheckedChanged);
            radioButtonNoBox4.CheckedChanged += new EventHandler(RadioButtonBox4_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox5.CheckedChanged += new EventHandler(RadioButtonBox5_CheckedChanged);
            radioButtonNoBox5.CheckedChanged += new EventHandler(RadioButtonBox5_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox6.CheckedChanged += new EventHandler(RadioButtonBox6_CheckedChanged);
            radioButtonNoBox6.CheckedChanged += new EventHandler(RadioButtonBox6_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox7.CheckedChanged += new EventHandler(RadioButtonBox7_CheckedChanged);
            radioButtonNoBox7.CheckedChanged += new EventHandler(RadioButtonBox7_CheckedChanged);
        }

        OleDbCommand cmd = new OleDbCommand(); //cmd for command
        OleDbConnection cn = new OleDbConnection();  // cn for connection
        OleDbDataReader dr;

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

        // Connection to the DB and loading the data into the box
        private void BoxStandard_Load(object sender, EventArgs e)
        {

            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= " + GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Database\DB_Lespieces.accdb;";
            cmd.Connection = cn;
            LoadData();
            LoadDataWidth();
            LoadDataDepth();
            LoadDataAngleColor();
            LoadDataBoxColor();
            LoadDataDoor();
        }

        // function model for loadData
        private void LoadDataGeneral(System.Windows.Forms.ComboBox[] m, string n)
        {
            foreach (System.Windows.Forms.ComboBox i in m)
            {
                i.Items.Clear();
            }
            try
            {
                string q = n;
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        foreach (System.Windows.Forms.ComboBox i in m)
                        {
                            i.Items.Add(dr[0].ToString());
                        }
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                MessageBox.Show(e.Message.ToString());
            }
        }

        // Loading data from data base
        private void LoadData()
        {
            System.Windows.Forms.ComboBox[] list = {
                comboBoxHeight,
                comboBoxDepth,
                comboBoxWidth,
                comboBoxColorAngles,
                comboBoxColorIf1,
                comboBoxColorS1,
                comboBoxColorS2,
                comboBoxColorS3,
                comboBoxColorS4,
                comboBoxColorS5,
                comboBoxColorS6,
                comboBoxColorS7,
                comboBoxColorSA,
                comboBoxDoorMatBox1,
                comboBoxDoorMatBox2,
                comboBoxDoorMatBox3,
                comboBoxDoorMatBox4,
                comboBoxDoorMatBox5,
                comboBoxDoorMatBox6,
                comboBoxDoorMatBox7
            };
            var count = numericUpDownQuantity.Value;
            LoadDataGeneral(list, "SELECT DISTINCT hauteur FROM Piece WHERE référence LIKE 'COR%' AND référence NOT LIKE '%DEC' " +
                    "AND division LIKE '" + count + "'");
        }

        // Loading Height data from data base
        private void LoadDataHeight()
        {
            System.Windows.Forms.ComboBox[] list = { comboBoxHeight };
            var count = numericUpDownQuantity.Value;
            LoadDataGeneral(list, "SELECT DISTINCT hauteur FROM Piece WHERE référence LIKE 'COR%' AND référence NOT LIKE '%DEC' " + "AND division LIKE '" + count + "'");
        }

        // Loading Width data from data base if cabinet without doors
        private void LoadDataWidth()
        {
            System.Windows.Forms.ComboBox[] list = {comboBoxWidth};
            LoadDataGeneral(list, "SELECT DISTINCT largeur FROM Piece WHERE référence LIKE 'PA%' AND référence NOT LIKE 'PAG%' ");
        }

        // Loading Width data from data base if cabinet with doors
        private void LoadDataWidthDoor()
        {
            System.Windows.Forms.ComboBox[] list = {comboBoxWidth};
            LoadDataGeneral(list, "SELECT DISTINCT largeur FROM Piece WHERE référence LIKE 'PAR%100BL' OR référence LIKE 'PAR%120BL' OR référence LIKE 'PAR%80BL' OR référence LIKE 'PAR%62BL'");
        }

        // Loading Depth data from data base
        private void LoadDataDepth()
        {
            System.Windows.Forms.ComboBox[] list = {comboBoxDepth};
            LoadDataGeneral(list, "SELECT DISTINCT profondeur FROM Piece WHERE référence LIKE 'PA%' AND référence NOT LIKE 'PAR%' ");
        }

        // Loading Angle Color data from data base
        private void LoadDataAngleColor()
        {
            System.Windows.Forms.ComboBox[] list = {comboBoxColorAngles};
            var count = numericUpDownQuantity.Value;
            LoadDataGeneral(list, "SELECT DISTINCT couleur FROM Piece WHERE référence LIKE 'COR%' AND référence NOT LIKE '%DEC' " +
                    "AND division LIKE '" + count + "'");
        }

        // Loading Box Color data from data base
        private void LoadDataBoxColor()
        {
            System.Windows.Forms.ComboBox[] list = {
                comboBoxColorIf1,
                comboBoxColorS1,
                comboBoxColorS2,
                comboBoxColorS3,
                comboBoxColorS4,
                comboBoxColorS5,
                comboBoxColorS6,
                comboBoxColorS7,
                comboBoxColorSA,
            };
            LoadDataGeneral(list, "SELECT DISTINCT couleur FROM Piece WHERE référence LIKE 'PA%' ");
        }

        // Loading Door Material data from data base
        private void LoadDataDoor()
        {
            System.Windows.Forms.ComboBox[] list = {
                comboBoxDoorMatIf1,
                comboBoxDoorMatBox1,
                comboBoxDoorMatBox2,
                comboBoxDoorMatBox3,
                comboBoxDoorMatBox4,
                comboBoxDoorMatBox5,
                comboBoxDoorMatBox6,
                comboBoxDoorMatBox7
            };
            LoadDataGeneral(list, "SELECT DISTINCT couleur FROM Piece WHERE référence LIKE 'POR%' ");
        }

        // function to make appear color choice for all the boxes at once and door choice
        private void CheckBoxColorYes_CheckedChanged(object sender, EventArgs e)
        {
            if (panelColorChoiceAll.Visible == true)
            {
                panelColorChoiceAll.Visible = false;
                panelDoorChoiceMultiple.Visible = false;
                comboBoxColorSA.SelectedItem = null;
            }
            // yes selected, reseting every comboBox to initial state
            else
            {
                panelColorChoiceAll.Visible = true;
                checkBoxColorNo.Checked = false;
                panelDoorChoiceMultiple.Visible = true;
                comboBoxColorS1.SelectedItem = null;
                comboBoxColorS2.SelectedItem = null;
                comboBoxColorS3.SelectedItem = null;
                comboBoxColorS4.SelectedItem = null;
                comboBoxColorS5.SelectedItem = null;
                comboBoxColorS6.SelectedItem = null;
                comboBoxColorS7.SelectedItem = null;
                colorS1 = null;
                colorSIf1 = null;
                LoadColorAllSame();
            }
        }

        // function to make appear color choice for all boxes apart and door choice
        private void CheckBoxColorNo_CheckedChanged(object sender, EventArgs e)
        {
            if (panelColorChoice.Visible == true)
            {
                panelColorChoice.Visible = false;
                panelDoorChoiceMultiple.Visible = false;
                comboBoxColorS1.SelectedItem = null;
                comboBoxColorS2.SelectedItem = null;
                comboBoxColorS3.SelectedItem = null;
                comboBoxColorS4.SelectedItem = null;
                comboBoxColorS5.SelectedItem = null;
                comboBoxColorS6.SelectedItem = null;
                comboBoxColorS7.SelectedItem = null;
            }
            else
            {
                panelColorChoice.Visible = true;
                checkBoxColorYes.Checked = false;
                panelDoorChoiceMultiple.Visible = true;
                comboBoxColorSA.SelectedItem = null;
            }
        }

        // function applied to number read on the numericUpDown
        // different groups will appear or disappear in function of how many boxes have
        // been chosen
        private void NumericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDownQuantity.Value);
            LoadDataHeight();
            if (checkBoxColorYes.Checked)
            {
                LoadColorAllSame();
            }
            comboBoxHeight.Text = "";
            if (count == 1)
            {
                // visibility for which panel to show (case1 : 1box, case2: 1+boxes)
                panelColorBoxIf1.Visible = true;
                panelColorBoxIfN1.Visible = false;
                panelDoorChoiceMultiple.Visible = false;
                // resets radiobuttons door for more than one box
                radioButtonNoIf2.Checked = true;    // no door at all
                radioButtonNoBox1.Checked = true;   // no door for box 1 checked
                radioButtonNoBox2.Checked = true;   // no door for box 2 checked
                // shelf image
                panelShelf2.Visible = false;
                // keep selected value of first box
                if (colorSA != null || colorS1 != null || doorM1 != null || doorM1 == null)
                {
                    if (colorSA != null)
                    {
                        comboBoxColorIf1.SelectedItem = colorSA;
                        //colorSA = null;
                    }
                    else if (colorS1 != null)
                    {
                        comboBoxColorIf1.SelectedItem = colorS1;
                        //colorS1 = null;
                    }
                    if (doorM1 != null)
                    {
                        comboBoxDoorMatIf1.SelectedItem = doorM1;
                        radioButtonYesIf1.Checked = true;
                        doorM1 = null;
                    }
                    else if (doorM1 == null)
                    {
                        radioButtonNoIf1.Checked = true;
                        comboBoxDoorMatIf1.SelectedItem = null;
                    }
                }
                comboBoxColorS1.SelectedItem = null;
                comboBoxColorS2.SelectedItem = null;
                AddColorToBox(comboBoxColorIf1, comboBoxDoorMatIf1, panelShelf1);
                AddColorToBox(comboBoxColorS2, comboBoxDoorMatBox2, panelShelf2);
                AddColorToBox(comboBoxColorS3, comboBoxDoorMatBox3, panelShelf3);
                AddColorToBox(comboBoxColorS4, comboBoxDoorMatBox4, panelShelf4);
                AddColorToBox(comboBoxColorS5, comboBoxDoorMatBox5, panelShelf5);
                AddColorToBox(comboBoxColorS6, comboBoxDoorMatBox6, panelShelf6);
                AddColorToBox(comboBoxColorS7, comboBoxDoorMatBox7, panelShelf7);
                colorSIf1 = comboBoxColorIf1.Text;
            }
            else if (count > 1)
            {
                // visibility for which panel to show (case1 : 1box, case2: 1+boxes)
                panelDoorChoiceMultiple.Visible = true;
                panelColorBoxIf1.Visible = false;
                panelColorBoxIfN1.Visible = true;
                // part to make appear features for box color and door
                // color features box 3
                labelColorS3.Visible = false;
                comboBoxColorS3.Visible = false;
                // shelf image
                panelShelf2.Visible = true;
                panelShelf3.Visible = false;

                if (count == 2)
                {
                    // door features box 3
                    labelDoorBox3.Visible = false;
                    panelYesNoBox3.Visible = false;
                    // resets radiobutton only if
                    radioButtonNoBox3.Checked = true;
                    comboBoxColorS3.SelectedItem = null;
                    // keep selected value of first box
                    if (colorSIf1 != null || doorMIf1 != null)
                    {
                        if (colorSIf1 != null)
                        {
                            comboBoxColorS1.SelectedItem = colorSIf1;
                            checkBoxColorNo.Checked = true;
                            //colorSIf1 = null;
                        }
                        if (doorMIf1 != null)
                        {
                            if (doorM1 == null || doorM1 == "")
                            {
                                comboBoxDoorMatBox1.SelectedItem = doorMIf1;
                            }
                            else
                            {
                                comboBoxDoorMatBox1.SelectedItem = doorM1;
                            }
                            radioButtonYesIf2.Checked = true;
                            radioButtonYesBox1.Checked = true;
                            //doorMIf1 = null;
                        }
                        else
                        {
                            // resets radiobuttons
                            radioButtonNoIf2.Checked = true;
                        }
                    }
                    if (comboBoxColorSA.SelectedItem == null)
                    {
                        AddColorToBox(comboBoxColorS1, comboBoxDoorMatBox1, panelShelf1);
                    }
                }
                // resets color for 1 box to null
                comboBoxColorIf1.SelectedItem = null;
                radioButtonNoIf1.Checked = true;
                if (count > 2)
                {
                    doorM1 = comboBoxDoorMatBox1.Text;
                    // color features box 3 and box 4
                    labelColorS3.Visible = true;
                    comboBoxColorS3.Visible = true;
                    labelColorS4.Visible = false;
                    comboBoxColorS4.Visible = false;
                    // door features box 3 and box 4
                    labelDoorBox3.Visible = true;
                    panelYesNoBox3.Visible = true;
                    if (count == 3)
                    {
                        // door features box 3
                        labelDoorBox4.Visible = false;
                        panelYesNoBox4.Visible = false;
                        // resets radiobutton only if
                        radioButtonNoBox4.Checked = true;
                        comboBoxColorS4.SelectedItem = null;
                    }
                    // shelf image
                    panelShelf3.Visible = true;
                    panelShelf4.Visible = false;
                    if (count > 3)
                    {
                        // color features box 4 and box 5
                        labelColorS4.Visible = true;
                        comboBoxColorS4.Visible = true;
                        labelColorS5.Visible = false;
                        comboBoxColorS5.Visible = false;
                        // door features box 4 and box 5
                        labelDoorBox4.Visible = true;
                        panelYesNoBox4.Visible = true;
                        if (count == 4)
                        {
                            // door features box 3
                            labelDoorBox5.Visible = false;
                            panelYesNoBox5.Visible = false;
                            // resets radiobutton only if
                            radioButtonNoBox5.Checked = true;
                            comboBoxColorS5.SelectedItem = null;
                        }
                        // shelf image
                        panelShelf4.Visible = true;
                        panelShelf5.Visible = false;
                        if (count > 4)
                        {
                            // color features box 5 and box 6
                            labelColorS5.Visible = true;
                            comboBoxColorS5.Visible = true;
                            labelColorS6.Visible = false;
                            comboBoxColorS6.Visible = false;
                            // door features box 5 and box 6
                            labelDoorBox5.Visible = true;
                            panelYesNoBox5.Visible = true;
                            if (count == 5)
                            {
                                // door features box 3
                                labelDoorBox6.Visible = false;
                                panelYesNoBox6.Visible = false;
                                // resets radiobutton only if
                                radioButtonNoBox6.Checked = true;
                                comboBoxColorS6.SelectedItem = null;
                            }
                            // shelf image
                            panelShelf5.Visible = true;
                            panelShelf6.Visible = false;
                            if (count > 5)
                            {
                                // color features box 6 and box 7
                                labelColorS6.Visible = true;
                                comboBoxColorS6.Visible = true;
                                labelColorS7.Visible = false;
                                comboBoxColorS7.Visible = false;
                                // door features box 6 and box 7
                                labelDoorBox6.Visible = true;
                                panelYesNoBox6.Visible = true;
                                if (count == 6)
                                {
                                    // door features box 3
                                    labelDoorBox7.Visible = false;
                                    panelYesNoBox7.Visible = false;
                                    // resets radiobutton only if
                                    radioButtonNoBox7.Checked = true;
                                    comboBoxColorS7.SelectedItem = null;
                                }
                                // shelf image
                                panelShelf6.Visible = true;
                                panelShelf7.Visible = false;
                                if (count > 6)
                                {
                                    // color features box 7
                                    labelColorS7.Visible = true;
                                    comboBoxColorS7.Visible = true;
                                    // door features box 7
                                    labelDoorBox7.Visible = true;
                                    panelYesNoBox7.Visible = true;
                                    // shelf image
                                    panelShelf7.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        // function for door in case only 1 box
        private void RadioButtonsYesNoIf1_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesIf1)
                {
                    panelDoorMaterial.Visible = true;
                    LoadDataWidthDoor();
                    comboBoxWidth.Text = "";
                }
                else if (((RadioButton)sender) == radioButtonNoIf1)
                {
                    panelDoorMaterial.Visible = false;
                    LoadDataWidth();
                    if (numericUpDownQuantity.Value == 1)
                    {
                        comboBoxDoorMatIf1.SelectedItem = null;
                        RemoveDoor(comboBoxColorIf1, panelShelf1);
                    }
                }
            }
        }

        // function for doors in case multiple boxes
        private void RadioButtonsYesNoIf2_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesIf2)
                {
                    panelDoorChoicesM.Visible = true;
                    LoadDataWidthDoor();
                    comboBoxWidth.Text = "";
                }
                else if (((RadioButton)sender) == radioButtonNoIf2)
                {
                    panelDoorChoicesM.Visible = false;
                    LoadDataWidth();
                    radioButtonNoBox1.Checked = true;
                    radioButtonNoBox2.Checked = true;
                    radioButtonNoBox3.Checked = true;
                    radioButtonNoBox4.Checked = true;
                    radioButtonNoBox5.Checked = true;
                    radioButtonNoBox6.Checked = true;
                    radioButtonNoBox7.Checked = true;
                }
            }
        }

        // function radiobuttons for door box 1
        private void RadioButtonBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox1)
                {
                    panelDoorChoiceBox1.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox1)
                {
                    panelDoorChoiceBox1.Visible = false;
                    comboBoxDoorMatBox1.SelectedItem = null;
                    if (numericUpDownQuantity.Value != 1)
                    {
                        doorM1 = null;
                    }
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS1, panelShelf1);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf1);
                    }
                }
            }
        }

        // function radiobuttons for door box 2
        private void RadioButtonBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox2)
                {
                    panelDoorChoiceBox2.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox2)
                {
                    panelDoorChoiceBox2.Visible = false;
                    comboBoxDoorMatBox2.SelectedItem = null;
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS2, panelShelf2);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf2);
                    }
                }
            }
        }

        // function radiobuttons for door box 3
        private void RadioButtonBox3_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox3)
                {
                    panelDoorChoiceBox3.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox3)
                {
                    panelDoorChoiceBox3.Visible = false;
                    comboBoxDoorMatBox3.SelectedItem = null;
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS3, panelShelf3);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf3);
                    }
                }
            }
        }

        // function radiobuttons for door box 4
        private void RadioButtonBox4_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox4)
                {
                    panelDoorChoiceBox4.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox4)
                {
                    panelDoorChoiceBox4.Visible = false;
                    comboBoxDoorMatBox4.SelectedItem = null;
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS4, panelShelf4);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf4);
                    }
                }
            }
        }

        // function radiobuttons for door box 5
        private void RadioButtonBox5_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox5)
                {
                    panelDoorChoiceBox5.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox5)
                {
                    panelDoorChoiceBox5.Visible = false;
                    comboBoxDoorMatBox5.SelectedItem = null;
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS5, panelShelf5);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf5);
                    }
                }
            }
        }

        // function radiobuttons for door box 6
        private void RadioButtonBox6_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox6)
                {
                    panelDoorChoiceBox6.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox6)
                {
                    panelDoorChoiceBox6.Visible = false;
                    comboBoxDoorMatBox6.SelectedItem = null;
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS6, panelShelf6);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf6);
                    }
                }
            }
        }

        // function radiobuttons for door box 7
        private void RadioButtonBox7_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == radioButtonYesBox7)
                {
                    panelDoorChoiceBox7.Visible = true;
                }
                else if (((RadioButton)sender) == radioButtonNoBox7)
                {
                    panelDoorChoiceBox7.Visible = false;
                    comboBoxDoorMatBox7.SelectedItem = null;
                    if (checkBoxColorNo.Checked)
                    {
                        RemoveDoor(comboBoxColorS7, panelShelf7);
                    }
                    else
                    {
                        RemoveDoor(comboBoxColorSA, panelShelf7);
                    }
                }
            }
        }

        // general function to add color to box cabinet image
        private void AddColorToBox(ComboBox box, ComboBox door, System.Windows.Forms.Panel shelf)
        {
            string color = box.Text;
            string doorMat = door.Text;
            if (color == "")
            {
                color = "blanc";
            }
            if (doorMat == "")
            {
                doorMat = "NoDoor";
            }
            Image myImage = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat + ".png");
            shelf.BackgroundImage = myImage;
        }

        private void ComboBoxColorIf1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numericUpDownQuantity.Value == 1)
            {
                AddColorToBox(comboBoxColorIf1, comboBoxDoorMatIf1, panelShelf1);
                colorSIf1 = comboBoxColorIf1.Text;
            }
        }

        // function to change colors of cabinet image in case checkBox "all color same" checked
        private void LoadColorAllSame()
        {
            int count = Convert.ToInt32(numericUpDownQuantity.Value);

            string color = comboBoxColorSA.Text;
            string doorMat1 = comboBoxDoorMatBox1.Text;
            if (doorMat1 == "")
            {
                doorMat1 = "NoDoor";
            }
            if (color == "")
            {
                color = "blanc";
            }
            Image myImage1 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat1 + ".png");
            panelShelf1.BackgroundImage = myImage1;
            if (count > 1)
            {
                string doorMat2 = comboBoxDoorMatBox2.Text;
                if (doorMat2 == "")
                {
                    doorMat2 = "NoDoor";
                }
                Image myImage2 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat2 + ".png");
                panelShelf2.BackgroundImage = myImage2;
                if (count > 2)
                {
                    string doorMat3 = comboBoxDoorMatBox3.Text;
                    if (doorMat3 == "")
                    {
                        doorMat3 = "NoDoor";
                    }
                    Image myImage3 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat3 + ".png");
                    panelShelf3.BackgroundImage = myImage3;
                    if (count > 3)
                    {
                        string doorMat4 = comboBoxDoorMatBox4.Text;
                        if (doorMat4 == "")
                        {
                            doorMat4 = "NoDoor";
                        }
                        Image myImage4 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat4 + ".png");
                        panelShelf4.BackgroundImage = myImage4;
                        if (count > 4)
                        {
                            string doorMat5 = comboBoxDoorMatBox5.Text;
                            if (doorMat5 == "")
                            {
                                doorMat5 = "NoDoor";
                            }
                            Image myImage5 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat5 + ".png");
                            panelShelf5.BackgroundImage = myImage5;
                            if (count > 5)
                            {
                                string doorMat6 = comboBoxDoorMatBox6.Text;
                                if (doorMat6 == "")
                                {
                                    doorMat6 = "NoDoor";
                                }
                                Image myImage6 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat6 + ".png");
                                panelShelf6.BackgroundImage = myImage6;
                                if (count > 6)
                                {
                                    string doorMat7 = comboBoxDoorMatBox7.Text;
                                    if (doorMat7 == "")
                                    {
                                        doorMat7 = "NoDoor";
                                    }
                                    Image myImage7 = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + doorMat7 + ".png");
                                    panelShelf7.BackgroundImage = myImage7;
                                }
                            }
                        }
                    }
                }
            }
        }

        // function to change color of all active boxPanels
        private void ComboBoxColorSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadColorAllSame();
            colorSA = comboBoxColorSA.Text;
        }

        // function to change color of boxPanel1
        private void ComboBoxColorS1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS1, comboBoxDoorMatBox1, panelShelf1);
            colorS1 = comboBoxColorS1.Text;
        }

        // function to change color of boxPanel2
        private void ComboBoxColorS2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS2, comboBoxDoorMatBox2, panelShelf2);
        }

        // function to change color of boxPanel3
        private void ComboBoxColorS3_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS3, comboBoxDoorMatBox3, panelShelf3);
        }

        // function to change color of boxPanel4
        private void ComboBoxColorS4_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS4, comboBoxDoorMatBox4, panelShelf4);
        }

        // function to change color of boxPanel5
        private void ComboBoxColorS5_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS5, comboBoxDoorMatBox5, panelShelf5);
        }

        // function to change color of boxPanel6
        private void ComboBoxColorS6_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS6, comboBoxDoorMatBox6, panelShelf6);
        }

        // function to change color of boxPanel7
        private void ComboBoxColorS7_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorS7, comboBoxDoorMatBox7, panelShelf7);
        }

        // general function to remove door image
        private void RemoveDoor(ComboBox a, System.Windows.Forms.Panel b)
        {
            string color = a.Text;
            if (color == "")
            {
                color = "blanc";
            }
            Image myImage = new Bitmap(GetRelativePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + @"Documents\GitHub\Projet_KitBox\Interface\KitBoxApplication\KitBoxApplication\Resources\" + color + "NoDoor.png");
            b.BackgroundImage = myImage;
        }

        // function to change color of door material of box 1
        private void ComboBoxDoorMatBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox1, panelShelf1);
            }
            else
            {
                AddColorToBox(comboBoxColorS1, comboBoxDoorMatBox1, panelShelf1);
            }
            if (comboBoxDoorMatBox1.Text != "")
            {
                doorM1 = comboBoxDoorMatBox1.Text;
            }
        }

        // function to change color of door material of box 2
        private void ComboBoxDoorMatBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox2, panelShelf2);
            }
            else
            {
                AddColorToBox(comboBoxColorS2, comboBoxDoorMatBox2, panelShelf2);
            }
        }

        // function to change color of door material of box 3
        private void ComboBoxDoorMatBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox3, panelShelf3);
            }
            else
            {
                AddColorToBox(comboBoxColorS3, comboBoxDoorMatBox3, panelShelf3);
            }
        }

        // function to change color of door material of box 4
        private void ComboBoxDoorMatBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox4, panelShelf4);
            }
            else
            {
                AddColorToBox(comboBoxColorS4, comboBoxDoorMatBox4, panelShelf4);
            }
        }

        // function to change color of door material of box 5
        private void ComboBoxDoorMatBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox5, panelShelf5);
            }
            else
            {
                AddColorToBox(comboBoxColorS5, comboBoxDoorMatBox5, panelShelf5);
            }
        }

        // function to change color of door material of box 6
        private void ComboBoxDoorMatBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox6, panelShelf6);
            }
            else
            {
                AddColorToBox(comboBoxColorS6, comboBoxDoorMatBox6, panelShelf6);
            }
        }

        // function to change color of door material of box 7
        private void ComboBoxDoorMatBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorSA.Text != "")
            {
                AddColorToBox(comboBoxColorSA, comboBoxDoorMatBox7, panelShelf7);
            }
            else
            {
                AddColorToBox(comboBoxColorS7, comboBoxDoorMatBox7, panelShelf7);
            }
        }

        // function to change color of door material of box 1 in case 1 box cabinet
        private void ComboBoxDoorMatIf1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColorToBox(comboBoxColorIf1, comboBoxDoorMatIf1, panelShelf1);
            doorMIf1 = comboBoxDoorMatIf1.Text;
        }


        //function that give the height of each box
        private int ProcessHeightForEachBox(int heightToGive, int nbrBoxToGive)
        {
            var height = heightToGive;
            var nbrBox = nbrBoxToGive;
            int boxHeight = (height) / nbrBox;
            return boxHeight;
        }

        // function to give dimension of the boxes
        private void ComboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            var height = 0;
            if (comboBoxHeight.SelectedItem != null)
            {
                height = Int32.Parse(comboBoxHeight.SelectedItem.ToString());
            }
            var nbrBox = Int32.Parse(numericUpDownQuantity.Value.ToString());
            int boxHeight = ProcessHeightForEachBox(height,nbrBox);
            string dimension = nbrBox + "x" + boxHeight.ToString() + "(h)";
            labelBoxHeight.Text = dimension.ToString();
        }

        private List<string> getColor(int qty)
        {
            List<string> colors = Enumerable.Repeat<string>(null, 7).ToList();
            if (checkBoxColorYes.Checked)
            {
                string color = comboBoxColorSA.SelectedItem.ToString();
                for(int i =0; i<qty; i++)
                {
                    colors[i] = color;
                }
            }
            else
            {
                colors = new List<string>
                {
                    (qty >= 1) ? comboBoxColorS1.SelectedItem.ToString(): null,
                    (qty >= 2) ? comboBoxColorS2.SelectedItem.ToString(): null,
                    (qty >= 3) ? comboBoxColorS3.SelectedItem.ToString(): null,
                    (qty >= 4) ? comboBoxColorS4.SelectedItem.ToString(): null,
                    (qty >= 5) ? comboBoxColorS5.SelectedItem.ToString(): null,
                    (qty >= 6) ? comboBoxColorS6.SelectedItem.ToString(): null,
                    (qty >= 7) ? comboBoxColorS7.SelectedItem.ToString(): null
                };
            }
            
            return colors;
        }

        private List<string> getDoorMat()
        {
            List<string> doorMat = Enumerable.Repeat<string>(null, 7).ToList();
            doorMat = new List<string>
            {
                (radioButtonYesBox1.Checked) ? comboBoxDoorMatBox1.SelectedItem.ToString():null,
                (radioButtonYesBox2.Checked) ? comboBoxDoorMatBox2.SelectedItem.ToString():null,
                (radioButtonYesBox3.Checked) ? comboBoxDoorMatBox3.SelectedItem.ToString():null,
                (radioButtonYesBox4.Checked) ? comboBoxDoorMatBox4.SelectedItem.ToString():null,
                (radioButtonYesBox5.Checked) ? comboBoxDoorMatBox5.SelectedItem.ToString():null,
                (radioButtonYesBox6.Checked) ? comboBoxDoorMatBox6.SelectedItem.ToString():null,
                (radioButtonYesBox7.Checked) ? comboBoxDoorMatBox7.SelectedItem.ToString():null
            };
            
            return doorMat;
        }

        //function that add the chosen features to the cart
        private void ButtonAddToCart_Click(object sender, EventArgs e)
        {


            //If the cart is empty, create it
            if (CartPage.Cart == null)
            {
                CartPage.Cart = new Cart();
            }


            try
            {
                int qty = (int)numericUpDownQuantity.Value;
                int totalHeight = Int32.Parse(comboBoxHeight.SelectedItem.ToString());
                int heightForEach = ProcessHeightForEachBox(totalHeight, qty);
                int width = Int32.Parse(comboBoxWidth.SelectedItem.ToString());
                int depth = Int32.Parse(comboBoxDepth.SelectedItem.ToString());
                string angleColor = comboBoxColorAngles.SelectedItem.ToString();

                //Initialize colors and doors choices
                List<string> color = Enumerable.Repeat<string>(null, 7).ToList();

                List<string> door = Enumerable.Repeat<string>(null, 7).ToList();

                if (qty == 1)
                {
                    color[0] = comboBoxColorIf1.SelectedItem.ToString();
                    if (radioButtonYesIf1.Checked == true)
                    {
                        door[0] = comboBoxDoorMatIf1.Text.ToString();
                    }
                }

                else
                {
                    if (checkBoxColorYes.Checked == true & radioButtonYesIf2.Checked == true)
                    {
                        color = getColor(qty);

                        door = getDoorMat();
                    }
                    else if (checkBoxColorYes.Checked == true & radioButtonYesIf2.Checked == false)
                    {
                        color = getColor(qty);
                    }
                    else if (checkBoxColorYes.Checked == false & radioButtonYesIf2.Checked == true)
                    {
                        door = getDoorMat();
                        color = getColor(qty);
                    }                              
                    else                           
                    {
                        color = getColor(qty);
                    }
                }
                List<Object> list = new List<Object> { qty, heightForEach, width, depth,angleColor, color, door };

                panel1.Visible = true;
                progressBar.Value = 0;

                loadingLabel.Text = "Status : Creating cabinet : Floor";

                backgroundWorker1.RunWorkerAsync(list);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter all the necessary information");
            }
        }


        // function to reset every combobox, numericupdown, radiobutton and checkbox to his initial state
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            numericUpDownQuantity.Value = 1;
            comboBoxColorAngles.SelectedItem = null;
            comboBoxHeight.SelectedItem = null;
            comboBoxWidth.SelectedItem = null;
            comboBoxDepth.SelectedItem = null;
            comboBoxColorIf1.SelectedItem = null;
            radioButtonNoIf1.Checked = true;
            labelBoxHeight.Text = "";
        }



        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.ReportProgress(5);

            List<Object> list = e.Argument as List<Object>;
            int qty = (int)list[0];
            int heightForEach = (int)list[1];
            int width = (int)list[2];
            int depth = (int)list[3];
            string angleColor = (string)list[4];
            List<string> color = (List<string>)list[5];
            List<string> door = (List<string>)list[6];

            Cabinet cabinet = new Cabinet();


            //All the boxes we can get
            int nbr = qty + 1;

            if (qty >= 1)
            {
                //int progress = 100 / nbr * 1;
                worker.ReportProgress(100 / nbr * 1);
                cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[0], panelCol: color[0]));
                if (qty >= 2)
                {
                    worker.ReportProgress(100 / nbr * 2);
                    incrementer();
                    cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[1], panelCol: color[1]));
                    if (qty >= 3)
                    {
                        worker.ReportProgress(100 / nbr * 3);
                        incrementer();
                        cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[2], panelCol: color[2]));
                        if (qty >= 4)
                        {
                            worker.ReportProgress(100 / nbr * 4);
                            incrementer();
                            cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[3], panelCol: color[3]));
                            if (qty >= 5)
                            {
                                worker.ReportProgress(100 / nbr * 5);
                                incrementer();
                                cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[4], panelCol: color[4]));
                                if (qty >= 6)
                                {
                                    worker.ReportProgress(100 / nbr * 6);
                                    incrementer();
                                    cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[5], panelCol: color[5]));
                                    if (qty >= 7)
                                    {
                                        worker.ReportProgress(100 / nbr * 7);
                                        incrementer();
                                        cabinet.AddStorageBox(new CabinetFloor(heightForEach, width, depth, door[6], panelCol: color[6]));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            worker.ReportProgress(100);

            cabinet.AddAngles(angleColor);

            CartPage.Cart.AddToCart(cabinet);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if(e.ProgressPercentage == 100)
            {
                incrementLabel.Text = "";
                loadingLabel.Text = "Status : Done!";
            }
            else
            {
                incrementLabel.Text = increment.ToString();
            }
            
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Visible = false;
            incrementLabel.Text = "0";
            increment = 1;
            progressBar.Value = 0;
        }

        private void incrementer()
        {
            increment++;
        }
    }
}
