
using WaveList = System.Collections.Generic.List<Wave>;

public static class Stages
{
    public static Stage Normal = new Stage(
        coal: 1, gold: 1, obstacle: 2, trader: false,
        dangerStartLevel: 10,
        dangerGrowSpeed: 0.3f,
        waves: new WaveList()
        {
            new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
            new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
            new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
            new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
        }
    );
}
