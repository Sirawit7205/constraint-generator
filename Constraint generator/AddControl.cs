using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constraint_generator
{
    class AddControl
    {
        DeterminePosition determinePosition = new DeterminePosition();

        public CheckBox[] CreateCheckBox(TabPage targetPage, GroupBox targetGroup, string prefix,int amount)
        {
            CheckBox[] checkBoxArray = new CheckBox[amount];
            var pos = determinePosition.CheckBoxPositions(prefix);

            for (int i = amount - 1; i >= 0; i--)
            {
                checkBoxArray[i] = new CheckBox
                {
                    //universal properties
                    AutoSize = true,
                    Size = new System.Drawing.Size(15, 14),
                    UseVisualStyleBackColor = true,
                    Enabled = false,

                    //specific properties
                    Location = new System.Drawing.Point(pos.posX+(amount-i-1)*pos.stepX, pos.posY),
                    Name = prefix + "-" + i.ToString(),                        
                };

                //add to form (page or group)
                if(targetGroup==null)
                    targetPage.Controls.Add(checkBoxArray[i]);
                else
                    targetGroup.Controls.Add(checkBoxArray[i]);
            }

            return checkBoxArray;
        }

        public TextBox[] CreateTextBox(TabPage targetPage, GroupBox targetGroup, string prefix, int amount)
        {
            TextBox[] textBoxArray = new TextBox[amount];
            var pos = determinePosition.TextBoxPositions(prefix);
          
            for (int i = amount - 1; i >= 0; i--)
            {
                textBoxArray[i] = new TextBox
                {
                    //universal properties
                    Size = new System.Drawing.Size(31, 20),
                    Enabled = false,

                    //specific properties
                    Location = new System.Drawing.Point(pos.posX + (amount - i - 1) * pos.stepX, pos.posY),
                    Name = prefix + "-" + i.ToString()
                };

                //add to form (page or group)
                if (targetGroup == null)
                    targetPage.Controls.Add(textBoxArray[i]);
                else
                    targetGroup.Controls.Add(textBoxArray[i]);
            }

            return textBoxArray;
        }
    }
    
    class Positions
    {
        public int posX, stepX, posY;
    }

    class DeterminePosition
    {
        public Positions CheckBoxPositions(string prefix)
        {
            var returnValue = new Positions();

            //determine positions
            if (prefix.Contains("Enable"))
            {
                returnValue.posX = 112;
                returnValue.stepX = 37;
                returnValue.posY = 57;
            }
            else if (prefix.Contains("Bus"))
            {
                returnValue.posX = 112;
                returnValue.stepX = 37;
                returnValue.posY = 123;
            }
            //dummy values
            else
            {
                returnValue.posX = 0;
                returnValue.stepX = 0;
                returnValue.posY = 0;
            }

            return returnValue;
        }

        public Positions TextBoxPositions(string prefix)
        {
            var returnValue = new Positions();

            //determine positions
            if (prefix.Contains("Name"))
            {
                returnValue.posX = 104;
                returnValue.stepX = 37;
                returnValue.posY = 79;
            }
            else if (prefix.Contains("Addr"))
            {
                returnValue.posX = 104;
                returnValue.stepX = 37;
                returnValue.posY = 145;
            }
            //dummy values
            else
            {
                returnValue.posX = 0;
                returnValue.stepX = 0;
                returnValue.posY = 0;
            }

            return returnValue;
        }
    }
}
