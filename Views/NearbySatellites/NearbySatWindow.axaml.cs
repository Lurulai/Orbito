using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RWI491775_Assessment_SATELLITES.Views.NearbySatellites;

public partial class NearbySatWindow : Window
{
    public NearbySatWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}