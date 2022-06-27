using System.Collections.Generic;

namespace RWI491775_Assessment_SATELLITES.Models;

public class Satellite
{
    public string Name { get; }
    public int SatId { get; }
    public List<SatTime> TimeFrame { get; }


    public Satellite(string name, int satid, List<SatTime> timeFrame1)
    {
        Name = name;
        SatId = satid;
        TimeFrame = timeFrame1;
    }

}