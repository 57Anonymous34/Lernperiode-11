using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ProteinTracker
{
    public partial class TrackerWindow : Window
    {
        private readonly string benutzerName;
        private readonly double proteinZiel;

        public TrackerWindow()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public TrackerWindow(string name, double ziel) : this()
        {
            benutzerName = name;
            proteinZiel = ziel;

            var nameAnzeige =
                this.FindControl<TextBlock>("NameAAnzeige");

            var fortschrittAnzeige =
                this.FindControl<TextBlock>("FortschrittAnzeige");


            var restAnzeige =
                this.FindControl<TextBlock>("RestAnzeige");
            if(fortschrittAnzeige != null)
            {
                fortschrittAnzeige.Text =
                    $"0 / {proteinZiel} g";

            }
            if (restAnzeige != null)
            {
                restAnzeige.Text =
                     $"Noch {proteinZiel} g Protein übrig.";

            }
        }
    }
}