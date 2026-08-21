using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ProteinTracker
{
    public partial class ZielWindow : Window
    {
        private readonly string benutzerName = "";

        public ZielWindow()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public ZielWindow(string name) : this()
        {
            benutzerName = name;

            var begruessungText =
                this.FindControl<TextBlock>("BegruessungText");

            if (begruessungText != null)
            {
                begruessungText.Text = $"Hallo {benutzerName}!";
            }
        }

        private void ZielFestlegen_Click(object? sender, RoutedEventArgs e)
        {
            var proteinZielInput = this.FindControl<TextBox>("ProteinZielInput");
            var fehlerAnzeige = this.FindControl<TextBlock>("FehlerAnzeige");

            string eingabe = proteinZielInput?.Text ?? "";

            if (double.TryParse(eingabe, out double ziel) && ziel > 0)
            {
                var trackerWindow = new TrackerWindow(benutzerName, ziel);

                trackerWindow.Show();
                Close();
            }
            else
            {
                if (fehlerAnzeige != null)
                {
                    fehlerAnzeige.Text = "Bitte gib eine gültige Zahl ein.";
                }
            }
        }
    }
    }
