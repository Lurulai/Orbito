using ReactiveUI;
using RWI491775_Assessment_SATELLITES.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RWI491775_Assessment_SATELLITES.ViewModels.NearbySatellites;

public class NearbySatViewModel : ViewModelBase
{
    private ObservableCollection<NSatViewModel> NSatelliteList { get; } = new();
    private bool _isBusy;

    public NearbySatViewModel()
    {
        GetNearbyInformation();
    }

    public async Task GetNearbyInformation()
    {
        if (NSatelliteList.Count == 0)
        {
            const string baseURL = "https://api.n2yo.com/rest/v1/satellite/above/";
            var url = $"{baseURL}/52.22/6.89/42/30/0/&apiKey=ZPUAGA-Y2FW52-VEVLP9-4W3W";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            // JSON retrieval & data parsing
            var json = JsonDocument.Parse(data);

            var satsAbove = json.RootElement.GetProperty("above");

            foreach (var info in satsAbove.EnumerateArray())
            {
                var satName = info.GetProperty("satname").GetString();
                var satId = info.GetProperty("satid").GetInt32();

                var time = new SatTime(info.GetProperty("satlat").GetDouble(),
                    info.GetProperty("satlng").GetDouble(),
                    info.GetProperty("satalt").GetDouble());
                var satList = new List<SatTime>();
                satList.Add(time);

                if (satName == null) continue;
                var sat1 = new Satellite(satName, satId, satList);
                NSatelliteList.Add(new NSatViewModel(sat1));
            }
            NSatelliteList.Sort();
        }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }
}