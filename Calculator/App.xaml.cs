using Avalonia;
using Avalonia.Markup.Xaml;

namespace Calculator
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}