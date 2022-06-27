using RWI491775_Assessment_SATELLITES.Models;

namespace RWI491775_Assessment_SATELLITES.ViewModels.PopularSatellite;

public class SatViewModel : ViewModelBase
{
    private readonly Satellite _sat;
    public SatViewModel(Satellite sat)
    {
        _sat = sat;
    }

    public string Name => _sat.Name;
    public int SatId => _sat.SatId;
    public string Latitude => _sat.TimeFrame[0].Latitude.ToString("0.00");
    public string Longitude => _sat.TimeFrame[0].Longitude.ToString("0.00");
    public string Altitude => _sat.TimeFrame[0].Altitude.ToString("0.00");
    public string Distance => $"{_sat.TimeFrame[0].Distance:0.00} km";
}