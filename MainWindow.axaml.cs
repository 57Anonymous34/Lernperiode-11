using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ProteinTracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Weiter_Click(object? sender, RoutedEventArgs e)
        {
            var nameInput = this.FindControl<TextBox>("NameInput");
            var fehlerAnzeige = this.FindControl<TextBlock>("FehlerAnzeige");

            string name = nameInput?.Text ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                if (fehlerAnzeige != null)
                    fehlerAnzeige.Text = "Bitte gib deinen Namen ein.";

                return;
            }

            var zielWindow = new ZielWindow(name);

            zielWindow.Show();
            Close();
        }
    }
}