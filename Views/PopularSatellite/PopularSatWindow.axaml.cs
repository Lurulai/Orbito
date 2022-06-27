using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RWI491775_Assessment_SATELLITES.Views.PopularSatellite;

public partial class PopularSatWindow : Window
{
    public PopularSatWindow()
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