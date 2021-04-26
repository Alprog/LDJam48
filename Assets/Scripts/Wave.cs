
public class Wave
{
    public int White;
    public int Yellow;
    public int Red;
    public int Green;
    public float Weight;

    public Wave(int w = 0, int y = 0, int r = 0, int g = 0, float weight = 1.0f)
    {
        this.White = w;
        this.Yellow = y;
        this.Red = r;
        this.Green = g;
    }

    public float GetPrice()
    {
        var cfg = Config.Instance;
        return White * GetDangerPrice(cfg.WhiteEnemyPrefab) +
               Yellow * GetDangerPrice(cfg.YellowEnemyPrefab) +
               Red * GetDangerPrice(cfg.RedEnemyPrefab) +
               Green * GetDangerPrice(cfg.GreenEnemyPrefab);
    }

    private float GetDangerPrice(CircleObject objcet)
    {
        return (objcet as Enemy).EnemyConfig.DangerPrice;
    }
}
