
using UnityEngine;
using System.Collections.Generic;

public class Ground
{
    public List<WalkZone> Zones;
    
    public void RefreshZones()
    {
        Zones = new List<WalkZone>();
        foreach (var zone in GameObject.FindObjectsOfType<WalkZone>())
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
