﻿using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KitBoxApplication
{
    public partial class BoxStandard : UserControl
    {
        public BoxStandard()
        {
            InitializeComponent();

            // Add a "CheckedChanged" event handler for each radio button.
            // Ensure that all radio buttons are in the same groupbox control.

            // radio buttons in same group added to same function - group : --panelYesNoIf1--
            radioButtonYesIf1.CheckedChanged += new EventHandler(radioButtonsYesNoIf1_CheckedChanged);
            radioButtonNoIf1.CheckedChanged += new EventHandler(radioButtonsYesNoIf1_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesIf2.CheckedChanged += new EventHandler(radioButtonsYesNoIf2_CheckedChanged);
            radioButtonNoIf2.CheckedChanged += new EventHandler(radioButtonsYesNoIf2_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox1.CheckedChanged += new EventHandler(radioButtonBox1_CheckedChanged);
            radioButtonNoBox1.CheckedChanged += new EventHandler(radioButtonBox1_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox2.CheckedChanged += new EventHandler(radioButtonBox2_CheckedChanged);
            radioButtonNoBox2.CheckedChanged += new EventHandler(radioButtonBox2_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox3.CheckedChanged += new EventHandler(radioButtonBox3_CheckedChanged);
            radioButtonNoBox3.CheckedChanged += new EventHandler(radioButtonBox3_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox4.CheckedChanged += new EventHandler(radioButtonBox4_CheckedChanged);
            radioButtonNoBox4.CheckedChanged += new EventHandler(radioButtonBox4_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox5.CheckedChanged += new EventHandler(radioButtonBox5_CheckedChanged);
            radioButtonNoBox5.CheckedChanged += new EventHandler(radioButtonBox5_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox6.CheckedChanged += new EventHandler(radioButtonBox6_CheckedChanged);
            radioButtonNoBox6.CheckedChanged += new EventHandler(radioButtonBox6_CheckedChanged);

            // radio buttons in same group added to same function - group : --panelYesNoIf2--
            radioButtonYesBox7.CheckedChanged += new EventHandler(radioButtonBox7_CheckedChanged);
            radioButtonNoBox7.CheckedChanged += new EventHandler(radioButtonBox7_CheckedChanged);           
        }

        OleDbCommand cmd = new OleDbCommand(); //cmd for command
        OleDbConnection cn = new OleDbConnection();  // cn for connection
        OleDbDataReader dr;

        // Connection to the DB and loading the data into the box
        private void BoxStandard_Load(object sender, EventArgs e) 
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\Harold\Documents\GitHub\Projet_kitBox_final\Projet_KitBox\Database\DB_Lespieces.accdb;";
            cmd.Connection = cn;
            LoadData();
            LoadDataWidth();
            LoadDataDepth();
            LoadDataAngleColor();
            LoadDataBoxColor();
            LoadDataDoor();
        }

        // Loading data from data base 
        private void LoadData()
        {
            comboBoxHeight.Items.Clear();
            comboBoxDepth.Items.Clear();
            comboBoxWidth.Items.Clear();
            comboBoxColorAngles.Items.Clear();
            comboBoxColorIf1.Items.Clear();
            comboBoxColorS1.Items.Clear();
            comboBoxColorS2.Items.Clear();
            comboBoxColorS3.Items.Clear();
            comboBoxColorS4.Items.Clear();
            comboBoxColorS5.Items.Clear();
            comboBoxColorS6.Items.Clear();
            comboBoxColorS7.Items.Clear();
            comboBoxColorSA.Items.Clear();
            comboBoxDoorMatBox1.Items.Clear();
            comboBoxDoorMatBox2.Items.Clear();
            comboBoxDoorMatBox3.Items.Clear();
            comboBoxDoorMatBox4.Items.Clear();
            comboBoxDoorMatBox5.Items.Clear();
            comboBoxDoorMatBox6.Items.Clear();
            comboBoxDoorMatBox7.Items.Clear();
            try
            {
                var count = numericUpDownQuantity.Value;
                string q = "SELECT DISTINCT hauteur FROM Piece WHERE référence LIKE 'COR%' AND référence NOT LIKE '%DEC' " +
                    "AND division LIKE '" + count + "'";
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxHeight.Items.Add(dr[0].ToString());                        
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
        
        // Loading Height data from data base 
        private void LoadDataHeight() 
        {
            comboBoxHeight.Items.Clear();            
            try
            {                
                var count = numericUpDownQuantity.Value;                
                string q = "SELECT DISTINCT hauteur FROM Piece WHERE référence LIKE 'COR%' AND référence NOT LIKE '%DEC' " +
                    "AND division LIKE '" + count + "'" ;
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxHeight.Items.Add(dr[0].ToString());                        
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

        // Loading Width data from data base if cabinet without doors
        private void LoadDataWidth()
        {                        
            comboBoxWidth.Items.Clear();
            try
            {
                var height = comboBoxHeight.SelectedValue;

                string q = "SELECT DISTINCT largeur FROM Piece WHERE référence LIKE 'PA%' AND référence NOT LIKE 'PAG%' "; //+
                   // "AND hauteur LIKE '" + height + "'";
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxWidth.Items.Add(dr[0].ToString());                        
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

        // Loading Width data from data base if cabinet with doors
        private void LoadDataWidthDoor()
        {
            comboBoxWidth.Items.Clear();
            try
            {                
                string q = "SELECT DISTINCT largeur FROM Piece WHERE référence LIKE 'POR%' ";                                                                                
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxWidth.Items.Add(dr[0].ToString());
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

        // Loading Depth data from data base 
        private void LoadDataDepth()
        {            
            comboBoxDepth.Items.Clear();            
            try
            {
                var count = numericUpDownQuantity.Value;
                string q = "SELECT DISTINCT profondeur FROM Piece WHERE référence LIKE 'PA%' AND référence NOT LIKE 'PAR%' "; 
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxDepth.Items.Add(dr[0].ToString());
                        //listBox2.Items.Add(dr[0].ToString());
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

        // Loading Angle Color data from data base 
        private void LoadDataAngleColor()
        {            
            comboBoxColorAngles.Items.Clear();            
            try
            {
                var count = numericUpDownQuantity.Value;
                string q = "SELECT DISTINCT couleur FROM Piece WHERE référence LIKE 'COR%' AND référence NOT LIKE '%DEC' " +
                    "AND division LIKE '" + count + "'";
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxColorAngles.Items.Add(dr[0].ToString());
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

        // Loading Box Color data from data base 
        private void LoadDataBoxColor()
        {            
            comboBoxColorIf1.Items.Clear();
            comboBoxColorS1.Items.Clear();
            comboBoxColorS2.Items.Clear();
            comboBoxColorS3.Items.Clear();
            comboBoxColorS4.Items.Clear();
            comboBoxColorS5.Items.Clear();
            comboBoxColorS6.Items.Clear();
            comboBoxColorS7.Items.Clear();
            comboBoxColorSA.Items.Clear();            
            try
            {
                var count = numericUpDownQuantity.Value;
                string q = "SELECT DISTINCT couleur FROM Piece WHERE référence LIKE 'PA%' ";
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxColorIf1.Items.Add(dr[0].ToString());
                        comboBoxColorS1.Items.Add(dr[0].ToString());
                        comboBoxColorS2.Items.Add(dr[0].ToString());
                        comboBoxColorS3.Items.Add(dr[0].ToString());
                        comboBoxColorS4.Items.Add(dr[0].ToString());
                        comboBoxColorS5.Items.Add(dr[0].ToString());
                        comboBoxColorS6.Items.Add(dr[0].ToString());
                        comboBoxColorS7.Items.Add(dr[0].ToString());
                        comboBoxColorSA.Items.Add(dr[0].ToString());                        
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

        // Loading Door Material data from data base 
        private void LoadDataDoor()
        {
            comboBoxDoorMatIf1.Items.Clear();
            comboBoxDoorMatBox1.Items.Clear();
            comboBoxDoorMatBox2.Items.Clear();
            comboBoxDoorMatBox3.Items.Clear();
            comboBoxDoorMatBox4.Items.Clear();
            comboBoxDoorMatBox5.Items.Clear();
            comboBoxDoorMatBox6.Items.Clear();
            comboBoxDoorMatBox7.Items.Clear();
            try
            {
                var count = numericUpDownQuantity.Value;
                string q = "SELECT DISTINCT couleur FROM Piece WHERE référence LIKE 'POR%' ";
                cmd.CommandText = q; // execution of a SQL instruction
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboBoxDoorMatIf1.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox1.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox2.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox3.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox4.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox5.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox6.Items.Add(dr[0].ToString());
                        comboBoxDoorMatBox7.Items.Add(dr[0].ToString());
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

        // function to make appear color choice for all the boxes at once and door choice
        private void checkBoxColorYes_CheckedChanged(object sender, EventArgs e)
        {
            if (panelColorChoiceAll.Visible == true)
            {
                panelColorChoiceAll.Visible = false;
                panelDoorChoiceMultiple.Visible = false;
            }
            else
            {
                panelColorChoiceAll.Visible = true;
                checkBoxColorNo.Checked = false;
                panelDoorChoiceMultiple.Visible = true;
            }
        }

        // function to make appear color choice for all boxes apart and door choice        
        private void checkBoxColorNo_CheckedChanged(object sender, EventArgs e)
        {
            if (panelColorChoice.Visible == true)
            {
                panelColorChoice.Visible = false;
                panelDoorChoiceMultiple.Visible = false;
            }
            else
            {
                panelColorChoice.Visible = true;
                checkBoxColorYes.Checked = false;
                panelDoorChoiceMultiple.Visible = true;
            }
        }

        // function applied to number read on the numericUpDown
        // different groups will appear or disappear in function of how many boxes have
        // been chosen
        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDownQuantity.Value);
            LoadDataHeight();
            comboBoxHeight.Text = "";
            if (count == 1)
            {
                panelColorBoxIf1.Visible = true;
                panelColorBoxIfN1.Visible = false;
                panelDoorChoiceMultiple.Visible = false;
                // resets radiobuttons
                radioButtonNoIf2.Checked = true;
                radioButtonNoBox1.Checked = true;
                radioButtonNoBox2.Checked = true;
                
            }        
            else if (count > 1)
            {
                panelDoorChoiceMultiple.Visible = true;
                panelColorBoxIf1.Visible = false;
                panelColorBoxIfN1.Visible = true;
                // part to make appear features for box color and door
                // color features box 3
                labelColorS3.Visible = false;
                comboBoxColorS3.Visible = false;
                // door features box 3
                labelDoorBox3.Visible = false;
                panelYesNoBox3.Visible = false;
                // resets radiobuttons
                radioButtonNoIf1.Checked = true;
                radioButtonNoBox3.Checked = true;
                if (count > 2)
                {
                    // color features box 3 and box 4
                    labelColorS3.Visible = true;
                    comboBoxColorS3.Visible = true;
                    labelColorS4.Visible = false;
                    comboBoxColorS4.Visible = false;
                    // door features box 3 and box 4
                    labelDoorBox3.Visible = true;
                    panelYesNoBox3.Visible = true;
                    labelDoorBox4.Visible = false;
                    panelYesNoBox4.Visible = false;
                    radioButtonNoBox4.Checked = true;
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
                        labelDoorBox5.Visible = false;
                        panelYesNoBox5.Visible = false;
                        radioButtonNoBox5.Checked = true;
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
                            labelDoorBox6.Visible = false;
                            panelYesNoBox6.Visible = false;
                            radioButtonNoBox6.Checked = true;
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
                                labelDoorBox7.Visible = false;
                                panelYesNoBox7.Visible = false;
                                radioButtonNoBox7.Checked = true;
                                if (count > 6)
                                {
                                    // color features box 7 
                                    labelColorS7.Visible = true;
                                    comboBoxColorS7.Visible = true;
                                    // door features box 7
                                    labelDoorBox7.Visible = true;
                                    panelYesNoBox7.Visible = true;
                                }
                            }
                        }
                    }
                }                
            }
        }

        // function for door in case only 1 box
        private void radioButtonsYesNoIf1_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function for doors in case multiple boxes
        private void radioButtonsYesNoIf2_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function radiobuttons for door box 1
        private void radioButtonBox1_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function radiobuttons for door box 2
        private void radioButtonBox2_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function radiobuttons for door box 3
        private void radioButtonBox3_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function radiobuttons for door box 4
        private void radioButtonBox4_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function radiobuttons for door box 5
        private void radioButtonBox5_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function radiobuttons for door box 6
        private void radioButtonBox6_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }
        
        // function radiobuttons for door box 7
        private void radioButtonBox7_CheckedChanged(object sender, EventArgs e)
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
                }
            }
        }

        // function to give dimension of the boxes 
        private void comboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO : sth to change text next to combobox containing height of the box
            var height = comboBoxHeight.SelectedValue;
            //var nbrBox = numericUpDownQuantity.Value;
            //int boxHeight = ((int)height - (int)nbrBox * 4) / (int)nbrBox;
            //string dimension = nbrBox + "x" + boxHeight.ToString() + "(h)";
            //labelBoxHeight.Text = height.ToString();
        }
    }
}
