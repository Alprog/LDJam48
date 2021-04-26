
using System.Collections.Generic;

public class Stage
{
    public float CoalCount;
    public float GoldCount;
    public float ObstacleCount;
    public bool HasTrader;
    public float DangerStartLevel;
    public float DangerGrowSpeed;
    public List<Wave> Waves;

    public Stage(int coal = 0, int gold = 0, int obstacle = 0, bool trader = false, float dangerStartLevel = 0, float dangerGrowSpeed = 0, List<Wave> waves = null)
    {
        this.CoalCount = coal;
        this.GoldCount = gold;
        this.ObstacleCount = obstacle;
        this.HasTrader = trader;
        this.DangerStartLevel = dangerStartLevel;
        this.DangerGrowSpeed = dangerGrowSpeed;
        this.Waves = waves;
    }
}
