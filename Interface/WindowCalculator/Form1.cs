using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factory;
using ElectricalAppliances;

namespace WindowCalculator
{
    public partial class Form1 : Form
    {
        ProductCalculator calculator = new ProductCalculator();
        public Form1()
        {
            InitializeComponent();
            calculator.InitCalculator();
            InsertInListBox();
            EnterConsumption();
        }
        private void InsertInListBox()
        {
            listBox1.Items.Clear();
            string[] list = calculator.GetInstruments();
            listBox1.Items.AddRange(list);
        }
        private void EnterConsumption()
        {
            label1.Text = String.Format("Total consumption: {0}",calculator.CalculatingConsumption().ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2();
            newForm.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductCalculator.indInstrument = listBox1.SelectedIndex;
            Form2 newForm = new Form2();
            newForm.ShowDialog();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            calculator.DeleteInstrument(listBox1.SelectedIndex);
            InsertInListBox();
            EnterConsumption();
        }
    }
}
