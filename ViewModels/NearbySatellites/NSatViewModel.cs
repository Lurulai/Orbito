using RWI491775_Assessment_SATELLITES.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RWI491775_Assessment_SATELLITES.ViewModels.NearbySatellites;

public class NSatViewModel : ViewModelBase, IComparable
{
    private readonly Satellite _sat;
    public NSatViewModel(Satellite sat)
    {
        _sat = sat;
    }

    public string Name => _sat.Name;
    public int SatId => _sat.SatId;
    public string Latitude => _sat.TimeFrame[0].Latitude.ToString("0.00");
    public string Longitude => _sat.TimeFrame[0].Longitude.ToString("0.00");
    public string Altitude => _sat.TimeFrame[0].Altitude.ToString("0.00");
    private string Distance => $"{_sat.TimeFrame[0].Distance:0.00} km";

    public int CompareTo(object? o)
    {
        var a = this;
        var b = o as NSatViewModel;
        return (int)(Convert.ToDouble(a.Distance.Split(" ").First()) - Convert.ToDouble(b?.Distance.Split(" ").First()));
    }
}

static class Extensions
{
    public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
    {
        var sorted = collection.OrderBy(x => x).ToList();
        for (var i = 0; i < sorted.Count; i++)
            collection.Move(collection.IndexOf(sorted[i]), i);
    }
}