using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RWI491775_Assessment_SATELLITES.Views.NearbySatellites;

public partial class NSatView : UserControl
{
    public NSatView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}