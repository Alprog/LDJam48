
using UnityEngine;
using System.Collections.Generic;

public class Ground
{
    public List<Zone> Zones;
    
    public void RefreshZones()
    {
        Zones = new List<Zone>();
        foreach (var zone in GameObject.FindObjectsOfType<Zone>())
        {
            Zones.Add(zone);
        }
    }

    public bool TestPoint(Vector2 point)
    {
        foreach (var zone in Zones)
        {
            if (!zone.TestPoint(point))
            {
                return false;
            }
        }
        return true;
    }
}
