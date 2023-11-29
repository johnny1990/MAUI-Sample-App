using MAUISampleApp.Models;

namespace MAUISampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ClearCalculator(this, null);

        }

        string currentEntry = "";
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        string decimalFormat = "N0";



        void SelectNumber(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string pressed = button.Text;

            currentEntry += pressed;

            if ((this.resultText.Text == "0" && pressed == "0")
                || (currentEntry.Length <= 1 && pressed != "0")
                || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            if (pressed == "." && decimalFormat != "N2")
            {
                decimalFormat = "N2";
            }

            this.resultText.Text += pressed;
        }

        void SelectOperator(object sender, EventArgs e)
        {
            LockNumberValue(resultText.Text);

            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        private void LockNumberValue(string text)
        {
            double number;
            if (double.TryParse(text, out number))
            {
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }

                currentEntry = string.Empty;
            }
        }

        void ClearCalculator(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            decimalFormat = "N0";
            this.resultText.Text = "0";
            currentEntry = string.Empty;
        }

        void CalculateComp(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                if (secondNumber == 0)
                    LockNumberValue(resultText.Text);

                double result = Calculator.CalculateOperationType(firstNumber, secondNumber, mathOperator);

                this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

                this.resultText.Text = result.ExtToTrimmedString(decimalFormat);
                firstNumber = result;
                secondNumber = 0;
                currentState = -1;
                currentEntry = string.Empty;
            }
        }

        void NegativeComp(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                secondNumber = -1;
                mathOperator = "×";
                currentState = 2;
                CalculateComp(this, null);
            }
        }

        void PercentageComp(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                LockNumberValue(resultText.Text);
                decimalFormat = "N2";
                secondNumber = 0.01;
                mathOperator = "×";
                currentState = 2;
                CalculateComp(this, null);
            }
        }
    }
}

