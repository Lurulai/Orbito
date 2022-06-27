using Avalonia.ReactiveUI;
using ReactiveUI;
using RWI491775_Assessment_SATELLITES.ViewModels;
using RWI491775_Assessment_SATELLITES.ViewModels.NearbySatellites;
using RWI491775_Assessment_SATELLITES.ViewModels.PopularSatellite;
using RWI491775_Assessment_SATELLITES.Views.NearbySatellites;
using RWI491775_Assessment_SATELLITES.Views.PopularSatellite;
using System.Threading.Tasks;

namespace RWI491775_Assessment_SATELLITES.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowDialogNearSats.RegisterHandler(DoShowDialogNearSatAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<PopularSatViewModel, SatViewModel?> interaction)
    {
        var dialog = new PopularSatWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<SatViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task DoShowDialogNearSatAsync(InteractionContext<NearbySatViewModel, NSatViewModel?> interaction)
    {
        var dialog = new NearbySatWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<NSatViewModel?>(this);
        interaction.SetOutput(result);
    }
}