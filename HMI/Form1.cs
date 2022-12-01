using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ComfortPanel;
using EssentialsPanel;
using PlantsPanel;
using PowerPanel;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace HMI
{
    public partial class Form1 : Form
    {
        PlantsPanel.PlantsPanel plantsPanel = new PlantsPanel.PlantsPanel();
        Energy power = new Energy();
        UseLevel uselevel = new UseLevel();

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void roundButton4_Click(object sender, EventArgs e)
        {
            double desiredTemperature = Convert.ToDouble(numericUpDownTemperaturePlants.Text);

            plantsPanel.setTemperaturePlants(plantsPanel, desiredTemperature);

            Cursor.Current = Cursors.WaitCursor;

            plantsPanel.createFileTemperature(plantsPanel);

            Cursor.Current = Cursors.Default;

            string[] lines = File.ReadAllLines("FileTemperature.txt");

            for(int i = 0; i < lines.Length; i++)
            {
                label11.Text = lines[i];
                WaitNSeconds(4);
            }
        }

        private void WaitNSeconds(int seconds)
        {
            if (seconds < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void newTotalEnergy()
        {
            float[] energy = new float[4];
            float totalEnergy = 0;
            for (int i = 0; i < 4; i++)
            {
                if (power.solar_Panel[i].getPanelState() == true)
                {
                    if (power.solar_Panel[i].readSolarEnergy() == 0)
                    {
                        energy[i] = energy[i] + power.solar_Panel[i].getSolarEnergy();
                    }
                }
            }

            totalEnergy = power.getTotalEnergy() + (energy[0] + energy[1] + energy[2] + energy[3]);
            power.setTotalEnergy(totalEnergy);
            power.calculateEnergyPercentage(totalEnergy, power.getMaxEnergy());

            label26.Text = Convert.ToString(power.getEnergyPercentage()) + '%';
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            power.checkEnergy();

            if (power.solar_Panel[0].getPanelState() == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[0].changePanelState(2);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[0].changePanelState(1);
                }
            }

            if (power.solar_Panel[0].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        newTotalEnergy();
                        WaitNSeconds(4);
                    }
                }
            }
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            power.checkEnergy();

            if (power.solar_Panel[1].getPanelState() == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[1].changePanelState(2);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[1].changePanelState(1);
                }
            }

            if (power.solar_Panel[1].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        newTotalEnergy();
                        WaitNSeconds(4);
                    }
                }
            }
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            power.checkEnergy();

            if (power.solar_Panel[2].getPanelState() == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[2].changePanelState(2);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[2].changePanelState(1);
                }
            }


            if (power.solar_Panel[2].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        newTotalEnergy();
                        WaitNSeconds(4);
                    }
                }
            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            power.checkEnergy();

            if (power.solar_Panel[3].getPanelState() == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel OFF?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[3].changePanelState(2);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to turn this panel ON?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    power.solar_Panel[3].changePanelState(1);
                }
            }

            if (power.solar_Panel[3].getPanelState() == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (power.getEnergyPercentage() < 100)
                    {
                        newTotalEnergy();
                        WaitNSeconds(4);
                    }
                }
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }

    public class RoundButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
}