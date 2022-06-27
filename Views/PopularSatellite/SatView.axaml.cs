using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RWI491775_Assessment_SATELLITES.Views.PopularSatellite;

public partial class SatView : UserControl
{
    public SatView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}