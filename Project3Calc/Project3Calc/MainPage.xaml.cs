using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project3Calc
{
    public partial class MainPage : ContentPage
    {

        double firstNumber, secondNumber;
        string currentDisplay = "";
        string[] temp;
        double memory;

        int start;
        int years;
        double perc;
        int investment;
        int depositsPerYear;
        int final;

        public MainPage()
        {
            InitializeComponent();
        }

        private int Compute(int start, int years, double perc, int investment, int depositsPerYear) {
            double bal = start;
            double monthlyRate = perc / 12.0;
            int monthsToDeposit = 12 / depositsPerYear;
            for (int y = 0; y < years; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    bal += bal * monthlyRate;
                    if (m % monthsToDeposit == 0)
                        bal += investment;
                }
            }
            return (int)Math.Round(bal); 
        }

        void OnMemoryTapped(System.Object sender, EventArgs e)
        {
            Button whichButton = (Button)sender;
            switch (whichButton.Text) {
                case "M+":
                    memory += Int32.Parse(display.Text); break;
                case "M-":
                    memory -= Int32.Parse(display.Text); break;
                case "MR":
                    display.Text = memory.ToString(); break;
                case "MC":
                    memory = 0; break;
            }
            
        }

        async void OnInvestTapped(System.Object sender, EventArgs e)
        {
            Button whichButton = (Button)sender;
            switch (whichButton.Text) {
                case "START":
                    startAmountLabel.Text = "$" + display.Text; start = Int32.Parse(display.Text); break;
                case "YEARS":
                    yearLabel.Text = display.Text; years = Int32.Parse(display.Text); break;
                case "RATE":
                    rorLabel.Text = display.Text + "%"; perc = Double.Parse(display.Text) /100.0; break;
                case "INVEST":
                    riLabel.Text = "$" + display.Text; investment = Int32.Parse(display.Text); break;
                case "FREQ":
                    string action = await DisplayActionSheet("Investment Frequency", "Cancel", "Monthly", "Quarterly", "Annually");
                    switch (action) {
                        case "Monthly":
                            foiLabel.Text = "Monthly"; depositsPerYear = 12; break;
                        case "Quarterly":
                            foiLabel.Text = "Quarterly"; depositsPerYear = 4; break;
                        case "Annually":
                            foiLabel.Text = "Annually"; depositsPerYear = 1; break;
                    }
                    break;
                case "FINAL":
                    final = Compute(start, years, perc, investment, depositsPerYear);
                    fbLabel.Text = final.ToString();
                    break;
            }
                
        }

        public void setInvestmentDisplayClear()
        {
            startAmountLabel.Text = "$0";
            yearLabel.Text = "0";
            rorLabel.Text = "0%";
            riLabel.Text = "$0";
            foiLabel.Text = "Monthly";
            fbLabel.Text = "$0";
        }

        public void setButtonsFalse()
        {
            startButton.IsEnabled = false; yearsButton.IsEnabled = false;
            rateButton.IsEnabled = false; investButton.IsEnabled = false;
            freqButton.IsEnabled = false;
        }

        public void setButtonsTrue()
        {
            startButton.IsEnabled = true; yearsButton.IsEnabled = true;
            rateButton.IsEnabled = true; investButton.IsEnabled = true;
            freqButton.IsEnabled = true;
        }

        void OnArithmaticTapped(System.Object sender, EventArgs e) {
            if (currentDisplay.Contains("/"))
            {
                temp = currentDisplay.Split('/');
                firstNumber = Int32.Parse(temp[0]);
                secondNumber = Int32.Parse(temp[1]);
                display.Text = (firstNumber / secondNumber).ToString();
            }

            if (currentDisplay.Contains("X"))
            {
                temp = currentDisplay.Split('X');
                firstNumber = Int32.Parse(temp[0]);
                secondNumber = Int32.Parse(temp[1]);
                display.Text = (firstNumber * secondNumber).ToString();
            }

            if (currentDisplay.Contains("+"))
            {
                temp = currentDisplay.Split('+');
                firstNumber = Int32.Parse(temp[0]);
                secondNumber = Int32.Parse(temp[1]);
                display.Text = (firstNumber + secondNumber).ToString();
            }

            if (currentDisplay.Contains("-"))
            {
                temp = currentDisplay.Split('-');
                firstNumber = Int32.Parse(temp[0]);
                secondNumber = Int32.Parse(temp[1]);
                display.Text = (firstNumber - secondNumber).ToString();
            }

        }

        void OnPlusMinusTapped(System.Object sender, EventArgs e) {
            if (display.Text.Contains("-"))
            {
                int temp = (Int32.Parse(display.Text) * -1);
                display.Text = temp.ToString();
                setButtonsTrue();
            } else if (!display.Text.Contains("-"))
            {
                display.Text = "-" + display.Text;
                setButtonsFalse();
            }
        }

        void OnDigTapped(System.Object sender, EventArgs e)
        {
            Button whichButton = (Button)sender;

            if (display.Text.Equals("0"))
                display.Text = "";
            if (whichButton.Text.Equals("C"))
            {
                display.Text = "0";
                currentDisplay = "";
                //if (final > 0)
                //    setInvestmentDisplayClear();
                setButtonsTrue();
            }
            if (whichButton.Text.Equals("0") && !(display.Text.Equals("0")))
            {
                display.Text += "0";
                currentDisplay += "0";
            }

            if (display.Text.Equals("+") || display.Text.Equals("X")
                || display.Text.Equals("/") || display.Text.Equals("-"))
                display.Text = "";

            switch (whichButton.Text)
            {
                case "1":
                    display.Text += "1"; currentDisplay += "1"; break;
                case "2":
                    display.Text += "2"; currentDisplay += "2"; break;
                case "3":
                    display.Text += "3"; currentDisplay += "3"; break;
                case "4":
                    display.Text += "4"; currentDisplay += "4"; break;
                case "5":
                    display.Text += "5"; currentDisplay += "5"; break;
                case "6":
                    display.Text += "6"; currentDisplay += "6"; break;
                case "7":
                    display.Text += "7"; currentDisplay += "7"; break;
                case "8":
                    display.Text += "8"; currentDisplay += "8"; break;
                case "9":
                    display.Text += "9"; currentDisplay += "9"; break;
                case "/":
                    display.Text = ""; display.Text += "/"; currentDisplay += "/"; break;
                case "X":
                    display.Text = ""; display.Text += "X"; currentDisplay += "X"; break;
                case "+":
                    display.Text = ""; display.Text += "+"; currentDisplay += "+"; break;
                case "-":
                    display.Text = ""; display.Text += "-"; currentDisplay += "-";
                    setButtonsFalse();
                    break;
            }
           
        }


        //void OnDigTapped1(System.Object sender, EventArgs e)
        //{
        //    Button whichButton = (Button)sender;

        //    if (display.Text.Equals("0"))
        //        display.Text = "";

        //    if (whichButton.Text.Equals("C"))
        //        display.Text = "0";

        //    if (whichButton.Text.Equals("0") && !(display.Text.Equals("0")))
        //        display.Text += "0";
        //    else if (whichButton.Text.Equals("1"))
        //        display.Text += "1";
        //    else if (whichButton.Text.Equals("2"))
        //        display.Text += "2";
        //    else if (whichButton.Text.Equals("3"))
        //        display.Text += "3";
        //    else if (whichButton.Text.Equals("4"))
        //        display.Text += "4";
        //    else if (whichButton.Text.Equals("5"))
        //        display.Text += "5";
        //    else if (whichButton.Text.Equals("6"))
        //        display.Text += "6";
        //    else if (whichButton.Text.Equals("7"))
        //        display.Text += "7";
        //    else if (whichButton.Text.Equals("8"))
        //        display.Text += "8";
        //    else if (whichButton.Text.Equals("9"))
        //        display.Text += "9";
        //    else if (whichButton.Text.Equals("/"))
        //        display.Text += "/";
        //    else if (whichButton.Text.Equals("X"))
        //        display.Text += "X";
        //    else if (whichButton.Text.Equals("+"))
        //        display.Text += "+";
        //    else if (whichButton.Text.Equals("-"))
        //        display.Text += "-";
        //}

    }
}
