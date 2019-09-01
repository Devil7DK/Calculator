using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Calculator
{
    public class MainWindow : Window
    {

#region Controls
        private TextBox txtInput;
#endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            this.txtInput = this.Get<TextBox>("txtInput");
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
    }
}