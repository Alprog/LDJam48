
using System.Collections.Generic;

public static class Data
{
    public static float Gold = 0;
    public static float Coal = 0;
    public static float Health = 100;
    public static List<GnomeData> GnomeDatas = CreateGnomeDatas(3);

    private static List<GnomeData> CreateGnomeDatas(int count)
    {
        var list = new List<GnomeData>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new GnomeData(100));
        }
        return list;
    }
}
