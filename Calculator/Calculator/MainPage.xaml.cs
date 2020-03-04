using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int CurrentState { get; private set; } = 1;
        public string MathOperator { get; private set; }
        public double FirstNumber { get; private set; }
        public double SecondNumber { get; private set; }

        public void OnSelectNumber(object sender, EventArgs e)
        {
            if (CurrentState < 0)
            {
                // From flowchart
                // state = state * -1
                CurrentState = CurrentState * -1;
            }

            // From flowchart
            // Set result label to number
            //ResultText.Text = first 

            Button numberPressed = (Button)sender;

            if (CurrentState == 1)
            {
                FirstNumber = double.Parse(numberPressed.Text);
            }
            else
            {
                SecondNumber = double.Parse(numberPressed.Text);
            }

        }

        public void OnSelectOperator(object sender, EventArgs e)
        {
            CurrentState = -2;
            Button OperatorClicked = (Button)sender;
            MathOperator = OperatorClicked.Text;
        }

        public void OnClear(object sender, EventArgs e)
        {
            CurrentState = 1;
            FirstNumber = 0;
            SecondNumber = 0;
            ResultText.Text = "0";
        }

        public void OnCalculate(object sender, EventArgs e)
        {
            CurrentState = -1;
            // ResultText.Text =


        }
        
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnNavigateToNewPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPage{});
        }

    }
}
