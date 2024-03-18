using System;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using CalculatorLibrary;

namespace CalculatorGUI01
{
    public partial class frmCalculatorGUI01 : Form
    {
        //  Declare and initialize class variables
        double num1 = 0;
        double num2 = 0;
        int op      = 0;

        public frmCalculatorGUI01()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string operand1 = txtOperand1.Text.Trim();
            string operand2 = txtOperand2.Text.Trim();
            string selection = ddlOperator.SelectedIndex.ToString();

            try
            {
                if (IsValidData())
                {
                    num1 = Convert.ToDouble(operand1);
                    num2 = Convert.ToDouble(operand2);
                    op   = ddlOperator.SelectedIndex;

                    CallCorrectFunction();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + "\n\n" +
                                 ex.GetType().ToString() + "\n" +
                                 ex.StackTrace, "EXCEPTION");
            }
        }

        private bool IsValidData()
        {
            string operand1 = txtOperand1.Text.Trim();
            string operand2 = txtOperand2.Text.Trim();
            string selection = ddlOperator.SelectedIndex.ToString();
            bool success = true;
            string errorMessage = "";

            //  Validate first textbox
            errorMessage += Validator.IsPresent(operand1, "Operand1");
            errorMessage += Validator.IsDouble(operand1, "Operand1");

            //  Validate second textbox
            errorMessage += Validator.IsPresent(operand2, "Operand2");
            errorMessage += Validator.IsDouble(operand2, "Operand2");

            //  Validate selection dropdown
            errorMessage += Validator.IsPresent(selection, "Selection");
            errorMessage += Validator.IsInt32(selection, "Selection");

            if (errorMessage != "")
            {
                success = false;
                ShowErrorMessage(errorMessage, "ERROR IN INPUT");
            }

            return success;
        }

        private void CallCorrectFunction()
        {
            double result = 0.0;

            //  Instantiate standard calculator object
            StandardCalculator sc = new StandardCalculator();

            switch (op)
            {
                case 0:
                    result = sc.Add(num1, num2);
                    break;

                case 1:
                    result = sc.Subtract(num1, num2);
                    break;

                case 2:
                    result = sc.Multiply(num1, num2);
                    break;

                case 3:
                    result = sc.Divide(num1, num2);
                    break;

                case 4:
                    result = sc.Modulo(num1, num2);
                    break;

                default:
                    break;
            }

            txtResult.Text = $"{result:n2}";
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
            ddlOperator.SelectedIndex = 0;
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

        private void frmCalculatorGUI01_Load(object sender, EventArgs e)
        {
            ddlOperator.SelectedIndex = 0;
        }
    }
}
