
using UnityEngine;

public static class Extensions
{
    public static Vector2 Truncate(this Vector2 vector, float maxMagnitude)
    {
        var k = vector.magnitude / maxMagnitude;
        if (k > 1)
        {
            return vector / k;
        }
        return vector;
    }
}
