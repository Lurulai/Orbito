using ReactiveUI;
using RWI491775_Assessment_SATELLITES.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RWI491775_Assessment_SATELLITES.ViewModels.PopularSatellite;

public class PopularSatViewModel : ViewModelBase
{
    public ObservableCollection<SatViewModel> SatelliteList { get; } = new();
    private bool _isBusy;

    public PopularSatViewModel()
    {
        GetPopularInformationAsync();
    }

    public async Task GetPopularInformationAsync()
    {
        if (SatelliteList.Count == 0)
        {
            const string baseURL = "https://api.n2yo.com/rest/v1/satellite/positions/";
            var arrayNORAD = new[]
            {
                25544, 27424, 38771, 31135, 20580,
                41339, 43931, 50463, 44824, 41731,
                42901, 27453, 39444, 40019, 25994,
                52629, 22286, 44072, 43613, 41783
            };
            foreach (var t in arrayNORAD)
            {
                var url = $"{baseURL}/{t}/52.22/6.89/42/1/&apiKey=ZPUAGA-Y2FW52-VEVLP9-4W3W";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string data = response.Content.ReadAsStringAsync().Result;

                // JSON retrieval & data parsing
                var json = JsonDocument.Parse(data);

                var info = json.RootElement.GetProperty("info");
                var satName = info.GetProperty("satname").GetString();
                var satID = info.GetProperty("satid").GetInt32(); // this is just to test if the array and json are a-ok

                var posList = new List<SatTime>();
                var pos = json.RootElement.GetProperty("positions");
                foreach (var position in pos.EnumerateArray())
                {
                    var time = new SatTime(position.GetProperty("satlatitude").GetDouble(),
                        position.GetProperty("satlongitude").GetDouble(),
                        position.GetProperty("sataltitude").GetDouble());
                    posList.Add(time);
                }

                if (satName == null) continue;
                var sat1 = new Satellite(satName, satID, posList);
                SatelliteList.Add(new SatViewModel(sat1));
            }
        }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }
}