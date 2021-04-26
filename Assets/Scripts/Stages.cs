
using System.Collections.Generic;
using WaveList = System.Collections.Generic.List<Wave>;

public static class Stages
{
    public static int Index;

    public static List<Stage> Levels = new List<Stage>()
    {
        new Stage(
            coal: 4, gold: 0, obstacle: 2, gnome: 0,
            dangerStartLevel: 10,
            dangerGrowSpeed: 0,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 2, gnome: 0,
            dangerStartLevel: 10,
            dangerGrowSpeed: 0.1f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 5, gnome: 1,
            dangerStartLevel: 10,
            dangerGrowSpeed: 0.3f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 10,
            dangerGrowSpeed: 0.5f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 30,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 50,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 100,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 200,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 400,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 800,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        ),
        new Stage(
            coal: 4, gold: 2, obstacle: 1, gnome: 1,
            dangerStartLevel: 1200,
            dangerGrowSpeed: 1.0f,
            waves: new WaveList()
            {
                new Wave(w: 1, y: 0, r: 0, g: 0, weight: 5),
                new Wave(w: 0, y: 5, r: 0, g: 0, weight: 1),
                new Wave(w: 0, y: 0, r: 0, g: 1, weight: 1),
                new Wave(w: 0, y: 0, r: 3, g: 0, weight: 1),
            }
        )
    };
};
