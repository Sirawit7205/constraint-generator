using System;
using System.Windows.Forms;

namespace Constraint_generator
{
    public partial class Form1 : Form
    {
        AddControl addControl = new AddControl();
        CheckBox[] swEnable, swBus, ledEnable, ledBus;
        CheckBox[] btnEnable, btnBus, sevensegEnable, sevensegBus;
        CheckBox[][] pmodEnable = new CheckBox[Constants.pmodCount][];
        CheckBox[][] pmodBus = new CheckBox[Constants.pmodCount][];
        TextBox[] swName, swBusAddr, ledName, ledBusAddr;
        TextBox[] btnName, btnBusAddr, sevensegName, sevensegBusAddr;
        TextBox[][] pmodName = new TextBox[Constants.pmodCount][];
        TextBox[][] pmodBusAddr = new TextBox[Constants.pmodCount][];

        public Form1()
        {
            InitializeComponent();          
        }

        //Create dynamic items at form load
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Switches
            swEnable = addControl.CreateCheckBox(tabPage1, null, "swEnable", Constants.swCount);
            swBus = addControl.CreateCheckBox(tabPage1, null, "swBus", Constants.swCount);
            swName = addControl.CreateTextBox(tabPage1, null, "swName", Constants.swCount);
            swBusAddr = addControl.CreateTextBox(tabPage1, null, "swBusAddr", Constants.swCount);

            foreach (CheckBox swEn in swEnable)
            {
                swEn.CheckedChanged += new EventHandler(SwEnableCheckBox_CheckedChanged);
                swEn.Enabled = true;
            }

            foreach (CheckBox bus in swBus)
            {
                bus.CheckedChanged += new EventHandler(SwBusCheckBox_CheckedChanged);
            }

            //LEDs
            ledEnable = addControl.CreateCheckBox(tabPage2, null, "ledEnable", Constants.ledCount);
            ledBus = addControl.CreateCheckBox(tabPage2, null, "ledBus", Constants.ledCount);
            ledName = addControl.CreateTextBox(tabPage2, null, "ledName", Constants.ledCount);
            ledBusAddr = addControl.CreateTextBox(tabPage2, null, "ledBusAddr", Constants.ledCount);

            foreach (CheckBox ledEn in ledEnable)
            {
                ledEn.CheckedChanged += new EventHandler(LedEnableCheckBox_CheckedChanged);
                ledEn.Enabled = true;
            }

            foreach (CheckBox bus in ledBus)
            {
                bus.CheckedChanged += new EventHandler(LedBusCheckBox_CheckedChanged);
            }

            //Buttons
            btnEnable = addControl.CreateCheckBox(tabPage3, null, "btnEnable", Constants.btnCount);
            btnBus = addControl.CreateCheckBox(tabPage3, null, "btnBus", Constants.btnCount);
            btnName = addControl.CreateTextBox(tabPage3, null, "btnName", Constants.btnCount);
            btnBusAddr = addControl.CreateTextBox(tabPage3, null, "btnBusAddr", Constants.btnCount);

            foreach (CheckBox btnEn in btnEnable)
            {
                btnEn.CheckedChanged += new EventHandler(BtnEnableCheckBox_CheckedChanged);
                btnEn.Enabled = true;
            }

            foreach (CheckBox bus in btnBus)
            {
                bus.CheckedChanged += new EventHandler(BtnBusCheckBox_CheckedChanged);
            }

            //7-segment
            sevensegEnable = addControl.CreateCheckBox(tabPage4, null, "sevensegEnable", Constants.sevensegCount);
            sevensegBus = addControl.CreateCheckBox(tabPage4, null, "sevensegBus", Constants.sevensegCount);
            sevensegName = addControl.CreateTextBox(tabPage4, null, "sevensegName", Constants.sevensegCount);
            sevensegBusAddr = addControl.CreateTextBox(tabPage4, null, "sevensegBusAddr", Constants.sevensegCount);

            foreach (CheckBox sevensegEn in sevensegEnable)
            {
                sevensegEn.CheckedChanged += new EventHandler(SevensegEnableCheckBox_CheckedChanged);
                sevensegEn.Enabled = true;
            }

            foreach (CheckBox bus in sevensegBus)
            {
                bus.CheckedChanged += new EventHandler(SevensegBusCheckBox_CheckedChanged);
            }

            //PMODs
            for (int i = 0; i < Constants.pmodCount; i++)
            {
                GroupBox currentGroupBox;
                if (i == 0) currentGroupBox = groupBoxPMODA;
                else if (i == 1) currentGroupBox = groupBoxPMODB;
                else if (i == 2) currentGroupBox = groupBoxPMODC;
                else currentGroupBox = groupBoxPMODX;

                pmodEnable[i] = addControl.CreateCheckBox(tabPage5, currentGroupBox, "pmodEnable" + "-" + i.ToString(), Constants.pmodPortCount);
                pmodBus[i] = addControl.CreateCheckBox(tabPage5, currentGroupBox, "pmodBus" + "-" + i.ToString(), Constants.pmodPortCount);
                pmodName[i] = addControl.CreateTextBox(tabPage5, currentGroupBox, "pmodName" + "-" + i.ToString(), Constants.pmodPortCount);
                pmodBusAddr[i] = addControl.CreateTextBox(tabPage5, currentGroupBox, "pmodBusAddr" + "-" + i.ToString(), Constants.pmodPortCount);

                foreach (CheckBox pmodEn in pmodEnable[i])
                {
                    pmodEn.CheckedChanged += new EventHandler(PmodEnableCheckBox_CheckedChanged);
                    pmodEn.Enabled = true;
                }

                foreach (CheckBox bus in pmodBus[i])
                {
                    bus.CheckedChanged += new EventHandler(PmodBusCheckBox_CheckedChanged);
                }
            }
        }

        //event handlers for enable checkboxes
        private void SwEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            swName[targetIdx].Enabled = checkbox.Checked;
            swBus[targetIdx].Enabled = checkbox.Checked;
            if (checkbox.Checked)
                swBusAddr[targetIdx].Enabled = swBus[targetIdx].Checked;
            else
                swBusAddr[targetIdx].Enabled = false;
        }

        private void LedEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            ledName[targetIdx].Enabled = checkbox.Checked;
            ledBus[targetIdx].Enabled = checkbox.Checked;
            if (checkbox.Checked)
                ledBusAddr[targetIdx].Enabled = ledBus[targetIdx].Checked;
            else
                ledBusAddr[targetIdx].Enabled = false;
        }

        private void BtnEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            btnName[targetIdx].Enabled = checkbox.Checked;
            btnBus[targetIdx].Enabled = checkbox.Checked;
            if (checkbox.Checked)
                btnBusAddr[targetIdx].Enabled = btnBus[targetIdx].Checked;
            else
                btnBusAddr[targetIdx].Enabled = false;
        }

        private void SevensegEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            sevensegName[targetIdx].Enabled = checkbox.Checked;
            sevensegBus[targetIdx].Enabled = checkbox.Checked;
            if (checkbox.Checked)
                sevensegBusAddr[targetIdx].Enabled = sevensegBus[targetIdx].Checked;
            else
                sevensegBusAddr[targetIdx].Enabled = false;
        }

        private void PmodEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            int targetPMOD = int.Parse(checkbox.Name.Split('-')[1]);
            int targetIdx = int.Parse(checkbox.Name.Split('-')[2]);

            pmodName[targetPMOD][targetIdx].Enabled = checkbox.Checked;
            pmodBus[targetPMOD][targetIdx].Enabled = checkbox.Checked;
            if (checkbox.Checked)
                pmodBusAddr[targetPMOD][targetIdx].Enabled = pmodBus[targetPMOD][targetIdx].Checked;
            else
                pmodBusAddr[targetPMOD][targetIdx].Enabled = false;
        }

        //event handlers for bus mode checkboxes
        private void SwBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            swBusAddr[targetIdx].Enabled = checkbox.Checked;
        }

        private void LedBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            ledBusAddr[targetIdx].Enabled = checkbox.Checked;
        }

        private void BtnBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            btnBusAddr[targetIdx].Enabled = checkbox.Checked;
        }

        private void SevensegBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int targetIdx = int.Parse(checkbox.Name.Split('-')[1]);

            sevensegBusAddr[targetIdx].Enabled = checkbox.Checked;
        }

        private void PmodBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int targetPMOD = int.Parse(checkbox.Name.Split('-')[1]);
            int targetIdx = int.Parse(checkbox.Name.Split('-')[2]);

            pmodBusAddr[targetPMOD][targetIdx].Enabled = checkbox.Checked;
        }

        //other interfaces event handler for enable checkboxes
        private void OtherInterfaces_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            string name = checkbox.Name;

            if (name.Contains("clk"))
            {
                clkName.Enabled = checkbox.Checked;
                clkPeriod.Enabled = checkbox.Checked;
                clkWaveform1.Enabled = checkbox.Checked;
                clkWaveform2.Enabled = checkbox.Checked;
            }
            else if(name.Contains("vga"))
            {
                vgaRedName.Enabled = checkbox.Checked;
                vgaGreenName.Enabled = checkbox.Checked;
                vgaBlueName.Enabled = checkbox.Checked;
                vgaHsyncName.Enabled = checkbox.Checked;
                vgaVsyncName.Enabled = checkbox.Checked;
            }
            else if(name.Contains("serial"))
            {
                serialRxName.Enabled = checkbox.Checked;
                serialTxName.Enabled = checkbox.Checked;
            }
            else if(name.Contains("hid"))
            {
                hidDataName.Enabled = checkbox.Checked;
                hidClkName.Enabled = checkbox.Checked;
            }
            else
            {
                spiBusName.Enabled = checkbox.Checked;
                spiCsName.Enabled = checkbox.Checked;
            }
        }

        //PMOD selector
        private void RadioPMOD_CheckedChanged(object sender, EventArgs e)
        {
            //init to false first
            groupBoxPMODA.Visible = false;
            groupBoxPMODB.Visible = false;
            groupBoxPMODC.Visible = false;
            groupBoxPMODX.Visible = false;

            if (radioPMODA.Checked)
                groupBoxPMODA.Visible = true;
            else if(radioPMODB.Checked)
                groupBoxPMODB.Visible = true;
            else if(radioPMODC.Checked)
                groupBoxPMODC.Visible = true;
            else
                groupBoxPMODX.Visible = true;
        }

        //Generate button
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            FileGenerator file = new FileGenerator();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file.OpenFile(saveFileDialog.OpenFile(), saveFileDialog.FileName);

                try
                {
                    //clock
                    file.GenerateClk(clkEnable, clkName, clkPeriod, clkWaveform1, clkWaveform2);
                    //switch 0/LED 1/sevenseg 2/button 3/PMODA 4/PMODB 5/PMODC 6/PMODX 7
                    file.GenerateBulk(0, swEnable, swBus, swName, swBusAddr);
                    file.GenerateBulk(1, ledEnable, ledBus, ledName, ledBusAddr);
                    file.GenerateBulk(2, sevensegEnable, sevensegBus, sevensegName, sevensegBusAddr);
                    file.GenerateBulk(3, btnEnable, btnBus, btnName, btnBusAddr);
                    file.GenerateBulk(4, pmodEnable[0], pmodBus[0], pmodName[0], pmodBusAddr[0]);
                    file.GenerateBulk(5, pmodEnable[1], pmodBus[1], pmodName[1], pmodBusAddr[1]);
                    file.GenerateBulk(6, pmodEnable[2], pmodBus[2], pmodName[2], pmodBusAddr[2]);
                    file.GenerateBulk(7, pmodEnable[3], pmodBus[3], pmodName[3], pmodBusAddr[3]);
                    //VGA
                    file.GenerateVga(vgaEnable, vgaRedName, vgaGreenName, vgaBlueName, vgaHsyncName, vgaVsyncName);
                    //Serial
                    file.GenerateSerial(serialEnable, serialRxName, serialTxName);
                    //HID
                    file.GenerateHid(hidEnable, hidClkName, hidDataName);
                    //SPI
                    file.GenerateSpi(spiEnable, spiBusName, spiCsName);

                    MessageBox.Show("Done!", "Info");
                }
                catch (EmptyArgumentException ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }
                catch (InvalidArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }

                file.CloseFile();
        }
            
        }
    }

    static class Constants
    {
        public const int swCount = 16;
        public const int ledCount = 16;
        public const int btnCount = 5;
        public const int sevensegCount = 12;
        public const int pmodCount = 4, pmodPortCount = 8;
    }

}
