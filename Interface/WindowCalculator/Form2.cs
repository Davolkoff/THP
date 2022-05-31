using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Factory;
using ElectricalAppliances;

namespace WindowCalculator
{
    public partial class Form2 : Form
    {
        ProductCalculator calc = new ProductCalculator();
        List<TextBox> listText = new List<TextBox>();
        Drill drill = new Drill();
        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.Add("Drill");
            comboBox1.Items.Add("Measurement Inst");
            if (ProductCalculator.indInstrument != -1)
            {
                comboBox1.SelectedIndex = 0;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Drill":
                    {
                        string[] labels = new string[] { "Name","Price","Consumption","Power","Type of power","Max chuk","Numb of speed"};
                        for (int i = 0; i < 7; i++)
                        {
                            CreateLabel(labels[i],i * 40 + 68);
                            CreateTextBox(i * 40 + 64);
                        }
                        if (ProductCalculator.indInstrument != -1)
                        {
                            drill = calc.GetInstrument();
                            listText[0].Text = drill.Name;
                            listText[1].Text = drill.Price.ToString();
                            listText[2].Text = drill.Consumption.ToString();
                            listText[3].Text = drill.Power.ToString();
                            listText[4].Text = drill.TypeOfPowerSupply;
                            listText[5].Text = drill.MaxChukSize.ToString();
                            listText[6].Text = drill.NumberOfSpeeds.ToString();
                        }
                        break;
                    }
                case "Measurement Inst":
                    {
                        break;
                    }
            }
        }
        private void CreateLabel(string text, int placeY)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new System.Drawing.Point(30, placeY);
            label.Size = new System.Drawing.Size(70, 30);
            this.Controls.Add(label);
        }
        private void CreateTextBox(int placeY)
        {
            TextBox textBox = new TextBox();
            textBox.Text = "";
            textBox.Location = new System.Drawing.Point(100, placeY);
            textBox.Size = new System.Drawing.Size(121, 23);
            this.Controls.Add(textBox);
            listText.Add(textBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductCalculator.indInstrument != -1)
                {
                    calc.EditInstrument(
                        listText[0].Text,
                        Convert.ToInt32(listText[1].Text),
                        Convert.ToInt32(listText[2].Text),
                        Convert.ToInt32(listText[3].Text),
                        listText[4].Text,
                        Convert.ToInt32(listText[5].Text),
                        Convert.ToInt32(listText[6].Text));
                    ProductCalculator.indInstrument = -1;
                }
                else
                {
                    calc.AddingInstrument(
                        listText[0].Text,
                        Convert.ToInt32(listText[1].Text),
                        Convert.ToInt32(listText[2].Text),
                        Convert.ToInt32(listText[3].Text),
                        listText[4].Text,
                        Convert.ToInt32(listText[5].Text),
                        Convert.ToInt32(listText[6].Text));
                }
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();

                this.Dispose();
            }
            catch (System.FormatException)
            {
                CreateLabel("Enter correctly", 360);
                button1.BackColor = System.Drawing.Color.FromName("Coral");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Dispose();
        }
    }
}
