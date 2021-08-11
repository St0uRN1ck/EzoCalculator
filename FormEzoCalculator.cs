using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EzoCalculator
{
    public partial class FormEzoCalculator : Form
    {
        #region Members

        OperationCalc m_objOperation = OperationCalc.None;
        IList<string> m_lstHistoricOperations = null;
        double m_dblFirstValue = 0.0;

        #endregion

        #region Enum

        public enum OperationCalc : int
        {
            Plus,
            Minus,
            Multiply,
            Divide,
            Square,
            SquareRoot,
            OneOnX,
            Parenthesis,
            Sin,
            Cos,
            Tan,
            None
        }

        #endregion

        #region Constructors

        public FormEzoCalculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        #endregion

        #region Events

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxResult.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "1";
            else
                textBoxResult.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "2";
            else
                textBoxResult.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "3";
            else
                textBoxResult.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "4";
            else
                textBoxResult.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "5";
            else
                textBoxResult.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "6";
            else
                textBoxResult.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "7";
            else
                textBoxResult.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "8";
            else
                textBoxResult.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxResult.Text) && textBoxResult.Text == "0")
                textBoxResult.Text = "9";
            else
                textBoxResult.Text += "9";
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            double valueToReverse = Convert.ToDouble(textBoxResult.Text);

            // Need to reverse the value from pos/neg or neg/pos.
            valueToReverse *= -1;

            textBoxResult.Text = valueToReverse.ToString();
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textBoxResult.Text += ",";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            double secondValue = Convert.ToDouble(textBoxResult.Text);
            double calcResult = 0.0;

            switch (m_objOperation)
            {
                case OperationCalc.Plus:
                    calcResult = (double)(m_dblFirstValue + secondValue);
                    break;
                case OperationCalc.Minus:
                    calcResult = (double)(m_dblFirstValue - secondValue);
                    break;
                case OperationCalc.Multiply:
                    calcResult = (double)(m_dblFirstValue * secondValue);
                    break;
                case OperationCalc.Divide:
                    if (secondValue == 0.0)
                    {
                        textBoxResult.Text = "ERROR: Cannot divide by zero";
                    }
                    else
                    {
                        calcResult = (double)(m_dblFirstValue / secondValue);
                    }
                   
                    break;
                default:
                    break;
            }


            m_dblFirstValue = calcResult;

            textBoxResult.Text = Convert.ToString(calcResult);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            m_dblFirstValue = Convert.ToDouble(textBoxResult.Text);

            // Empty the Result textBox
            textBoxResult.Text = "0";

            m_objOperation = OperationCalc.Plus;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            m_dblFirstValue = Convert.ToDouble(textBoxResult.Text);

            // Empty the Result textBox
            textBoxResult.Text = "0";

            m_objOperation = OperationCalc.Minus;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            m_dblFirstValue = Convert.ToDouble(textBoxResult.Text.Replace(".",","));

            // Empty the Result textBox
            textBoxResult.Text = "0";

            m_objOperation = OperationCalc.Multiply;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            m_dblFirstValue = Convert.ToDouble(textBoxResult.Text);

            // Empty the Result textBox
            textBoxResult.Text = "0";

            m_objOperation = OperationCalc.Divide;
        } 

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Remove the last char of the string
            string result = textBoxResult.Text.Remove(textBoxResult.Text.Length - 1, 1);

            textBoxResult.Text = result;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            ResetCalc();
            textBoxResult.Text = m_dblFirstValue.ToString();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            ResetCalc();
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            m_dblFirstValue = Convert.ToDouble(textBoxResult.Text) / 100.0;
            textBoxResult.Text = m_dblFirstValue.ToString();
        }

        private void button1OnX_Click(object sender, EventArgs e)
        {
            var value = Convert.ToDouble(textBoxResult.Text);

            m_dblFirstValue = 1.0 / value;

            textBoxResult.Text = m_dblFirstValue.ToString();
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            var value = Convert.ToDouble(textBoxResult.Text);

            m_dblFirstValue = value * value;

            textBoxResult.Text = m_dblFirstValue.ToString();
        }

        private void buttonSquareRootsX_Click(object sender, EventArgs e)
        {
            var value = Convert.ToDouble(textBoxResult.Text);

            m_dblFirstValue = Math.Sqrt(value);

            textBoxResult.Text = m_dblFirstValue.ToString();
        }

        #endregion

        #region Private methods

        private void InitializeCalculator()
        {
            ResetCalc();
            
            m_lstHistoricOperations = new List<string>();
        }

        private void ResetCalc()
        {
            if (m_lstHistoricOperations != null)
                m_lstHistoricOperations.Clear();
               
            m_dblFirstValue = 0.0;
            m_objOperation = OperationCalc.None;
            textBoxResult.Text = "0";
        }


        #endregion
    }
}
