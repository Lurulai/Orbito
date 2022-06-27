using ReactiveUI;
using RWI491775_Assessment_SATELLITES.ViewModels.NearbySatellites;
using RWI491775_Assessment_SATELLITES.ViewModels.PopularSatellite;
using System.Reactive.Linq;
using System.Windows.Input;

namespace RWI491775_Assessment_SATELLITES.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public MainWindowViewModel()
    {
        ShowDialog = new Interaction<PopularSatViewModel, SatViewModel?>();
        ShowDialogNearSats = new Interaction<NearbySatViewModel, NSatViewModel?>();

        OpenPopSat = ReactiveCommand.CreateFromTask(async () =>
        {
            var popSat = new PopularSatViewModel();
            var result = await ShowDialog.Handle(popSat);
        });

        OpenNearbySat = ReactiveCommand.CreateFromTask(async () =>
        {
            var nearbySat = new NearbySatViewModel();
            var result = await ShowDialogNearSats.Handle(nearbySat);
        });
    }

    public ICommand OpenPopSat { get; }

    public ICommand OpenNearbySat { get; }

    public Interaction<PopularSatViewModel, SatViewModel?> ShowDialog { get; }

    public Interaction<NearbySatViewModel, NSatViewModel?> ShowDialogNearSats { get; }
}