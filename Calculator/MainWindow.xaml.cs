using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NCalc;
using System.Collections.Generic;

namespace Calculator
{
    public class MainWindow : Window
    {

#region Controls
        private TextBox txtInput;
        private TextBox txtOutput;
#endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            this.txtInput = this.Get<TextBox>("txtInput");
            this.txtOutput = this.Get<TextBox>("txtOutput");
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            this.txtInput.Text = this.txtInput.Text + ((Button)sender).Content.ToString();
        }

        private void Symbol_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (button.Content.ToString() == "." && !this.txtInput.Text.Contains("."))
            {
                if (this.txtInput.Text == null || this.txtInput.Text.Length <= 0)
                    this.txtInput.Text = "0";
                this.txtInput.Text += ".";
            }
            else
            {
                this.txtInput.Text += button.Content.ToString();
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> replaceSymbols = new Dictionary<string, string>();
            replaceSymbols["÷"] = "/";
            replaceSymbols["×"] = "*";
            replaceSymbols["√"] = "sqrt";

            string expressionString = this.txtInput.Text;
            foreach(string oldValue in replaceSymbols.Keys)
                expressionString = expressionString.Replace(oldValue, replaceSymbols[oldValue]);

            Expression expression = new Expression(expressionString);

            this.txtOutput.Text = expression.Evaluate().ToString();
        }
    }
}