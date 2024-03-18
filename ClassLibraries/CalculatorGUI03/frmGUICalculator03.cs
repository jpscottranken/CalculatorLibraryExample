﻿using System;
using System.Windows.Forms;
using CalculatorLibrary;

namespace CalculatorGUI03
{
    public partial class frmGUICalculator03 : Form
    {
        double n1 = 0;
        double n2 = 0;

        public frmGUICalculator03()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                StandardCalculator sc = new StandardCalculator();
                result = sc.Add(n1, n2);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                StandardCalculator sc = new StandardCalculator();
                result = sc.Subtract(n1, n2);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                StandardCalculator sc = new StandardCalculator();
                result = sc.Multiply(n1, n2);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                StandardCalculator sc = new StandardCalculator();
                result = sc.Divide(n1, n2);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnModulo_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                StandardCalculator sc = new StandardCalculator();
                result = sc.Modulo(n1, n2);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            txtOperand2.Text = 0.ToString();

            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                ScientificCalculator scc = new ScientificCalculator();
                result = scc.SquareRoot(n1);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnExponent_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                ScientificCalculator scc = new ScientificCalculator();
                result = scc.Exponent(n1, n2);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnLog10_Click(object sender, EventArgs e)
        {
            txtOperand2.Text = 0.ToString();
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                ScientificCalculator scc = new ScientificCalculator();
                result = scc.Log(n1);
                txtResult.Text = $"{result:n2}";
            }
        }

        private void btnNaturalLog_Click(object sender, EventArgs e)
        {
            txtOperand2.Text = 0.ToString();
            bool keepGoing = ValidateData();
            double result = 0.0;

            if (keepGoing)
            {
                //  Instantiate new Standard Calculator object
                ScientificCalculator scc = new ScientificCalculator();
                result = scc.Ln(n1);
                txtResult.Text = $"{result:n2}";
            }
        }

        private bool ValidateData()
        {
            string operand1 = txtOperand1.Text.Trim();
            string operand2 = txtOperand2.Text.Trim();

            try
            {
                if (IsValidData())
                {
                    n1 = Convert.ToDouble(operand1);
                    n2 = Convert.ToDouble(operand2);
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + "\n\n" +
                                 ex.GetType().ToString() + "\n" +
                                 ex.StackTrace, "EXCEPTION");
                return false;
            }
        }

        private bool IsValidData()
        {
            string operand1 = txtOperand1.Text.Trim();
            string operand2 = txtOperand2.Text.Trim();
            bool success = true;
            string errorMessage = "";

            //  Validate first textbox
            errorMessage += Validator.IsPresent(operand1, "Operand1");
            errorMessage += Validator.IsDouble(operand1, "Operand1");

            //  Validate second textbox
            errorMessage += Validator.IsPresent(operand2, "Operand2");
            errorMessage += Validator.IsDouble(operand2, "Operand2");

            if (errorMessage != "")
            {
                success = false;
                ShowErrorMessage(errorMessage, "ERROR IN INPUT");
            }

            return success;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtOperand1.Text = "";
            txtOperand2.Text = "";
            txtResult.Text = "";
            txtOperand1.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show(
                        "Do You Really Want To Exit The Program?",
                        "EXIT NOW?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
