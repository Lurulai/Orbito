using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RWI491775_Assessment_SATELLITES.Views.NearbySatellites;

public partial class NearbySatView : UserControl
{
    public NearbySatView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}